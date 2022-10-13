using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien_Nhom7
{
    public partial class fLuong : Form
    {
        public fLuong()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        DataSet ds1 = new DataSet();
        private void fLuong_Load(object sender, EventArgs e)
        {

            dateTimePicker6.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker2.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker3.CustomFormat = " MM / dd / yyyy ";
            DataSet ds1 = new DataSet();
            cls.loaddatagridview(bangLuongCTyDataGridView, "select * from BangLuongCTy");
            cls.loaddatagridview1(tangLuongDataGridView, ds1, "select * from TangLuong");
            cls.loadcombobox(comboBox1, "select * from TTNVCoBan", 2);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #region Hoạt Động nút
        //rs mới

        //them
        private void button1_Click(object sender, EventArgs e)

        {
            try
            {

                string insert = "insert into BangLuongCTy values(N'" + txt1.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + dateTimePicker1.Text + "',N'" + txt6.Text + "',N'" + dateTimePicker2.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + dateTimePicker3.Text + "',N'" + txt9.Text + "')";
                if (!cls.kttrungkhoa(txt1.Text, "select MaLuong from BangLuongCTy"))
                {
                    if (txt1.Text != "")
                    {
                        cls.thucthiketnoi(insert);
                        bangLuongCTyDataGridView.Refresh();
                        cls.loaddatagridview(bangLuongCTyDataGridView, "select * from BangLuongCTy");
                        MessageBox.Show("Thêm thành công");
                    }
                    else MessageBox.Show("Bạn chưa nhập Mã Lương");
                }
                else
                    MessageBox.Show("Mã Lương này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string update = "update TangLuongCTy set LCB=N'" + txt4.Text + "',PCChucVu=N'" + txt5.Text + "',NgayNhap='" + dateTimePicker1.Text + "',LCBMoi=N'" + txt6.Text + "',NgaySua=N'" + dateTimePicker2.Text + "',LyDo=N'" + txt7.Text + "',PCCVuMoi='" + txt8.Text + "',NgaySuaPC=N'" + dateTimePicker3.Text + "',GhiChu=N'" + txt9.Text + "' where MaLuong=N'" + txt1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(bangLuongCTyDataGridView, "select * from BangLuongCTy");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string delete = "delete from BangLuongCTy where MaLuong=N'" + txt1.Text + "'";
            string delete1 = "delete from SoBH where MaLuong=N'" + txt1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete1);
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(bangLuongCTyDataGridView, "select * from BangLuongCTy");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button11_Click_1(object sender, EventArgs e)
        {

        }
        private void button12_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region xuất chữ
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dg2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        private void tangLuongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void bangLuongCTyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt1.Text = bangLuongCTyDataGridView.Rows[i].Cells[0].Value.ToString();
            txt4.Text = bangLuongCTyDataGridView.Rows[i].Cells[1].Value.ToString();
            txt5.Text = bangLuongCTyDataGridView.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = bangLuongCTyDataGridView.Rows[i].Cells[3].Value.ToString();
            txt6.Text = bangLuongCTyDataGridView.Rows[i].Cells[4].Value.ToString();
            dateTimePicker2.Text = bangLuongCTyDataGridView.Rows[i].Cells[5].Value.ToString();
            txt7.Text = bangLuongCTyDataGridView.Rows[i].Cells[6].Value.ToString();
            txt8.Text = bangLuongCTyDataGridView.Rows[i].Cells[7].Value.ToString();
            dateTimePicker3.Text = bangLuongCTyDataGridView.Rows[i].Cells[8].Value.ToString();
            txt9.Text = bangLuongCTyDataGridView.Rows[i].Cells[9].Value.ToString();
        }

        private void tangLuongDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            //MessageBox.Show(dg2.Rows[i].Cells[0].Value.ToString());

            comboBox1.Text = tangLuongDataGridView.Rows[i].Cells[0].Value.ToString();
            txt10.Text = tangLuongDataGridView.Rows[i].Cells[1].Value.ToString();
            txt11.Text = tangLuongDataGridView.Rows[i].Cells[2].Value.ToString();
            txt12.Text = tangLuongDataGridView.Rows[i].Cells[3].Value.ToString();
            textBox1.Text = tangLuongDataGridView.Rows[i].Cells[4].Value.ToString();
            txt15.Text = tangLuongDataGridView.Rows[i].Cells[5].Value.ToString();
            dateTimePicker6.Text = tangLuongDataGridView.Rows[i].Cells[6].Value.ToString();
            txt18.Text = tangLuongDataGridView.Rows[i].Cells[7].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cls.loadtextbox(txt10, "select HoTen from TTNVCoBan where MaNV='" + comboBox1.Text + "'");
            cls.loadtextbox(txt11, "select GioiTinh from TTNVCoBan where MaNV='" + comboBox1.Text + "'");
            cls.loadtextbox(txt12, "select ChucVu from TTNVCoBan where MaNV='" + comboBox1.Text + "'");
            cls.loadtextbox(textBox1, "select MaLuong from CongKhoiDieuHanh where MaNV='" + comboBox1.Text + "'");
            cls.loadtextbox(txt15, "select MaLuongMoi from TangLuong where MaNV='" + comboBox1.Text + "'");
            cls.loadtextbox(txt18, "select LyDo from TangLuong where MaNV='" + comboBox1.Text + "'");
            cls.loaddatetime(dateTimePicker6, "select NgayTang from TangLuong where MaNV='" + comboBox1.Text + "'", 0);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                string insert = "insert into TangLuong values(N'" + comboBox1.Text + "',N'" + txt10.Text + "',N'" + txt11.Text + "',N'" + txt12.Text + "',N'" + textBox1.Text + "',N'" + txt15.Text + "',N'" + dateTimePicker6.Text + "',N'" + txt18.Text + "')";
                if (!cls.kttrungkhoa(comboBox1.Text, "select MaNV from TangLuong"))
                {
                    if (comboBox1.Text != "")
                    {
                        cls.thucthiketnoi(insert);
                        tangLuongDataGridView.Refresh();
                        cls.loaddatagridview(tangLuongDataGridView, "select * from TangLuong");
                        MessageBox.Show("Thêm thành công");
                    }
                    else MessageBox.Show("Bạn chưa chọn mà nhân viên");
                }
                else
                    MessageBox.Show("Nhân viên này bạn đã nhập dữ liêu rồi", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
            string up = "update TTNVCoBan set MaLuong=N'" + txt15.Text + "' where MaNV='" + comboBox1.Text + "'";
            cls.thucthiketnoi(up);
            cls.loaddatagridview1(tangLuongDataGridView, ds1, "select * from TangLuong");
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {

                string update = "update TangLuong set HoTen=N'" + txt10.Text + "',GioiTinh=N'" + txt11.Text + "',ChucVu=N'" + txt12.Text + "',MaLuongCu='" + textBox1.Text + "',MaLuongMoi=N'" + txt15.Text + "',NgayTang='" + dateTimePicker6.Text + "',LyDo=N'" + txt18.Text + "' where MaNV=N'" + comboBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview1(tangLuongDataGridView, ds1, "select * from TangLuong");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
            string up = "update TTNVCoBan set MaLuong=N'" + txt15.Text + "' where MaNV='" + comboBox1.Text + "'";
            cls.thucthiketnoi(up);
            cls.loaddatagridview1(tangLuongDataGridView, ds1, "select * from TangLuong");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            string delete = "delete from TangLuong where MaNV=N'" + comboBox1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview1(tangLuongDataGridView, ds1, "select * from TangLuong");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
