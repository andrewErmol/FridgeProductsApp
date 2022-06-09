﻿using FridgeProductsApp.Contracts;
using FridgeProductsApp.Database;
using FridgeProductsApp.LoggerService;
using Microsoft.EntityFrameworkCore;

namespace FridgeProductsApp.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(optionss =>
            {
                optionss.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
             services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FridgeProductsDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("SqlConnection"), b =>
            b.MigrationsAssembly("FridgeProductsApp.Database")));
        }            
    }
}
