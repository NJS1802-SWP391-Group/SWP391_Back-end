
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Databases;
using SWP391_Project.Databases.DiamondSystem;
using SWP391_Project.Databases.System;
using SWP391_Project.Mapper;
using SWP391_Project.Repositories;
using SWP391_Project.Repositories.Interfaces;
using SWP391_Project.Services;
using SWP391_Project.Settings;
using System.Globalization;
using System.Text;

namespace SWP391_Project.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        //Add Mapper
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ApplicationMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        services.Configure<JwtSettings>(val =>
        {
            val.Key = jwtSettings.Key;
        });

        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddDbContext<DiamondContext>(options => 
        { 
            options.UseSqlServer(configuration.GetConnectionString("DiamondConnection"));
        });
    

        AppContext.SetSwitch("System.Globalization.Invariant", true);
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<UserService>();
        services.AddScoped<IdentityService>();
        //services.AddScoped<RequestValuationFormService>();
        //services.AddScoped<ScheduleFormService>();
        //services.AddScoped<ServiceService>();


        return services;
    }
}
