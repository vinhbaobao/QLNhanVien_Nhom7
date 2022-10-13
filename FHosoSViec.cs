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
    public partial class FHosoSViec : Form
    {
        public FHosoSViec()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();

        private void FHosoSViec_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker2.CustomFormat = " MM / dd / yyyy ";
            cls.loaddatagridview(hoSoThuViecDataGridView, "select * from HoSoThuViec");
            cls.loadcombobox(comboBox1, "select * from PhongBan", 1);
        }

        private void hoSoThuViecDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            comboBox1.Text = hoSoThuViecDataGridView.Rows[i].Cells[0].Value.ToString();
            txt1.Text = hoSoThuViecDataGridView.Rows[i].Cells[1].Value.ToString();
            txt2.Text = hoSoThuViecDataGridView.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = hoSoThuViecDataGridView.Rows[i].Cells[3].Value.ToString();
            txt4.Text = hoSoThuViecDataGridView.Rows[i].Cells[4].Value.ToString();
            txt5.Text = hoSoThuViecDataGridView.Rows[i].Cells[5].Value.ToString();
            txt6.Text = hoSoThuViecDataGridView.Rows[i].Cells[6].Value.ToString();
            txt7.Text = hoSoThuViecDataGridView.Rows[i].Cells[7].Value.ToString();
            txt8.Text = hoSoThuViecDataGridView.Rows[i].Cells[8].Value.ToString();
            dateTimePicker2.Text = hoSoThuViecDataGridView.Rows[i].Cells[9].Value.ToString();
            txt10.Text = hoSoThuViecDataGridView.Rows[i].Cells[10].Value.ToString();
            txt11.Text = hoSoThuViecDataGridView.Rows[i].Cells[11].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!cls.kttrungkhoa(txt1.Text, "select MaNVTV from HoSoThuViec"))
            {
                string insert = "insert into HoSoThuViec values('" + comboBox1.Text + "',N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + dateTimePicker1.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + dateTimePicker2.Text + "',N'" + txt10.Text + "',N'" + txt11.Text + "')";
                cls.thucthiketnoi(insert);
                cls.loaddatagridview(hoSoThuViecDataGridView, "select * from HoSoThuViec");
            }
            else
            {
                MessageBox.Show("Mã nhân viên này đã tòn tại bạn có thể thử mã nhân viên khác", "Trùng mã nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update HoSoThuViec set MaPhong=N'" + comboBox1.Text + "',HoTen=N'" + txt2.Text + "',NgaySinh=N'" + dateTimePicker1.Text + "',GioiTinh=N'" + txt4.Text + "',DiaChi=N'" + txt5.Text + "',TDHocVan=N'" + txt6.Text + "',HocHam=N'" + txt7.Text + "',ViTriThuViec=N'" + txt8.Text + "',NgayTV=N'" + dateTimePicker2.Text + "',ThangTV=N'" + txt10.Text + "',GhiChu=N'" + txt11.Text + "' where MaNVTV='" + txt1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(hoSoThuViecDataGridView, "select * from HoSoThuViec");
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
                string del = "delete from HoSoThuViec where MaNVTV='" + txt1.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(hoSoThuViecDataGridView, "select * from HoSoThuViec");
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
    }
}
