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
    public partial class FThongtincanhan : Form
    {
        Clsdatabase cls = new Clsdatabase();
        public FThongtincanhan()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tTCaNhanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
         

        }

        private void FThongtincanhan_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dataGridView1, "select * from TTCaNhan");
            cls.loadcombobox(comboBox1, "select * from TTNVCoBan", 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update TTCaNhan set MaNV=N'" + comboBox1.Text + "',Noisinh=N'" + textBox2.Text + "',NguyenQuan=N'" + textBox3.Text + "',DCThuongChu=N'" + textBox4.Text + "',Email=N'" + textBox5.Text + "',SDT=N'" + textBox6.Text + "',DanToc=N'" + textBox7.Text + "',TonGiao=N'" + textBox8.Text + "',QuocTich=N'" + textBox9.Text + "',HocVan=N'" + textBox12.Text + "',GhiChu=N'" + textBox17.Text + "' where MaNV=N'" + comboBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from TTCaNhan");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "delete from TTCaNhan where MaNV=N'" + comboBox1.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(delete);
                    cls.loaddatagridview(dataGridView1, "select * from TTCaNhan");
                }
            }
            catch
            {
                MessageBox.Show("không xóa được");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tTCaNhanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(textBox1, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 1);
            cls.loadtextboxchiso(textBox2, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 2);
            cls.loadtextboxchiso(textBox3, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 3);
            cls.loadtextboxchiso(textBox4, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 4);
            cls.loadtextboxchiso(textBox5, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 5);
            cls.loadtextboxchiso(textBox6, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 6);
            cls.loadtextboxchiso(textBox7, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 7);
            cls.loadtextboxchiso(textBox8, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 8);
            cls.loadtextboxchiso(textBox9, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 9);
            cls.loadtextboxchiso(textBox12, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 10);
            cls.loadtextboxchiso(textBox17, "select * from TTCaNhan where MaNV='" + comboBox1.Text + "'", 11);
        
    }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tTCaNhanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cls.kttrungkhoa(comboBox1.Text, "select MaNV from TTCaNhan"))
                {
                    string insert = "insert into TTCaNhan values(N'" + comboBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "',N'" + textBox5.Text + "',N'" + textBox6.Text + "',N'" + textBox7.Text + "',N'" + textBox8.Text + "',N'" + textBox9.Text + "',N'" + textBox12.Text + "',N'" + textBox17.Text + "')";
                    cls.thucthiketnoi(insert);
                    dataGridView1.Refresh();
                    cls.loaddatagridview(dataGridView1, "select * from TTCaNhan");
                }
                else MessageBox.Show("Thông tin về nhân viên này đã tồn tại");

            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không chính sác");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                comboBox1.Text = dataGridView1.Rows[hang].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[hang].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[hang].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[hang].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[hang].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[hang].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[hang].Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.Rows[hang].Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.Rows[hang].Cells[8].Value.ToString();
                textBox9.Text = dataGridView1.Rows[hang].Cells[9].Value.ToString();
                textBox12.Text = dataGridView1.Rows[hang].Cells[10].Value.ToString();
                textBox17.Text = dataGridView1.Rows[hang].Cells[11].Value.ToString();
                //

            }
            catch (Exception)
            { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
