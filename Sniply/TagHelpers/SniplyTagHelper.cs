using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace Sniply.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "external")]
    public class SniplyTagHelper : TagHelper
    {
        private readonly LinkGenerator linkGenerator;
        private readonly string linkTarget;

        public SniplyTagHelper(LinkGenerator linkGenerator, IOptionsMonitor<SniplyOptions> optionsMonitor)
        {
            this.linkGenerator = linkGenerator;
            linkTarget = optionsMonitor.CurrentValue.LinkTarget;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.AllAttributes.ContainsName("href"))
            {

                var href = linkGenerator.GetPathByPage("/Index", null, values: new
                {
                    area = "sniply",
                    url = Regex.Replace(context.AllAttributes["href"].Value.ToString(), @"^http(?:(s):(\/)|:\/)\/", @"\1\2"),
                });

                //output.Attributes.Remove("external");
                output.Attributes.SetAttribute("href", href);

                if (!string.IsNullOrWhiteSpace(linkTarget))

                    output.Attributes.SetAttribute("target", "_blank");
            }
        }

    }
}
