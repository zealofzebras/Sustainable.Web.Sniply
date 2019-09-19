using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace Sniply.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "external")]
    public class SniplyTagHelper : TagHelper
    {
        private readonly LinkGenerator linkGenerator;
        
        public SniplyTagHelper(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.AllAttributes.ContainsName("href"))
            {

                var href = linkGenerator.GetPathByPage("/Index", null, values: new
                {
                    area = "sniply",
                    url = context.AllAttributes["href"].Value,
                });

                //output.Attributes.Remove("external");
                output.Attributes.SetAttribute("href", href);
            }
        }

    }
}
