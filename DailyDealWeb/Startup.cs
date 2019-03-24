using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;

namespace DailyDealWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            CultureInfo cultureInfo = new CultureInfo("is-IS");
            cultureInfo.NumberFormat.CurrencySymbol = "kr.";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        public IConfiguration Configuration { get; }

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
            CookiePolicyAppBuilderExtensions.UseCookiePolicy(app);
            MvcApplicationBuilderExtensions.UseMvc(app);
        }
    }
}
