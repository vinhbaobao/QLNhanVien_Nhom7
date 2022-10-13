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
    public partial class FTimkiem : Form
    {
        public FTimkiem()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int i = 0;
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            i = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            i = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            i = 3;
        }
        private void FTimkiem_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan");
        }


        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("kjlhjkl");


            //if (i == 1)
            //{
            //    cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where MaNV like '%'" + textBox1.Text + "'%'");
            //}
        }

    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text == "") || (textBox1.Text == "Nhập vào từ khóa tìm kiếm"))
                {
                    MessageBox.Show("bạn chưa nhập tù khóa", "Nhập từ khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (i == 1)
                    {
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where MaNV=N'" + textBox1.Text + "'");
                    }
                    if (i == 2)
                    {
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where HoTen=N'" + textBox1.Text + "'");
                    }
                    if (i == 3)
                    {
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where CMTND=N'" + textBox1.Text + "'");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tìm kiếm sai");
            }
        }

   

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            try
            {

                if ((textBox1.Text == "") || (textBox1.Text == "Nhập vào từ khóa tìm kiếm"))
                {
                    cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan");
                }
                else
                {

                    if (i == 1)
                    {
                        cls.loatextbox(textBox1, "select * from TTNVCoBan where MaNV like N'" + textBox1.Text + "%'", 2);
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where MaNV like N'" + textBox1.Text + "%'");
                    }
                    if (i == 2)
                    {
                        cls.loatextbox(textBox1, "select * from TTNVCoBan where MaNV like N'" + textBox1.Text + "%'", 3);
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where HoTen like N'" + textBox1.Text + "%'");
                    }
                    if (i == 3)
                    {
                        cls.loatextbox(textBox1, "select * from TTNVCoBan where MaNV like N'" + textBox1.Text + "%'", 8);
                        cls.loaddatagridview(dataGridView1, "select * from TTNVCoBan where CMTND like N'" + textBox1.Text + "%'");
                    }
                }
            }
            catch
            {
                MessageBox.Show("tìm kiếm sai");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            
           
                if (textBox1.Text == "Nhập vào từ khóa tìm kiếm")
                {
                    textBox1.Text = "";
                }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
 }
