using Application.EntitiesCore;
using Application.Interfaces;
using Ardalis.GuardClauses;
using Infrastructure.Identification;
using Infrastructure.Interceptors;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            services.AddScoped<IDbCommandInterceptor, EntityWithAuditCommandInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, EntityWithAuditInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchEventsInterceptor>();

            services.AddDbContext<DatabaseContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.AddInterceptors(sp.GetServices<IDbCommandInterceptor>());
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IDatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());

            services.AddScoped<DatabaseContextInitialiser>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
                option.DefaultChallengeScheme = IdentityConstants.BearerScheme;
                option.DefaultScheme = IdentityConstants.BearerScheme;
            }).AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorizationBuilder();

            services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
            {
                options.BearerTokenExpiration = TimeSpan.FromSeconds(configuration.GetValue<int>("BearerToken:BearerTokenExpiration"));
                options.RefreshTokenExpiration = TimeSpan.FromSeconds(configuration.GetValue<int>("BearerToken:BearerTokenExpiration"));
            });

            services
                .AddIdentityCore<ApplicationUser<Guid>>()
                .AddRoles<ApplicationRole<Guid>>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddRoleStore<ApplicationRoleStore<ApplicationRole<Guid>>>()
                .AddUserManager<ApplicationUserManager<ApplicationUser<Guid>>>()
                .AddRoleManager<ApplicationRoleManager<ApplicationRole<Guid>>>()
                .AddApiEndpoints();


            services
                .AddDefaultIdentity<ApplicationUser<Guid>>(options => { options.SignIn.RequireConfirmedAccount = true; })
                .AddDefaultUI()
                .AddSignInManager<ApplicationSignInManager<ApplicationUser<Guid>>>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser<Guid>>>(TokenOptions.DefaultAuthenticatorProvider);


            services.AddSingleton(TimeProvider.System);

            services.AddTransient<ICongestionTaxCalculator, CongestionTaxCalculator>();

            services.AddTransient<IIdentificationService, IdentificationService>();


            return services;
        }
    }
}
