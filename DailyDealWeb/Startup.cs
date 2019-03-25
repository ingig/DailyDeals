using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace DailyDealWeb
{
    public class Startup
    {
        public static string ApiKey;
        public static string ConnectionString;

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.HostingEnvironment = env;

            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            ApiKey = configuration["HeimkaupApi"];

            CultureInfo cultureInfo = new CultureInfo("is-IS");
            cultureInfo.NumberFormat.CurrencySymbol = "kr.";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MvcCoreMvcBuilderExtensions.SetCompatibilityVersion(MvcServiceCollectionExtensions.AddMvc(services), (CompatibilityVersion)1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (HostingEnvironmentExtensions.IsDevelopment(env))
            {
                DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(app);
            }
            else
            {
                ExceptionHandlerExtensions.UseExceptionHandler(app, "/Error");
                HstsBuilderExtensions.UseHsts(app);

            }
            HttpsPolicyBuilderExtensions.UseHttpsRedirection(app);
            StaticFileExtensions.UseStaticFiles(app);
            MvcApplicationBuilderExtensions.UseMvc(app);
        }
    }
}
