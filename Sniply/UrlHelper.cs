using System.Text.RegularExpressions;

namespace Sniply
{
    internal static class UrlHelper
    {
        public static string ReplaceHttp(string url)
        {
            return Regex.Replace(url, @"^http(?:(s):(\/)|:\/)\/", @"$1$2");
        }
    }
}
