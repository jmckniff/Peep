using Peep.Domain.Aggregates;

namespace Peep.Scraper.Common
{
    public interface IScrapeStreamingProvider
    {
        StreamingProvider Scrape();
    }
}
