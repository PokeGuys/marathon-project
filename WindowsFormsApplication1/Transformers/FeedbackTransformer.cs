using MarathonSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSystem.Transformers
{
    class FeedbackTransformer : Transformer
    {
        public FeedbackTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Feedback> events)
        {
            var list = new List<object>();
            foreach (var item in events)
            {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "name",  item.name},
                    { "message",  item.message},
                    { "updated_at",  new DateTime(1970, 1, 1).AddSeconds(item.updated_at).ToLocalTime().ToString("yyyy-MM-dd")},
                    { "created_at",  new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd")}
                }));
            }
            return list;
        }
    }
}
