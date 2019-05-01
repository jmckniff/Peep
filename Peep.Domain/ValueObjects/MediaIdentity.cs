using System;

namespace Peep.Domain.ValueObjects
{
    public class MediaIdentity
    {
        public Guid Id { get; }
        public string Name { get; }

        public MediaIdentity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public MediaIdentity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
