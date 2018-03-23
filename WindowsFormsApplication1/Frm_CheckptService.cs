using MarathonSystem.Components;
using MarathonSystem.Helpers;
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
    public partial class Frm_CheckptService : Form
    {
        private int id;
        private int x, y;
        private dynamic request;
        private bool avaliable = true;
        private int selectedIdx;

        public Frm_CheckptService(int id)
        {
            InitializeComponent();
            this.id = id;
            selectedIdx = 0;
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

        private void picMap_Click(object sender, EventArgs e)
        {
            if (avaliable) {
                string landmark = "";
                Point point = PointToClient(Cursor.Position);
                if (MessageHelper.InputBox("New CheckPoint", "Landmark name:", ref landmark) == DialogResult.OK) {
                    if (landmark != string.Empty) {
                        serviceList.SelectedItems.Clear();
                        PictureBox checkpoint = new PictureBox();
                        point.X -= 17;
                        point.Y -= 70;
                        checkpoint.Location = new Point(point.X - 36 / 2, point.Y - 36 / 2);
                        checkpoint.BackColor = Color.Transparent;
                        checkpoint.Parent = picMap;
                        checkpoint.Name = "picNewCheckpt";
                        checkpoint.Size = new Size(36, 36);
                        checkpoint.SizeMode = PictureBoxSizeMode.StretchImage;
                        checkpoint.Cursor = Cursors.Hand;
                        checkpoint.Image = Properties.Resources.checkpoint_new;
                        checkpoint.Click += (senders, events) => RemoveCheckPoint_Click(senders, events);
                        picMap.Controls.Add(checkpoint);
                        checkpoint.BringToFront();
                        avaliable = false;
                        request = new {
                            landmark = landmark,
                            x = point.X.ToString(),
                            y = point.Y.ToString()
                        };
                    } else {
                        MessageBox.Show(string.Format(Properties.strings.validation_required, "landmark"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show(Properties.strings.checkpoint_unavaliable, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            var services = new List<int>();
            foreach (var item in serviceList.SelectedItems) {
                services.Add(int.Parse((item as ComboboxItem).Value.ToString()));
            }
            string json = await Route.execute("MapController@applyCheckpoint", new object[] {
                new {
                    checkpoint = request,
                    services = services
                }, id
            });
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)result["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                avaliable = true;
                await reloadMap();
            }
        }

        private void serviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serviceList.SelectedItems.Count > 0) {
                btnApply.BackColor = lbl_title.BackColor;
                btnApply.Enabled = true;
                if (selectedIdx > 0) {
                    btnDelete.BackColor = Color.FromArgb(229, 57, 53);
                    btnDelete.Enabled = true;
                }
            } else {
                btnDelete.BackColor = Color.Gainsboro;
                btnApply.BackColor = Color.Gainsboro;
                btnDelete.Enabled = false;
                btnApply.Enabled = false;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Frm_CheckptService_Load(object sender, EventArgs e)
        {
            await reloadMap();
        }

        private async Task reloadMap()
        {
            var checkPt = picMap.Controls.OfType<PictureBox>().ToList();
            checkPt.ForEach(pt => {
                pt.Dispose();
            });
            string json = await Route.execute("MapController@mapInit", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var map = result["data"]["map"];
                var services = result["data"]["services"].ToList();
                byte[] imageBytes = Convert.FromBase64String(map.ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    picMap.Image = Image.FromStream(ms, true);
                }
                serviceList.Items.Clear();
                services.ForEach(items => {
                    serviceList.Items.Add(new ComboboxItem() {
                        Text = items["name"].ToString(),
                        Value = items["id"]
                    });
                });
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            json = await Route.execute("MapController@getCheckpoint", new object[] { id });
            result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                serviceList.SelectedItems.Clear();
                var rows = result["data"].ToList();
                rows.ForEach(items => {
                    PictureBox checkpoint = new PictureBox();
                    checkpoint.Location = new Point((int)items["X"], (int)items["Y"]);
                    checkpoint.BackColor = Color.Transparent;
                    checkpoint.Parent = picMap;
                    checkpoint.Name = "picCheckpt" + items["id"];
                    checkpoint.Size = new Size(20, 30);
                    checkpoint.SizeMode = PictureBoxSizeMode.StretchImage;
                    checkpoint.Cursor = Cursors.Hand;
                    checkpoint.Image = Properties.Resources.checkpoint;
                    checkpoint.Click += (senders, events) => ShowCheckPoint_Click(items);
                    picMap.Controls.Add(checkpoint);
                    checkpoint.BringToFront();
                });
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ShowCheckPoint_Click(JToken items)
        {
            var services = items["service"].ToList();
            selectedIdx = (int)items["id"];
            btnDelete.BackColor = Color.FromArgb(229, 57, 53);
            btnApply.BackColor = lbl_title.BackColor;
            btnDelete.Enabled = true;
            btnApply.Enabled = true;
            serviceList.SelectedItems.Clear();
            services.ForEach(item => {
                ComboboxItem selected = null;
                selected = serviceList.Items.Cast<ComboboxItem>().Where(p => p.Text == item["name"].ToString()).FirstOrDefault();
                if (selected != null) {
                    serviceList.SelectedItems.Add(selected);
                }
            });
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string json = await Route.execute("MapController@removeCheckpoint", new object[] { selectedIdx });
                JObject result = JObject.Parse(json);
                bool success = Convert.ToBoolean(result["success"]);
                string msgTitle = success ? "Info" : "Error";
                MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show((string)result["message"], msgTitle, MessageBoxButtons.OK, icon);
                if (success) {
                    selectedIdx = 0;
                    await reloadMap();
                }
            }
        }

        private void RemoveCheckPoint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                avaliable = true;
                picMap.Controls.Remove(sender as PictureBox);
            }
        }
    }
}
