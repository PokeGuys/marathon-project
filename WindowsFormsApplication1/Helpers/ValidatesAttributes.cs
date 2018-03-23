using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarathonSystem.Helpers
{
    class ValidatesAttributes
    {
        public dynamic request;
        public Dictionary<string, object[]> rules;

        protected bool validateNumber(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            decimal num;
            if (value is int || value is double || value is decimal) {
                return true;
            }
            return decimal.TryParse(value.toString(), out num);
        }

        protected bool validatePresent(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            return request.GetType().GetProperty(attribute) != null;
        }

        protected bool validateGender(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (!(value is string)) {
                return false;
            }
            return value == "M" || value == "F";
        }

        protected bool validateAdult(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (!validateDate(attribute, value, parameters, validator)) {
                return false;
            }
            DateTime date;
            DateTime.TryParse(value, out date);
            var today = DateTime.Now;
            int years = today.Year - date.Year;
            if ((date.Month > today.Month) || (date.Month == today.Month && date.Day > today.Day))
                years--;
            return years >= 18;
        }

        protected bool validateDate(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            DateTime date;
            bool success = DateTime.TryParse(value, out date);
            return success;
        }

        protected bool validateRequired(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (value == null) {
                return false;
            } else if (value is string && value.Trim() == string.Empty) {
                return false;
            }

            return true;
        }

        protected bool validateMin(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (value == null) {
                return false;
            }
            return getSize(attribute, value) >= int.Parse(parameters);
        }

        protected bool validateMax(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (value == null) {
                return false;
            }
            return getSize(attribute, value) <= int.Parse(parameters);
        }

        protected bool validateUrl(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            Uri uriResult;
            if (!(value is string)) {
                return false;
            }
            return Uri.TryCreate(value, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        protected bool validatePassword(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            if (!(value is string)) {
                return false;
            }
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^])[A-Za-z\d!@#$%^]{6,}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        protected bool validateConfirmed(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            return validateSame(attribute, value, attribute + "_confirmation", validator);
        }

        protected bool validateEmail(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            return new EmailAddressAttribute().IsValid(value);
        }

        protected bool validateSame(string attribute, dynamic value, dynamic parameters, Validator validator)
        {
            var other = request.GetType().GetProperty(parameters).GetValue(request, null);
            return value == other;
        }

        private dynamic getSize(string attribute, dynamic value)
        {
            if (value is int || value is double || value is decimal) {
                return value;
            }

            return value.Length;
        }
    }
}
