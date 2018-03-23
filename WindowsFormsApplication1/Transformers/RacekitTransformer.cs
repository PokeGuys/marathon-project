using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class RacekitTransformer : Transformer
    {
        public RacekitTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<RaceKit> reg)
        {
            var list = new List<object>();
            foreach (var item in reg) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "name", item.name },
                    { "description", item.description },
                    { "price", item.price },
                    { "stock", item.stock },
                    { "sales", item.sales },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
