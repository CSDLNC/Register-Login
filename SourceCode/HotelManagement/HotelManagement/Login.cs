using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagement
{
    public partial class Login : Form
    {
        private int islogin = 0; //check da dang nhap chua
        private string username; // luu username
        public Login()
        {
            if(this.islogin == 1)
            {
                Application.Run(new HotelSearching());
            }
            else
            {
                InitializeComponent();

                DangNhap_Option.Click += new EventHandler(this.DangNhap_Option_Click);
            }
            
        }

        private void DangNhap_Option_Click(object sender, EventArgs e)
        {

            string username = tendangnhaptb.Text;
            string pass = matkhautb.Text;

            string connetionString = null;
            SqlConnection cnn;

            //Minh
            connetionString = @"Server=WIN-964NJSN787F\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=SSPI;";
            cnn = new SqlConnection(connetionString);

            try
            {
               

                using (SqlCommand cmd = new SqlCommand("SP_LoginAccount", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.VarChar).Value = username.Trim();
                    cmd.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = pass.Trim();
                    cmd.Parameters.Add("@RESULT", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
       
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    string retunvalue = cmd.Parameters["@RESULT"].Value.ToString();

                    if(retunvalue == "1")
                    {
                        MessageBox.Show("Đăng Nhập Thành Công !!!.");
                        HotelSearching search = new HotelSearching();
                        search.Show();
                        this.Hide();
                        this.islogin = 1;
                        this.username = username.Trim();
                    }
                    else
                    {
                        if(retunvalue == "2")
                        {
                            MessageBox.Show("Tên Đăng Nhập Không Tồn Tại Hoặc Mật Khẩu Không Chính Xác !!!.");
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Nhập Đầy Đủ Tên Đăng Nhập Và Mật Khẩu !!!.");
                        }
                    }

                }

                
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
