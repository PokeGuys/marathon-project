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
    public partial class Frm_Racekit : Form
    {
        private string type;
        private int id;
        private int x, y;

        public Frm_Racekit(string type, int id = 0)
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
            btn_submit.Text = type;
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

        private async Task getRacekit()
        {
            string json = await Route.execute("RaceKitController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var row = result["data"].First();
                txt_name.Text = row["name"].ToString();
                txtDescription.Text = row["description"].ToString();
                numStock.Value = row["stock"].ToObject<int>();
                numPrice.Value = row["price"].ToObject<int>();
                lbl_title.Text = string.Format("Race Kit - Sold: {0}", row["sales"]);
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json;
            if (type == "Edit") {
                json = await Route.execute("RaceKitController@Update", new object[] {
                    new {
                        name = txt_name.Text,
                        description = txtDescription.Text,
                        stock = numStock.Value,
                        price = numPrice.Value
                    }, id
                });
            } else {
                json = await Route.execute("RaceKitController@Create", new object[] {
                    new {
                        name = txt_name.Text,
                        description = txtDescription.Text,
                        stock = numStock.Value,
                        price = numPrice.Value
                    }
                });
            }
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(20);
                Close();
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getRacekit();
            } else {
                txt_name.Text = txtDescription.Text = null;
                numStock.Value = numPrice.Value = 0;
            }
        }

        private async void Frm_Racekit_Load(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getRacekit();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
