// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using CashOverflow.API.Brokers.DateTimes;
using CashOverflow.API.Brokers.Loggings;
using CashOverflow.API.Brokers.Storages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CashOverflow.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "CashOverflow.API",
                        Version = "v1"
                    });
            });

            services.AddDbContext<StorageBroker>();
            AddBroker(services);
        }

        private static void AddBroker(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(config =>
                    config.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "CashOverflow.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
