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
    public partial class Frm_Password : Form
    {
        public int x, y;

        private void Lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        public Frm_Password()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_username.Text = txt_password.Text = txt_password_confirmeation.Text = txt_idcard.Text = null;

        }

        private async void btn_register_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("MemberController@resetPassword", new object[] {
                new {
                    username = txt_username.Text,
                    password = txt_password.Text,
                    password_confirmation = txt_password_confirmeation.Text,
                    idcard = txt_idcard.Text
                }
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                Close();
            }
        }
    }
}
