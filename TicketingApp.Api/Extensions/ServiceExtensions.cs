using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketingApp.Infrastructure.Options;
using TicketingApp.Models.Data;
using TicketingApp.Repositories;
using TicketingApp.Repositories.Interfaces;
using TicketingApp.Services.Interfaces;
using Microsoft.Identity.Web;

namespace TicketingApp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddB2CAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMicrosoftIdentityWebApiAuthentication(configuration, "AzureAdB2C");
        }

        public static void AddApplicationDatabaseContext (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("TicketingApp.Api");
                });
            });
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.AddScoped<IdentityOptions>(sp =>
            {
                var context = sp.GetService<IHttpContextAccessor>().HttpContext;

                var identityOptions = new IdentityOptions();

                if (context.User.Identity.IsAuthenticated)
                {
                    identityOptions.User = context.User;
                    // TODO:Configure other identity properties
                }

                    return identityOptions;
            });
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfilesService, UserProfilesService >();
        }
    }
}
