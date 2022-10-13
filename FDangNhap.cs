using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNhanVien_Nhom7
{
    public partial class FDangNhap : Form
    {
        Clsdatabase cls = new Clsdatabase();
        private SqlConnection Con = null;
        public FDangNhap()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          

        }

        private void FDangNhap_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=MSI;Initial Catalog=QLNS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Con.Open();
            string select = "Select * From TaiKhoan where ID='" + iDTextBox.Text + "' and Pass='" + passTextBox.Text + "' and Quyen='Admin'";
            SqlCommand cmd = new SqlCommand(select, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Read();
                MessageBox.Show("Đăng nhập vào hệ thống (Quyền Admin) !", "Thông báo !");
                DXIMainChinh.quyen = "Admin";
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập vào hệ thống (Quyền user) !", "Thông báo !");
                DXIMainChinh.quyen = "user";
                this.Hide();
                this.Close();
            }
            DXIMainChinh frm = new DXIMainChinh();
            //frm.Show();
            frm.ShowDialog();
            cmd.Dispose();
            reader.Close();
            reader.Dispose();


        }
    }
 }

