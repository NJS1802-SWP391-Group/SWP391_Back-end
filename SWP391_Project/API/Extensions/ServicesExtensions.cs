using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Common.Mapper;
using SWP391_Project.Services;
using SWP391_Project.Settings;
using System.Globalization;
using System.Text;
using SWP391_Project.Data.Repositories.Interfaces;
using Data.Repositories.Generic;
using SWP391_Project.Middlewares;
using Data.Repositories;
using Business.Services;
using Business.Services.Email;
using Common.Settings;
using static Common.Settings.ConfigurationModel;
using Business.Services.Firebase;
using Data.DiamondModels;
using Data.DiavanModels;

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

        services.AddDbContext<SWP391_DiavanSystemContext>(opt =>
        {
            opt.UseSqlServer("data source=diavan-valuation.asia;initial catalog=SWP391_DiavanSystem;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;");
        });

        services.AddDbContext<SWP391_DiamondSystemContext>(options =>
        {
            options.UseSqlServer("data source=diavan-valuation.asia;initial catalog=SWP391_DiamondSystem;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;");
        });

        //services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

        var mailConfigSection = configuration.GetSection("MailSettings");
        var mailConfig = mailConfigSection.Get<MailSettings>();
        services.Configure<MailSettings>(mailConfigSection);
        services.AddSingleton(mailConfig);

        var firebaseConfigSection = configuration.GetSection("Firebase");
        var firebaseConfig = firebaseConfigSection.Get<FirebaseConfiguration>();
        services.Configure<FirebaseConfiguration>(firebaseConfigSection);
        services.AddSingleton(firebaseConfig);

        AppContext.SetSwitch("System.Globalization.Invariant", true);
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
        services.AddScoped<DiamondService>();
        services.AddScoped<IFirebaseService, FirebaseService>();

        services.AddScoped(typeof(IRepository<>), typeof(DiamondGenericRepository<>));
        services.AddScoped<DiamondCheckService>();

        return services;
    }
}