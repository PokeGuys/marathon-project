using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Helpers;
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
    class MapController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.Services.Where(p => p.state == 1).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new ServiceTransformer(new Dictionary<string, List<string>> {{
                        "only",
                        new List<string>() {
                            "id",
                            "name"
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
                context.Configuration.LazyLoadingEnabled = false;
                var rows = await context.Services.FindAsync(id);
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = rows
                });
            }
        }

        public static async Task<string> mapInit(int id)
        {
            using (var context = new MarathonEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                var map = await context.MarathonEvents.Where(p => p.id == id).Include(p => p.Marathon).FirstAsync();
                var services = await context.Services.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new {
                        map = map.Marathon.map,
                        services = services
                    }
                });
            }
        }

        public static async Task<string> getCheckpoint(int id)
        {
            using (var context = new MarathonEntities()) {
                var events = await context.MarathonEvents.Where(p => p.id == id).FirstAsync();
                var rows = await context.Checkpoints.Where(p => p.marathon_id == events.marathon_id).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new CheckPointTransformer().transform(rows)
                },
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
        }

        public static async Task<string> applyCheckpoint(dynamic request, int id)
        {
            using (var context = new MarathonEntities()) {
                var events = await context.MarathonEvents.Where(p => p.id == id).FirstAsync();
                Checkpoint rows = new Checkpoint() {
                    marathon_id = events.marathon_id,
                    X = int.Parse(request.checkpoint.x),
                    Y = int.Parse(request.checkpoint.y),
                    landmark = request.checkpoint.landmark
                };
                foreach (var item in request.services) {
                    Service service = await context.Services.FindAsync(item);
                    rows.Services.Add(service);
                }
                context.Checkpoints.Add(rows);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Checkpoint created."
                });
            }
        }

        public static async Task<string> removeCheckpoint(int id)
        {
            using (var context = new MarathonEntities()) {
                Checkpoint rows = null;
                rows = await context.Checkpoints.FindAsync(id);
                if (rows == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "Checkpoint"));
                }
                foreach (var service in rows.Services.Where(p => p.id == id).ToList()) {
                    rows.Services.Remove(service);
                }
                context.Entry(rows).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Checkpoint removed."
                });
            }
        }

        public static async Task<string> Create(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                title = "required",
                image = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Service newService = new Service() {
                    name = request.title,
                    image = request.image,
                    state = 1
                };
                context.Services.Add(newService);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Service created"
                });
            }
        }

        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                title = "required",
                image = "present",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Service service = null;
                service = await context.Services.FindAsync(id);
                if (service == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "service"));
                }
                if (request.image != null && request.image != string.Empty) {
                    service.image = request.image;
                }
                service.name = request.title;
                context.Entry(service).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Service updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Service services = null;
                services = await context.Services.FindAsync(id);
                if (services == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "service"));
                }
                services.state = 0;
                context.Entry(services).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Services deleted"
                });
            }
        }
    }
}
