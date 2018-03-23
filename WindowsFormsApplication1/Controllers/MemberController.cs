using DevOne.Security.Cryptography.BCrypt;
using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Helpers;
using MarathonSystem.Mail;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using MarathonSystem.Transformers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MarathonSystem.Controllers
{
    class MemberController
    {
        public static async Task<string> getRunner()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Members.Where(items => items.state == 2).Include(p => p.Status).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new MemberTransformer(new Dictionary<string, List<string>>() {{
                        "only",
                        new List<string> {
                            "id",
                            "status_name",
                            "name",
                            "created_at"
                        }
                    }}).transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Members.Where(p => p.state >= 0).Include(p => p.Status).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new MemberTransformer(new Dictionary<string, List<string>>() {{
                        "only",
                        new List<string> {
                            "id",
                            "status_name",
                            "username",
                            "created_at"
                        }
                    }}).transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> Details(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Members.Include(p => p.Status).Where(item => item.id == id && item.state >= 0).ToListAsync();
                if (rows.Count == 0) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "member"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new MemberTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> sponsor(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                runner_id = "required",
                name = "required",
                sponsorship = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Sponsorship sponsor = new Sponsorship() {
                    runner_id = request.runner_id,
                    name = request.name,
                    amount = request.sponsorship,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                context.Sponsorships.Add(sponsor);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Runner sponsored.\r\nOnce the payment is approved, we will send an notification mail to your address."
                });
            }
        }

        public static async Task<string> authenticate(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                username = "required|min:6|max:20",
                password = "required|min:6|password",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Member member = null;
                string username = request.username;
                member = await context.Members.Include(p => p.Status).Where(m => m.username == username && m.state != -1).FirstOrDefaultAsync();
                if (member == null) {
                    throw new UnauthorizedAccessException(Properties.strings.auth_failed);
                } else if (!BCryptHelper.CheckPassword(request.password, member.password)) {
                    throw new UnauthorizedAccessException(Properties.strings.auth_failed);
                }
                member.lastlogin = currentTimestamp;
                context.Entry(member).State = EntityState.Modified;
                await context.SaveChangesAsync();
                Auth.setUser(member);
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Login successful!"
                });
            }
        }

        public static async Task<string> registration(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                username = "required|min:6|max:20",
                password = "required|min:6|password|confirmed",
                email = "required|email",
                idcard = "required",
                state = "required",
                gender = "present|gender",
                birthday = "present|date|adult",
                country = "present|max:3"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                string username = request.username;
                string email = request.email;
                string idcard = request.idcard;
                Member member = null;
                member = await context.Members.Where(m => m.username == username || m.email == email || m.idcard == idcard).FirstOrDefaultAsync();
                if (member != null) {
                    if (string.Equals(member.username, request.username, StringComparison.OrdinalIgnoreCase)) {
                        throw new ConflictException(string.Format(Properties.strings.validation_unique, "username"));
                    } else if (string.Equals(member.email, request.email, StringComparison.OrdinalIgnoreCase)) {
                        throw new ConflictException(string.Format(Properties.strings.validation_unique, "email"));
                    } else {
                        throw new ConflictException(string.Format(Properties.strings.validation_unique, "idcard"));
                    }
                }
                const string chars = "0123456789abcdef";
                Random random = new Random();
                string token = new string(Enumerable.Repeat(chars, 40).Select(s => s[random.Next(s.Length)]).ToArray());
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                DateTime? birthday = null;
                DateTime tempDate;
                bool success = DateTime.TryParseExact(request.birthday, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out tempDate);
                if (success) birthday = tempDate;
                Member newMember = new Member() {
                    state = request.state,
                    username = request.username,
                    password = BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt()),
                    name = request.name,
                    email = request.email,
                    idcard = request.idcard,
                    gender = request.gender,
                    birthday = birthday,
                    phone = request.phone,
                    country = request.country,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                if (request.state == 0) {
                    bool mailSent = await Mailgun.sendMessage(request.email, token);
                    if (!mailSent) throw new UnprocessableEntityException(Properties.strings.service_unavailable);
                    Verification verify = new Verification() {
                        token = token,
                        created_at = currentTimestamp,
                        updated_at = currentTimestamp,
                        Member = newMember
                    };
                    context.Verifications.Add(verify);
                }
                context.Members.Add(newMember);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Account registrated."
                });
            }
        }

        public static async Task<string> resetPassword(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                username = "required|min:6|max:20",
                password = "required|min:6|password|confirmed",
                idcard = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                string username = request.username;
                string idcard = request.idcard;
                Member member = null;
                member = await context.Members.Where(m => m.username == username && m.idcard == idcard).FirstOrDefaultAsync();
                if (member == null) {
                    throw new UnauthorizedAccessException(Properties.strings.auth_failed);
                }
                member.password = BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt());
                context.Entry(member).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Your password has been reset!"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Member member = await context.Members.FindAsync(id);
                if (member == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "account"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                member.state = -1;
                member.deleted_at = currentTimestamp;
                context.Entry(member).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Account deleted"
                });
            }
        }

        public static async Task<string> editProfile(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                oldpassword = "present|min:6|password",
                password = "present|min:6|password|confirmed",
                email = "present|email",
                name = "present",
                birthday = "present|date|adult",
                idcard = "present",
                country = "present|max:3",
                phone = "present",
                gender = "present|gender"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Member member = Auth.User();
                if (request.oldpassword != string.Empty) {
                    if (!BCryptHelper.CheckPassword(request.oldpassword, member.password)) {
                        throw new UnauthorizedAccessException(string.Format(Properties.strings.auth_password));
                    }
                    member.password = BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt());
                }
                var rules = validator.getRules();
                DateTime? birthday = null;
                DateTime tempDate;
                bool success = DateTime.TryParseExact(request.birthday, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out tempDate);
                if (success) birthday = tempDate;
                foreach (var rule in rules.Where(items => !items.Key.Contains("password"))) {
                    string attribute = rule.Key;
                    var fieldProperty = member.GetType().GetProperty(attribute);
                    var field = fieldProperty.GetType();
                    var memberValue = fieldProperty.GetValue(member, null) ?? string.Empty;
                    var value = string.Equals(attribute, "birthday") ? birthday : request.GetType().GetProperty(attribute).GetValue(request, null);
                    fieldProperty.SetValue(member, value, null);
                }

                context.Entry(member).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Your profile has been updated!"
                });
            }
        }
        public static async Task<string> update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                password = "present|min:6|password",
                email = "present|email",
                name = "present",
                birthday = "present|date|adult",
                idcard = "present",
                country = "present|max:3",
                phone = "present",
                gender = "present|gender"
            });
            if (validator.fails())
            {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities())
            {
                Member member = await context.Members.FindAsync(id);
                if (member == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "account"));
                }
                if (request.password != string.Empty) {
                    member.password = BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt());
                }
                var rules = validator.getRules();
                DateTime? birthday = null;
                DateTime tempDate;
                bool success = DateTime.TryParseExact(request.birthday, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out tempDate);
                if (success) birthday = tempDate;
                foreach (var rule in rules.Where(items => !items.Key.Contains("password"))) {
                    string attribute = rule.Key;
                    var fieldProperty = member.GetType().GetProperty(attribute);
                    var field = fieldProperty.GetType();
                    var memberValue = fieldProperty.GetValue(member, null) ?? string.Empty;
                    var value = string.Equals(attribute, "birthday") ? birthday : request.GetType().GetProperty(attribute).GetValue(request, null);
                    fieldProperty.SetValue(member, value, null);
                }

                context.Entry(member).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter
                {
                    success = true,
                    message = "The profile has been updated!"
                });
            }
        }
    }
}
