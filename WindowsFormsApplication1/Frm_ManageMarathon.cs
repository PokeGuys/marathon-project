using MarathonSystem.Controllers;
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
    public partial class Frm_ManageMarathon : Form
    {
        private string type;
        private int id;
        private int x, y;
        private string mapBase64;
        private string logoBase64;
        private string sealBase64;

        public Frm_ManageMarathon(string type, int id = 0)
        {
            InitializeComponent();
            this.type = type;
            this.id = id;
            btn_submit.Text = type;
            updateCountry();
        }

        private async void updateCountry()
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
                    Value = item["id"].ToString()
                });
            });
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

        private async void Frm_ManageMarathon_Load(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getMarathon();
            }
        }

        private async Task getMarathon()
        {
            string json = await Route.execute("MarathonController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var row = result["data"].First();
                txt_city.Text = row["city"].ToString();
                txt_logo.Text = row["logo"].ToString();
                txt_map.Text = row["map"].ToString();
                txt_name.Text = row["name"].ToString();
                txt_seal.Text = row["seal"].ToString();
                date_holdat.Value = new DateTime(row["hold_at"].ToObject<int>(), 1, 1);

                var list = countryList.Items.OfType<ComboboxItem>().ToList();
                ComboboxItem selected = null;
                selected = list.Where((ComboboxItem items) => items.Value.Equals(row["country_id"].ToString())).FirstOrDefault();
                countryList.SelectedItem = selected;
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            if (type == "Edit") {
                await getMarathon();
            } else {
                txt_city.Text = txt_logo.Text = txt_map.Text = txt_name.Text = txt_seal.Text = null;
                countryList.SelectedItem = null;
            }
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            string json;
            if (type == "Edit") {
                json = await Route.execute("MarathonController@Update", new object[] {
                    new {
                        name = txt_name.Text,
                        city = txt_city.Text,
                        hold_at = int.Parse(date_holdat.Text),
                        country = (countryList.SelectedItem as ComboboxItem).Value,
                        logo = logoBase64,
                        map = mapBase64,
                        seal = sealBase64
                    }, id
                });
            } else {
                json = await Route.execute("MarathonController@Create", new object[] {
                    new {
                        name = txt_name.Text,
                        city = txt_city.Text,
                        hold_at = int.Parse(date_holdat.Text),
                        country = (countryList.SelectedItem as ComboboxItem).Value,
                        logo = logoBase64,
                        map = mapBase64,
                        seal = sealBase64
                    }
                });
            }
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                (Owner as frm_index).reloadTable(18);
                Close();
            }
        }

        private void btn_upload_map_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK) {
                byte[] bytes = File.ReadAllBytes(dialog.FileName);
                txt_map.Text = dialog.SafeFileName;
                mapBase64 = Convert.ToBase64String(bytes);
                if (txt_city.Text != string.Empty && logoBase64 != string.Empty && mapBase64 != string.Empty && txt_name.Text != string.Empty && sealBase64 != string.Empty && countryList.SelectedIndex > -1) {
                    btn_submit.ForeColor = Color.White;
                    btn_submit.BackColor = lbl_title.BackColor;
                    btn_submit.Enabled = true;
                }
            }
        }

        private void btn_upload_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK) {
                byte[] bytes = File.ReadAllBytes(dialog.FileName);
                txt_logo.Text = dialog.SafeFileName;
                logoBase64 = Convert.ToBase64String(bytes);
                if (txt_city.Text != string.Empty && logoBase64 != string.Empty && mapBase64 != string.Empty && txt_name.Text != string.Empty && sealBase64 != string.Empty && countryList.SelectedIndex > -1) {
                    btn_submit.ForeColor = Color.White;
                    btn_submit.BackColor = lbl_title.BackColor;
                    btn_submit.Enabled = true;
                }
            }
        }

        private void btn_upload_seal_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK) {
                byte[] bytes = File.ReadAllBytes(dialog.FileName);
                txt_seal.Text = dialog.SafeFileName;
                sealBase64 = Convert.ToBase64String(bytes);
                if (txt_city.Text != string.Empty && logoBase64 != string.Empty && mapBase64 != string.Empty && txt_name.Text != string.Empty && sealBase64 != string.Empty && countryList.SelectedIndex > -1) {
                    btn_submit.ForeColor = Color.White;
                    btn_submit.BackColor = lbl_title.BackColor;
                    btn_submit.Enabled = true;
                }
            }
        }

        private void countryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_city.Text != string.Empty && txt_logo.Text != string.Empty && txt_map.Text != string.Empty && txt_name.Text != string.Empty && txt_seal.Text != string.Empty && countryList.SelectedIndex > -1) {
                btn_submit.ForeColor = Color.White;
                btn_submit.BackColor = lbl_title.BackColor;
                btn_submit.Enabled = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
