using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SWP391_Project.Extensions;
using SWP391_Project.Helpers;
using SWP391_Project.Middlewares;
using Common.Settings;
using Data.DiamondModels;
using Data.DiavanModels;

namespace SWP391_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
         
            builder.Services.AddScoped<RedisManagerment>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
              //  options.JsonSerializerOptions.Converters.Add(new DateTimeHelper("yyyy-MM-ddTHH:mm:ss"));
                options.JsonSerializerOptions.Converters.Add(new DateTimeHelper("MM/dd/yyyy HH:mm:ss"));
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
                option.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "string",
                    Pattern = @"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}$"
                });
                /*                option.MapType<DateTime>(() => new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "date",
                                });*/
            });


            builder.Services.AddCors(option =>
                option.AddPolicy("CORS", builder =>
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true)));

            var app = builder.Build();

            // Hook into application lifetime events and trigger only application fully started 
            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                // Database Initialiser 
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                await using (var scope = app.Services.CreateAsyncScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SWP391_DiamondSystemContext>();
                }

                await using (var scope = app.Services.CreateAsyncScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SWP391_DiavanSystemContext>();
                   
                }

                app.UseSwagger();
                app.UseSwaggerUI();
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
}