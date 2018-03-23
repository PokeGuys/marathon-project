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
    public partial class Frm_PaymentMethod : Form
    {
        public int racekit_id, charity_id, event_id, runner_id;
        public decimal cost, sponsorship;
        public string type, name;
        public int x, y;
        public Frm_PaymentMethod(string type, decimal cost, decimal sponsorship = 0, string name = "", int runner_id = 0, int racekit_id = 0, int charity_id = 0, int event_id = 0)
        {
            InitializeComponent();
            this.type = type;
            this.cost = cost;
            this.sponsorship = sponsorship;
            this.runner_id = runner_id;
            this.racekit_id = racekit_id;
            this.charity_id = charity_id;
            this.event_id = event_id;
            this.name = name;
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

        private void Frm_PaymentMethod_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            (Owner as Form).Show();
            Close();
        }

        private void btn_credit_Click(object sender, EventArgs e)
        {
            Hide();
            new frm_credit(type, cost, sponsorship, name, runner_id, racekit_id, charity_id, event_id).ShowDialog(this);
            
        }

        private void btn_bank_Click(object sender, EventArgs e)
        {
            Hide();
            new Frm_Bank(type, cost, sponsorship, name, runner_id, racekit_id, charity_id, event_id).ShowDialog(this);
        }

        private void lbl_cancel_Click(object sender, EventArgs e)
        {
            (Owner as Form).Show();
            Close();
        }
    }
}
