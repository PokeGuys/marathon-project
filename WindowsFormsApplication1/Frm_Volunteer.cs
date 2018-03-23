using MarathonSystem.Helpers;
using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Volunteer : Form
    {
        private int id;
        private int x, y;

        public Frm_Volunteer(string name, int id)
        {
            InitializeComponent();
            this.id = id;
            lbl_runner.Text = string.Format("Runer: {0}", name);
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

        private void volunteerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_next.Enabled = true;
            btn_next.BackColor = lbl_title.BackColor;
            btn_next.ForeColor = Color.White;
        }

        private async void Frm_Volunteer_Load(object sender, EventArgs e)
        {
            string json = await Route.execute("VolunteerController@volunteerRows");
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var rows = result["data"].ToList();
                rows.ForEach(item => {
                    volunteerList.Items.Add(new ComboboxItem() {
                        Text = item["username"].ToString(),
                        Value = item["id"].ToObject<int>()
                    });
                });
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("VolunteerController@assignVolunteer", new object[] {
                id,
                (volunteerList.SelectedItem as ComboboxItem).Value
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(15);
                Close();
            }
        }
    }
}
