using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
namespace VNVC_Jackpot
{
    

    public class HourUpdater
    {
        private System.Timers.Timer timer;
        private Label labelNextHour;

        public HourUpdater(Label labelNextHour)
        {
            this.labelNextHour = labelNextHour;
        }

        public void StartUpdating()
        {
            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;

            // Tính thời gian chờ đến giờ tiếp theo
            DateTime nextHour = now.AddHours(1);
            TimeSpan timeToNextHour = nextHour - now;


            // Đặt thời gian chờ đến giờ tiếp theo cho timer
            UpdateLabel(GetNextHour());


            timer = new System.Timers.Timer(timeToNextHour.TotalMilliseconds);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Lấy giờ tiếp theo và cập nhật label
            int nextHour = GetNextHour();
            UpdateLabel(nextHour);
        }

        private int GetNextHour()
        {
            DateTime now = DateTime.Now;
            int currentHour = now.Hour;
            int nextHour = currentHour + 1;

            if (nextHour == 24)
            {
                nextHour = 0;
            }

            return nextHour;
        }

        private void UpdateLabel(int nextHour)
        {
            // Sử dụng cú pháp chuỗi để cập nhật label
            labelNextHour.Invoke((MethodInvoker)(() =>
            {
                labelNextHour.Text = nextHour.ToString() + ":00";
            }));
        }
    }
}
