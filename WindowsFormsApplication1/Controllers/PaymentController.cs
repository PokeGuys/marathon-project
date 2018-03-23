using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using MarathonSystem.Transformers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSystem.Controllers
{
    class PaymentController
    {
        public static async Task<string> Rows()
        {
            if (!Auth.isStaff()) throw new UnauthorizedAccessException(Properties.strings.auth_unauth);
            using (var context = new MarathonEntities()) {
                var rows = await context.Registrations.Where(p => p.approval == 0).Include(p => p.Member).ToListAsync();

                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new RegistrationTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> Details(int id)
        {
            if (!Auth.isStaff()) throw new UnauthorizedAccessException(Properties.strings.auth_unauth);
            using (var context = new MarathonEntities()) {
                var rows = await context.Registrations.Where(p => p.id == id).Include(p => p.BankReceipt).ToListAsync();

                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new PaymentTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> Approve(int id)
        {
            if (!Auth.isStaff()) throw new UnauthorizedAccessException(Properties.strings.auth_unauth);
            using (var context = new MarathonEntities()) {
                Registration rows = null;
                rows = await context.Registrations.Where(p => p.id == id).Include(p => p.BankReceipt).FirstOrDefaultAsync();
                if (rows == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "account"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int bibId = await context.RunnerEvents.Where(p => p.Registration.event_id == rows.event_id).MaxAsync(p => p.bib_id);
                RunnerEvent runnerEvent = new RunnerEvent() {
                    registration_id = id,
                    bib_id = bibId + 1,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };

                rows.approval = 1;
                context.Entry(rows).State = EntityState.Modified;
                context.RunnerEvents.Add(runnerEvent);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Payment Approved."
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }
    }
}
