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
    public partial class Frm_Info : Form
    {
        private string type;
        private int id;
        private int x, y;

        public Frm_Info(string type, int id = 0)
        {
            InitializeComponent();
            this.type = type;
            this.id = id;
            btn_submit.Text = type;
            updateEventList();
        }

        private async void updateEventList()
        {
            string json = await Route.execute("PropertyController@getEventType");
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            if (success) {
                var list = result["data"].ToList();
                list.ForEach(item => {
                    eventTypeList.Items.Add(new ComboboxItem() {
                        Text = item["name"].ToString(),
                        Value = (int)item["id"]
                    });
                });
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async void Frm_Info_Load(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getMarathon();
            }
        }

        private async Task getMarathon()
        {
            string json = await Route.execute("EventController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var row = result["data"].First();
                txt_title.Text = row["name"].ToString();
                dateStartAt.Text = row["start_datetime"].ToString();
                dateRegStart.Text = row["start_at"].ToString();
                dateRegEnd.Text = row["end_at"].ToString();
                numQuota.Value = row["quota"].ToObject<int>();
                numPrice.Value = row["price"].ToObject<int>();

                var list = eventTypeList.Items.OfType<ComboboxItem>().ToList();
                ComboboxItem selected = null;
                selected = list.Where((ComboboxItem items) => items.Value.Equals(row["Event"]["id"].ToObject<int>())).FirstOrDefault();
                eventTypeList.SelectedItem = selected;
                dateStartAt.CustomFormat = dateRegStart.CustomFormat = dateRegEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json;
            if (type == "Edit") {
                json = await Route.execute("EventController@updateEvent", new object[] {
                    new {
                        name = txt_title.Text,
                        type_id = (eventTypeList.SelectedItem as ComboboxItem).Value,
                        quota = numQuota.Value,
                        start_at = dateRegStart.Value,
                        end_at = dateRegEnd.Value,
                        cost = numPrice.Value,
                        start_datetime = dateStartAt.Value
                    }, id
                });
            } else {
                json = await Route.execute("EventController@createEvent", new object[] {
                    new {
                        name = txt_title.Text,
                        type_id = (eventTypeList.SelectedItem as ComboboxItem).Value,
                        quota = numQuota.Value,
                        start_at = dateRegStart.Value,
                        end_at = dateRegEnd.Value,
                        cost = numPrice.Value,
                        start_datetime = dateStartAt.Value
                    }
                });
            }
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(14);
                Close();
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getMarathon();
            } else {
                txt_title.Text = null;
                eventTypeList.SelectedItem = null;
                dateRegEnd.CustomFormat = dateRegStart.CustomFormat = dateStartAt.CustomFormat = " ";
                numQuota.Value = numPrice.Value = 0;
            }
        }

        private void dateRegStart_ValueChanged(object sender, EventArgs e)
        {
            (sender as DateTimePicker).CustomFormat = "yyyy-MM-dd HH:mm";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
