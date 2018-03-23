using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using MarathonSystem.Helpers;
using MarathonSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarathonSystem.Transformers;
using System.Data.Entity;

namespace MarathonSystem.Controllers
{
    class RaceKitController
    {
        public static async Task<string> Create(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                price = "required|number",
                stock = "required|number",
                description = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                RaceKit racekit = new RaceKit() {
                    state = 1,
                    name = request.name,
                    price = request.price,
                    stock = (int)request.stock,
                    description = request.description,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                context.RaceKits.Add(racekit);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Racekit created."
                });
            }
        }

        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RaceKits.Where(p => p.state == 1).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new RacekitTransformer(new Dictionary<string, List<string>>() {{
                        "only",
                        new List<string> {
                            "id",
                            "name",
                            "price",
                            "stock",
                            "sales",
                            "created_at"
                        }
                    }}).transform(rows)
                });
            }
        }

        public static async Task<string> Details(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.RaceKits.Where(RaceKits => RaceKits.id == id && RaceKits.state == 1).ToListAsync();
                if (rows.Count == 0) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "RaceKits"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new RacekitTransformer().transform(rows)
                });
            }
        }

        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                price = "required|number",
                stock = "required|number",
                description = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                RaceKit RaceKits = null;
                RaceKits = await context.RaceKits.FindAsync(id);
                if (RaceKits == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "RaceKits"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                RaceKits.name = request.name;
                RaceKits.price = request.price;
                RaceKits.stock = (int)request.stock;
                RaceKits.description = request.description;
                RaceKits.updated_at = currentTimestamp;

                context.Entry(RaceKits).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "RaceKits updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                RaceKit RaceKits = null;
                RaceKits = await context.RaceKits.FindAsync(id);
                if (RaceKits == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "RaceKits"));
                }
                RaceKits.state = 0;
                context.Entry(RaceKits).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "RaceKits deleted"
                });
            }
        }
    }
}
