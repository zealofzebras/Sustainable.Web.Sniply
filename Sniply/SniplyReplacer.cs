﻿using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace Sniply
{
    public class SniplyReplacer
    {
        private readonly LinkGenerator linkGenerator;
        public SniplyReplacer(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        public string Replace(string content) => Regex.Replace(content, @"(?<=href=)(.)((?:(?!\1).)*)\1", m => GetHref(m.Groups[1].Value, m.Groups[2].Value));

        private string GetHref(string delimeter, string original)
        {
            return delimeter + linkGenerator.GetPathByPage("/Index", null, values: new
            {
                area = "sniply",
                url = UrlHelper.ReplaceHttp(original),
            }) + delimeter;
        }
    }
}
