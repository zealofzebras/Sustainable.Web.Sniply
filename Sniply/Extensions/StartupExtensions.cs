using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniply.Extensions
{
    public static class StartupExtensions
    {

        public static IServiceCollection AddSniply(this IServiceCollection services, Action<SniplyOptions> options)
        {
            return services.Configure(options)
                           .AddSingleton<SniplyReplacer>();

        }

        public static PageConventionCollection SetSniplyPath(this PageConventionCollection conventions, string sniplyPath)
        {
            return conventions.AddAreaPageRoute("Sniply", "/Index", $"{sniplyPath}/{{*url}}");
        }
    }
}
