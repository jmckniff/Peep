namespace Peep.Scraper.NowTv.Models
{
    public class NowTvScraperSettings
    {
        public string BaseUrl { get; }
        public string Username { get; }
        public string Password { get; }

        public NowTvScraperSettings()
        {
            BaseUrl = "https://www.nowtv.com";
            Username = "USERNAME";
            Password = "PASSWORD";
        }
    }
}
