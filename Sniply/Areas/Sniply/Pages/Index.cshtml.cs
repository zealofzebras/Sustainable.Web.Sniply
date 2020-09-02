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

                if (url.StartsWith("://"))
                    url = "https" + url;
                else if (url.StartsWith("s/"))
                    url = "https://" + url.Substring(2);
                else if (!url.StartsWith("https://") && !url.StartsWith("http://"))
                {
                    if (url.StartsWith("http:/"))
                        url = "http://" + url.Substring(6);
                    else if (url.StartsWith("https:/"))
                        url = "https://" + url.Substring(7);
                    else
                        url = "http://" + url;
                }

                return Redirect("https://snip.ly/external-lib-redirect/v2/?url=" + Uri.EscapeDataString(url) + "&siteid=" + options.SiteId);
            }
            else
            {
                return Redirect("/");
            }

        }
    }
}