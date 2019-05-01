using System;
using System.Collections.Generic;
using System.Linq;
using Peep.Domain.Entities;

namespace Peep.Domain.ValueObjects
{
    public class MediaCategory
    {
        public string Name { get; }
        public IEnumerable<Media> Media => _media;

        private readonly List<Media> _media;

        public MediaCategory(string name)
        {
            Name = name;
            _media = new List<Media>();
        }

        public void AddMedia(Media media)
        {
            if (!HasMedia(media.Name))
            {
                _media.Add(media);
            }
        }

        public void RemoveMedia(string mediaName)
        {
            var existingMedia = FindMedia(mediaName);
            existingMedia?.MakeUnavailable();
        }

        public bool HasMedia(string mediaName)
        {
            return FindMedia(mediaName) != null;
        }

        public Media FindMedia(string name)
        {
            return _media.FirstOrDefault(m =>
                m.Identity.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
