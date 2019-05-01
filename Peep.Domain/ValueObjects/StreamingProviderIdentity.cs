using System;

namespace Peep.Domain.ValueObjects
{
    public class StreamingProviderIdentity
    {
        public Guid Id { get; private set; }
        public StreamingProviderType Type { get; }
       
        public StreamingProviderIdentity(StreamingProviderType type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }
    }
}