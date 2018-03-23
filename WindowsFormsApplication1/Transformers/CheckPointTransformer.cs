using MarathonSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSystem.Transformers
{
    class CheckPointTransformer : Transformer
    {
        public CheckPointTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<dynamic> transform(List<Checkpoint> events)
        {
            var list = new List<dynamic>();
            foreach (var item in events) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    {"id",  item.id},
                    {"X",  item.X},
                    {"Y",  item.Y},
                    {"landmark",  item.landmark},
                    {"service",  new ServiceTransformer().transform(item.Services.ToList())},
                }));
            }
            return list;
        }
    }
}
