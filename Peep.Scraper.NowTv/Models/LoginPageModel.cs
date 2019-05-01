using System.Web;
using OpenQA.Selenium;
using Peep.Scraper.Common.Extensions;

namespace Peep.Scraper.NowTv.Models
{
    internal class LoginPageModel
    {
        private readonly IWebDriver _webDriver;
        private readonly string _baseUrl;
          
        public LoginPageModel(IWebDriver webDriver, string baseUrl)
        {
            _webDriver = webDriver;
            _baseUrl = baseUrl;
        }

        public void NavigateTo()
        {
            var loginUrl = $"{_baseUrl}/ie/sign-in?successUrl={HttpUtility.UrlEncode(_baseUrl)}";

            _webDriver.Navigate(loginUrl);
        }

        public void Login(string username, string password)
        {
            CloseCookieModal();

            _webDriver.WriteTextToElement(username, "#userIdentifier");
            _webDriver.WriteTextToElement(password, "#password");
            _webDriver.SubmitForm();
        }

        private void CloseCookieModal()
        {
            var cookieModalDismiss = _webDriver.FindOne(".cookie-notification__dismiss");
            cookieModalDismiss?.Click();
        }
    }
}
