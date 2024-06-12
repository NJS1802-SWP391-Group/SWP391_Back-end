using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Data.Databases.DiavanSystem;
using SWP391_Project.Data.Databases.DiamondSystem;
using SWP391_Project.Common.Mapper;
using SWP391_Project.Services;
using SWP391_Project.Settings;
using System.Globalization;
using System.Text;
using SWP391_Project.Data.Repositories.Interfaces;
using Data.Repositories.Generic;
using SWP391_Project.Data.Databases;
using SWP391_Project.Middlewares;
using Data.Repositories;
using SWP391_Project.Domain.DiavanEntities;
using Business.Services;
using Business.Services.Email;
using Common.Settings;

namespace SWP391_Project.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionMiddleware>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

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

        //services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

        var firebaseConfigSection = configuration.GetSection("MailSettings");
        var firebaseConfig = firebaseConfigSection.Get<MailSettings>();
        services.Configure<MailSettings>(firebaseConfigSection);
        services.AddSingleton(firebaseConfig);

        AppContext.SetSwitch("System.Globalization.Invariant", true);
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<Data.Databases.DatabaseInitialiser>();
        services.AddScoped<UnitOfWork>();
        services.AddScoped<UserService>();
        services.AddScoped<IdentityService>();
        services.AddScoped<OrderService>();
        services.AddScoped<ServiceDetailService>();
        services.AddScoped<ServiceService>();
        services.AddScoped<ResultService>();
        services.AddScoped<OrderDetailService>();
        services.AddScoped<PaymentService>();
        services.AddScoped<EmailService>();

        return services;
    }
}