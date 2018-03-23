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
    public partial class Frm_RaceBib : Form
    {
        private int id, event_id;
        private JToken item, rank, marathon;
        private int x, y;

        public Frm_RaceBib(int id, int event_id)
        {
            InitializeComponent();
            this.id = id;
            this.event_id = event_id;
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

        private void btn_cert_Click(object sender, EventArgs e)
        {
            if (item != null) {
                int finishTime = item["finished_at"].ToObject<int>();
                double distance = double.Parse(item["distance"].ToString().Replace("KM", string.Empty));
                double finishedInMin = finishTime / 60.0;
                double pace = Math.Round(finishedInMin / distance, 2);
                TimeSpan paceSpan = TimeSpan.FromMinutes(pace);
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
                MessageBox.Show(Properties.strings.validation_allrequired, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Frm_RaceBib_Load(object sender, EventArgs e)
        {
            string json = await Route.execute("EventController@getResultDetails", new object[] { id, event_id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                JToken rows = result["data"].First();
                item = rows;
                int finishTime = rows["finished_at"].ToObject<int>();
                TimeSpan t = TimeSpan.FromSeconds(finishTime);
                double distance = double.Parse(rows["distance"].ToString().Replace("KM", string.Empty));
                double finishedInMin = finishTime / 60.0;
                double finishedInHour = finishTime / 3600.0;
                double speed = Math.Round(distance / finishedInHour, 2);
                double pace = Math.Round(finishedInMin / distance, 2);
                TimeSpan paceSpan = TimeSpan.FromMinutes(pace);

                lbl_runner_name.Text = rows["name"].ToString();
                lbl_info.Text = string.Format("Bib #{0} , {1}, {2}", rows["bib_id"], rows["country"], rows["gender"]);
                lbl_finished_at.Text = (int)t.TotalHours + t.ToString(@"\:mm\:ss");
                lbl_distance.Text = string.Format("{0} KM", distance);
                lbl_speed.Text = string.Format("{0} km/H", speed);
                lbl_pace.Text = string.Format("{0}:{1} min/km", (int)paceSpan.TotalMinutes, paceSpan.Seconds);

                json = await Route.execute("EventController@getRanking", new object[] {
                    rows["bib_id"].ToObject<int>(),
                    rows["event_id"].ToObject<int>()
                });
                result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"])) {
                    rank = result["data"];
                    lbl_total_postition_header.Text = string.Format("Out of {0}", result["data"]["total"]);
                    lbl_current_position.Text = string.Format("{0}", result["data"]["current"]);
                } else {
                    MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                json = await Route.execute("EventController@getMarathon", new object[] { event_id });
                result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"])) {
                    marathon = result["data"];
                    lblStartat.Text = string.Format("Running @ {0}, {1}, {2}", result["data"]["country"], result["data"]["city"], result["data"]["hold_at"]);
                    lblEvent.Text = string.Format("{0}", result["data"]["name"]);
                } else {
                    MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
