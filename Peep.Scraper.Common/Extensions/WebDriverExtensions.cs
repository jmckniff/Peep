using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Peep.Scraper.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static void Navigate(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
        
        public static void WriteTextToElement(this IWebDriver webDriver, string input, string cssSelector)
        {
            var element = webDriver.FindOne(cssSelector);

            element.Clear();
            element.SendKeys(input);
        }

        public static void SubmitForm(this IWebDriver webDriver)
        {
            var form = webDriver.FindElement(By.TagName("form"));
            form.Submit();
        }

        public static IEnumerable<string> GetTextFromElements(this IWebDriver webDriver, string cssSelector)
        {
            var elements = webDriver.FindAll(cssSelector);
            return elements.Select(x => x.Text);
        }

        public static IWebElement FindOne(this IWebDriver webDriver, string cssSelector)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ElementExists(By.CssSelector(cssSelector)));

            return element;
        }

        public static IEnumerable<IWebElement> FindAll(this IWebDriver webDriver, string cssSelector)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var elements = wait.Until(ElementsExist(By.CssSelector(cssSelector)));

            return elements;
        }

        private static Func<IWebDriver, IWebElement> ElementExists(By locator)
        {
            return driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }

        private static Func<IWebDriver, IEnumerable<IWebElement>> ElementsExist(By locator)
        {
            return driver =>
            {
                try
                {
                    var elements = driver.FindElements(locator);
                    return (elements != null && elements.Any()) ? elements : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }

    }
}
