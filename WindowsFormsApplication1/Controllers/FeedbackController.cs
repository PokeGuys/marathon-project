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
    class FeedbackController
    {
        public static async Task<string> Rows()
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Feedbacks.ToListAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new FeedbackTransformer().transform(rows)
                });
            }
        }

        public static async Task<string> Details(int id)
        {
            using (var context = new MarathonEntities()) {
                var rows = await context.Feedbacks.Where(feedback => feedback.id == id && feedback.state == 1).ToListAsync();
                if (rows.Count == 0) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "feedback"));
                }
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    data = new FeedbackTransformer().transform(rows)
                });
            }
        }

        public static async Task<string> Delete(int id)
        {
            using (var context = new MarathonEntities())
            {
                Feedback feedback = null;
                feedback = await context.Feedbacks.FindAsync(id);
                if (feedback == null) {
                    throw new NotFoundException(string.Format(Properties.strings.validation_exists, "feedback"));
                }
                feedback.state = 0;
                context.Entry(feedback).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Feedback deleted"
                });
            }
        }

        public static async Task<string> Create(dynamic request)
        {
            Validator validator = new Validator();
            validator.make(request, new {
                name = "required",
                feedback = "required"
            });
            if (validator.fails()) {
                throw new UnprocessableEntityException(validator.errors().First());
            }
            using (var context = new MarathonEntities()) {
                int currentTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Feedback newFeedback = new Feedback() {
                    name = request.name,
                    message = request.feedback,
                    created_at = currentTimestamp,
                    updated_at = currentTimestamp
                };
                context.Feedbacks.Add(newFeedback);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(new MessageFormatter {
                    success = true,
                    message = "Thank you for your feedback."
                });
            }
        }
    }
}
