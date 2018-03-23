using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem.Helpers
{
    class Validator : ValidatesAttributes
    {
        private List<string> message = new List<string>();

        public void validate()
        {
            if (fails()) {
                throw new ValidationException(message.First());
            }
        }

        public Validator make(dynamic request, dynamic rule)
        {
            this.request = request;
            rules = explodeRules(rule);
            return this;
        }

        public IDictionary<string, object[]> getRules()
        {
            return rules;
        }

        public bool fails()
        {
            return !passes();
        }

        public bool passes()
        {
            foreach (var rule in rules) {
                bool ignorable = isIgnorable(rule.Value);
                string attribute = rule.Key;
                foreach (string fieldRule in rule.Value) {
                    validateAttribute(rule.Key, fieldRule, ignorable);
                }
            }
            return !message.Any();
        }

        private bool isIgnorable(object[] rule)
        {
            foreach (string fieldRule in rule) {
                if (fieldRule == "required") {
                    return false;
                }
            }
            return true;
        }

        private void validateAttribute(string attribute, string fieldRule, bool ignorable)
        {
            string[] ruleList = parse(fieldRule);
            string method = string.Format("validate{0}", ruleList[0]);
            var value = request.GetType().GetProperty(attribute).GetValue(request, null);
            MethodInfo theMethod = typeof(ValidatesAttributes).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            bool valid = (bool)theMethod.Invoke(this, new object[] { attribute, value, ruleList[1], this });
            if (!valid && (!ignorable || (value != null && value != string.Empty))) {
                addFailure(ruleList[0], attribute, value, ruleList[1]);
            }
        }

        private void addFailure(string rule, string attribute, string value, string parameter)
        {
            string reason = Properties.strings.ResourceManager.GetObject(string.Format("validation_{0}", rule.ToLower())).ToString();
            var matches = Regex.Matches(reason, @"{(.*?)}");
            var uniqueMatchCount = matches.OfType<Match>().Select(m => m.Value).Distinct().Count();
            if (uniqueMatchCount == 0) {
                message.Add(reason);
            } else if (parameter.Trim() != string.Empty) {
                message.Add(string.Format(reason, attribute, parameter));
            } else {
                message.Add(string.Format(reason, attribute));
            }
        }

        private dynamic parse(string value)
        {
            string parameters = "";
            if (value.IndexOf(":") >= 0) {
                var splitRule = value.Split(':');
                value = splitRule[0];
                parameters = splitRule[1];
            }
            value = value.Replace('-', ' ').Replace('_', ' ');
            string rule = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()).Replace(" ", String.Empty);
            return new string[] {
                rule.Trim(), 
                parameters
            };
        }

        public List<string> errors()
        {
            return message;
        }

        private Dictionary<string, object[]> explodeRules(dynamic rules)
        {
            var rule = new Dictionary<string, object[]>();
            foreach (PropertyInfo propertyInfo in rules.GetType().GetProperties()) {
                string key = propertyInfo.Name;
                string value = propertyInfo.GetValue(rules, null);
                rule.Add(key, value.Split('|'));
            }
            return rule;
        }
    }
}
