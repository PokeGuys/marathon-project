using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Payment : Form
    {
        private int id;
        private JToken item;
        public Frm_Payment(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Frm_Payment_Load(object sender, EventArgs e)
        {
            await getReceipt();
        }

        private async Task getReceipt()
        {
            string json = await Route.execute("PaymentController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var item = result["data"].First();
                this.item = item;
                byte[] imageBytes = Convert.FromBase64String(item["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    picReceipt.Image = Image.FromStream(ms, true);
                }
                lbl_created.Text = item["created_at"].ToString();
                lbl_status.Text = string.Format("Username: {0} / Cost: ${1}", item["username"], item["cost"]);
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to approve this bank-in receipt?", "Ask", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("PaymentController@Approve", new object[] { id });
                JObject result = JObject.Parse(json);
                bool success = Convert.ToBoolean(result["success"]);
                string msgTitle = success ? "Info" : "Error";
                var msgIcon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(result["message"].ToString(), msgTitle, MessageBoxButtons.OK, msgIcon);
                if (success) {
                    (Owner as frm_index).reloadTable(16);
                    Close();
                }
            }
        }

        private void picReceipt_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            var directory = Path.GetDirectoryName(path);
            var storePath = directory + @"\tmp\" + randomFileName() + ".jpg";
            bool exists = Directory.Exists(directory + @"\tmp");

            if (!exists)
                Directory.CreateDirectory(directory + @"\tmp");
            var bytes = Convert.FromBase64String(item["image"].ToString());
            using (var imageFile = new FileStream(storePath, FileMode.Create)) {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
            if (MessageBox.Show("File is ready. Do you need to open it?", "Ask", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Process.Start(storePath);
            }
        }

        private string randomFileName()
        {
            const string chars = "0123456789abcdef";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
