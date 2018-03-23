using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class Frm_Certificate : Form
    {
        private dynamic record, marathon;
        private string name;

        public Frm_Certificate(string name, dynamic record, dynamic marathon)
        {
            InitializeComponent();
            this.name = name;
            this.record = record;
            this.marathon = marathon;
            lbl_name.Text = name;
            lbl_event.Text = string.Format("Officially completed the {0} on {1}", marathon.name, marathon.created_at);
            lbl_desc.Text = string.Format("Official Finish Time: {0}\r\nPace Per KM: {1}\r\nOverall Place: {2} of {3}", record.finished_at, record.ppm, record.current, record.total);
            byte[] imageBytes = Convert.FromBase64String(marathon.logo.ToString());
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                picLogo.Image = Image.FromStream(ms, true);
            }
            imageBytes = Convert.FromBase64String(marathon.seal.ToString());
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                picSeal.Image = Image.FromStream(ms, true);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            btn_download.Visible = false;
            string fn = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "cert" + name + "_race" + marathon.name + ".png");
            Bitmap bmp = new Bitmap(Width, Height);
            DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save(fn, ImageFormat.Png);
            MessageBox.Show("Download Completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_download.Visible = true;
        }
    }
}
