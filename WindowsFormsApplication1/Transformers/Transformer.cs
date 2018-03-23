using System.Collections.Generic;
using System.Linq;

namespace MarathonSystem.Transformers
{
    abstract class Transformer
    {
        public dynamic filters = new Dictionary<string, List<string>>();
        public Dictionary<string, object> trasnformWithFilter(Dictionary<string, object> p)
        {
            if (filters == null) {
                return p;
            }
            if (filters.ContainsKey("only")) {
                return p.Where(item => filters["only"].Contains(item.Key)).ToDictionary(t => t.Key, t => t.Value);
            }
            return p.Where(item => !filters["filter"].Contains(item.Key)).ToDictionary(t => t.Key, t => t.Value); ;
        }
    }
}
