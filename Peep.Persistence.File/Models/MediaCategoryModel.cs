using System.Collections.Generic;

namespace Peep.Persistence.File.Models
{
    public class MediaCategoryModel
    {
        public string Name { get; set; }
        public List<MediaModel> Media { get; set; }

        public MediaCategoryModel()
        {
            Media = new List<MediaModel>();
        }
    }
}