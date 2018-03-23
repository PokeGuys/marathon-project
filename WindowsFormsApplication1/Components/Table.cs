using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MarathonSystem.Components
{
    public partial class Table : Form
    {
        public List<JToken> items;
        private int type;
        public Table(int type, List<JToken> items)
        {
            InitializeComponent();
            this.type = type;
            this.items = items;
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (tableList.SelectedItems.Count > 0) {
                switch (type) {
                    case 11:
                        new Frm_Runner(int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 12:
                        new Frm_News("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 13:
                        new Frm_Charity("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 14:
                        new Frm_Info("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 15:
                        new Frm_Volunteer(tableList.SelectedItems[0].SubItems[1].Text, int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 16:
                        new Frm_Payment(int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 17:
                        MessageBox.Show(tableList.SelectedItems[0].SubItems[2].Text, tableList.SelectedItems[0].SubItems[1].Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 18:
                        new Frm_ManageMarathon("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 19:
                        new Frm_Banner("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 20:
                        new Frm_Racekit("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 22:
                        new Frm_Photo("Edit", int.Parse(tableList.SelectedItems[0].Text)).ShowDialog(this);
                        break;
                    case 23:
                        new Frm_Result(int.Parse(tableList.SelectedItems[0].Text), tableList.SelectedItems[0].SubItems[2].Text, int.Parse(tableList.SelectedItems[0].SubItems[6].Text)).ShowDialog(this);
                        break;
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Table_Load(object sender, EventArgs e)
        {
            initTable();
            reloadTable();
        }

        private void initTable()
        {
            tableList.BeginUpdate();
            tableList.Columns.Clear();
            tableList.Items.Clear();
            tableList.View = View.Details;
            if (items.Count() > 0) {
                JObject inner = items.First().Value<JObject>();
                var keys = inner.Properties().Select(p => p.Name).ToList();
                keys.ForEach(key => {
                    key = key.Replace('-', ' ').Replace('_', ' ');
                    string rule = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(key.ToLower()).Replace(" ", string.Empty);
                    tableList.Columns.Add(key, -2, HorizontalAlignment.Center);
                });
            }
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            tableList.EndUpdate();
        }

        public async void reloadTable()
        {
            tableList.BeginUpdate();
            tableList.Items.Clear();
            tableList.View = View.Details;
            items = await (Owner as frm_index).updateTab(type);
            if (items.Count() > 0) {
                JObject inner = items.First().Value<JObject>();
                var keys = inner.Properties().Select(p => p.Name).ToList();
                items.ForEach(item => {
                    string[] subItem = new string[keys.Count];
                    int i = 0;

                    foreach (string field in item) {
                        subItem[i++] = field;
                    }
                    ListViewItem lvi = new ListViewItem(subItem);
                    tableList.Items.Add(lvi);
                });
            }
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            tableList.EndUpdate();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (tableList.SelectedItems.Count > 0) {
                if (MessageBox.Show("Are you sure you want to delete?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    switch (type) {
                        case 11:
                            remove("MemberController@Delete");
                            break;
                        case 12:
                            remove("NewsController@Delete");
                            break;
                        case 13:
                            remove("CharityController@Delete");
                            break;
                        case 14:
                            remove("EventController@Delete");
                            break;
                        case 15:
                            remove("VolunteerController@Delete");
                            break;
                        case 16:
                            remove("PaymentController@Delete");
                            break;
                        case 17:
                            remove("FeedbackController@Delete");
                            break;
                        case 18:
                            remove("EventController@DeleteType");
                            break;
                        case 19:
                            remove("BannerController@Delete");
                            break;
                        case 20:
                            remove("RaceKitController@Delete");
                            break;
                        case 21:
                            remove("MapController@Delete");
                            break;
                        case 22:
                            remove("PhotoController@Delete");
                            break;
                    }
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void remove(string route)
        {
            string json = await Route.execute(route, new object[] {
                int.Parse(tableList.SelectedItems[0].Text)
            });
            JObject rss = JObject.Parse(json);
            bool success = Convert.ToBoolean(rss["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                reloadTable();
            }
        }

        public void updateTable(List<JToken> list)
        {
            tableList.BeginUpdate();
            tableList.Items.Clear();
            tableList.View = View.Details;
            items = list;
            if (items.Count() > 0) {
                JObject inner = items.First().Value<JObject>();
                var keys = inner.Properties().Select(p => p.Name).ToList();
                items.ForEach(item => {
                    string[] subItem = new string[keys.Count];
                    int i = 0;

                    foreach (string field in item) {
                        subItem[i++] = field;
                    }
                    ListViewItem lvi = new ListViewItem(subItem);
                    tableList.Items.Add(lvi);
                });
            }
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            tableList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            tableList.EndUpdate();
        }
    }
}
