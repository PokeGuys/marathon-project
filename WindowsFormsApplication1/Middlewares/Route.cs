using MarathonSystem.Controllers;
using MarathonSystem.Exceptions;
using MarathonSystem.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem.Middlewares
{
    class Route
    {
        public static async Task<string> execute(string path, object[] funcParameters = null) {
            string result = "";
            string message = null;
            try {
                string[] split_path = path.Split('@');
                var route = new {
                    controller = split_path[0],
                    function = split_path[1]
                };
                Type controller = Type.GetType(string.Format("MarathonSystem.Controllers.{0}, {1}", route.controller, Assembly.GetExecutingAssembly().GetName().Name));
                MethodInfo theMethod = controller.GetMethod(route.function);
                result = await (Task<string>)theMethod.Invoke(null, funcParameters);
            } catch (DbEntityValidationException ex) {
                message = ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage).First();
            } catch (Exception ex) {
                message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            } finally {
                if (string.IsNullOrWhiteSpace(result)) {
                    result = JsonConvert.SerializeObject(new MessageFormatter {
                        success = false,
                        message = message
                    });
                }
            }
            return result;
        }
    }
}
