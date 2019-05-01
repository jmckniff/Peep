using Peep.Domain.Aggregates;
using Peep.Domain.Repositories;
using Peep.Scraper.Common;

namespace Peep.Application
{
    public class StreamingProviderService
    {
        private readonly IScrapeStreamingProvider _scraper;
        private readonly IStreamingProviderRepository _repository;

        public StreamingProviderService(IScrapeStreamingProvider scraper, IStreamingProviderRepository repository)
        {
            _scraper = scraper;
            _repository = repository;
        }

        public StreamingProvider ScrapeAndSave()
        {
            var streamingProvider = _scraper.Scrape();

            _repository.Save(streamingProvider);

            return streamingProvider;
        }
    }
}
