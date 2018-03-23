using MarathonSystem.Helpers;
using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Marathon : Form
    {
        public decimal cost, sponsorship;
        public int racekit_id, event_id, charity_id;
        private int x, y;
        private string step = "1";
        private JToken property;

        public Frm_Marathon()
        {
            InitializeComponent();
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

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (btn_next.Text == "Submit") {
                sponsorship = getSponsorshipCost();
                cost = getTotalCost();
                Hide();
                new Frm_PaymentMethod("event", cost, sponsorship, "", 0, racekit_id, charity_id, event_id).ShowDialog(this);
            } else {
                btn_next.Enabled = false;
                btn_next.BackColor = Color.Gainsboro;
                switch (step) {
                    case "1":
                        cardContentStep1.Enabled = false;
                        cardContentStep2.Enabled = true;
                        cardStep1.Enabled = false;
                        cardStep2.Enabled = true;
                        lbl_step2_header.ForeColor = Color.DodgerBlue;
                        cardStep1.BackColor = Color.White;
                        cardStep2.BackColor = Color.Gainsboro;
                        break;
                    case "2":
                        cardContentStep2.Enabled = false;
                        cardContentStep3.Enabled = true;
                        cardStep2.Enabled = false;
                        cardStep3.Enabled = true;
                        lbl_step3_header.ForeColor = Color.DodgerBlue;
                        cardStep2.BackColor = Color.White;
                        cardStep3.BackColor = Color.Gainsboro;
                        break;
                    case "3":
                        cardStep3.Enabled = false;
                        cardContentStep3.Enabled = false;
                        cardContentStep4.Enabled = true;
                        cardStep3.BackColor = Color.White;
                        btn_next.Enabled = true;
                        btn_next.ForeColor = Color.White;
                        btn_next.BackColor = lbl_title.BackColor;
                        btn_next.Text = "Submit";
                        break;
                }
                var currentStep = Controls.OfType<Panel>().Where(c => c.Name == "cardStep" + step).First();
                currentStep.Enabled = false;
                while (cardAnimator.Location.X > -37 - (int.Parse(step) * 315)) {
                    cardAnimator.Location = new Point(cardAnimator.Location.X - 21, cardAnimator.Location.Y);
                }
                step = (int.Parse(step) + 1).ToString();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Marathon_Load(object sender, EventArgs e)
        {
            getProperty();
        }

        private async void getProperty()
        {
            string json = await Route.execute("PropertyController@getRegistration");
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            if (success) {
                property = result["data"];
                result["data"]["marathon"].ToList().ForEach(item => {
                    eventList.Items.Add(new ComboboxItem() {
                        Text = string.Format("{0} - ${1}", item["name"], item["price"]),
                        Value = item["id"].ToString()
                    });
                });
                result["data"]["racekit"].ToList().ForEach(item => {
                    racekitList.Items.Add(new ComboboxItem() {
                        Text = string.Format("{0} - ${1}", item["name"], item["price"]),
                        Value = item["id"].ToString()
                    });
                });
                result["data"]["charity"].ToList().ForEach(item => {
                    charityList.Items.Add(new ComboboxItem() {
                        Text = item["title"].ToString(),
                        Value = item["id"].ToString()
                    });
                });
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            step = "1";
            txt_sponsorship.Text = null;
            charityList.SelectedIndex = -1;
            eventList.SelectedIndex = -1;
            racekitList.SelectedIndex = -1;
            cardStep1.BackColor = Color.Gainsboro;
            cardStep2.BackColor = Color.White;
            cardStep3.BackColor = Color.White;
            cardContentStep1.Enabled = true;
            cardContentStep2.Enabled = false;
            cardContentStep3.Enabled = false;
            cardContentStep4.Enabled = false;
            cardStep1.Enabled = true;
            cardStep2.Enabled = false;
            cardStep3.Enabled = false;
            btn_next.Text = "Next";
            btn_next.Enabled = false;
            btn_next.BackColor = Color.Gainsboro;
            while (cardAnimator.Location.X < -57) {
                cardAnimator.Location = new Point(cardAnimator.Location.X + 21, cardAnimator.Location.Y);
            }
        }

        private void cardStep_MouseEnter(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) {
                card = (sender as Control).Parent as Panel;
            }
            var list = Controls.OfType<Panel>().Where(item => {
                return item.Name != "cardStep" + step;
            }).ToList();
            list.ForEach(c => {
                c.BackColor = Color.White;
            });
            card.BackColor = card.Tag.ToString() == step ? Color.LightGray : Color.WhiteSmoke;
        }

        private void cardStep_MouseLeave(object sender, EventArgs e)
        {
            var card = sender as Panel;
            if (card == null) {
                card = (sender as Control).Parent as Panel;
            }
            var list = Controls.OfType<Panel>().Where(item => {
                return item.Name != "cardStep" + step;
            }).ToList();
            list.ForEach(c => {
                c.BackColor = Color.White;
            });
            card.BackColor = card.Tag.ToString() == step ? Color.Gainsboro : Color.White;
        }

        private void itemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = new List<string> {
                "Event", "RaceKit", "Sponsorship", "TotalCost"
            };
            ComboBox list = sender as ComboBox;
            int selectedItem = list.SelectedIndex;
            var currentItem = cardContentStep4.Controls.OfType<Label>().Where(c => c.Name == "lbl_item" + step).First();
            int stepIdx = int.Parse(step) - 1;
            string method = string.Format("get{0}Cost", methodName[stepIdx]);
            MethodInfo theMethod = GetType().GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
            decimal cost = (decimal)theMethod.Invoke(this, null);

            currentItem.Text = string.Format("{0}: ${1}", methodName[stepIdx], cost);
            updateEstCost();
            if (stepIdx == 2 && getSponsorshipCost() <= 0) {
                return;
            }
            btn_next.Enabled = true;
            btn_next.ForeColor = Color.White;
            btn_next.BackColor = lbl_title.BackColor;
        }

        private void updateEstCost()
        {
            lbl_est_cost.Text = string.Format("Est. Cost: ${0}", getTotalCost());
            lbl_item4.Text = string.Format("{0}: ${1}", "TotalCost", getTotalCost());
        }

        private decimal getTotalCost()
        {
            return getEventCost() + getRaceKitCost() + getSponsorshipCost();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int selectedIdx = charityList.SelectedIndex;
            if (selectedIdx >= 0) {
                charity_id = int.Parse((charityList.SelectedItem as ComboboxItem).Value.ToString());
                new Frm_CharityInfo(charity_id).ShowDialog(this);
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal getSponsorshipCost()
        {
            decimal cost;
            int selectedIdx = charityList.SelectedIndex;
            if (selectedIdx < 0) {
                return 0;
            }
            charity_id = int.Parse((charityList.SelectedItem as ComboboxItem).Value.ToString());
            decimal.TryParse(txt_sponsorship.Text, out cost);
            return cost;
        }

        private decimal getRaceKitCost()
        {
            decimal cost;
            int selectedIdx = racekitList.SelectedIndex;
            if (selectedIdx < 0) {
                return 0;
            }
            racekit_id = int.Parse((racekitList.SelectedItem as ComboboxItem).Value.ToString());
            var racekit = property["racekit"].Where(item => (int)item["id"] == event_id).First();
            decimal.TryParse(racekit["price"].ToString(), out cost);
            return cost;
        }

        private void txt_sponsorship_TextChanged(object sender, EventArgs e)
        {
            decimal cost = getSponsorshipCost();
            if (cost > 0) {
                updateEstCost();
                lbl_item3.Text = string.Format("{0}: ${1}", "Sponsorship", cost);
                btn_next.Enabled = true;
                btn_next.ForeColor = Color.White;
                btn_next.BackColor = lbl_title.BackColor;
            } else {
                btn_next.Enabled = false;
                btn_next.BackColor = Color.Gainsboro;
            }
        }

        private decimal getEventCost()
        {
            decimal cost;
            int selectedIdx = eventList.SelectedIndex;
            if (selectedIdx < 0) {
                return 0;
            }
            event_id = int.Parse((eventList.SelectedItem as ComboboxItem).Value.ToString());
            var events = property["marathon"].Where(item => (int)item["id"] == event_id).First();
            decimal.TryParse(events["price"].ToString(), out cost);
            return cost;
        }
    }
}
