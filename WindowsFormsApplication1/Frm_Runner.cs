using MarathonSystem.Controllers;
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
    public partial class Frm_Runner : Form
    {
        private int id;
        private int x, y;
        private JToken items;

        public Frm_Runner(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void Frm_Runner_Load(object sender, EventArgs e)
        {
            getPersonalInfo();
            getEventInfo();
            var country = PropertyController.country;
            if (country == null) {
                string json = await Route.execute("PropertyController@getCountry");
                JObject result = JObject.Parse(json);
                bool success = Convert.ToBoolean(result["success"]);
                if (success) {
                    PropertyController.country = result["data"].ToList();
                    country = PropertyController.country;
                } else {
                    MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
            country.ForEach(item => {
                countryList.Items.Add(new ComboboxItem() {
                    Text = item["name"].ToString(),
                    Value = item["id"]
                });
            });
        }

        private async void getEventInfo()
        {
            string json = await Route.execute("EventController@getRegistered", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                eventList.BeginUpdate();
                eventList.Columns.Clear();
                eventList.Items.Clear();
                eventList.View = View.Details;
                eventList.Columns.Add("ID", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("EVENT", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("ASSIGNED", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("APPROVED?", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("RACEKIT SENT?", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("ATTENDED?", -2, HorizontalAlignment.Center);
                eventList.Columns.Add("GUN TIME", -2, HorizontalAlignment.Center);
                var rows = result["data"];
                items = rows;
                rows.Select(p => new {
                    id = p["id"].ToString(),
                    event_name = p["event_name"].ToString(),
                    payment = p["approval"].ToString(),
                    racekitsend = p["racekitsend"].ToString(),
                    checkedin = p["checkedin"].ToString(),
                    gun_time = p["finished_time"].ToString(),
                    assgined_to = p["assgined_to"].ToString()
                }).ToList().ForEach(item => {
                    string[] subItem = new string[] {
                        item.id,
                        item.event_name,
                        item.assgined_to,
                        item.payment,
                        item.racekitsend,
                        item.checkedin,
                        item.gun_time
                    };
                    ListViewItem lvi = new ListViewItem(subItem);
                    eventList.Items.Add(lvi);
                });
                eventList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                eventList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                eventList.EndUpdate();
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
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

        private async void getPersonalInfo()
        {
            string json = await Route.execute("MemberController@Details", new object[] {id});
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            if (success) {
                JToken member = result["data"].First();
                lbl_title.Text = string.Format("{0} ({1})", member["username"], member["id"]);
                lbl_username.Text = string.Format("{0}", member["status_name"]);
                lbl_date.Text = string.Format("Created at: {0} / Last Login: {1}", member["created_at"], member["lastlogin"]);
                txt_email.Text = member["email"].ToString();
                txt_idcard.Text = member["idcard"].ToString();
                txt_name.Text = member["name"].ToString();
                txt_phone.Text = member["phone"].ToString();
                radio_female.Checked = member["gender"].ToString() == "F";
                radio_male.Checked = member["gender"].ToString() == "M";
                if (member["birthday"] == null) {
                    birthday.Value = (DateTime)member["birthday"];
                }
                var list = countryList.Items.OfType<ComboboxItem>().ToList();
                ComboboxItem selected = null;
                selected = list.Where((ComboboxItem items) => items.Value.Equals(member["country"])).FirstOrDefault();
                countryList.SelectedItem = selected;
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            getPersonalInfo();
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string gender = radio_female.Checked ? "F" :
                            radio_male.Checked ? "M" : null;
            string json = await Route.execute("MemberController@update", new object[] {
                new {
                    password = txt_password.Text,
                    email = txt_email.Text,
                    name = txt_name.Text,
                    gender = gender,
                    idcard = txt_idcard.Text,
                    birthday = birthday.CustomFormat == " " ? null : birthday.Text,
                    phone = txt_phone.Text,
                    country = countryList.SelectedIndex > -1 ? (countryList.SelectedItem as ComboboxItem).Value.ToString() : null
                }, id
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                getPersonalInfo();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (eventList.SelectedItems.Count > 0) {
                var rows = items.Where(p => p["id"].ToString() == eventList.SelectedItems[0].Text).First();
                new Frm_RunnerEvent(id, rows["id"].ToObject<int>(), rows["event_name"].ToString(), rows["racekitsend"].ToString(), rows["checkedin"].ToString(), rows["finished_at"].ToObject<int>()).ShowDialog(this);
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void birthday_ValueChanged(object sender, EventArgs e)
        {
            birthday.CustomFormat = "yyyy-MM-dd";
        }

        private async void btn_cert_Click(object sender, EventArgs e)
        {
            if (eventList.SelectedItems.Count > 0) {
                int event_id = int.Parse(eventList.SelectedItems[0].Text);
                JToken events = await getBibEvent(event_id);
                if (events != null) {
                    var register = events["Registration"];
                    string json = await Route.execute("EventController@getResultDetails", new object[] { events["bib_id"].ToObject<int>(), register["event_id"].ToObject<int>() });
                    JObject result = JObject.Parse(json);
                    if (Convert.ToBoolean(result["success"])) {
                        JToken item = result["data"].First();
                        int finishTime = item["finished_at"].ToObject<int>();
                        double distance = double.Parse(item["distance"].ToString().Replace("KM", string.Empty));
                        double finishedInMin = finishTime / 60.0;
                        double pace = Math.Round(finishedInMin / distance, 2);
                        TimeSpan paceSpan = TimeSpan.FromMinutes(pace);
                        json = await Route.execute("EventController@getRanking", new object[] {
                            item["bib_id"].ToObject<int>(),
                            item["event_id"].ToObject<int>()
                        });

                        result = JObject.Parse(json);
                        if (Convert.ToBoolean(result["success"])) {
                            var rank = result["data"];
                            json = await Route.execute("EventController@getMarathon", new object[] { item["event_id"].ToObject<int>() });
                            result = JObject.Parse(json);
                            if (Convert.ToBoolean(result["success"])){
                                var marathon = result["data"];
                                new Frm_Certificate(item["name"].ToString(), new {
                                    finished_at = item["finished_time"],
                                    ppm = string.Format("{0}:{1} min/km", (int)paceSpan.TotalMinutes, paceSpan.Seconds),
                                    current = rank["current"],
                                    total = rank["total"]
                                }, new {
                                    id = marathon["id"],
                                    name = marathon["name"],
                                    logo = marathon["logo"],
                                    seal = marathon["seal"],
                                    created_at = marathon["hold_at"]
                                }).ShowDialog(Owner);
                            } else {
                                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else {
                            MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<JToken> getBibEvent(int id)
        {
            string json = await Route.execute("EventController@getBibEvent", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                return result["data"];
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void reloadTable()
        {
            getEventInfo();
        }
    }
}
