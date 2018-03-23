using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Helpers;
using MarathonSystem.Mail;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSystem.Controllers
{
    class VerificationController
    {
        public static async Task<string> verification(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                token = "required",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Member member = Auth.User();
                string token = request.token;
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (member.state != 0) {
                    throw new UnauthorizedAccessException(string.Format(Properties.strings.auth_unauth));
                }
                Verification verify = null;
                verify = await context.Verifications.Where(verification => verification.token.Equals(token) && verification.user_id == member.id).FirstOrDefaultAsync();
                if (verify == null) {
                    throw new UnprocessableEntityException(string.Format(Properties.strings.verification_token));
                }
                member.state = 1;
                member.Status = new Status() { id = 1 };
                context.Entry(member).State = EntityState.Modified;
                context.Entry(verify).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Member verified!"
                });
            }
        }

        public static async Task<string> resend()
        {
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Member member = Auth.User();
                if (member.state != 0) {
                    throw new UnauthorizedAccessException(string.Format(Properties.strings.auth_unauth));
                }
                Verification verify = null;
                verify = await context.Verifications.Where(v => v.user_id == member.id).FirstOrDefaultAsync();
                if (verify == null) {
                    throw new UnauthorizedAccessException(string.Format(Properties.strings.auth_unauth));
                }
                int lastSent = verify.updated_at;
                if (currentTimestamp - lastSent < 30 * 60) {
                    throw new UnprocessableEntityException(string.Format(Properties.strings.verification_limit));
                }
                const string chars = "0123456789abcdef";
                Random random = new Random();
                string token = new string(Enumerable.Repeat(chars, 40).Select(s => s[random.Next(s.Length)]).ToArray());
                bool mailSent = await Mailgun.sendMessage(member.email, token);
                if (!mailSent) throw new UnprocessableEntityException(Properties.strings.service_unavailable);
                verify.token = token;
                verify.updated_at = currentTimestamp;
                context.Entry(verify).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Verification code has been sent! Please check your email address."
                });
            }
        }
    }
}
