using System.Threading;
using OpenQA.Selenium;
using Peep.Domain.Aggregates;
using Peep.Domain.ValueObjects;
using Peep.Scraper.Common;
using Peep.Scraper.NowTv.Models;

namespace Peep.Scraper.NowTv
{
    public class NowTvScraper : IScrapeStreamingProvider
    {
        private readonly IWebDriver _webDriver;
        private readonly NowTvScraperSettings _settings;

        public NowTvScraper(IWebDriver webDriver, NowTvScraperSettings settings)
        {
            _webDriver = webDriver;
            _settings = settings;
        }

        public StreamingProvider Scrape()
        {
            Login();

            Thread.Sleep(2000);
            
            var streamingProviderIdentity = new StreamingProviderIdentity(StreamingProviderType.NowTv);
            var streamingProvider = new StreamingProvider(streamingProviderIdentity);

            AddCategories(streamingProvider);

            return streamingProvider;
        }

        private void AddCategories(StreamingProvider streamingProvider)
        {
            var categoryPage = new CategoryPageModel(_webDriver, _settings.BaseUrl);
            categoryPage.NavigateTo();

            var categories = categoryPage.GetCategories();

            foreach (var category in categories)
            {
                var mediaCategory = categoryPage.GetCategory(category.Name);
                streamingProvider.AddCategory(mediaCategory);
            }
        }

        private void Login()
        {
            var loginPage = new LoginPageModel(_webDriver, _settings.BaseUrl);
            loginPage.NavigateTo();
            loginPage.Login(_settings.Username, _settings.Password);
        }
    }
}
