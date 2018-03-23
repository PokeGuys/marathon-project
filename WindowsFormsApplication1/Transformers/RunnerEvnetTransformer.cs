using MarathonSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSystem.Transformers
{
    class RunnerEvnetTransformer : Transformer
    {
        public RunnerEvnetTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<RunnerEvent> events)
        {
            var list = new List<object>();
            int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            foreach (var item in events) {
                var finished = new List<string> { "Not Yet", "Yes" };
                int status = currentTimestamp > item.Registration.MarathonEvent.start_datetime ? 1 : 0;
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id",  item.id },
                    { "username", item.Registration.Member.username },
                    { "real_name", item.Registration.Member.name },
                    { "bib_id", item.bib_id },
                    { "event_name", item.Registration.MarathonEvent.name },
                    { "event_finished?", finished[status] },
                    { "finished_time",  item.finished_at }
                }));
            }
            return list;
        }
    }
}
