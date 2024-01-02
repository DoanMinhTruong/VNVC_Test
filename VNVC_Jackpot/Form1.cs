using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Reflection.Emit;
using System.Web;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VNVC_Jackpot
{
    public partial class MainForm : Form
    {
        public ApiResultNumberClient apiResultNumberClient;
        private string _sdt;
        private LoginForm _lf;
        private int user_id;
        private HourUpdater hu;
        private System.Windows.Forms.Timer updateDataJackPotTimer;
        private System.Windows.Forms.Timer updateNumberStat;


        private void SetupDataGridViewJackPot()
        {
            dgvJackPot.ColumnCount = 7;
            dgvJackPot.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvJackPot.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvJackPot.ColumnHeadersDefaultCellStyle.Font = new Font(dgvJackPot.Font, FontStyle.Bold);
            dgvJackPot.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvJackPot.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            dgvJackPot.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvJackPot.GridColor = Color.Black;
            dgvJackPot.RowHeadersVisible = false;
            dgvJackPot.Columns[0].Name = "STT";
            dgvJackPot.Columns[1].Name = "SDT";
            dgvJackPot.Columns[2].Name = "Họ tên";
            dgvJackPot.Columns[3].Name = "Số đặt";
            dgvJackPot.Columns[4].Name = "Slot";
            dgvJackPot.Columns[5].Name = "Ngày";
            dgvJackPot.Columns[6].Name = "Trạng thái";
            dgvJackPot.Columns[6].DefaultCellStyle.Font =
            new Font(dgvJackPot.DefaultCellStyle.Font, FontStyle.Italic);
            dgvJackPot.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            dgvJackPot.MultiSelect = false;

        }
        private async void UpdateDataJackPotHandler(object sender, EventArgs myEventArgs)
        {
            UpdateDataJackPot(await apiResultNumberClient.GetBySize(50));
        }
        private async void UpdateNumberStat(object sender, EventArgs myEventArgs)
        {
            UpdatePieChart1(await apiResultNumberClient.GetNumberStat());
        }
        private async void UpdateNumberStatWin(object sender, EventArgs myEventArgs)
        {
            UpdatePieChart2(await apiResultNumberClient.GetNumberStatWin());
        }
        public MainForm(LoginForm lf , string sdt , int user_id)
        {
            InitializeComponent();
            _sdt = sdt;
            this.Text += " - User : " + _sdt;
            _lf = lf;
            this.user_id = user_id;
            hu = new HourUpdater(lblNextSlot);
            SetupDataGridViewJackPot();
            pieChart1.Titles.Add("Phân bổ Số của người dùng đã đặt");
            pieChart2.Titles.Add("Phân bổ Số của người dùng đã thắng");



            updateDataJackPotTimer = new System.Windows.Forms.Timer();
            updateDataJackPotTimer.Tick += new EventHandler(UpdateDataJackPotHandler);
            updateDataJackPotTimer.Interval = 1000;
            updateDataJackPotTimer.Start();

            updateNumberStat = new System.Windows.Forms.Timer();
            updateNumberStat.Tick += new EventHandler(UpdateNumberStat);
            updateNumberStat.Tick += new EventHandler(UpdateNumberStatWin);
            updateNumberStat.Interval = 1000;
            updateNumberStat.Start();


            

            apiResultNumberClient = new ApiResultNumberClient();
            string response = apiResultNumberClient.GetApiResponse("current_result_number/");
            try
            {
                JsonDocument jsonDocument = JsonDocument.Parse(response);
                JsonElement root = jsonDocument.RootElement;

                int number = root.GetProperty("current_number").GetInt32();
                lblNumber.Text = "Số đã sổ gần nhất: " + number.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phân tích dữ liệu JSON Khởi tạo: {ex.Message}");
            }



        }


        public class UpdateLabelNumber : IJob
        {
            
            public async Task Execute(IJobExecutionContext context)
            {
                //string res = apiResultNumberClient.GetApiResponse("current_result_number/");
                //lblNumber.Text = res;
                var jobDataMap = context.JobDetail.JobDataMap;
                var label = (System.Windows.Forms.Label)jobDataMap["lblNumber"];
                var api = (ApiResultNumberClient)jobDataMap["apiResultNumberClient"];
                string res = api.GetApiResponse("current_result_number/");
                try
                {
                    JsonDocument jsonDocument = JsonDocument.Parse(res);
                    JsonElement root = jsonDocument.RootElement;
                    
                    int number = root.GetProperty("current_number").GetInt32();
                    label.Text = "Số đã sổ gần nhất: " + number.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show ($"Lỗi khi phân tích dữ liệu JSON: {ex.Message}");
                }
                
                await Task.CompletedTask;
            }
        }
        
        private async void UpdateDataJackPot(JsonElement jse)
        {
            dgvJackPot.Rows.Clear();
            for(int i = jse.GetArrayLength() - 1; i >= 0; i--)
            {
                int stt = i + 1;
                string phone_number = jse[i].GetProperty("user").GetProperty("phone_number").GetString();
                string name = jse[i].GetProperty("user").GetProperty("name").GetString();
                int number = jse[i].GetProperty("number").GetInt32();
                int slot = jse[i].GetProperty("slot").GetInt32();
                int status = jse[i].GetProperty("status").GetInt32();
                string created = jse[i].GetProperty("created").GetString();
                string str_status = "";
                if (status == 0)
                {
                    str_status = "Pending";
                }
                else if (status == 1) str_status = "Win";
                else str_status = "Lose";
                string[] dt = { stt.ToString(), phone_number, name, number.ToString(), slot.ToString() + ":00",  created, str_status};
                dgvJackPot.Rows.Add (dt);
            }
        }
        private async void UpdatePieChart1(JsonElement jse)
        {
            pieChart1.Series["s1"].Points.Clear();
            for(int i = 0; i < jse.GetArrayLength(); i++) {
                pieChart1.Series["s1"].Points.AddXY(jse[i].GetProperty("number").GetInt32().ToString(), jse[i].GetProperty("count").GetInt32().ToString());
            }
        }
        private async void UpdatePieChart2(JsonElement jse)
        {
            pieChart2.Series["s1"].Points.Clear();
            for (int i = 0; i < jse.GetArrayLength(); i++)
            {
                pieChart2.Series["s1"].Points.AddXY(jse[i].GetProperty("number").GetInt32().ToString(), jse[i].GetProperty("count").GetInt32().ToString());
            }
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            _lf.Hide();
            //MessageBox.Show(res);
            hu.StartUpdating();
            //UpdateDataJackPot(await apiResultNumberClient.GetBySize(100));

            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();


            var jobDataMap = new JobDataMap();
            jobDataMap.Add("lblNumber", lblNumber);
            jobDataMap.Add("apiResultNumberClient", apiResultNumberClient);

            // Định nghĩa công việc
            var job = JobBuilder.Create<UpdateLabelNumber>()
                .WithIdentity("updateNumberJob", "group1")
                .UsingJobData(jobDataMap)
                .Build();

            // Định nghĩa trigger để kích hoạt công việc vào các khung giờ cụ thể
            var trigger = TriggerBuilder.Create()
                .WithIdentity("updateNumberJobTrigger", "group1")
                .WithCronSchedule("0 0 0-23 * * ?") // Chạy vào 1:00, 2:00, 3:00,... hàng ngày
                //.WithSimpleSchedule(x => x
                //.WithIntervalInSeconds(10)
                //.RepeatForever())
                .Build();

            // Lập lịch công việc theo trigger
            await scheduler.ScheduleJob(job, trigger);

            // Chờ 5 phút để quan sát kết quả
            await Task.Delay(TimeSpan.FromMinutes(1));

            // Dừng và giải phóng lập lịch Quartz
            await scheduler.Shutdown();


            
            
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _lf.Close();
            updateDataJackPotTimer.Stop();
            updateDataJackPotTimer.Dispose();

            updateNumberStat.Stop();
            updateNumberStat.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string inputText = cbbSelectNumber.Text;
            int number;
            int slot = int.Parse((lblNextSlot.Text).Split(':')[0]);
            if (int.TryParse(inputText, out number))
            {
               
            }
            else
            {
                MessageBox.Show("Vui lòng đảm bảo Số cần Đặt là số nguyên");
                return;
            }
            try
            {
                string response = await apiResultNumberClient.CreateJackPot(user_id, slot, number);
                MessageBox.Show("Đặt thành công");
            }
            catch (Exception ex) {
                MessageBox.Show("Đặt thất bại, hãy thử lại");
                cbbSelectNumber.Text = "";
            }
           
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {

        }

        private void cbbSelectNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
