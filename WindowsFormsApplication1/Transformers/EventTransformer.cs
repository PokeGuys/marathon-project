using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class EventTransformer : Transformer
    {
        public EventTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<MarathonEvent> events)
        {
            var list = new List<object>();
            foreach (var item in events) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "name",  item.name},
                    { "quota",  item.quota},
                    { "price",  item.cost},
                    { "Event", new {
                            id = item.EventType.id,
                            name = item.EventType.name,
                            distance = item.EventType.distance
                        }
                    },
                    { "start_datetime", new DateTime(1970, 1, 1).AddSeconds(item.start_datetime).ToLocalTime().ToString("yyyy-MM-dd HH:mm") },
                    { "start_at",  new DateTime(1970, 1, 1).AddSeconds(item.start_at).ToLocalTime().ToString("yyyy-MM-dd HH:mm") },
                    { "end_at",  new DateTime(1970, 1, 1).AddSeconds(item.end_at).ToLocalTime().ToString("yyyy-MM-dd HH:mm") },
                    { "created_at",  new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd")}
                }));
            }
            return list;
        } 
    }
}
