using MarathonSystem.Controllers;
using MarathonSystem.Helpers;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class frm_Register : Form
    {
        public int x, y;
        public frm_Register()
        {
            InitializeComponent();
            if (!Auth.guest()) {
                if (Auth.isStaff()) {
                    updateStatusList();
                    grpAdmin.Visible = true;
                    grpType.Visible = false;
                }
            }
        }

        private async void updateStatusList()
        {
            string json = await Route.execute("PropertyController@getStatus");
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            if (success) {
                var list = result["data"].ToList();
                list.ForEach(item => {
                    statusList.Items.Add(new ComboboxItem() {
                        Text = item["name"].ToString(),
                        Value = (int)item["id"]
                    });
                });
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chk_extra_CheckedChanged(object sender, EventArgs e)
        {
            requiredFieldCheck();
            if (chk_extra.Checked) {
                while(Height < 500) {
                    Height += 46;
                    chk_extra.Location = new Point(chk_extra.Location.X, chk_extra.Location.Y + 46);
                    btn_register.Location = new Point(btn_register.Location.X, btn_register.Location.Y + 46);
                    btn_Cancel.Location = new Point(btn_Cancel.Location.X, btn_Cancel.Location.Y + 46);
                    Thread.Sleep(7);
                }
                grpExtra.Visible = true;
            } else {
                while (Height > 380) {
                    Height -= 46;
                    chk_extra.Location = new Point(chk_extra.Location.X, chk_extra.Location.Y - 46);
                    btn_register.Location = new Point(btn_register.Location.X, btn_register.Location.Y - 46);
                    btn_Cancel.Location = new Point(btn_Cancel.Location.X, btn_Cancel.Location.Y - 46);
                    Thread.Sleep(7);
                }
                grpExtra.Visible = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_register_Click(object sender, EventArgs e)
        {
            var stateRadio = grpType.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            int status = 0;
            if (Auth.guest()) {
                status = int.Parse((string)stateRadio.Tag);
            } else if (Auth.User().state >= 4) {
                status = (int)(statusList.SelectedItem as ComboboxItem).Value;
            }
            string json = await Route.execute("MemberController@registration", new object[] {
                new {
                    state = status,
                    username = txt_username.Text,
                    password = txt_password.Text,
                    password_confirmation = txt_password_confirmation.Text,
                    email = txt_email.Text,
                    name = txt_name.Text,
                    idcard = txt_idcard.Text,
                    gender = radio_F.Checked ? "F" :
                            (radio_M.Checked ? "M" : null),
                    birthday = birthdayPicker.CustomFormat.Trim() == string.Empty ? null : birthdayPicker.Text,
                    phone = txt_Phone.Text,
                    country = combo_country.SelectedIndex > -1 ? (combo_country.SelectedItem as ComboboxItem).Value : null
                }
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                if (Auth.isStaff()) {
                    (Owner as frm_index).reloadTable(11);
                }
                Close();
            }
        }

        public void requiredFieldCheck(object sender = null, EventArgs e = null)
        {
            int gender = grpExtra.Controls.OfType<RadioButton>().Where(n => n.Checked).Count();
            int availableBasicTxtbox = grpBasic.Controls.OfType<TextBox>().Where(n => !string.IsNullOrWhiteSpace(n.Text)).Count();
            int availableExtraTxtbox = grpExtra.Controls.OfType<TextBox>().Where(n => !string.IsNullOrWhiteSpace(n.Text)).Count();
            if (availableBasicTxtbox != 6 || (chk_extra.Checked && (availableExtraTxtbox != 1 || gender == 0 || string.IsNullOrWhiteSpace(combo_country.Text)))) {
                disableRegistration();
            } else {
                enableRegistration();
            }
        }

        public void disableRegistration()
        {
            btn_register.BackColor = Color.FromArgb(224, 224, 224);
            btn_register.ForeColor = Color.DimGray;
            btn_register.Enabled = false;
        }

        private void birthdayPicker_ValueChanged(object sender, EventArgs e)
        {
            birthdayPicker.CustomFormat = "yyyy-MM-dd";
        }

        private async void frm_Register_Load(object sender, EventArgs e)
        {
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
                combo_country.Items.Add(new ComboboxItem() {
                    Text = item["name"].ToString(),
                    Value = item["id"].ToString()
                });
            });
        }

        private void grpBasic_Paint(object sender, PaintEventArgs e)
        {

        }

        public void enableRegistration()
        {
            btn_register.BackColor = Color.FromArgb(2, 136, 209);
            btn_register.ForeColor = Color.White;
            btn_register.Enabled = true;
        }
    }
}
