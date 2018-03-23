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
    class NewsController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.News.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new NewsTransformer(new Dictionary<string, List<string>>() {
                        {
                            "only",
                            new List<string> {
                                "id",
                                "title",
                                "created_at"
                            }
                        },
                    }).transform(rows)
                });
            }
        }

        public static async Task<string> Details(int id)
        {
            using (var context = new MarathonEntities())
            {
                var rows = await context.News.Where(news => news.id == id).ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new NewsTransformer().transform(rows)
                });
            }
        }

        public static async Task<string> Create(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                title = "required",
                message = "required",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                News newNews = new News() {
                    title = request.title,
                    message = request.message,
                    created_at = timestamp,
                    updated_at = timestamp
                };
                context.News.Add(newNews);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "News created"
                });
            }
        }

        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                title = "required",
                message = "required",
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                News news = null;
                news = await context.News.FindAsync(id);
                if (news == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "news"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                news.title = request.title;
                news.message = request.message;
                news.updated_at = currentTimestamp;
                context.Entry(news).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "News updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                News news = null;
                news = await context.News.FindAsync(id);
                if (news == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "news"));
                }
                context.Entry(news).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "News deleted"
                });
            }
        }
    }
}
