using System;
using System.Collections.Generic;
using System.IO;
using EmployeeDirectory.Api.Interfaces;
using EmployeeDirectoryProcessor.Data;
using EmployeeDirectoryServices.ProcessorManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace EmployeeDirectory.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config/appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Error;

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(Configuration)
                                // There is an issue in Serilog where the minimum level override in the appsettings is not recognized
                                // So we are doing this to reduce ASP Net Core related logs
                                .MinimumLevel.Override("Microsoft", levelSwitch)
                                .CreateLogger();
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddMvc();
            services.AddDbContext<DirectoryContext>(options => options.UseSqlite("Data Source=BCSDirectory.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
