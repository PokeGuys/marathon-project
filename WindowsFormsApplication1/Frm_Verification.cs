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
    public partial class Frm_Verification : Form
    {
        public int x, y;
        public Frm_Verification()
        {
            InitializeComponent();
        }

        private void Lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_token.Text = null;
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("VerificationController@verification", new object[] {
                new {
                    token = txt_token.Text
                }
            });
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)result["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                Close();
                (Owner as frm_index).updateLoginState();
            }
        }

        private async void lbl_resend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to resend the verification code?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("VerificationController@resend");
                JObject result = JObject.Parse(json);
                bool success = Convert.ToBoolean(result["success"]);
                string msgTitle = success ? "Info" : "Error";
                MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show((string)result["message"], msgTitle, MessageBoxButtons.OK, icon);
            }
        }

        private void Lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
