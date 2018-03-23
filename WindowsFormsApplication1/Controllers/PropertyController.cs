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
    class PropertyController
    {
        public static List<JToken> country;

        public static async Task<string> getBanner()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Banners.ToListAsync();
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

        public static async Task<string> getStat()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.StatLogs.ToListAsync();
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

        public static async Task<string> getGenderInEvent()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RunnerEvents.GroupBy(p => new { p.Registration.event_id, p.Registration.MarathonEvent.name }).Select(c => new {
                    name = c.Key.name,
                    male = c.Where(p => p.Registration.Member.gender == "M").Count(),
                    female = c.Where(p => p.Registration.Member.gender == "F").Count(),
                }).ToListAsync();
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

        public static async Task<string> getRacekitInEvent()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.RaceKits.Where(p => p.state == 1).ToListAsync();
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

        public static async Task<string> getStatus()
        {
            using (var context = new MarathonEntities()) {
                Member member = Auth.User();
                context.Configuration.LazyLoadingEnabled = false;
                var status = await context.Status.Where(item => item.id >= 0 && (item.id < member.state || member.state == 99)).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = status
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getRegistration()
        {
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                var marathon = await context.MarathonEvents.Where(p => (p.start_at <= currentTimestamp && currentTimestamp <= p.end_at) && p.currentQuota > 0 && p.state == 1).ToListAsync();
                var racekit = await context.RaceKits.Where(item => item.stock > 0 && item.state == 1).ToListAsync();
                var charity = await context.Charities.Where(item => item.state == 1).ToListAsync();

                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        marathon = new EventTransformer().transform(marathon),
                        racekit = new RacekitTransformer().transform(racekit),
                        charity = new CharityTransformer().transform(charity)
                    }
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getCountry()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var countries = await context.Countries.Select(p => new { id = p.id, name = p.name }).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = countries
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getOverview()
        {
            if (!Auth.isStaff()) throw new UnauthorizedAccessException(Properties.strings.auth_unauth);
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var runner = await context.Members.Where(p => p.state == 3).ToListAsync();
                var sponsorship = await context.Sponsorships.SumAsync(p => p.amount);
                var charity = await context.Registrations.SumAsync(p => p.sponsorship);
                var receipt = await context.Registrations.Where(p => p.bank_id != null).ToListAsync();

                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        runner = runner.Count,
                        sponsorship = sponsorship + charity,
                        receipt = new {
                            current = receipt.Where(p => p.approval == 1).Count(),
                            total = receipt.Count
                        }
                    }
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getSponsorship()
        {
            if (!Auth.isStaff()) throw new UnauthorizedAccessException(Properties.strings.auth_unauth);
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var sponsorship = await context.Sponsorships.SumAsync(p => p.amount);
                var charity = await context.Registrations.SumAsync(p => p.sponsorship);

                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        runner = sponsorship,
                        charity = charity,
                        total = sponsorship + charity
                    }
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> getEventType()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.EventTypes.Select(p => new { id = p.id, name = p.name, distance = p.distance }).ToListAsync();

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

        public static async Task<string> getPayment()
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
    }
}
