using MarathonSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MarathonSystem.Transformers
{
    class ResultTransformer : Transformer
    {
        public ResultTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<RunnerEvent> events)
        {
            var list = new List<object>();
            foreach (var item in events) {
                var duration = TimeSpan.FromSeconds(item.finished_at);
                var status = new string[] { "Not Yet", "Yes" };
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "name",  item.Registration.Member.name},
                    { "country", item.Registration.Member.Country1.name },
                    { "gender", item.Registration.Member.Gender1.name },
                    { "bib_id", item.bib_id },
                    { "event_id", item.Registration.event_id },
                    { "event_name", item.Registration.MarathonEvent.name },
                    { "distance", item.Registration.MarathonEvent.EventType.distance },
                    { "approval", status[item.Registration.approval] },
                    { "racekitsend", status[item.racekitsend] },
                    { "checkedin", status[item.checkin_at > 0 ? 1 : 0] },
                    { "finished_at",  item.finished_at},
                    { "assgined_to", item.Member.name },
                    { "finished_time",  (int)duration.TotalHours + duration.ToString(@"\:mm\:ss") }
                }));
            }
            return list;
        } 
    }
}
