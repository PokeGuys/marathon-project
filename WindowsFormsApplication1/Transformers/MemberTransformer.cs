using MarathonSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarathonSystem.Transformers
{
    class MemberTransformer : Transformer
    {
        public MemberTransformer(Dictionary<string, List<string>> rule = null)
        {
            filters = rule;
        }

        public List<object> transform(List<Member> member)
        {
            var list = new List<object>();
            foreach (var item in member) {
                list.Add(trasnformWithFilter(new Dictionary<string, object>() {
                    {"id", item.id},
                    {"state", item.state}, 
                    {"status_name", item.Status.name},
                    {"username", item.username},
                    {"email", item.email},
                    {"idcard", item.idcard},
                    {"name", item.name},
                    {"gender", item.gender},
                    {"phone", item.phone},
                    {"birthday", item.birthday},
                    {"country", item.country},
                    {"created_at", new DateTime(1970, 1, 1).AddSeconds(item.created_at).ToLocalTime().ToString("yyyy-MM-dd")},
                    {"updated_at", new DateTime(1970, 1, 1).AddSeconds(item.updated_at).ToLocalTime().ToString("yyyy-MM-dd")},
                    {"lastlogin", new DateTime(1970, 1, 1).AddSeconds(item.lastlogin).ToLocalTime().ToString("yyyy-MM-dd")}
                }));
            }
            return list;
        }
    }
}
