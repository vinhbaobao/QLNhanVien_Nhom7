using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace QLNhanVien_Nhom7
{
    public partial class FChedo : Form
    {
        public FChedo()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txt1, "select * from TTNVCoBan where MaNV=N'" + comboBox1.Text + "'", 4);
            cls.loadtextboxchiso(txt2, "select * from SoBH where MaNV=N'" + comboBox1.Text + "'", 2);
            cls.loaddatetime(dt1, "select * from SoBH where MaNV=N'" + comboBox1.Text + "'", 3);
            cls.loadtextboxchiso(txt3, "select * from SoBH where MaNV=N'" + comboBox1.Text + "'", 4);
            cls.loadtextboxchiso(txt4, "select * from SoBH where MaNV=N'" + comboBox1.Text + "'", 5);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txt5, "select * from TTNVCoBan where MaNV=N'" + comboBox2.Text + "'", 0);
            cls.loadtextboxchiso(txt6, "select * from TTNVCoBan where MaNV=N'" + comboBox2.Text + "'", 1);
            cls.loadtextboxchiso(txt7, "select * from TTNVCoBan where MaNV=N'" + comboBox2.Text + "'", 3);
            cls.loadtextboxchiso(txt8, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 8);
            cls.loadtextboxchiso(txt9, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 9);
            cls.loaddatetime(dt2, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 4);
            cls.loaddatetime(dt3, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 5);
            cls.loaddatetime(dt4, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 6);
            cls.loaddatetime(dt5, "select * from ThaiSan where MaNV=N'" + comboBox2.Text + "'", 7);
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

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
            try
            {

                string insert = "insert into SoBH values(N'" + comboBox1.Text + "',N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + dt1.Text + "',N'" + txt3.Text + "',N'" + txt4.Text + "')";
                if (!cls.kttrungkhoa(txt1.Text, "select MaSoBH from SoBH"))
                {
                    if (txt1.Text != "")
                    {
                        cls.thucthiketnoi(insert);
                        soBHDataGridView.Refresh();
                        cls.loaddatagridview1(soBHDataGridView, ds1, "select * from SoBH");
                        MessageBox.Show("Thêm thành công");
                    }
                    else MessageBox.Show("Bạn chưa nhập Mã số bảo hiểm");
                }
                else
                    MessageBox.Show("Mã số bảo hiểm này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string update = "update SoBH set NgayCapSo=N'" + dt1.Text + "',NoiCapSo=N'" + txt3.Text + "',GhiChu=N'" + txt4.Text + "' where MaNV=N'" + comboBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview1(soBHDataGridView, ds1, "select * from SoBH");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string delete = "delete from SoBH where MaNV'" + comboBox1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview1(soBHDataGridView, ds1, "select * from SoBH");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox4.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string insert = "insert into ThaiSan values(N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + comboBox2.Text + "',N'" + txt7.Text + "',N'" + dt2.Text + "',N'" + dt3.Text + "',N'" + dt4.Text + "',N'" + dt5.Text + "',N'" + txt8.Text + "',N'" + txt9.Text + "')";
            if (!cls.kttrungkhoa(comboBox2.Text, "select MaNV from ThaiSan"))
            {
                if (comboBox2.Text != "")
                {
                    cls.thucthiketnoi(insert);
                    soBHDataGridView.Refresh();
                    cls.loaddatagridview1(thaiSanDataGridView, ds2, "select * from ThaiSan");
                    MessageBox.Show("Thêm thành công");
                }
                else MessageBox.Show("Bạn chưa nhập Mã  nhân vien");
            }
            else
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update ThaiSan set HoTen=N'" + txt7.Text + "',NgaySinh=N'" + dt2.Text + "',NgayVeSom=N'" + dt3.Text + "',NgayNghiSinh=N'" + dt4.Text + "',NgayLamTroLai='" + dt5.Text + "',TroCapCTy=N'" + txt8.Text + "',GhiChu=N'" + txt9.Text + "' where MaNV=N'" + comboBox2.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview1(thaiSanDataGridView, ds2, "select * from ThaiSan");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string delete = "delete from ThaiSan where MaNV=N'" + comboBox2.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview1(thaiSanDataGridView, ds2, "select * from ThaiSan");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FChedo_Load(object sender, EventArgs e)
        {
            dt1.CustomFormat = " MM / dd / yyyy ";
            dt2.CustomFormat = " MM / dd / yyyy ";
            dt3.CustomFormat = " MM / dd / yyyy ";
            dt4.CustomFormat = " MM / dd / yyyy ";
            dt5.CustomFormat = " MM / dd / yyyy ";
            cls.loadcombobox(comboBox1, "select * from TTNVCoBan", 2);
            cls.loadcombobox(comboBox2, "select * from TTNVCoBan", 2);
            cls.loaddatagridview1(soBHDataGridView, ds1, "select * from SoBH");
            cls.loaddatagridview1(thaiSanDataGridView, ds2, "select * from ThaiSan");
        }

        private void soBHDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            //MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());

            comboBox1.Text = soBHDataGridView.Rows[i].Cells[0].Value.ToString();
            txt1.Text = soBHDataGridView.Rows[i].Cells[1].Value.ToString();
            txt2.Text = soBHDataGridView.Rows[i].Cells[2].Value.ToString();
            dt1.Text = soBHDataGridView.Rows[i].Cells[3].Value.ToString();
            txt3.Text = soBHDataGridView.Rows[i].Cells[4].Value.ToString();
            txt4.Text = soBHDataGridView.Rows[i].Cells[5].Value.ToString();
        }

        private void thaiSanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt5.Text = thaiSanDataGridView.Rows[i].Cells[0].Value.ToString();
            txt6.Text = thaiSanDataGridView.Rows[i].Cells[1].Value.ToString();
            comboBox2.Text = thaiSanDataGridView.Rows[i].Cells[2].Value.ToString();
            txt7.Text = thaiSanDataGridView.Rows[i].Cells[3].Value.ToString();
            dt2.Text = thaiSanDataGridView.Rows[i].Cells[4].Value.ToString();
            dt3.Text = thaiSanDataGridView.Rows[i].Cells[5].Value.ToString();
            dt4.Text = thaiSanDataGridView.Rows[i].Cells[6].Value.ToString();
            dt5.Text = thaiSanDataGridView.Rows[i].Cells[7].Value.ToString();
            txt8.Text = thaiSanDataGridView.Rows[i].Cells[8].Value.ToString();
            txt9.Text = thaiSanDataGridView.Rows[i].Cells[9].Value.ToString();
        }
    }
}
