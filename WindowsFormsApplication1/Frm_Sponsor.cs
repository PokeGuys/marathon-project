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
    public partial class Frm_Sponsor : Form
    {
        public int x, y;
        public decimal cost;
        public Frm_Sponsor()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
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

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            setName();
            txt_Sponsorship.Text = string.Empty;
            runnerList.SelectedItem = null;
        }

        private void setName()
        {
            txt_Name.ReadOnly = !Auth.guest();
            txt_Name.Text = !Auth.guest() ? Auth.User().name : string.Empty;
        }

        private async void Frm_Sponsor_Load(object sender, EventArgs e)
        {
            setName();
            string json = await Route.execute("MemberController@getRunner");
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var list = result["data"].ToList();
                list.ForEach(item => {
                    runnerList.Items.Add(new ComboboxItem() {
                        Text = string.Format("id: {0} - {1}", item["id"], item["name"]),
                        Value = item["id"]
                    });
                });
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtField_TextChange(object sender, EventArgs e)
        {
            decimal.TryParse(txt_Sponsorship.Text, out cost);
            if (txt_Name.Text != string.Empty && (txt_Sponsorship.Text != string.Empty && cost > 0) && runnerList.SelectedIndex > -1) {
                btn_next.Enabled = true;
                btn_next.ForeColor = Color.White;
                btn_next.BackColor = lbl_title.BackColor;
            } else {
                btn_next.Enabled = false;
                btn_next.BackColor = Color.Gainsboro;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            int runner_id = int.Parse((runnerList.SelectedItem as ComboboxItem).Value.ToString());
            Hide();
            new frm_credit("sponsor", cost, 0, txt_Name.Text, runner_id).ShowDialog(this);
        }
    }
}
