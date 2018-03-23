using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Helpers;
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
    class EventController
    {
        public static async Task<string> registration(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                charity_id = "required",
                event_id = "required",
                racekit_id = "required",
                cost = "required",
                sponsorship = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int event_id = request.event_id;
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                BankReceipt bank = null;
                Member member = Auth.User();
                member.state = 3;
                member.Status = new Status() { id = 3 };
                int approval = request.payment == "credit" ? 1 : 0;
                MarathonEvent marathon = await context.MarathonEvents.FindAsync(event_id);
                RaceKit racekit = await context.RaceKits.FindAsync(request.racekit_id);
                racekit.sales++;
                racekit.stock--;
                marathon.currentQuota--;

                if (!request.image.Equals(string.Empty)) {
                    bank = new BankReceipt() {
                        image = request.image,
                        created_at = currentTimestamp,
                        updated_at = currentTimestamp
                    };
                    context.BankReceipts.Add(bank);
                }
                Registration events = new Registration() {
                    user_id = member.id,
                    charity_id = request.charity_id,
                    event_id = event_id,
                    racekit_id = request.racekit_id,
                    sponsorship = request.sponsorship,
                    cost = request.cost,
                    approval = approval,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                if (!request.image.Equals(string.Empty)) {
                    events.bank_id = bank.id;
                    events.BankReceipt = bank;
                }

                if (approval == 1) {
                    int bibId = await context.RunnerEvents.Where(p => p.Registration.event_id == event_id).MaxAsync(p => p.bib_id);
                    RunnerEvent runnerEvent = new RunnerEvent() {
                        registration_id = events.id,
                        bib_id = bibId + 1,
                        created_at = currentTimestamp,
                        updated_at = currentTimestamp
                    };
                    context.RunnerEvents.Add(runnerEvent);
                }
                context.Registrations.Add(events);
                context.Entry(member).State = EntityState.Modified;
                context.Entry(racekit).State = EntityState.Modified;
                context.Entry(marathon).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Event registered.\r\nOnce the payment is approved, we will send an notification mail to your address."
                });
            }
        }

        public static async Task<string> getPersonalResult()
        {
            using (var context = new MarathonEntities()) {
                var member = Auth.User();
                var rows = await context.RunnerEvents.Where(p => p.Registration.user_id == member.id && p.finished_at > 0).OrderBy(p => p.finished_at).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new ResultTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getRegistered(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.Where(p => p.Registration.user_id == id).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new ResultTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getBibEvent(int id)
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                RunnerEvent rows = null;
                rows = await context.RunnerEvents.Include(x => x.Registration).Where(p => p.id == id).FirstOrDefaultAsync();
                if (rows == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "event"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getMap()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Marathons.Where(item => item.hold_at == DateTime.Today.Year).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new MapTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getTimestamp()
        {
            using (var context = new MarathonEntities())
            {
                var rows = await context.Marathons.Where(item => item.hold_at == DateTime.Today.Year).FirstAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        timestamp = rows.MarathonEvents.First().start_datetime
                    }
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getEventRows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.EventTypes.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getEventDetails(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.EventTypes.Where(events => events.id == id).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> MarathonRows(int id = 0)
        {
            using (var context = new MarathonEntities()) {
                List<MarathonEvent> rows = null;
                if (id == 0) {
                    rows = await context.MarathonEvents.Where(p => p.Marathon.hold_at == DateTime.Now.Year).ToListAsync();
                } else {
                    rows = await context.MarathonEvents.Where(p => p.Marathon.id == id).ToListAsync();
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new EventTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getAllMarathon()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.Marathons.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getMarathon(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.MarathonEvents.Where(p => p.id == id).FirstAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        name = rows.Marathon.name,
                        city = rows.Marathon.city,
                        country = rows.Marathon.Country.name,
                        logo = rows.Marathon.logo,
                        seal = rows.Marathon.seal,
                        hold_at = new DateTime(1970, 1, 1).AddSeconds(rows.start_datetime).ToLocalTime().ToString("yyyy-MM-dd")
                    }
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
                var rows = await context.MarathonEvents.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new EventTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> dashboardRows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.MarathonEvents.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new EventTransformer(new Dictionary<string, List<string>>() {
                        {
                            "only",
                            new List<string> {
                                "id",
                                "name",
                                "price",
                                "quota",
                                "start_datetime"
                            }
                        },
                    }).transform(rows)
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
                var rows = await context.MarathonEvents.Where(events => events.id == id).Include(p => p.EventType).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new EventTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getJoinnedEvent(int id)
        {
            using (var context = new MarathonEntities())
            {
                var rows = await context.Registrations.Where(p => p.user_id == id).ToListAsync();
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

        public static async Task<string> getResult(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.Where(p => p.Registration.event_id == id && p.finished_at > 0 && p.checkin_at > 0).OrderBy(p => p.finished_at).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new ResultTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getRanking(int bib_id, int event_id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.OrderBy(p => p.finished_at)
                                        .Where(p => p.Registration.event_id == event_id && p.finished_at > 0 && p.checkin_at > 0)
                                        .Select(p => new {
                                            bib_id = p.bib_id,
                                            Rank = context.RunnerEvents.Where(x => x.Registration.event_id == event_id && x.finished_at > 0 && x.checkin_at > 0).Where(x => x.finished_at < p.finished_at).Count() + 1
                                        }).ToListAsync();
                var current = rows.Where(p => p.bib_id == bib_id).First();
                int total = rows.Count();
                int currentRank = current.Rank;
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        current = currentRank,
                        total = total
                    }
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getResultDetails(int id, int event_id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.Where(p => p.bib_id == id && p.Registration.event_id == event_id).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new ResultTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> createEvent(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                type_id = "required",
                quota = "required|min:0",
                start_at = "required",
                end_at = "required",
                cost = "required",
                start_datetime = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                var rows = await context.Marathons.Where(item => item.hold_at == DateTime.Today.Year).FirstAsync();
                MarathonEvent marathon = new MarathonEvent() {
                    state = 1,
                    currentQuota = (int)request.quota,
                    marathon_id = rows.id,
                    name = request.name,
                    type_id = request.type_id,
                    quota = (int)request.quota,
                    start_at = (int)request.start_at.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    end_at = (int)request.end_at.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    cost = request.cost,
                    start_datetime = (int)request.start_datetime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                context.MarathonEvents.Add(marathon);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Event created."
                });
            }
        }

        public static async Task<string> updateEvent(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                type_id = "required",
                quota = "required|min:0",
                start_at = "required",
                end_at = "required",
                cost = "required",
                start_datetime = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                MarathonEvent marathon = null;
                marathon = await context.MarathonEvents.FindAsync(id);
                if (marathon == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "marathon"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                marathon.name = request.name;
                marathon.type_id = request.type_id;
                marathon.quota = (int)request.quota;
                marathon.start_at = (int)request.start_at.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                marathon.end_at = (int)request.end_at.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                marathon.cost = request.cost;
                marathon.start_datetime = (int)request.start_datetime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                marathon.updated_at = currentTimestamp;
                context.Entry(marathon).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Event updated"
                });
            }
        }

        public static async Task<string> updateResult(int finishtime, int id)
        {
            using (var context = new MarathonEntities()) {
                RunnerEvent marathon = null;
                marathon = await context.RunnerEvents.FindAsync(id);
                if (marathon == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "event"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                marathon.finished_at = finishtime;
                marathon.updated_at = currentTimestamp;
                context.Entry(marathon).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Result updated"
                });
            }
        }

        public static async Task<string> getJoinedRows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.Where(p => p.checkin_at > 0).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new RunnerEvnetTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }
    }
}
