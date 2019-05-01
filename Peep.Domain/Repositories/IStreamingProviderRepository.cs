using Peep.Domain.Aggregates;

namespace Peep.Domain.Repositories
{
    public interface IStreamingProviderRepository
    {
        void Save(StreamingProvider streamingProvider);
    }
}
