using MarathonSystem.Models;
using System.Linq;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class MapTransformer : Transformer
    {
        public MapTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<dynamic> transform(List<Marathon> events)
        {
            var list = new List<dynamic>();
            foreach (var item in events) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    {"name",  item.name},
                    {"city",  item.city},
                    {"map",  item.map},
                    {"checkpoints",  new CheckPointTransformer().transform(item.Checkpoints.ToList())},
                }));
            }
            return list;
        }
    }
}
