using MarathonSystem.Controllers;
using MarathonSystem.Helpers;
using MarathonSystem.Middlewares;
using MarathonSystem.Models;
using MarathonSystem.Transformers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Profile : Form
    {
        public int x, y;
        public Frm_Profile()
        {
            InitializeComponent();
        }

        private async void Frm_Profile_Load(object sender, EventArgs e)
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
                countryList.Items.Add(new ComboboxItem() {
                    Text = item["name"].ToString(),
                    Value = item["id"]
                });
            });
            getPersonalInfo();
        }

        private void getPersonalInfo()
        {
            var result = new MemberTransformer().transform(new List<Member> { Auth.User() });
            dynamic member = result.First();
            lbl_state.Text = string.Format("Username: {0} / {1} (id:{2})", member["username"], member["status_name"], member["id"]);
            lbl_date.Text = string.Format("Created at: {0} / Last Login: {1}", member["created_at"], member["lastlogin"]);
            txt_email.Text = member["email"];
            txt_idcard.Text = member["idcard"];
            txt_name.Text = member["name"];
            txt_phone.Text = member["phone"];
            opt_Female.Checked = member["gender"] == "F";
            opt_Male.Checked = member["gender"] == "M";
            if (member["birthday"] != null) {
                birthday.Value = member["birthday"];
            }
            var list = countryList.Items.OfType<ComboboxItem>().ToList();
            ComboboxItem selected = null;
            selected = list.Where((ComboboxItem items) => items.Value == member["country"]).FirstOrDefault();
            countryList.SelectedItem = selected;
        }

        private void Btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_currentPassword.Text = txt_password.Text = txt_password_confirmation.Text = null;
            getPersonalInfo();
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string gender = opt_Female.Checked ? "F" :
                            opt_Male.Checked ? "M" : null;
            string json = await Route.execute("MemberController@editProfile", new object[] {
                new {
                    oldpassword = txt_currentPassword.Text,
                    password = txt_password.Text,
                    password_confirmation = txt_password_confirmation.Text,
                    email = txt_email.Text,
                    name = txt_name.Text,
                    gender = gender,
                    idcard = txt_idcard.Text,
                    birthday = birthday.CustomFormat == " " ? null : birthday.Text,
                    phone = txt_phone.Text,
                    country = countryList.SelectedIndex > -1 ? (countryList.SelectedItem as ComboboxItem).Value.ToString() : null
                }
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

        private void birthday_ValueChanged(object sender, EventArgs e)
        {
            birthday.CustomFormat = "yyyy-MM-dd";
        }

        private void Lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
