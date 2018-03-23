using System;
using System.Drawing;
using System.Windows.Forms;
using MarathonSystem.Controllers;
using Newtonsoft.Json.Linq;
using MarathonSystem.Middlewares;

namespace MarathonSystem
{
    public partial class Frm_Login : Form
    {
        private int x, y;

        public Frm_Login()
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

        private void btn_register_Click(object sender, EventArgs e)
        {
            new frm_Register().ShowDialog();
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("MemberController@authenticate", new object[] {
                new {
                    username = txt_username.Text,
                    password = txt_password.Text
                }
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            if (success) {
                (Owner as frm_index).btn_profile.Visible = true;
                (Owner as frm_index).btn_login.Visible = false;
                (Owner as frm_index).btn_logout.Visible = true;
                (Owner as frm_index).btn_profile.Visible = true;
                (Owner as frm_index).updateLoginState();
                Close();
            }
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
        }

        private void lbl_forgetpw_Click(object sender, EventArgs e)
        {
            new Frm_Password().ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
