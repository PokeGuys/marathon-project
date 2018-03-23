using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class RegistrationTransformer : Transformer
    {
        public RegistrationTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Registration> reg)
        {
            var list = new List<object>();
            var approved = new List<string>() { "No Payment", "Approved" };
            foreach (var item in reg) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "username", item.Member.username },
                    { "cost", item.cost },
                    { "approved", approved[item.approval] },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
