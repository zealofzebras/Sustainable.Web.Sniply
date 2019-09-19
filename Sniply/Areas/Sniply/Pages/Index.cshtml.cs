using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;

namespace Sniply.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SniplyOptions options;

        public IndexModel(IOptionsMonitor<SniplyOptions> optionsMonitor)
        {
            this.options = optionsMonitor.CurrentValue;
        }

        public IActionResult OnGet()
        {
            var headers = Request.GetTypedHeaders();
            if (options.CheckReferrer && headers.Referer?.Host != headers.Host.Host)
                return Redirect("/");

            if (RouteData.Values["url"] != null)
            {
                var url = Uri.UnescapeDataString(RouteData.Values["url"].ToString());
                return Redirect("https://snip.ly/external-lib-redirect/v2/?url=" + Uri.EscapeDataString(url) + "&siteid=" + options.SiteId);
            }
            else
            {
                return Redirect("/");
            }

        }
    }
}