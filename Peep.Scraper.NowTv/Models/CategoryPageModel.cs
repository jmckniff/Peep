using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Peep.Domain.Entities;
using Peep.Domain.ValueObjects;
using Peep.Scraper.Common.Extensions;

namespace Peep.Scraper.NowTv.Models
{
    internal class CategoryPageModel
    {
        private readonly IWebDriver _webDriver;
        private readonly string _baseUrl;

        public CategoryPageModel(IWebDriver webDriver, string baseUrl)
        {
            _webDriver = webDriver;
            _baseUrl = baseUrl;
        }

        public void NavigateTo()
        {
            _webDriver.Navigate($"{_baseUrl}/gb/watch/movies/explorer");
        }

        public IEnumerable<MediaCategory> GetCategories()
        {
            var categoryNames = _webDriver.GetTextFromElements(".watch-navigation-link");

            return categoryNames.Select(categoryName => new MediaCategory(categoryName)).ToList();
        }

        public MediaCategory GetCategory(string categoryName)
        {
            OrderMoviesAlphabetically();
            DisplayCategory(categoryName);
            ScrollToFooter();

            return GetMovieMediaCategory(categoryName);
        }

        private MediaCategory GetMovieMediaCategory(string categoryName)
        {
            var category = new MediaCategory(categoryName);

            var moviePortraitLinks = _webDriver.FindAll(".asset-item-component__link");
         
            foreach (var link in moviePortraitLinks)
            {
                var relativeUrl = link.GetAttribute("href");
                var portrait = link.FindElement(By.CssSelector(".aspect-ratio-image__img"));
                var name = portrait.GetAttribute("alt");

                var movie = new Media(name);
                movie.SetRelativeUrl(relativeUrl);
                movie.MakeAvailable();

                category.AddMedia(movie);
            }

            return category;
        }

        private void DisplayCategory(string categoryName)
        {
            var categoryLinks = _webDriver.FindAll(".watch-navigation-link");

            var categoryLink = categoryLinks.FirstOrDefault(x =>
                x.Text.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase));

            categoryLink.Click();
        }

        private void OrderMoviesAlphabetically()
        {
            var orderBy = new SelectElement(_webDriver.FindOne(".explorer__sorter--selector"));
            orderBy.SelectByValue("title{asc}");
        }

        private void ScrollToFooter()
        {
            const string script = "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            var scriptExecutor = (IJavaScriptExecutor)_webDriver;
            scriptExecutor.ExecuteScript(script);

            Thread.Sleep(2000);
        }
    }
}
