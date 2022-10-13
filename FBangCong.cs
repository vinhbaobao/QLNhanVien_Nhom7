using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLNhanVien_Nhom7
{
    public partial class FBangCong : Form
    {
        public FBangCong()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        public static SqlConnection Con;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txt2, "select * from PhongBan b,HoSoThuViec a where a.MaPhong=b.MaPhong and MaNVTV='" + cb1.Text + "'", 2);
            cls.loadtextboxchiso(txt1, "select * from BoPhan,PhongBan where PhongBan.MaBoPhan=BoPhan.MaBoPhan and TenPhong=N'" + txt2.Text + "'", 1);
            cls.loadtextboxchiso(txt3, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 3);
            cls.loadtextboxchiso(txt4, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 4);
            cls.loadtextboxchiso(txt5, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 5);
            cls.loadtextboxchiso(txt6, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 6);
            cls.loadtextboxchiso(txt7, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 7);
            cls.loadtextboxchiso(txt8, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 8);
            cls.loadtextboxchiso(textBox3, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 9);
            cls.loadtextboxchiso(txt9, "select * from BangCongThuViec where MaNVTV='" + cb1.Text + "'", 10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string insert = "insert into BangCongThuViec values(N'" + txt1.Text + "',N'" + txt2.Text + "',N'" + cb1.Text + "',N'" + txt3.Text + "',N'" + txt4.Text + "',N'" + txt5.Text + "',N'" + txt6.Text + "',N'" + txt7.Text + "',N'" + txt8.Text + "',N'" + textBox3.Text + "',N'" + txt9.Text + "')";
            if (!cls.kttrungkhoa(cb1.Text, "select MaNVTV from BangCongThuViec"))
            {
                if (cb1.Text != "")
                {
                    cls.thucthiketnoi(insert);
                    bangCongThuViecDataGridView.Refresh();
                    cls.loaddatagridview1(bangCongThuViecDataGridView, ds1, "select * from BangCongThuViec");

                }
                else MessageBox.Show("Bạn chưa nhập Mã nhân viên");
            }
            else
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update BangCongThuViec set TenBoPhan=N'" + txt1.Text + "',TenPhong=N'" + txt2.Text + "',LuongTViec=N'" + txt3.Text + "',Thang=N'" + txt4.Text + "',Nam='" + txt5.Text + "',SoNgayCong=N'" + txt6.Text + "',SoNgayNghi=N'" + txt7.Text + "',SoGioLamThem=N'" + txt8.Text + "',Luong=N'" + textBox3.Text + "',GhiChu='" + txt9.Text + "' where MaNVTV=N'" + cb1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview1(bangCongThuViecDataGridView, ds1, "select * from BangCongThuViec");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "delete from BangCongThuViec where MaNVTV=N'" + cb1.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(delete);
                    cls.loaddatagridview1(bangCongThuViecDataGridView, ds1, "select * from BangCongThuViec");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int l = Convert.ToInt32(txt3.Text);
            int nc = Convert.ToInt32(txt6.Text);
            int lt = Convert.ToInt32(txt8.Text);
            float luong = ((l / 26) * nc + (lt * 40000));
            textBox3.Text = luong.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bangCongThuViecDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt1.Text = bangCongThuViecDataGridView.Rows[i].Cells[0].Value.ToString();
            txt2.Text = bangCongThuViecDataGridView.Rows[i].Cells[1].Value.ToString();
            cb1.Text = bangCongThuViecDataGridView.Rows[i].Cells[2].Value.ToString();
            txt3.Text = bangCongThuViecDataGridView.Rows[i].Cells[3].Value.ToString();
            txt4.Text = bangCongThuViecDataGridView.Rows[i].Cells[4].Value.ToString();
            txt5.Text = bangCongThuViecDataGridView.Rows[i].Cells[5].Value.ToString();
            txt6.Text = bangCongThuViecDataGridView.Rows[i].Cells[6].Value.ToString();
            txt7.Text = bangCongThuViecDataGridView.Rows[i].Cells[7].Value.ToString();
            txt8.Text = bangCongThuViecDataGridView.Rows[i].Cells[8].Value.ToString();
            textBox3.Text = bangCongThuViecDataGridView.Rows[i].Cells[9].Value.ToString();
            txt9.Text = bangCongThuViecDataGridView.Rows[i].Cells[10].Value.ToString();
        }

        private void congKhoiDieuHanhDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cb2.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[0].Value.ToString();
            comboBox10.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[1].Value.ToString();
            txt53.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[2].Value.ToString();
            txt50.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[3].Value.ToString();
            txt10.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[4].Value.ToString();      
            txt11.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[5].Value.ToString();
            txt12.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[6].Value.ToString();
            textBox1.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[7].Value.ToString();
            textBox2.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[8].Value.ToString();
            txt13.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[9].Value.ToString();
            txt14.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[10].Value.ToString();
            txt15.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[11].Value.ToString();
            txt16.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[12].Value.ToString();
            txt17.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[13].Value.ToString();
            txt52.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[14].Value.ToString();
            txt18.Text = congKhoiDieuHanhDataGridView.Rows[i].Cells[15].Value.ToString();
        }

        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txt50, "select * from TTNVCoBan where MaNV='" + cb2.Text + "'", 4);
            cls.loadtextboxchiso(txt10, "select * from BangLuongCTy l where l.MaLuong='" + txt50.Text + "'", 1);
            cls.loadtextboxchiso(txt11, "select * from BangLuongCTy l where l.MaLuong='" + txt50.Text + "'", 2);
            //cls.loadtextboxchiso(txt10, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 4);
            cls.loadtextboxchiso(txt53, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 2);
            //cls.loadtextboxchiso(txt51, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 3);
            // cls.loadtextboxchiso(txt11, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 5);
            cls.loadtextboxchiso(txt12, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 6);
            cls.loadtextboxchiso(textBox1, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 7);
            cls.loadtextboxchiso(textBox2, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 8);
            cls.loadtextboxchiso(txt13, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 9);
            cls.loadtextboxchiso(txt14, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 10);
            cls.loadtextboxchiso(txt15, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 11);
            cls.loadtextboxchiso(txt16, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 12);
            cls.loadtextboxchiso(txt17, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 13);
            cls.loadtextboxchiso(txt52, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 14);
            cls.loadtextboxchiso(txt18, "select * from CongKhoiDieuHanh where MaNV='" + cb2.Text + "'", 15);
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            FBangCong.FillCombo("select MaNV from CongKhoiDieuHanh where TenPhong=(select top(1) TenPhong from PhongBan a, TTNVCoBan b where a.MaPhong=b.MaPhong and a.TenPhong=N'" + comboBox10.SelectedValue + "' group by TenPhong)", cb2, "MaNV", "MaNV");
            cb2.DisplayMember = "MaNV";
            cb2.ValueMember = "MaNV";
            cls.loaddatagridview1(congKhoiDieuHanhDataGridView, ds2, "select * from CongKhoiDieuHanh b where b.TenPhong=N'" + comboBox10.SelectedValue + "'");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox4.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update CongKhoiDieuHanh set MaNV='" + cb2.Text + "', MaLuong=N'" + txt50.Text + "',TenPhong=N'" + comboBox10.Text + "', HoTen=N'" + txt53.Text + "',LCB=N'" + txt10.Text + "',PCChucVu=N'" + txt11.Text + "',PCapKhac=N'" + txt12.Text + "',Thuong=N'" + textBox1.Text + "',KyLuat='" + textBox2.Text + "',Thang=N'" + txt13.Text + "',Nam='" + txt14.Text + "',SoNgayCongThang=N'" + txt15.Text + "',SoNgayNghi=N'" + txt16.Text + "',SoGioLamThem=N'" + txt17.Text + "',Luong=N'" + txt52.Text + "',GhiChu='" + txt18.Text + "' where MaNV=N'" + cb2.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview1(congKhoiDieuHanhDataGridView, ds2, "select * from CongKhoiDieuHanh where TenPhong=N'" + comboBox10.SelectedValue + "'");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "delete from CongKhoiDieuHanh where MaNV=N'" + cb2.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(delete);
                    cls.loaddatagridview1(congKhoiDieuHanhDataGridView, ds2, "select * from CongKhoiDieuHanh");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int lcb = Convert.ToInt32(txt10.Text);
            int pc = Convert.ToInt32(txt11.Text);
            int pck = Convert.ToInt32(txt12.Text);
            int nc = Convert.ToInt32(txt15.Text);
            int lt = Convert.ToInt32(txt17.Text);
            int th = Convert.ToInt32(textBox1.Text);
            int kl = Convert.ToInt32(textBox2.Text);

            float luong = ((lcb / 26) * nc + (lt * 40000) + pc + pck + th - kl);
            txt52.Text = luong.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FBangCong_Load(object sender, EventArgs e)
        {
            DateTime dt1, dt2;
            dt1 = new DateTime(2009, 5, 10);
            dt2 = new DateTime(2009, 10, 10);
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=MSI;Initial Catalog=QLNS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cls.loadcombobox(cb1, "select MaNVTV from HoSoThuViec", 0);


            FBangCong.FillCombo("SELECT TenPhong FROM PhongBan", comboBox10, "TenPhong", "TenPhong");
            comboBox10.SelectedIndex = -1;

            cls.loaddatagridview1(bangCongThuViecDataGridView, ds1, "select * from BangCongThuViec");
           cls.loaddatagridview1(congKhoiDieuHanhDataGridView, ds2, "select * from CongKhoiDieuHanh ");


        }

        private void txt50_TextChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txt10, "select * from BangLuongCTy l where l.MaLuong='" + txt50.Text + "'", 1);



            String i = "select LCB from BangLuongCTy l where l.MaLuong ='" + txt50.Text + "'" ;
            cls.thucthiketnoi(i);



            //thử xem
        }

        private void txt53_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void txt10_TextChanged(object sender, EventArgs e)
        {
            //string i="select LCB from BangLuongCTy l where l.MaLuong ='"+txt50.Text+"'";
            //txt10.Text = i.ToString();

        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt18_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
