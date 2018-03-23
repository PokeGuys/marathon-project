using System;
using System.Collections.Generic;
using MarathonSystem.Models;

namespace MarathonSystem.Transformers
{
    class PhotoTransformer : Transformer
    {
        public PhotoTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Photo> charity)
        {
            var list = new List<object>();
            foreach (var item in charity)
            {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "name", item.name },
                    { "image", item.image },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") },
                    { "updated_at", new DateTime(1970, 1 ,1).AddSeconds(item.updated_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
