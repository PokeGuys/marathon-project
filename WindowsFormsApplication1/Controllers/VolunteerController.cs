using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using MarathonSystem.Transformers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSystem.Controllers
{
    class VolunteerController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var member = Auth.User();
                var rows = await context.RunnerEvents.Where(p => (p.volunteer_id == member.id || member.state > 3) && (p.checkin_at == 0 || p.racekitsend == 0)).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new VolunteerTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> volunteerRows()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.Members.Where(p => p.state == 2).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                });
            }
        }

        public static async Task<string> assignVolunteer(int id, int volunteer_id)
        {
            using (var context = new MarathonEntities()) {
                RunnerEvent record = null;
                record = await context.RunnerEvents.Where(p => p.id == id).FirstOrDefaultAsync();
                if (record == null) throw new NotFoundException(string.Format(Properties.strings.validation_exists, "record"));
                record.volunteer_id = volunteer_id;
                context.Entry(record).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Runner assigned."
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> sendracekit(int id)
        {
            using (var context = new MarathonEntities()) {
                RunnerEvent record = null;
                record = await context.RunnerEvents.Where(p => p.id == id).FirstOrDefaultAsync();
                var member = Auth.User();
                if (record == null) throw new NotFoundException(string.Format(Properties.strings.validation_exists, "record"));
                record.racekitsend = record.racekitsend == 0 ? 1 : 0;
                context.Entry(record).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "RaceKitSend Status updated."
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> checkin(int id)
        {
            using (var context = new MarathonEntities()) {
                RunnerEvent record = null;
                record = await context.RunnerEvents.Where(p => p.id == id).FirstOrDefaultAsync();
                var member = Auth.User();
                if (record == null) throw new NotFoundException(string.Format(Properties.strings.validation_exists, "record"));
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                record.checkin_at = currentTimestamp;
                context.Entry(record).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Runner check-in successful."
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> updateGunTime(int id, int guntime)
        {
            using (var context = new MarathonEntities()) {
                RunnerEvent record = null;
                record = await context.RunnerEvents.Where(p => p.id == id).FirstOrDefaultAsync();
                if (record == null) throw new NotFoundException(string.Format(Properties.strings.validation_exists, "record"));
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                record.finished_at = guntime;
                context.Entry(record).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Runner guntime update successful."
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }
    }
}
