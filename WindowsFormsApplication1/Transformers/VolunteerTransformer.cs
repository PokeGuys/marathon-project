using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class VolunteerTransformer : Transformer
    {
        public VolunteerTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<RunnerEvent> register)
        {
            var list = new List<object>();
            var checkin = new List<string>() {
                "Not Yet",
                "Checked-in"
            };
            var send = new List<string>() {
                "Not Yet",
                "Sent"
            };

            foreach (var item in register) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "username", item.Registration.Member.username },
                    { "checked-in", checkin[item.checkin_at > 0 ? 1 : 0] },
                    { "racekitsend", send[item.racekitsend] },
                    { "event_name", item.Registration.MarathonEvent.name },
                    { "assigned_to", item.Member == null ? "Not Yet" : item.Member.name },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
