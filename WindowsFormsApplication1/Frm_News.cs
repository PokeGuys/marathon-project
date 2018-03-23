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
    public partial class Frm_News : Form
    {
        private string type;
        private int id;
        private int x, y;

        public Frm_News(string type, int id = 0)
        {
            InitializeComponent();
            this.type = type;
            this.id = id;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private async void Frm_News_Load(object sender, EventArgs e)
        {
            lbl_title.Text = string.Format("{0} News", type);
            btn_submit.Text = type;
            if (type == "Edit") {
                await getNews();
            }
        }

        private async Task getNews()
        {
            string json = await Route.execute("NewsController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                JToken item = result["data"].First();
                txt_title.Text = item["title"].ToString();
                txt_message.Text = item["message"].ToString();
                btn_submit.Enabled = true;
                btn_submit.ForeColor = Color.White;
                btn_submit.BackColor = lbl_title.BackColor;
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json;
            if (type == "Edit") {
                json = await Route.execute("NewsController@Update", new object[] {
                    new {
                        title = txt_title.Text,
                        message = txt_message.Text
                    }, id
                });
            } else {
                json = await Route.execute("NewsController@Create", new object[] {
                    new {
                        title = txt_title.Text,
                        message = txt_message.Text
                    }
                });
            }
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(12);
                Close();
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getNews();
            } else {
                txt_title.Text = null;
                txt_message.Text = null;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtField_TextChange(object sender, EventArgs e)
        {
            if (txt_title.Text != string.Empty && txt_message.Text != string.Empty) {
                btn_submit.Enabled = true;
                btn_submit.ForeColor = Color.White;
                btn_submit.BackColor = lbl_title.BackColor;
            } else {
                btn_submit.Enabled = false;
                btn_submit.BackColor = Color.Gainsboro;
            }
        }
    }
}
