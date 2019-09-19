namespace Sniply
{
    public class SniplyOptions
    {
        public SniplyOptions()
        {

        }

        public string SiteId { get; set; }
        public bool CheckReferrer { get; set; }
        public string LinkTarget { get; set; } = "_blank";
    }
}