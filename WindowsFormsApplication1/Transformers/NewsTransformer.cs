using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class NewsTransformer : Transformer
    {
        public NewsTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<News> news)
        {
            var list = new List<object>();
            foreach (var item in news) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "title",  item.title},
                    { "message",  item.message},
                    { "created_at",  new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd")}
                }));
            }
            return list;
        } 
    }
}
