using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class BannerTransformer : Transformer
    {
        public BannerTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Banner> banner)
        {
            var list = new List<object>();
            foreach (var item in banner) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "title", item.name },
                    { "image", item.image },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
