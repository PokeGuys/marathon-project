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
    class BannerController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Banners.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new BannerTransformer(new Dictionary<string, List<string>>() {{
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
                var rows = await context.Banners.Where(p => p.id == id).ToListAsync();
                if (rows.Count == 0) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "banner"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new BannerTransformer().transform(rows)
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
                image = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Banner newBanner = new Banner() {
                    name = request.title,
                    image = request.image,
                    created_at = timestamp,
                    updated_at = timestamp
                };
                context.Banners.Add(newBanner);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Banner created"
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
                Banner banner = null;
                banner = await context.Banners.FindAsync(id);
                if (banner == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "banner"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (request.image != null && request.image != string.Empty) {
                    banner.image = request.image;
                }
                banner.name = request.title;
                banner.updated_at = currentTimestamp;
                context.Entry(banner).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Banner updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Banner banner = null;
                banner = await context.Banners.FindAsync(id);
                if (banner == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "banner"));
                }
                context.Entry(banner).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Baner deleted"
                });
            }
        }
    }
}
