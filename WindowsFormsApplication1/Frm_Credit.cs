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
    public partial class frm_credit : Form
    {
        public int charity_id, event_id, racekit_id, runner_id;
        public decimal cost, sponsorship;
        private string type, name;
        private int x, y;

        public frm_credit(string type, decimal cost, decimal sponsorship, string name, int runner_id, int racekit_id = 0, int charity_id = 0, int event_id = 0)
        {
            InitializeComponent();
            this.cost = cost;
            this.sponsorship = sponsorship;
            this.type = type;
            this.charity_id = charity_id;
            this.event_id = event_id;
            this.racekit_id = racekit_id;
            this.runner_id = runner_id;
            this.name = name;
            lbl_item.Text = type == "sponsor" ? "Sponsorship" : "Event Registration";
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Frm_Credit_Load(object sender, EventArgs e)
        {
            lbl_cost.Text = "$" + cost;
        }

        private void txt_expire_year_LostFocus(object sender, EventArgs e) {
            if (txt_expire_year.Text == string.Empty) {
                txt_expire_year.Text = "YY";
                txt_expire_year.ForeColor = Color.LightGray;
            }
        }

        private void txt_expire_month_LostFocus(object sender, EventArgs e) {
            if (txt_expire_month.Text == string.Empty) {
                txt_expire_month.Text = "MM";
                txt_expire_month.ForeColor = Color.LightGray;
            }
        }

        private void txt_expire_year_GotFocus(object sender, EventArgs e)
        {
            if (txt_expire_year.Text == "YY") {
                txt_expire_year.Text = "";
                txt_expire_year.ForeColor = Color.Black;
            }
        }

        private void txt_field_TextChanged(object sender, EventArgs e)
        {
            if (txt_credit.Text != string.Empty && txt_cvv.Text != string.Empty && (txt_expire_month.Text != string.Empty && txt_expire_month.Text != "MM") && (txt_expire_year.Text != string.Empty && txt_expire_year.Text != "YY")) {
                btn_pay.ForeColor = Color.White;
                btn_pay.BackColor = lbl_title.BackColor;
                btn_pay.Enabled = true;
            } else {
                btn_pay.ForeColor = Color.Black;
                btn_pay.BackColor = Color.Gainsboro;
                btn_pay.Enabled = false;
            }
        }

        private void txt_expire_month_GotFocus(object sender, EventArgs e)
        {
            if (txt_expire_month.Text == "MM") {
                txt_expire_month.Text = "";
                txt_expire_month.ForeColor = Color.Black;
            }
        }

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            (Owner as Frm_PaymentMethod).Show();
            Close();
        }

        private async void btn_pay_Click(object sender, EventArgs e)
        {
            string json = type == "sponsor" ? await sponsor() : await registration();
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
                    payment = "credit",
                    charity_id = charity_id,
                    event_id = event_id,
                    racekit_id = racekit_id,
                    cost = cost,
                    sponsorship = sponsorship,
                    image = ""
                }
            });
        }

        private async Task<string> sponsor()
        {
            return await Route.execute("MemberController@sponsor", new object[] {
                new {
                    runner_id = runner_id,
                    name = name,
                    sponsorship = cost
                }
            });
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (type == "event") {
                (Owner as Frm_PaymentMethod).Show();
            }
            Close();
        }
    }
}
