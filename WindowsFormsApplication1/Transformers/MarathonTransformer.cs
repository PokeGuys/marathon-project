using MarathonSystem.Models;
using System.Linq;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class MarathonTransformer : Transformer
    {
        public MarathonTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<dynamic> transform(List<Marathon> events)
        {
            var list = new List<dynamic>();
            foreach (var item in events)
            {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "name",  item.name },
                    { "city",  item.city },
                    { "hold_at", item.hold_at },
                    { "country", item.Country.name }
                }));
            }
            return list;
        }
    }
}
