using MarathonSystem.Helpers;
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
    public partial class Frm_EventResult : Form
    {
        private int x, y;
        private int id;
        private List<JToken> items;

        public Frm_EventResult(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Frm_EventResult_Load(object sender, EventArgs e)
        {
            string json = await Route.execute("EventController@getResult", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                items = result["data"].ToList();
                var rows = items.Take(5).ToList();
                int i = 0;
                rows.ForEach(item => {
                    var rowResult = new Panel() {
                        Name = "rowRecord" + i,
                        Cursor = Cursors.Hand,
                        Location = new Point(0, 23 + 29 * i),
                        Size = new Size(406, 30),
                        Parent = cardTable,
                    };
                    rowResult.MouseEnter += (senders, events) => rowResult_MoveEnter(senders, events);
                    rowResult.MouseLeave += (senders, events) => rowResult_MouseLeave(senders, events);
                    rowResult.Click += (senders, events) => rowResult_Click(senders, events, (int)item["bib_id"]);
                    cardTable.Controls.Add(rowResult);

                    var rowID = new Label() {
                        Name = "lbl_id_record" + i,
                        Location = new Point(3, 9),
                        Parent = rowResult,
                        Cursor = Cursors.Hand,
                        Text = item["bib_id"].ToString()
                    };
                    var rowName = new Label() {
                        Name = "lbl_name_record" + i,
                        Location = new Point(114, 9),
                        Parent = rowResult,
                        Cursor = Cursors.Hand,
                        Text = item["name"].ToString()
                    };
                    var rowTime = new Label() {
                        Name = "lbl_time_record" + i,
                        Location = new Point(301, 9),
                        Parent = rowResult,
                        Cursor = Cursors.Hand,
                        Text = item["finished_time"].ToString()
                    };

                    rowID.MouseEnter += (senders, events) => rowResult_MoveEnter(senders, events);
                    rowID.MouseLeave += (senders, events) => rowResult_MouseLeave(senders, events);
                    rowID.Click += (senders, events) => rowResult_Click(senders, events, (int)item["bib_id"]);

                    rowName.MouseEnter += (senders, events) => rowResult_MoveEnter(senders, events);
                    rowName.MouseLeave += (senders, events) => rowResult_MouseLeave(senders, events);
                    rowName.Click += (senders, events) => rowResult_Click(senders, events, (int)item["bib_id"]);

                    rowTime.MouseEnter += (senders, events) => rowResult_MoveEnter(senders, events);
                    rowTime.MouseLeave += (senders, events) => rowResult_MouseLeave(senders, events);
                    rowTime.Click += (senders, events) => rowResult_Click(senders, events, (int)item["bib_id"]);
                    rowResult.Controls.Add(rowID);
                    rowResult.Controls.Add(rowName);
                    rowResult.Controls.Add(rowTime);
                    i++;
                });

                json = await Route.execute("EventController@Details", new object[] { id });
                result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"])) {
                    var row = result["data"].First();
                    lbl_eventHeader.Text = string.Format("{0}", row["name"]);
                    cardEventHeader.Text = string.Format("{0}", row["name"]);
                } else {
                    MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                json = await Route.execute("EventController@getMarathon", new object[] { id });
                result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"])) {
                    lblStartat.Text = string.Format("Running @ {0}, {1}, {2}", result["data"]["country"], result["data"]["city"], result["data"]["hold_at"]);
                    lblEvent.Text = string.Format("{0}", result["data"]["name"]);
                } else {
                    MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

                if (rows.Count == 0) {
                    lbl_message.Text = "There is no record here.";
                } else {
                    lbl_message.Visible = false;
                }
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void rowResult_Click(object senders, EventArgs events, int bib_id)
        {
            new Frm_RaceBib(bib_id, id).ShowDialog(Owner);
        }

        private void rowResult_MouseLeave(object senders, EventArgs events)
        {
            if (senders is Label) {
                (senders as Label).Parent.BackColor = Color.White;
            } else {
                (senders as Panel).BackColor = Color.White;
            }
        }

        private void rowResult_MoveEnter(object senders, EventArgs events)
        {
            if (senders is Label) {
                (senders as Label).Parent.BackColor = Color.FromArgb(229, 229, 229);
            } else {
                (senders as Panel).BackColor = Color.FromArgb(229, 229, 229);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty) {
                cardResultList.Visible = true;
                cardEvent.Visible = false;
                updateList();
            } else {
                MessageBox.Show(Properties.strings.validation_allrequired, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateList()
        {
            if (items != null) {
                resultList.BeginUpdate();
                resultList.Columns.Clear();
                resultList.Items.Clear();
                resultList.View = View.Details;
                if (items.Count() > 0) {
                    resultList.Columns.Add("BIB", -2, HorizontalAlignment.Center);
                    resultList.Columns.Add("NAME", -2, HorizontalAlignment.Center);
                    resultList.Columns.Add("CONUTRY", -2, HorizontalAlignment.Center);
                    resultList.Columns.Add("GUN TIME", -2, HorizontalAlignment.Center);
                    var rows = items.Where(p => p["bib_id"].ToString().Contains(txtSearch.Text) || p["name"].ToString().Contains(txtSearch.Text) || txtSearch.Text == string.Empty).ToList();
                    rows.Select(p => new {
                        name = p["name"].ToString(),
                        bib = p["bib_id"].ToString(),
                        country = p["country"].ToString(),
                        gun_tim = p["finished_time"].ToString()
                    }).ToList().ForEach(item => {
                        string[] subItem = new string[] {
                            item.bib,
                            item.name,
                            item.country,
                            item.gun_tim
                        };
                        ListViewItem lvi = new ListViewItem(subItem);
                        resultList.Items.Add(lvi);
                    });
                }
                resultList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                resultList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                resultList.EndUpdate();
            } else {
                MessageBox.Show("Unexpected error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cardResultList.Visible = false;
            cardEvent.Visible = true;
            updateList();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count > 0) {
                rowResult_Click(sender, e, int.Parse(resultList.SelectedItems[0].Text));
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_viewAll_Click(object sender, EventArgs e)
        {
            cardResultList.Visible = true;
            cardEvent.Visible = false;
            updateList();
        }

        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
