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
    class CharityController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Charities.Where(p => p.state == 1).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new CharityTransformer(new Dictionary<string, List<string>>() {{
                        "only",
                        new List<string> {
                            "id",
                            "title",
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
                var rows = await context.Charities.Where(charity => charity.id == id && charity.state == 1).ToListAsync();
                if (rows.Count == 0) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "charity"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new CharityTransformer().transform(rows)
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
                title = "required",
                description = "required",
                image = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Charity newCharity = new Charity() {
                    name = request.title,
                    image = request.image,
                    created_at = timestamp,
                    updated_at = timestamp,
                    state = 1,
                    description = request.description
                };
                context.Charities.Add(newCharity);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Charity created"
                });
            }
        }

        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                title = "required",
                description = "required",
                image = "present",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Charity charity = null;
                charity = await context.Charities.FindAsync(id);
                if (charity == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "charity"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (request.image != null && request.image != string.Empty) {
                    charity.image = request.image;
                }
                charity.name = request.title;
                charity.description = request.description;
                charity.updated_at = currentTimestamp;
                context.Entry(charity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Charity updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Charity charity = null;
                charity = await context.Charities.FindAsync(id);
                if (charity == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "charity"));
                }
                charity.state = 0;
                context.Entry(charity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Charity deleted"
                });
            }
        }
    }
}
