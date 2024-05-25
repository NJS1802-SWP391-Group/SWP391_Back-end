using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SWP391_Project.Databases;
using SWP391_Project.Databases.DiamondSystem;
using SWP391_Project.Databases.System;
using SWP391_Project.Extensions;
using SWP391_Project.Helpers;

namespace SWP391_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeHelper("yyyy-MM-ddTHH:mm:ss"));
            });

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Mock API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
                option.MapType<DateTime>(() => new OpenApiSchema { 
                    Type = "string", 
                    Format = "string",
                    Pattern = @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$" 
                });
            });


            builder.Services.AddCors(option =>
                option.AddPolicy("CORS", builder =>
                    builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((host) => true)));

            var app = builder.Build();

            // Hook into application lifetime events and trigger only application fully started 
            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                // Database Initialiser 
                await InitialiseDatabaseAsync();
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                using (var dbContext = new AppDbContext())
                {
                    await dbContext.Database.MigrateAsync();
                }

                using (var diamondContext = new DiamondContext())
                {
                    await diamondContext.Database.MigrateAsync();
                }

                app.UseSwagger();
            }

            app.UseCors("CORS");

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();


            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

    internal class ExceptionMiddleware
    {
    }
}