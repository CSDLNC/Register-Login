using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            DangNhap.Click += new EventHandler(this.DangNhap_Click);
            DangKi.Click += new EventHandler(this.DangKi_Click);
        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            Login form_login = new Login();
            form_login.Show();
            this.Hide();
        }

        private void DangKi_Click(object sender, EventArgs e)
        {
            Signin form_signin = new Signin();
            form_signin.Show();
            this.Hide();
        }
    }
}
