using MarathonSystem.Models;
using System;
using System.Collections.Generic;

namespace MarathonSystem.Transformers
{
    class PaymentTransformer : Transformer
    {
        public PaymentTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Registration> reg)
        {
            var list = new List<object>();
            foreach (var item in reg) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    { "id", item.id },
                    { "username", item.Member.username },
                    { "image", item.BankReceipt.image },
                    { "cost", item.cost },
                    { "created_at", new DateTime(1970, 1 ,1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd") }
                }));
            }
            return list;
        }
    }
}
