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
    public partial class FPhongBan : Form
    {
        public FPhongBan()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void phongBanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phongBanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLNSDataSet);

        }

        private void FPhongBan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            cls.loaddatagridview(phongBanDataGridView, "select * from PhongBan");
            cls.loadcombobox(comboBox1, "select * from BoPhan", 0);
            // TODO: This line of code loads data into the 'qLNSDataSet.PhongBan' table. You can move, or remove it, as needed.
            this.phongBanTableAdapter.Fill(this.qLNSDataSet.PhongBan);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
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
                if (!cls.kttrungkhoa(textBox2.Text, "select MaPhong from PhongBan"))
                {
                    string insert = "insert into PhongBan values('" + comboBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + dateTimePicker1.Text + "',N'" + textBox5.Text + "')";
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(phongBanDataGridView, "select * from PhongBan");
                }
                else
                {
                    MessageBox.Show("Mã phòng này đã tòn tại bạn có thể thử mã phòng khác", "Trùng mã phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string update = "update PhongBan set MaBoPhan=N'" + comboBox1.Text + "',TenPhong=N'" + textBox3.Text + "',NgayThanhLap=N'" + dateTimePicker1.Text + "',GhiChu=N'" + textBox5.Text + "' where MaPhong=N'" + textBox2.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(phongBanDataGridView, "select * from PhongBan");
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
                string del = "delete from PhongBan where MaPhong=N'" + textBox2.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(phongBanDataGridView, "select * from PhongBan");
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phongBanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            comboBox1.Text = phongBanDataGridView.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = phongBanDataGridView.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = phongBanDataGridView.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = phongBanDataGridView.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = phongBanDataGridView.Rows[i].Cells[4].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
