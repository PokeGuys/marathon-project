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
    public partial class Frm_Result : Form
    {
        private string name;
        private int x, y;
        private int id, finished;
        public Frm_Result(int id, string name, int finished)
        {
            InitializeComponent();
            this.id = id;
            txtRunner.Text = name;
            txt_finished.Text = finished.ToString();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("EventController@updateResult", new object[] {
                int.Parse(txt_finished.Text),
                id
            });
            var result = JObject.Parse(json);
            var success = Convert.ToBoolean(result["success"]);
            var message = result["message"].ToString();
            var title = success ? "Info" : "Error";
            var msgIcon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, title, MessageBoxButtons.OK, msgIcon);
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }
    }
}
