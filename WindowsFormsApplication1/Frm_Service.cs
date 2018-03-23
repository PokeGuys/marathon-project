using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Service : Form
    {
        private string type;
        private int id;
        private int x, y;
        private string image, path;

        public Frm_Service(string type, int id = 0)
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
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

        private async void Frm_Service_Load(object sender, EventArgs e)
        {
            lbl_title.Text = string.Format("{0} Checkpoint Service", type);
            btn_submit.Text = type;
            if (type == "Edit") {
                await getService();
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getService();
            } else {
                picPreview.Cursor = Cursors.Default;
                lbl_filename.Text = path = txt_title.Text = null;
                picPreview.Image = null;
            }
        }

        private void txtField_TextChange(object sender, EventArgs e)
        {
            if (txt_title.Text != string.Empty && (path != null || type == "Edit")) {
                btn_submit.Enabled = true;
                btn_submit.ForeColor = Color.White;
                btn_submit.BackColor = lbl_title.BackColor;
            } else {
                btn_submit.Enabled = false;
                btn_submit.BackColor = Color.Gainsboro;
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK) {
                path = dialog.FileName;
                byte[] bytes = File.ReadAllBytes(path);
                image = Convert.ToBase64String(bytes);
                lbl_filename.Text = dialog.SafeFileName;
                picPreview.Image = Image.FromFile(path);
                picPreview.Cursor = Cursors.Hand;
                if (txt_title.Text != string.Empty) {
                    btn_submit.ForeColor = Color.White;
                    btn_submit.BackColor = lbl_title.BackColor;
                    btn_submit.Enabled = true;
                }
            }
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json;
            if (type == "Edit") {
                json = await Route.execute("MapController@Update", new object[] {
                    new {
                        title = txt_title.Text,
                        image = image
                    }, id
                });
            } else {
                json = await Route.execute("MapController@Create", new object[] {
                    new {
                        title = txt_title.Text,
                        image = image
                    }
                });
            }
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(21);
                Close();
            }
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            if (path != null) {
                Process.Start(path);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task getService()
        {
            string json = await Route.execute("MapController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var item = result["data"].First();
                byte[] imageBytes = Convert.FromBase64String(item["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    picPreview.Image = Image.FromStream(ms, true);
                }
                txt_title.Text = item["title"].ToString();
                btn_submit.Enabled = true;
                btn_submit.ForeColor = Color.White;
                btn_submit.BackColor = lbl_title.BackColor;
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
