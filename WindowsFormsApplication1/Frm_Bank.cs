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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Bank : Form
    {
        public int charity_id, event_id, racekit_id, runner_id;
        public decimal cost, sponsorship;
        private string image, path, type, name;
        private int x, y;

        public Frm_Bank(string type, decimal cost, decimal sponsorship, string name, int runner_id, int racekit_id, int charity_id, int event_id)
        {
            InitializeComponent();
            this.cost = cost;
            this.sponsorship = sponsorship;
            this.type = type;
            this.charity_id = charity_id;
            this.event_id = event_id;
            this.runner_id = runner_id;
            this.racekit_id = racekit_id;
            this.name = name;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            (Owner as Frm_PaymentMethod).Show();
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            (Owner as Frm_PaymentMethod).Show();
            Close();
        }

        private void Frm_Bank_Load(object sender, EventArgs e)
        {
            lbl_item.Text = type == "event" ? "Event Registration" : "Sponsor runner";
            lbl_cost.Text = "$" + cost;
        }

        private async void btn_pay_Click(object sender, EventArgs e)
        {
            string json = type == "event" ? await registration() : await sponsor();
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                if (type == "event") {
                    (Owner.Owner.Owner as frm_index).updateLoginState();
                }
                Close();
            }
        }

        private async Task<string> registration()
        {
            return await Route.execute("EventController@registration", new object[] {
                new {
                    payment = "bank",
                    type = type,
                    charity_id = charity_id,
                    event_id = event_id,
                    racekit_id = racekit_id,
                    cost = cost,
                    sponsorship = sponsorship,
                    image = image
                }
            });
        }

        private async Task<string> sponsor()
        {
            return await Route.execute("MemberController@sponsor", new object[] {
                new {
                    payment = "bank",
                    type = type,
                    name = name,
                    runner_id = runner_id,
                    sponsorship = cost,
                    image = image
                }
            });
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK) {
                path = dialog.FileName;
                byte[] bytes = File.ReadAllBytes(path);
                image = Convert.ToBase64String(bytes);
                lbl_filename.Text = dialog.SafeFileName;
                picPreview.Image = Image.FromFile(path);
                picPreview.Cursor = Cursors.Hand;
                btn_pay.ForeColor = Color.White;
                btn_pay.BackColor = lbl_title.BackColor;
                btn_pay.Enabled = true;
            }
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            if (path != null) {
                Process.Start(path);
            }
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
