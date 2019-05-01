using Newtonsoft.Json;
using Peep.Domain.Aggregates;
using Peep.Domain.Repositories;
using Peep.Persistence.File.Models;

namespace Peep.Persistence.File
{
    public class StreamingProviderFileRepository : IStreamingProviderRepository
    {
        public void Save(StreamingProvider streamingProvider)
        {
            var streamingProviderModel = new StreamingProviderModel
            {
                Id = streamingProvider.Identity.Id,
                Type = streamingProvider.Identity.Type.ToString()
            };

            foreach (var category in streamingProvider.Categories)
            {
                var categoryModel = new MediaCategoryModel
                {
                    Name = category.Name
                };

                foreach (var media in category.Media)
                {
                    var mediaModel = new MediaModel
                    {
                        Name = media.Name,
                        DateAdded = media.DateAdded,
                        RelativeUrl = media.RelativeUrl.Value
                    };

                    categoryModel.Media.Add(mediaModel);
                }

                streamingProviderModel.Categories.Add(categoryModel);
            }

            System.IO.File.WriteAllText(
                $"{streamingProviderModel.Type.ToLower()}-data.json",
                JsonConvert.SerializeObject(streamingProviderModel, Formatting.Indented));
        }
    }
}
