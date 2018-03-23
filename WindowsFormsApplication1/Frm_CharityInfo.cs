using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_CharityInfo : Form
    {
        private int id;
        private int x, y;
        public Frm_CharityInfo(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void Frm_CharityInfo_Load(object sender, EventArgs e)
        {
            string json = await Route.execute("CharityController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var item = result["data"].First();
                byte[] imageBytes = Convert.FromBase64String(item["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    picLogo.Image = Image.FromStream(ms, true);
                }
                lbl_name.Text = item["title"].ToString();
                lbl_description.Text = item["description"].ToString();
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
