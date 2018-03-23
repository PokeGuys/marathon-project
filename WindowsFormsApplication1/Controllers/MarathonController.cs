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
using System.Threading.Tasks;

namespace MarathonSystem.Controllers
{
    class MarathonController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Marathons.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new MarathonTransformer().transform(rows)
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
                var rows = await context.Marathons.Where(p => p.id == id).ToListAsync();
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

        public static async Task<string> Create(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                city = "required",
                hold_at = "required",
                country = "required",
                logo = "required",
                map = "required",
                seal = "required",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Marathon marathon = new Marathon() {
                    name = request.name,
                    city = request.city,
                    hold_at = request.hold_at,
                    country_id = request.country,
                    logo = request.logo,
                    map = request.map,
                    seal = request.seal
                };
                context.Marathons.Add(marathon);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Marathon created"
                });
            }
        }

        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                city = "required",
                hold_at = "required",
                country = "required",
                logo = "present",
                map = "present",
                seal = "present"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Marathon marathon = null;
                marathon = await context.Marathons.FindAsync(id);
                if (marathon == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "marathon"));
                }
                if (request.logo != null && request.logo != string.Empty) {
                    marathon.logo = request.image;
                }
                if (request.map != null && request.map != string.Empty) {
                    marathon.map = request.image;
                }
                if (request.seal != null && request.seal != string.Empty) {
                    marathon.seal = request.image;
                }
                marathon.name = request.name;
                marathon.city = request.city;
                marathon.hold_at = request.hold_at;
                marathon.country_id = request.country;
                context.Entry(marathon).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Marathon updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Marathon marathon = null;
                marathon = await context.Marathons.FindAsync(id);
                if (marathon == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "marathon"));
                }
                context.Entry(marathon).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Marathon deleted"
                });
            }
        }
    }
}
