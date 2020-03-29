using System;
using DIAndCommonAppSettings.Demo2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIAndCommonAppSettings.Demo2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Implementing Factory overload to register AppSettingService Singleton
            services.AddSingleton<IAppSettingService, AppSettingService>(sp =>
            {
                return new AppSettingService( 
                    Convert.ToInt32(Configuration["AppSettings:RefreshGridTimerInSeconds"]),
                    Convert.ToInt32(Configuration["AppSettings:RowsPerPage"]),
                    Configuration["AppSettings:StorageAddress"]);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
