using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_RunnerEvent : Form
    {
        private int user_id, id, x, y;

        private async void btn_send_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure the racekit has been sent?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("VolunteerController@sendracekit", new object[] { id });
                JObject rss = JObject.Parse(json);
                bool success = Convert.ToBoolean(rss["success"]);
                string msgTitle = success ? "Info" : "Error";
                MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
                if (success) {
                    (Owner as Frm_Runner).reloadTable();
                    updateInfo();
                }
            }
        }

        private async void btn_checkin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to help runner to check-in?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("VolunteerController@checkin", new object[] { id });
                JObject rss = JObject.Parse(json);
                bool success = Convert.ToBoolean(rss["success"]);
                string msgTitle = success ? "Info" : "Error";
                MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
                if (success) {
                    (Owner as Frm_Runner).reloadTable();
                    updateInfo();
                }
            }
        }

        private async void updateInfo()
        {
            string json = await Route.execute("EventController@getRegistered", new object[] { user_id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var row = result["data"].First();
                lbl_status.Text = string.Format("Race Kit: {0} | Checked-in: {1}", row["racekitsend"].ToString(), row["checkedin"].ToString());
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to help runner to check-in?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("VolunteerController@updateGunTime", new object[] { id, int.Parse(txt_finished.Text) });
                JObject rss = JObject.Parse(json);
                bool success = Convert.ToBoolean(rss["success"]);
                string msgTitle = success ? "Info" : "Error";
                MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
                if (success) {
                    (Owner as Frm_Runner).reloadTable();
                }
            }
        }

        public Frm_RunnerEvent(int user_id, int id, string name, string racekit, string checkin, int guntime)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.id = id;
            lbl_item.Text = name;
            lbl_status.Text = string.Format("Race Kit: {0} | Checked-in: {1}", racekit, checkin);
            txt_finished.Text = guntime.ToString();
        }

        private void Lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void Lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
