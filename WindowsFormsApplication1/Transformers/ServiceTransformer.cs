using MarathonSystem.Models;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class ServiceTransformer : Transformer
    {
        public ServiceTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<dynamic> transform(List<Service> events)
        {
            var list = new List<dynamic>();
            foreach (var item in events) {
                if (item.state == 1) {
                    list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                        {"id",  item.id},
                        {"name",  item.name},
                        {"image",  item.image}
                    }));
                }
            }
            return list;
        }
    }
}
