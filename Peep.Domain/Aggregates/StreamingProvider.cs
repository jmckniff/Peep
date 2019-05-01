using Peep.Domain.ValueObjects;
using System.Collections.Generic;

namespace Peep.Domain.Aggregates
{
    public class StreamingProvider
    {
        public StreamingProviderIdentity Identity { get; }

        public IEnumerable<MediaCategory> Categories => _categories;
        public StreamingProviderType Type => Identity.Type;
        
        private readonly List<MediaCategory> _categories;
        
        public StreamingProvider(StreamingProviderIdentity identity)
        {
            Identity = identity;
            _categories = new List<MediaCategory>();
        }
        
        public void AddCategory(MediaCategory category)
        {
            _categories.Add(category);
        }
    }
}
