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
    public partial class FBoPhan : Form
    {
        public FBoPhan()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void FBoPhan_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(boPhanDataGridView, "select * from BoPhan");
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            // TODO: This line of code loads data into the 'qLNSDataSet.BoPhan' table. You can move, or remove it, as needed.
            this.boPhanTableAdapter.Fill(this.qLNSDataSet.BoPhan);


        }

        private void boPhanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.boPhanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLNSDataSet);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cls.kttrungkhoa(textBox1.Text, "select MaBoPhan from BoPhan"))
                {
                    string insert = "insert into BoPhan values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox3.Text + "')";
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(boPhanDataGridView, "select * from BoPhan");
                }
                else
                {
                    MessageBox.Show("Bộ phận này đã tòn tại ", "Trùng bộ phân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update BoPhan set TenBoPhan=N'" + textBox2.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox3.Text + "' where MaBoPhan='" + textBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(boPhanDataGridView, "select * from BoPhan");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string del = "delete from BoPhan where MaBoPhan='" + textBox1.Text + "'";
            string del1 = "delete from PhongBan where MaBoPhan='" + textBox1.Text + "'";
            //string del = "delete from TblPhongBan where MaPhong=N'" + textBox2.Text + "'";
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(del1);
                cls.thucthiketnoi(del);
                cls.loaddatagridview(boPhanDataGridView, "select * from BoPhan");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boPhanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = boPhanDataGridView.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = boPhanDataGridView.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = boPhanDataGridView.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = boPhanDataGridView.Rows[i].Cells[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void boPhanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
