using System;
using OpenQA.Selenium.Chrome;
using Peep.Application;
using Peep.Persistence.File;
using Peep.Scraper.NowTv.Models;

namespace Peep.Scraper.NowTv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scraping media from NOW TV...");

            var webDriver = new ChromeDriver();
            var nowTvSettings = new NowTvScraperSettings();
            var nowTvScraper = new NowTvScraper(webDriver, nowTvSettings);
            var nowTvStreamingRepository = new StreamingProviderFileRepository();
            var nowTvService = new StreamingProviderService(nowTvScraper, nowTvStreamingRepository);
            
            nowTvService.ScrapeAndSave();

            webDriver.Dispose();
            webDriver.Quit();

            Console.WriteLine("Scraping complete, press any key to exit...");
            Console.ReadLine();
        }
    }
}
