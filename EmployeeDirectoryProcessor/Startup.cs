using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EmployeeDirectoryProcessor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using StructureMap;

namespace EmployeeDirectoryProcessor
{
    public class Startup : Interfaces.IContainer
    {
        private IConfigurationRoot Configuration { get; }
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
        public Container ConfigureServices(IServiceCollection services)
        {
            var container = new Container();
            services.AddDbContext<DirectoryContext>(options => options.UseSqlite("Data Source=BCSDirectory.db"));
            return container;
        }
    }
}
