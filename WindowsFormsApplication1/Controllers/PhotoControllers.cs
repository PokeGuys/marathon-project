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
    class PhotoControllers
    {
        public static async Task<string> upload(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                image = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Photo photo = new Photo() {
                    name = request.name,
                    image = request.image,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                context.Photos.Add(photo);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Photo created."
                });
            }
        }


        public static async Task<string> Update(dynamic request, int id)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                image = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                Photo photo = null;
                photo = await context.Photos.FindAsync(id);
                if (photo == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "photo"));
                }
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                photo.name = request.name;
                photo.updated_at = currentTimestamp;
                photo.image = request.image;
                context.Entry(photo).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "photo updated"
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities()) {
                Photo photo = null;
                photo = await context.Photos.FindAsync(id);
                if (photo == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "photo"));
                }
                context.Entry(photo).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "photo deleted"
                });
            }
        }


        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Photos.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new PhotoTransformer().transform(rows)
                });
            }
        }
    }
}
