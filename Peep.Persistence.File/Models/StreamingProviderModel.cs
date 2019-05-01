using System;
using System.Collections.Generic;

namespace Peep.Persistence.File.Models
{
    public class StreamingProviderModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public List<MediaCategoryModel> Categories { get; set; }

        public StreamingProviderModel()
        {
            Categories = new List<MediaCategoryModel>();
        }
    }
}
