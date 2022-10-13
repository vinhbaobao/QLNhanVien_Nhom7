using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien_Nhom7
{
    public partial class FDangKi : Form
    {
        public FDangKi()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void FDangKi_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dataGridView1, "select * from TaiKhoan");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
              
                string insert = "insert into TaiKhoan values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox4.Text + "',N'" + textBox3.Text + "','" + textBox5.Text + "')";
                if (cls.kttrungkhoa(textBox1.Text, "select * from TaiKhoan") == true)
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Bạn có thể thử tên khác");
                else
                {
                    cls.thucthiketnoi(insert);
                    MessageBox.Show("Chúc mừng bạn đã đăng kí thành công");
                    cls.loaddatagridview(dataGridView1, "select * from TaiKhoan");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update TaiKhoan set ID=N'" + textBox1.Text + "',Pass=N'" + textBox2.Text + "',Quyen=N'" + textBox4.Text + "',Ten=N'" + textBox3.Text + "',Email='" + textBox5.Text + "' where ID='" + textBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from TaiKhoan");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string delete = "delete from TaiKhoan where ID=N'" + textBox1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(dataGridView1, "select * from TaiKhoan");
            }
            MessageBox.Show("Đã xóa dữ liệu ");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[hang].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[hang].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[hang].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[hang].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[hang].Cells[4].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }
}
