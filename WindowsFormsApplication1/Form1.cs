using MarathonSystem.Components;
using MarathonSystem.Controllers;
using MarathonSystem.Helpers;
using MarathonSystem.Middlewares;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSystem
{
    public partial class frm_index : Form
    {
        public int currentIdx = 0;
        private int x, y;
        private int targeTimestamp = -1;
        private int currentPage = 1, totalPage = 1, bannerIdx = 0;
        public List<JToken> NewsRows = new List<JToken>();
        private List<JToken> bannerRows = new List<JToken>();

        public frm_index()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void Category_Click(object sender, EventArgs e)
        {
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab.SelectedIndex = selectedItem;
            lbl_title.Text = myControl.Text;
            if (selectedItem < 11) {
                clearNavItemForeColor();
                myControl.ForeColor = Color.FromArgb(3, 155, 229);
            }
            dashboardDropdown.Visible = false;
        }

        private void DashboardMain_Click(object sender, EventArgs e)
        {
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab.SelectedIndex = selectedItem;
            lbl_title.Text = "Dashboard";
        }

        private void FAQQuestion_Click(object sender, EventArgs e)
        {
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab_faq_index.SelectedIndex = selectedItem;
        }

        public void clearNavItemForeColor()
        {
            List<Button> Md_child = navBar.Controls.OfType<Button>().ToList();
            foreach (Button btn in Md_child) {
                btn.ForeColor = Color.FromArgb(117, 117, 117);
            }
        }

        public void reloadTable(int v)
        {
            currentIdx = 0;
            tab.SelectedIndex = 0;
            currentIdx = v;
            tab.SelectedIndex = v;
        }

        private void NavItem_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.LightGray;
        }


        private void NavItem_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }

        private void Pic_home_Click(object sender, EventArgs e)
        {
            lbl_title.Text = "Home";
            clearNavItemForeColor();
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab.SelectedIndex = selectedItem;
        }

        private async void tabIndex_Enter(object sender, EventArgs e)
        {
            await getNewsRows();
            renderNewsRows(5);
            timerBanner.Enabled = true;
        }

        private async void timer_countdown_Tick(object sender, EventArgs e)
        {
            if (targeTimestamp < 0) {
                string json = await Route.execute("EventController@getTimestamp");
                JObject result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"])) {
                    targeTimestamp = result["data"]["timestamp"].ToObject<int>();
                } else {
                    MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            DateTime gtm = new DateTime(1970, 1, 1);
            DateTime utc = DateTime.UtcNow;
            int currentTimestamp = Convert.ToInt32((utc.Subtract(gtm)).TotalSeconds);
            TimeSpan s = TimeSpan.FromSeconds(targeTimestamp - currentTimestamp);
            string format = "{0} days {1} hours and {2} minutes{3}until the race start";
            lbl_countdown.Text = string.Format(format, s.Days, s.Hours, s.Minutes, Environment.NewLine);
            if (!Auth.guest()) {
                // Authenticated
                if (currentTimestamp - Auth.User().lastlogin > 15 * 60) {
                    updateLogoutState();
                    Auth.logout();
                }
            }
        }

        public void updateLoginState()
        {
            currentIdx = 0;
            tab.SelectedIndex = 0;
            clearStateButton();
            switch (Auth.User().state) {
                case 1:
                    btn_register_event.Visible = true;
                    break;
                case 2:
                    btn_volunteer.Visible = true;
                    break;
                case 3:
                    btn_result.Visible = true;
                    break;
                case 4:
                case 5:
                case 99:
                    btn_dashboard.Visible = true;
                    break;
                default:
                    btn_verification.Visible = true;
                    break;
            }
        }

        private void clearStateButton()
        {
            clearNavItemForeColor();
            currentIdx = 0;
            tab.SelectedIndex = currentIdx;
            btn_register_event.Visible = false;
            btn_volunteer.Visible = false;
            btn_result.Visible = false;
            btn_dashboard.Visible = false;
            btn_verification.Visible = false;
        }

        public void updateLogoutState()
        {
            switch (Auth.User().state) {
                case 1:
                    btn_register_event.Visible = false;
                    break;
                case 2:
                    btn_volunteer.Visible = false;
                    break;
                case 3:
                    btn_result.Visible = false;
                    break;
                case 4:
                case 5:
                case 99:
                    btn_dashboard.Visible = false;
                    break;
                default:
                    btn_verification.Visible = false;
                    break;
            }
            btn_login.Visible = true;

            btn_profile.Visible = false;
            btn_profile.Visible = false;
            btn_logout.Visible = false;
            currentIdx = 0;
            tab.SelectedIndex = 0;
        }

        private void btn_feedback_reset_Click(object sender, EventArgs e)
        {
            txt_feedback_message.Text = string.Empty;
            txt_feedback_name.Text = string.Empty;
        }

        private async void tabNews_Enter(object sender, EventArgs e)
        {
            await getNewsRows();
            renderNewsRows();
        }

        private void renderNewsRows(int limit = 15)
        {
            var rows = NewsRows.OrderByDescending(item => item["id"]).Skip(limit == 5 ? 0 : (currentPage - 1) * limit).Take(limit).ToList();
            if (rows.Count() == 0) {
                lbl_news_message.Text = lbl_hotnews_message.Text = "There is no news here.";
            } else {
                lbl_news_message.Visible = false;
                lbl_hotnews_message.Visible = false;
            }
            int i = 0;
            rows.ForEach(item => {
                var size = limit == 5 ? new Size(415, 19) : new Size(331, 19);
                var point = new List<Point> {
                    limit == 5 ? new Point(4, 7 + i * 30) : new Point(59, 29 + i * 21),
                    limit == 5 ? new Point(424, 7 + i * 30) : new Point(387, 29 + i * 21),
                };
                var parent = limit == 5 ? cardHotNews : cardNewsRows;
                string prefix = limit == 5 ? "lbl_hotnews_title_" : "lbl_news_title_";
                Label title = new Label();
                title.Cursor = Cursors.Hand;
                title.Location = point[0];
                title.Parent = parent;
                title.ForeColor = Color.DodgerBlue;
                title.Name = prefix + (string)item["id"];
                title.Text = (string)item["title"];
                title.Size = size;
                title.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                title.Click += (sender, e) => newsTitle_Click(sender, e, (int)item["id"]);

                Label date = new Label();
                date.Location = point[1];
                date.Parent = parent;
                date.Name = prefix + (string)item["id"];
                date.Text = (string)item["created_at"];
                date.Anchor = AnchorStyles.Right;
                date.AutoSize = true;

                parent.Controls.Add(title);
                parent.Controls.Add(date);
                if (limit == 15) {
                    Label id = new Label();
                    id.Location = new Point(10, 29 + i * 21);
                    id.Parent = parent;
                    id.Name = prefix + (string)item["id"];
                    id.Text = (string)item["id"];
                    id.AutoSize = true;
                    parent.Controls.Add(id);
                }
                i++;
            });
        }

        private async void eventTitle_Click(object sender, EventArgs e, int id)
        {
            string json = await Route.execute("EventController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var Details = result["data"].First();
                btnResult.Tag = Details["id"];
                lbl_event_name.Text = (string)Details["name"];
                txt_event_details.Text = string.Format("Disatnace: {0}\r\nStart Time: {1}\r\nRegistration Period: {2} - {3}\r\nQuota: {4}\r\nPrice: ${5}", Details["Event"]["distance"], Details["start_datetime"], Details["start_at"], Details["end_at"], Details["quota"], Details["price"]);
                currentIdx = 8;
                tab.SelectedIndex = 8;
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void newsTitle_Click(object sender, EventArgs e, int id)
        {
            string json = await Route.execute("NewsController@Details", new object[] { id });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var Details = result["data"].First();
                lbl_newsdetail_message.Visible = false;
                lbl_newsdetail_title.Text = (string)Details["title"];
                newsdetail_content.Text = (string)Details["message"];
                lbl_newsdetail_date.Text = (string)Details["created_at"];
                currentIdx = 7;
                tab.SelectedIndex = 7;
                lbl_title.Text = "News";
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Frm_index_Load(object sender, EventArgs e)
        {
            await getNewsRows();
            renderNewsRows(5);
            JToken result = await fetchAPI("PropertyController@getBanner");
            if (result != null) {
                bannerRows = result.ToList();
            } else {
                MessageBox.Show(Properties.strings.service_unavailable, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            result = await fetchAPI("PropertyController@getCountry");
            if (result != null) {
                PropertyController.country = result.ToList();
            } else {
                MessageBox.Show(Properties.strings.service_unavailable, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btn_feedback_submit_Click(object sender, EventArgs e)
        {
            string json = await Route.execute("FeedbackController@Create", new object[] {
                new {
                    name = txt_feedback_name.Text,
                    feedback = txt_feedback_message.Text
                }
            });
            JObject result = JObject.Parse(json);
            bool success = Convert.ToBoolean(result["success"]);
            string msgTitle = success ? "Info" : "Error";
            MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show((string)result["message"], msgTitle, MessageBoxButtons.OK, icon);
            if (success) {
                txt_feedback_message.Text = string.Empty;
                txt_feedback_name.Text = string.Empty;
            }
        }

        private void btn_news_prev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) {
                currentPage--;
                lbl_news_currentpage.Text = currentPage.ToString();
                clearNewsRows();
                renderNewsRows();
            }
        }

        private void btn_news_next_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage) {
                currentPage++;
                lbl_news_currentpage.Text = currentPage.ToString();
                clearNewsRows();
                renderNewsRows();
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            new Frm_Profile().ShowDialog(this);
        }

        private void btn_volunteer_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_event_Click(object sender, EventArgs e)
        {
            var member = Auth.User();
            if (member.country != null && member.gender != null) {
                new Frm_Marathon().ShowDialog(this);
            } else {
                MessageBox.Show("Please enter the country field and gender before you register an event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Frm_Profile().ShowDialog(this);
            }
        }

        private void FAQ_Back_Click(object sender, EventArgs e)
        {

        }

        private void trackHeight_Scroll(object sender, EventArgs e)
        {
            lbl_trackHeight.Text = trackHeight.Value.ToString() + " cm";
        }

        private void trackWeight_Scroll(object sender, EventArgs e)
        {
            lbl_trackWeight.Text = trackWeight.Value.ToString() + " kg";
        }

        private void trackAge_Scroll(object sender, EventArgs e)
        {
            lbl_trackAge.Text = trackAge.Value.ToString();
        }

        private void ShowCheckPoint_Click(JToken rows)
        {
            cardMapInfo.Visible = true;
            lblMapChkPt.Text = "CheckPoint " + rows["id"];
            lbl_Landmark.Text = rows["landmark"].ToString();
            var services = cardService.Controls.OfType<Control>().ToList();
            services.ForEach(pt => {
                pt.Dispose();
            });
            int i = 1;
            rows["service"].ToList().ForEach(item => {
                PictureBox servicePic = new PictureBox() {
                    BackColor = Color.Transparent,
                    Parent = cardService,
                    Name = "picService" + i,
                    Size = new Size(32, 32),
                    Location = new Point(12, 8 + 39 * (i - 1)),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                byte[] imageBytes = Convert.FromBase64String(item["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    servicePic.Image = Image.FromStream(ms, true);
                }

                Label serviceLbl = new Label() {
                    Name = "lblService" + i,
                    Parent = cardService,
                    AutoSize = true,
                    Text = item["name"].ToString(),
                    Location = new Point(50, 16 + 39 * (i - 1)),
                };

                cardService.Controls.Add(servicePic);
                cardService.Controls.Add(serviceLbl);
                i++;
            });
        }

        private void Login_Click(object sender, EventArgs e)
        {
            new Frm_Login().ShowDialog(this);
        }

        private void Speed_Click(object sender, EventArgs e)
        {
            string speedDesc = string.Format("speed{0}", (sender as Control).Tag.ToString());
            picSpeedLarge.Image = (sender as PictureBox).Image;
            lbl_SpeedDesc.Text = Properties.Resources.ResourceManager.GetObject(speedDesc).ToString();
        }

        private void lbl_returnRows_Click(object sender, EventArgs e)
        {
            currentIdx = 1;
            tab.SelectedIndex = 1;
        }

        private async void tabMap_FAQ_Enter(object sender, EventArgs e)
        {
            List<PictureBox> checkPt = picMap.Controls.OfType<PictureBox>().ToList();
            checkPt.ForEach(pt => {
                pt.Dispose();
            });
            cardMapInfo.Visible = false;
            string json = await Route.execute("EventController@getMap");
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                if (result["data"].Count() > 0) {
                    lbl_map_message.Visible = false;
                    int i = 0;
                    var rows = result["data"].First();
                    byte[] imageBytes = Convert.FromBase64String(rows["map"].ToString());
                    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                        picMap.Image = Image.FromStream(ms, true);
                    }
                    foreach (var item in rows["checkpoints"]) {
                        PictureBox checkpoint = new PictureBox();
                        checkpoint.Location = new Point((int)item["X"], (int)item["Y"]);
                        checkpoint.BackColor = Color.Transparent;
                        checkpoint.Parent = picMap;
                        checkpoint.Name = "picCheckpt" + i;
                        checkpoint.Size = new Size(20, 30);
                        checkpoint.SizeMode = PictureBoxSizeMode.StretchImage;
                        checkpoint.Cursor = Cursors.Hand;
                        checkpoint.Image = Properties.Resources.checkpoint;
                        checkpoint.Click += (senders, events) => ShowCheckPoint_Click(item);
                        picMap.Controls.Add(checkpoint);
                        checkpoint.BringToFront();
                        i++;
                    }
                } else {
                    lbl_map_message.Visible = true;
                }
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseCard_Click(object sender, EventArgs e)
        {
            cardMapInfo.Visible = false;
        }

        private void btn_verification_Click(object sender, EventArgs e)
        {
            new Frm_Verification().ShowDialog(this);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                updateLogoutState();
                Auth.logout();
            }
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            if (calcCategory.SelectedIndex > -1 && (opt_calc_male.Checked || opt_calc_female.Checked) && trackHeight.Value > 0 && trackAge.Value > 0 && trackWeight.Value > 0) {
                if (calcCategory.SelectedItem.ToString() == "BMI") {
                    double BMI = (trackWeight.Value / ((trackHeight.Value / 100.0) * (trackHeight.Value / 100.0)));
                    string state = "obese";
                    if (BMI < 18.5) {
                        state = "underweight";
                    } else if (BMI >= 18.5 && BMI <= 24.9) {
                        state = "normal";
                    } else if (BMI >= 25 && BMI <= 29.9) {
                        state = "overweight";
                    }
                    MessageBox.Show(string.Format("Your BMI is {0}\r\nYou are {1}.", BMI, state), "Info", MessageBoxButtons.OK, BMI >= 18.5 && BMI <= 24.9 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation);
                } else {
                    double BMR = opt_calc_male.Checked ?
                        13.7 * trackWeight.Value + (5 * trackHeight.Value) - (6.8 * trackAge.Value) + 66 :
                        9.6 * trackWeight.Value + (1.8 * trackHeight.Value) - (4.5 * trackAge.Value) + 655;
                    MessageBox.Show(string.Format("Your BMR is {0} kcal/day", BMR), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != currentIdx) {
                e.Cancel = true;
            } else {
                if (e.TabPageIndex > 10) {
                    var list = await updateTab(e.TabPageIndex);
                    if (list != null) {
                        var tabPage = tab.Controls.OfType<TabPage>().Where(c => c.Name.Equals(string.Format("tabDashboard{0}", e.TabPageIndex - 10))).First();
                        var tables = tabPage.Controls.OfType<Panel>().First().Controls.OfType<Panel>().Where(p => p.Name.Equals(string.Format("tableDashboard_item{0}", e.TabPageIndex - 10))).First();
                        if (tables.Controls.Count > 0) {
                            for (int i = 0; i < tables.Controls.Count; i++) {
                                tables.Controls.RemoveAt(i);
                            }
                        }
                        Table table = new Table(e.TabPageIndex, list);
                        table.Owner = this;
                        table.TopLevel = false;
                        tables.Controls.Add(table);
                        table.Show();
                    } else {
                        currentIdx = 6;
                        tab.SelectedIndex = 6;
                    }
                }
            }
        }

        public async Task<List<JToken>> updateTab(int idx)
        {
            string route = "";
            switch (idx) {
                case 11:
                    route = "MemberController@Rows";
                    break;
                case 12:
                    route = "NewsController@Rows";
                    break;
                case 13:
                    route = "CharityController@Rows";
                    break;
                case 14:
                    route = "EventController@dashboardRows";
                    break;
                case 15:
                    // Volunteer
                    route = "VolunteerController@Rows";
                    break;
                case 16:
                    route = "PaymentController@Rows";
                    break;
                case 17:
                    route = "FeedbackController@Rows";
                    break;
                case 18:
                    route = "MarathonController@Rows";
                    break;
                case 19:
                    // Banner
                    route = "BannerController@Rows";
                    break;
                case 20:
                    // Racekit
                    route = "RaceKitController@Rows";
                    break;
                case 21:
                    // Map
                    route = "MapController@Rows";
                    break;
                case 22:
                    // Racekit
                    route = "PhotoController@dashboardRows";
                    break;
                case 23:
                    // Racekit
                    route = "EventController@getJoinedRows";
                    break;
            }
            JToken list = await fetchAPI(route);
            return list.ToList();
        }

        private async Task<JToken> fetchAPI(string route, object[] param = null)
        {
            string json = await Route.execute(route, param);
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                return result["data"];
            } else {
                MessageBox.Show((string)result["message"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btn_aboutBMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BMI Categories:\r\nUnderweight = <18.5\r\nNormal weight = 18.5–24.9\r\nOverweight = 25–29.9\r\nObesity = BMI of 30 or greater", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picCreateAccount_Click(object sender, EventArgs e)
        {
            new frm_Register().ShowDialog(this);
        }

        private void Sponsorship_Click(object sender, EventArgs e)
        {
            new Frm_Sponsor().ShowDialog(this);
        }

        private async void tabPhoto_Enter(object sender, EventArgs e)
        {
            JToken list = await fetchAPI("PhotoController@Rows");
            var rows = list.ToList();
            List<Control> scrollbar = photoSubbar.Controls.OfType<Control>().ToList();
            scrollbar.ForEach(c => {
                c.Dispose();
            });
            int i = 0;
            rows.ForEach(item => {
                PictureBox photo = new PictureBox();
                photo.Cursor = Cursors.Hand;
                photo.Location = new Point(0, i * 114);
                photo.Parent = photoSubbar;
                photo.Name = "pic_event_photo" + i;
                photo.Size = new Size(160, 97);
                photo.Tag = item["id"].ToObject<int>();
                photo.SizeMode = PictureBoxSizeMode.Zoom;
                photo.Click += (senders, events) => picsubPhoto_Click(senders, events);
                byte[] imageBytes = Convert.FromBase64String(item["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    photo.Image = Image.FromStream(ms, true);
                }

                photoSubbar.Controls.Add(photo);
                i++;
            });

        }

        private async void picsubPhoto_Click(object senders, EventArgs events)
        {
            JToken list = await fetchAPI("PhotoController@Details", new object[] {
                (int)(senders as PictureBox).Tag
            });
            var rows = list.First();
            picLargePhoto.Image = (senders as PictureBox).Image;
            lbl_photo_desc.Text = rows["name"].ToString();
        }

        private void picCreateNews_Click(object sender, EventArgs e)
        {
            new Frm_News("Create").ShowDialog(this);
        }

        private void picCreateCharity_Click(object sender, EventArgs e)
        {
            new Frm_Charity("Create").ShowDialog(this);
        }

        private void picCreateEvent_Click(object sender, EventArgs e)
        {
            new Frm_Info("Create").ShowDialog(this);
        }

        private void picCreateRacekit_Click(object sender, EventArgs e)
        {
            new Frm_Racekit("Create").ShowDialog(this);
        }

        private void picCreateBanner_Click(object sender, EventArgs e)
        {
            new Frm_Banner("Create").ShowDialog(this);
        }

        private void Distance_Click(object sender, EventArgs e)
        {
            string distanceDesc = string.Format("distance{0}", (sender as Control).Tag.ToString());
            picDistanceLarge.Image = (sender as PictureBox).Image;
            lbl_DistanceDesc.Text = Properties.Resources.ResourceManager.GetObject(distanceDesc).ToString();
        }

        public async Task getNewsRows()
        {
            clearHotNews();
            clearNewsRows();
            JToken list = await fetchAPI("NewsController@Rows");
            NewsRows = list.ToList();
            currentPage = 1;
            lbl_news_currentpage.Text = currentPage.ToString();
            totalPage = (int)Math.Ceiling(NewsRows.Count / 15.0);
            lbl_newsrows_totalpage.Text = "Total Page: " + totalPage;
        }

        private void lbl_prev_event_Click(object sender, EventArgs e)
        {
            currentIdx = 2;
            tab.SelectedIndex = 2;
        }

        private async void tabEvent_Enter(object sender, EventArgs e)
        {
            lblEventTitle.Text = "Marathon Skills 2017";
            var eventRows = cardSubEventType.Controls.OfType<Control>().ToList();
            eventRows.ForEach(items => {
                items.Dispose();
            });
            string json = await Route.execute("EventController@MarathonRows", new object[] { 0 });
            JObject result = JObject.Parse(json);
            int i = 0;
            foreach (var item in result["data"]) {
                Label title = new Label();
                title.Cursor = Cursors.Hand;
                title.Location = new Point(3, 2 + i * 36);
                title.Parent = cardSubEventType;
                title.ForeColor = Color.DodgerBlue;
                title.Name = "lbl_event_title_" + i;
                title.Text = (string)item["name"];
                title.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                title.Size = new Size(434, 17);
                title.Click += (senders, events) => eventTitle_Click(senders, events, (int)item["id"]);

                Panel eventHR = new Panel();
                eventHR.Name = "event_type_HR" + i;
                eventHR.Location = new Point(9, 27 + i * 36);
                eventHR.Parent = cardSubEventType;
                eventHR.Size = new Size(434, 2);
                eventHR.BackColor = Color.DarkGray;

                cardSubEventType.Controls.Add(eventHR);
                cardSubEventType.Controls.Add(title);
                i++;
            }
        }

        private async void tabDashboard_Enter(object sender, EventArgs e)
        {
            var result = await fetchAPI("PropertyController@getOverview");
            if (result != null) {
                lbl_dashboarditem1_number.Text = result["runner"].ToString();
                lbl_dashboarditem2_number.Text = string.Format("${0}", result["sponsorship"]);
                lbl_dashboarditem3_number.Text = string.Format("{0} / {1}", result["receipt"]["current"], result["receipt"]["total"]);
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
            await loadOverview();
        }

        private async Task loadOverview()
        {
            JToken result = await fetchAPI("PropertyController@getStat");
            if (result != null) {
                dataChart.Series["Runner"].Points.Clear();
                dataChart.Series["Volunteers"].Points.Clear();
                dataChart.Series["Sponsorship"].Points.Clear();
                var row = result.ToList();
                row.ForEach(item => {
                    string date = item["created_at"].ToObject<DateTime>().ToString("yyyy-MM-dd");
                    var runnerPt = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = date,
                        YValues = new double[] {
                            item["runner"].ToObject<double>()
                        },
                        Color = Color.DodgerBlue
                    };
                    dataChart.Series["Runner"].Points.Add(runnerPt);

                    var volunteerPt = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = date,
                        YValues = new double[] {
                            item["volunteer"].ToObject<double>()
                        },
                        Color = Color.Orange
                    };
                    dataChart.Series["Volunteers"].Points.Add(volunteerPt);

                    var sponsorshipPt = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = date,
                        YValues = new double[] {
                            item["sponsorship"].ToObject<double>()
                        },
                        Color = Color.Red
                    };
                    dataChart.Series["Sponsorship"].Points.Add(sponsorshipPt);
                });
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
        }

        private async Task loadGender()
        {
            JToken result = await fetchAPI("PropertyController@getGenderInEvent");
            if (result != null) {
                chart1.Series["Male"].Points.Clear();
                chart1.Series["Female"].Points.Clear();
                var row = result.ToList();
                row.ForEach(item => {
                    var male = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = item["name"].ToString(),
                        YValues = new double[] {
                            item["male"].ToObject<double>()
                        },
                        Color = Color.DodgerBlue
                    };
                    chart1.Series["Male"].Points.Add(male);

                    var female = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = item["name"].ToString(),
                        YValues = new double[] {
                            item["female"].ToObject<double>()
                        },
                        Color = Color.Orange
                    };
                    chart1.Series["Female"].Points.Add(female);
                });
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
        }

        private async Task loadRaceKit()
        {
            JToken result = await fetchAPI("PropertyController@getRacekitInEvent");
            if (result != null) {
                chart3.Series.Clear();
                var row = result.ToList();
                row.ForEach(item => {
                    var series = new System.Windows.Forms.DataVisualization.Charting.Series(item["name"].ToString()) {
                        XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single
                    };
                    var sales = new System.Windows.Forms.DataVisualization.Charting.DataPoint() {
                        AxisLabel = "Sales",
                        YValues = new double[] {
                            item["sales"].ToObject<int>()
                        }
                    };
                    series.Points.Add(sales);
                    chart3.Series.Add(series);
                });
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
        }

        private async void dashboarditem2_more_Click(object sender, EventArgs e)
        {
            JToken result = await fetchAPI("PropertyController@getSponsorship");
            if (result != null) {
                MessageBox.Show(string.Format("Charity Sponsorship: ${0}\r\nRunner Sponsorship: ${1}\r\nTotal: ${2}", result["charity"], result["runner"], result["total"]), "Sponsorship Overview", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show(Properties.strings.service_unavailable, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabIndex_Leave(object sender, EventArgs e)
        {
            timerBanner.Enabled = false;
        }

        private void btn_dashboard_item7_Click(object sender, EventArgs e)
        {
            dashboardDropdown.Visible = !dashboardDropdown.Visible;
        }

        private void txt_member_search_Enter(object sender, EventArgs e)
        {
            memberSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_member_search.Text == "Keyword") {
                txt_member_search.ForeColor = Color.Black;
                txt_member_search.Text = "";
            }
        }

        private void txt_member_search_Leave(object sender, EventArgs e)
        {
            memberSearchBorder.BackColor = Color.DarkGray;
            if (txt_member_search.Text == "") {
                txt_member_search.ForeColor = Color.DarkGray;
                txt_member_search.Text = "Keyword";
            }
        }

        private async void txt_member_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_member_search.ForeColor == Color.Black) {
                var table = tableDashboard_item1.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("MemberController@Rows");
                var item = list.Where(p => p["username"].ToString().Contains(txt_member_search.Text) || p["id"].ToString().Contains(txt_member_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_news_search_Enter(object sender, EventArgs e)
        {
            newsSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_news_search.Text == "Keyword") {
                txt_news_search.ForeColor = Color.Black;
                txt_news_search.Text = "";
            }
        }

        private void txt_news_search_Leave(object sender, EventArgs e)
        {
            newsSearchBorder.BackColor = Color.DarkGray;
            if (txt_news_search.Text == "") {
                txt_news_search.ForeColor = Color.DarkGray;
                txt_news_search.Text = "Keyword";
            }
        }

        private void dashboarditem1_Click(object sender, EventArgs e)
        {
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab.SelectedIndex = selectedItem;
            lbl_title.Text = "Member";
            dashboardDropdown.Visible = false;
        }

        private void dashboarditem3_Click(object sender, EventArgs e)
        {
            var myControl = sender as Control;
            int selectedItem = int.Parse(myControl.Tag.ToString());
            currentIdx = selectedItem;
            tab.SelectedIndex = selectedItem;
            lbl_title.Text = "Payment";
            dashboardDropdown.Visible = false;
        }

        private async void txt_news_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_news_search.ForeColor == Color.Black) {
                var table = tableDashboard_item2.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("NewsController@Rows");
                var item = list.Where(p => p["title"].ToString().Contains(txt_news_search.Text) || p["id"].ToString().Contains(txt_news_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private async void txt_charity_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_charity_search.ForeColor == Color.Black) {
                var table = tableDashboard_item3.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("CharityController@Rows");
                var item = list.Where(p => p["title"].ToString().Contains(txt_charity_search.Text) || p["id"].ToString().Contains(txt_charity_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_charity_search_Enter(object sender, EventArgs e)
        {
            charitySearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_charity_search.Text == "Keyword") {
                txt_charity_search.ForeColor = Color.Black;
                txt_charity_search.Text = "";
            }
        }

        private void txt_charity_search_Leave(object sender, EventArgs e)
        {
            charitySearchBorder.BackColor = Color.DarkGray;
            if (txt_charity_search.Text == "") {
                txt_charity_search.ForeColor = Color.DarkGray;
                txt_charity_search.Text = "Keyword";
            }
        }

        private async void txt_event_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_event_search.ForeColor == Color.Black) {
                var table = tableDashboard_item4.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("EventController@dashboardRows");
                var item = list.Where(p => p["name"].ToString().Contains(txt_event_search.Text) || p["id"].ToString().Contains(txt_event_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_event_search_Enter(object sender, EventArgs e)
        {
            eventSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_event_search.Text == "Keyword") {
                txt_event_search.ForeColor = Color.Black;
                txt_event_search.Text = "";
            }
        }

        private void txt_event_search_Leave(object sender, EventArgs e)
        {
            eventSearchBorder.BackColor = Color.DarkGray;
            if (txt_event_search.Text == "") {
                txt_event_search.ForeColor = Color.DarkGray;
                txt_event_search.Text = "Keyword";
            }
        }

        private async void txt_volunteer_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_volunteer_search.ForeColor == Color.Black) {
                var table = tableDashboard_item5.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("VolunteerController@Rows");
                var item = list.Where(p => p["username"].ToString().Contains(txt_volunteer_search.Text) || p["id"].ToString().Contains(txt_volunteer_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_volunteer_search_Leave(object sender, EventArgs e)
        {
            volunteerSearchBorder.BackColor = Color.DarkGray;
            if (txt_volunteer_search.Text == "") {
                txt_volunteer_search.ForeColor = Color.DarkGray;
                txt_volunteer_search.Text = "Keyword";
            }
        }

        private void txt_volunteer_search_Enter(object sender, EventArgs e)
        {
            volunteerSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_volunteer_search.Text == "Keyword") {
                txt_volunteer_search.ForeColor = Color.Black;
                txt_volunteer_search.Text = "";
            }
        }

        private async void txt_payment_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_payment_search.ForeColor == Color.Black) {
                var table = tableDashboard_item6.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("PaymentController@Rows");
                var item = list.Where(p => p["username"].ToString().Contains(txt_payment_search.Text) || p["id"].ToString().Contains(txt_payment_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_payment_search_Leave(object sender, EventArgs e)
        {
            paymentSearchBorder.BackColor = Color.DarkGray;
            if (txt_payment_search.Text == "") {
                txt_payment_search.ForeColor = Color.DarkGray;
                txt_payment_search.Text = "Keyword";
            }
        }

        private void txt_payment_search_Enter(object sender, EventArgs e)
        {
            paymentSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_payment_search.Text == "Keyword") {
                txt_payment_search.ForeColor = Color.Black;
                txt_payment_search.Text = "";
            }
        }

        private async void txt_feedback_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_feedback_search.ForeColor == Color.Black) {
                var table = tableDashboard_item7.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("FeedbackController@Rows");
                var item = list.Where(p => p["name"].ToString().Contains(txt_feedback_search.Text) || p["id"].ToString().Contains(txt_feedback_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_feedback_search_Enter(object sender, EventArgs e)
        {
            feedbackSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_feedback_search.Text == "Keyword") {
                txt_feedback_search.ForeColor = Color.Black;
                txt_feedback_search.Text = "";
            }
        }

        private void txt_feedback_search_Leave(object sender, EventArgs e)
        {
            feedbackSearchBorder.BackColor = Color.DarkGray;
            if (txt_feedback_search.Text == "") {
                txt_feedback_search.ForeColor = Color.DarkGray;
                txt_feedback_search.Text = "Keyword";
            }
        }

        private async void txt_banner_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_banner_search.ForeColor == Color.Black) {
                var table = tableDashboard_item9.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("BannerController@Rows");
                var item = list.Where(p => p["title"].ToString().Contains(txt_banner_search.Text) || p["id"].ToString().Contains(txt_banner_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_banner_search_Leave(object sender, EventArgs e)
        {
            bannerSearchBorder.BackColor = Color.DarkGray;
            if (txt_banner_search.Text == "") {
                txt_banner_search.ForeColor = Color.DarkGray;
                txt_banner_search.Text = "Keyword";
            }
        }

        private void txt_banner_search_Enter(object sender, EventArgs e)
        {
            bannerSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_banner_search.Text == "Keyword") {
                txt_banner_search.ForeColor = Color.Black;
                txt_banner_search.Text = "";
            }
        }

        private async void txt_racekit_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_racekit_search.ForeColor == Color.Black) {
                var table = tableDashboard_item10.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("RaceKitController@Rows");
                var item = list.Where(p => p["name"].ToString().Contains(txt_racekit_search.Text) || p["id"].ToString().Contains(txt_racekit_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_racekit_search_Leave(object sender, EventArgs e)
        {
            racekitSearchBorder.BackColor = Color.DarkGray;
            if (txt_racekit_search.Text == "") {
                txt_racekit_search.ForeColor = Color.DarkGray;
                txt_racekit_search.Text = "Keyword";
            }
        }

        private void txt_racekit_search_Enter(object sender, EventArgs e)
        {
            racekitSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_racekit_search.Text == "Keyword") {
                txt_racekit_search.ForeColor = Color.Black;
                txt_racekit_search.Text = "";
            }
        }

        private async void txt_photo_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_photo_search.ForeColor == Color.Black) {
                var table = tableDashboard_item12.Controls.OfType<Table>().First();
                JToken list = await fetchAPI("PhotoController@dashboardRows");
                var item = list.Where(p => p["name"].ToString().Contains(txt_photo_search.Text) || p["id"].ToString().Contains(txt_photo_search.Text)).ToList();
                table.updateTable(item);
            }
        }

        private void txt_photo_search_Leave(object sender, EventArgs e)
        {
            photoSearchBorder.BackColor = Color.DarkGray;
            if (txt_photo_search.Text == "") {
                txt_photo_search.ForeColor = Color.DarkGray;
                txt_photo_search.Text = "Keyword";
            }
        }

        private void txt_photo_search_Enter(object sender, EventArgs e)
        {
            photoSearchBorder.BackColor = Color.FromArgb(2, 136, 209);
            if (txt_photo_search.Text == "Keyword") {
                txt_photo_search.ForeColor = Color.Black;
                txt_photo_search.Text = "";
            }
        }

        private void picCreatePhoto_Click(object sender, EventArgs e)
        {
            new Frm_Photo("Create").ShowDialog(this);
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int event_id = int.Parse(btnResult.Tag.ToString());
            new Frm_EventResult(event_id).ShowDialog(this);
        }

        private async void tabVolunteer_Enter(object sender, EventArgs e)
        {
            var items = await fetchAPI("VolunteerController@Rows");
            if (items != null) {
                tbl_assignedRunner.BeginUpdate();
                tbl_assignedRunner.Columns.Clear();
                tbl_assignedRunner.Items.Clear();
                tbl_assignedRunner.View = View.Details;
                if (items.Count() > 0) {
                    JObject inner = items.First().Value<JObject>();
                    var keys = inner.Properties().Select(p => p.Name).ToList();
                    keys.ForEach(key => {
                        key = key.Replace('-', ' ').Replace('_', ' ');
                        string rule = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(key.ToLower()).Replace(" ", string.Empty);
                        tbl_assignedRunner.Columns.Add(key, -2, HorizontalAlignment.Center);
                    });
                    items.ToList().ForEach(item => {
                        string[] subItem = new string[keys.Count];
                        int i = 0;

                        foreach (string field in item) {
                            subItem[i++] = field;
                        }
                        ListViewItem lvi = new ListViewItem(subItem);
                        tbl_assignedRunner.Items.Add(lvi);
                    });
                }
                tbl_assignedRunner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                tbl_assignedRunner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                tbl_assignedRunner.EndUpdate();
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
        }

        private async void btn_volunteer_checkin_Click(object sender, EventArgs e)
        {
            if (tbl_assignedRunner.SelectedItems.Count > 0) {
                if (MessageBox.Show("Are you sure you want to help runner to check-in?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string json = await Route.execute("VolunteerController@checkin", new object[] {
                        int.Parse(tbl_assignedRunner.SelectedItems[0].Text)
                    });
                    JObject rss = JObject.Parse(json);
                    bool success = Convert.ToBoolean(rss["success"]);
                    string msgTitle = success ? "Info" : "Error";
                    MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                    MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
                    if (success) {
                        reloadTable(9);
                    }
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_volunteer_racekit_Click(object sender, EventArgs e)
        {
            if (tbl_assignedRunner.SelectedItems.Count > 0) {
                if (MessageBox.Show("Are you sure the racekit has been sent?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string json = await Route.execute("VolunteerController@sendracekit", new object[] {
                        int.Parse(tbl_assignedRunner.SelectedItems[0].Text)
                    });
                    JObject rss = JObject.Parse(json);
                    bool success = Convert.ToBoolean(rss["success"]);
                    string msgTitle = success ? "Info" : "Error";
                    MessageBoxIcon icon = success ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                    MessageBox.Show((string)rss["message"], msgTitle, MessageBoxButtons.OK, icon);
                    if (success) {
                        reloadTable(9);
                    }
                }
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_assigncheckpoint_Click(object sender, EventArgs e)
        {
            var card = tableDashboard_item4.Controls.OfType<Table>().First();
            if (card.tableList.SelectedItems.Count > 0) {
                new Frm_CheckptService(int.Parse(card.tableList.SelectedItems[0].Text)).ShowDialog(this);
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picCreateService_Click(object sender, EventArgs e)
        {
            new Frm_Service("Create").ShowDialog(this);
        }

        private async void lbl_marathon_prev_Click(object sender, EventArgs e)
        {
            var eventRows = cardMarathonTop.Controls.OfType<Control>().ToList();
            eventRows.ForEach(items => {
                items.Dispose();
            });
            string json = await Route.execute("EventController@getAllMarathon");
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                var row = result["data"].ToList();
                int i = 0;
                row.ForEach(item => {
                    var marathonName = new Label() {
                        Name = "lbl_marathon_name_" + i,
                        Parent = cardMarathonTop,
                        Location = new Point(12, 22 + 36 * i),
                        Size = new Size(457, 22),
                        Font = new Font("Open Sans Semibold", 12, FontStyle.Bold),
                        Image = Properties.Resources.chevron_right,
                        ImageAlign = ContentAlignment.MiddleRight,
                        Text = item["name"].ToString(),
                        Cursor = Cursors.Hand
                    };
                    var marathonHR = new Panel() {
                        Name = "lbl_marathon_name_HR_" + i,
                        Parent = cardMarathonTop,
                        Location = new Point(10, 49 + 36 * i),
                        Size = new Size(459, 1),
                        BackColor = Color.DimGray
                    };
                    marathonName.Click += (senders, events) => marathonName_Click(senders, events, (int)item["id"], item["name"].ToString());
                    cardMarathonTop.Controls.Add(marathonName);
                    cardMarathonTop.Controls.Add(marathonHR);
                    i++;
                });
                cardInfo.Visible = false;
                cardMarathonList.Visible = true;
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void marathonName_Click(object senders, EventArgs events, int v, string name)
        {
            lblEventTitle.Text = name;
            var eventRows = cardSubEventType.Controls.OfType<Control>().ToList();
            eventRows.ForEach(items => {
                items.Dispose();
            });
            string json = await Route.execute("EventController@MarathonRows", new object[] { v });
            JObject result = JObject.Parse(json);
            if (Convert.ToBoolean(result["success"])) {
                int i = 0;
                foreach (var item in result["data"]) {
                    Label title = new Label();
                    title.Cursor = Cursors.Hand;
                    title.Location = new Point(3, 2 + i * 36);
                    title.Parent = cardSubEventType;
                    title.ForeColor = Color.DodgerBlue;
                    title.Name = "lbl_event_title_" + i;
                    title.Text = (string)item["name"];
                    title.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    title.Size = new Size(434, 17);
                    title.Click += (s, e) => eventTitle_Click(s, e, (int)item["id"]);

                    Panel eventHR = new Panel();
                    eventHR.Name = "event_type_HR" + i;
                    eventHR.Location = new Point(9, 27 + i * 36);
                    eventHR.Parent = cardSubEventType;
                    eventHR.Size = new Size(434, 2);
                    eventHR.BackColor = Color.DarkGray;

                    cardSubEventType.Controls.Add(eventHR);
                    cardSubEventType.Controls.Add(title);
                    i++;
                }
                cardInfo.Visible = true;
                cardMarathonList.Visible = false;
            } else {
                MessageBox.Show(result["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_recent_marathon_Click(object sender, EventArgs e)
        {
            cardInfo.Visible = true;
            cardMarathonList.Visible = false;
        }

        private async void tabRegistered_Enter(object sender, EventArgs e)
        {
            var items = await fetchAPI("EventController@getPersonalResult");
            if (items != null) {
                tbl_event_result.BeginUpdate();
                tbl_event_result.Columns.Clear();
                tbl_event_result.Items.Clear();
                tbl_event_result.View = View.Details;
                if (items.Count() > 0) {
                    tbl_event_result.Columns.Add("BIB", -2, HorizontalAlignment.Center);
                    tbl_event_result.Columns.Add("EVENT ID", -2, HorizontalAlignment.Center);
                    tbl_event_result.Columns.Add("EVENT", -2, HorizontalAlignment.Center);
                    tbl_event_result.Columns.Add("GUN TIME", -2, HorizontalAlignment.Center);
                    var rows = items.ToList();
                    rows.Select(p => new {
                        bib = p["bib_id"].ToString(),
                        event_id = p["event_id"].ToString(),
                        event_name = p["event_name"].ToString(),
                        gun_tim = p["finished_time"].ToString()
                    }).ToList().ForEach(item => {
                        string[] subItem = new string[] {
                            item.bib,
                            item.event_id,
                            item.event_name,
                            item.gun_tim
                        };
                        ListViewItem lvi = new ListViewItem(subItem);
                        tbl_event_result.Items.Add(lvi);
                    });
                }
                tbl_event_result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                tbl_event_result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                tbl_event_result.EndUpdate();
            } else {
                currentIdx = 0;
                tab.SelectedIndex = 0;
            }
        }

        private void btn_viewResult_Click(object sender, EventArgs e)
        {
            if (tbl_event_result.SelectedItems.Count > 0) {
                int bib_id = int.Parse(tbl_event_result.SelectedItems[0].Text);
                int event_id = int.Parse(tbl_event_result.SelectedItems[0].SubItems[1].Text);
                new Frm_RaceBib(bib_id, event_id).ShowDialog(Owner);
            } else {
                MessageBox.Show(string.Format(Properties.strings.validation_allrequired), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabWeather_FAQ_Enter(object sender, EventArgs e)
        {
            var rhiInWeek = WeatherController.GetHumi();
            var minInWeek = WeatherController.GetMaxTemp();
            var maxInWeek = WeatherController.GetMinTemp();
            lbl_temp_weather.Text = string.Format("{0} ℃", WeatherController.GetCTemp());
            lbl_rhi_weather.Text = string.Format("{0}%", WeatherController.GetCHumi());
            lbl_forecast_desc.Text = WeatherController.GetDesc();
            lbl_rhi_day1.Text = string.Format("{0}%", rhiInWeek[0]);
            lbl_rhi_day2.Text = string.Format("{0}%", rhiInWeek[1]);
            lbl_rhi_day3.Text = string.Format("{0}%", rhiInWeek[2]);
            lbl_rhi_day4.Text = string.Format("{0}%", rhiInWeek[3]);
            lbl_temp_day1.Text = string.Format("{0} | {1} ℃", minInWeek[0], maxInWeek[0]);
            lbl_temp_day2.Text = string.Format("{0} | {1} ℃", minInWeek[1], maxInWeek[1]);
            lbl_temp_day3.Text = string.Format("{0} | {1} ℃", minInWeek[2], maxInWeek[2]);
            lbl_temp_day4.Text = string.Format("{0} | {1} ℃", minInWeek[3], maxInWeek[3]);
            lbl_weather_day1.Text = string.Format("{0}", DateTime.Today.ToString("m"));
            lbl_weather_day2.Text = string.Format("{0}", DateTime.Today.AddDays(1).ToString("m"));
            lbl_weather_day3.Text = string.Format("{0}", DateTime.Today.AddDays(2).ToString("m"));
            lbl_weather_day4.Text = string.Format("{0}", DateTime.Today.AddDays(3).ToString("m"));
            lbl_warning_desc.Text = WeatherController.GetWarning();
        }

        private async void tabGraphGender_Enter(object sender, EventArgs e)
        {
            await loadGender();
        }

        private async void tabGraphOverview_Enter(object sender, EventArgs e)
        {
            await loadOverview();
        }

        private async void tabGraphRacekit_Enter(object sender, EventArgs e)
        {
            await loadRaceKit();
        }

        private void picCreateMarathon_Click(object sender, EventArgs e)
        {
            new Frm_ManageMarathon("Create").ShowDialog(this);
        }

        private void timerBanner_Tick(object sender, EventArgs e)
        {
            if (bannerRows.Count > 0) {
                bannerIdx = bannerIdx >= bannerRows.Count ? 0 : bannerIdx;
                byte[] imageBytes = Convert.FromBase64String(bannerRows[bannerIdx]["image"].ToString());
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                    pic_silder.Image = Image.FromStream(ms, true);
                }
                bannerIdx++;
                timerBanner.Interval = 5000;
            }
        }

        private void clearHotNews()
        {
            List<Label> controlHostNews = cardHotNews.Controls.OfType<Label>().ToList();
            controlHostNews.ForEach(news => {
                news.Dispose();
            });
        }

        private void clearNewsRows()
        {
            List<Label> controlNewsRows = cardNewsRows.Controls.OfType<Label>().ToList();
            controlNewsRows.ForEach(news => {
                news.Dispose();
            });
        }
    }
}
