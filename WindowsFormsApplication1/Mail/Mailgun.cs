using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;

namespace MarathonSystem.Mail
{
    class Mailgun
    {
        const string DOMAIN = "";
        const string API_KEY = "";

        public static async Task<bool> sendMessage(string recipient, string token)
        {
            string title = "Marathon Skills Account Verification";
            string message = "Your verification token: " + token;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("api" + ":" + API_KEY)));
            var form = new Dictionary<string, string>();
            form.Add("from", "no-reply@marathonskill.com");
            form.Add("to", recipient);
            form.Add("subject", title);
            form.Add("text", message);

            var response = await client.PostAsync("https://api.mailgun.net/v3/" + DOMAIN + "/messages", new FormUrlEncodedContent(form));
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
