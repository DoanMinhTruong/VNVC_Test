using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNVC_Jackpot
{
    public partial class LoginForm : Form
    {
        private ApiUserClient api; 
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Enabled = false;
            api = new ApiUserClient();
        }
        private bool checkFormatDate(string inputString)
        {
            DateTime dt;
            string[] formats = { "yyyy-MM-dd" };
            if (!DateTime.TryParseExact(inputString, formats,
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
            {
                //your condition fail code goes here
                return false;
            }
            else
            {
                return true;
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void isHasAccount_CheckedChanged(object sender, EventArgs e)
        {
            if(isHasAccount.Checked)
            {
                btnLogin.Enabled = true;
                btnRegister.Enabled = false;
                txtHoTen.Enabled = false;   
                txtNgaySinh.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = true;
                txtHoTen.Enabled = true;
                txtNgaySinh.Enabled = true;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtNgaySinh.Text))
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin");
                return;
            }
            string sdt = txtSDT.Text;
            string hoten = txtHoTen.Text;
            string ngaysinh = txtNgaySinh.Text;
            if(!checkFormatDate(ngaysinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
            }
            if (!IsDigitsOnly(sdt))
            {
                MessageBox.Show("SĐT không hợp lệ");
            }
            bool isExist = await api.CheckExistUser(sdt);
            if(isExist) {
                MessageBox.Show("SĐT này đã tồn tại");
            }
            try
            {
                var response = await api.Register(sdt, hoten, ngaysinh);
                MessageBox.Show("Đăng ký tài khoản thành công, giờ bạn có thể đăng nhập: \n "  + response);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Chưa điền thông tin SĐT");
                return;
            }
            string sdt = txtSDT.Text;
            bool isExist = await api.CheckExistUser(sdt);
            if (isExist)
            {
                try
                {
                    int user_id = await api.GetUserId(sdt);
                    MessageBox.Show("Chúc mừng bạn đăng nhập thành công");
                    MainForm mainForm = new MainForm(this, sdt, user_id);
                    mainForm.ShowDialog();

                }catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại");
                }
                //this.Hide();

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");

            }
        }
    }
}
