using System;
using Peep.Domain.ValueObjects;

namespace Peep.Domain.Entities
{
    public class Media
    {
        public MediaIdentity Identity { get; }
        
        public DateTime DateAdded { get; private set; }
        public DateTime? DateRemoved { get; private set; }
        public MediaRelativeUrl RelativeUrl { get; private set; }
        
        public string Name => Identity?.Name;

        public Media(string name)
        {
            Identity = new MediaIdentity(name);
        }

        public void MakeAvailable()
        {
            DateRemoved = null;
            DateAdded = DateTime.Now;
        }

        public void MakeUnavailable()
        {
            DateRemoved = DateTime.Now;
            RelativeUrl = null;
        }

        public bool IsAvailable()
        {
            return DateRemoved.HasValue == false;
        }

        public void SetRelativeUrl(string relativeUrl)
        {
            RelativeUrl = new MediaRelativeUrl(relativeUrl);
        }
    }
}
