using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;


namespace QLNhanVien_Nhom7
{
    public partial class FNVCoban : Form
    {
        public FNVCoban()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        public static SqlConnection Con;
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị

        }
        private void FNVCoban_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=MSI;Initial Catalog=QLNS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker3.CustomFormat = " MM / dd / yyyy ";
            dateTimePicker4.CustomFormat = " MM / dd / yyyy ";
            cls.loadcombobox(comboBox4, "select MaLuong from BangLuongCTy", 0);

            FNVCoban.FillCombo("SELECT MaBoPhan FROM BoPhan", comboBox2, "MaBoPhan", "MaBoPhan");
            comboBox2.SelectedIndex = -1;

            cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string insert = "insert into TTNVCoBan values(N'" + comboBox2.Text + "',N'" + comboBox3.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "',N'" + comboBox4.Text + "',N'" + dateTimePicker1.Text + "',N'" + comboBox1.Text + "',N'" + textBox8.Text + "',N'" + textBox9.Text + "',N'" + textBox11.Text + "',N'" + textBox12.Text + "',N'" + textBox14.Text + "',N'" + textBox15.Text + "',N'" + dateTimePicker3.Text + "',N'" + dateTimePicker4.Text + "',N'" + textBox19.Text + "')";

            if ((!cls.kttrungkhoa(textBox3.Text, "select MaNV from TTNVCoBan")) && (!cls.kttrungkhoa(textBox9.Text, "select CMTND from NVThoiViec")))
            {
                if (textBox3.Text != "" && textBox9.Text != "")
                {
                    cls.thucthiketnoi(insert);
                    tTNVCoBanDataGridView.Refresh();
                    cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
                    MessageBox.Show("Thêm thành công");
                }
                else if (textBox3.Text == "") MessageBox.Show("Bạn chưa nhập Mã nhân viên");
                else if (textBox9.Text == "") MessageBox.Show("Bạn chưa nhập số CMTND");
            }
            else if ((!cls.kttrungkhoa(textBox3.Text, "select MaNV from TTNVCoBan")) && (cls.kttrungkhoa(textBox9.Text, "select CMTND from NVThoiViec")))
            {
                if (MessageBox.Show("Nhân viên này đã từng làm ở công ty, bạn có chắc muốn thêm?", "Thêm thất bại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
                    MessageBox.Show("Thêm thành công");
                    string delete = "delete from NVThoiViec where CMTND='" + textBox9.Text + "'";
                    cls.thucthiketnoi(delete);
                }
            }
            else if ((cls.kttrungkhoa(textBox3.Text, "select MaNV from TTNVCoBan")) && (!cls.kttrungkhoa(textBox9.Text, "select CMTND from NVThoiViec")))
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string ine = "insert into TTCaNhan(MaNV,HoTen) select MaNV,HoTen from TTNVCoBan where MaNV='" + textBox3.Text + "'";
            if ((!cls.kttrungkhoa(textBox3.Text, "select MaNV from TTCaNhan")))
            {
                if (textBox3.Text != "")
                {
                    cls.thucthiketnoi(ine);
                    tTNVCoBanDataGridView.Refresh();
                }
                else MessageBox.Show("Bạn chưa nhập Mã nhân viên");
            }
            else
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string ins = "insert into CongKhoiDieuhanh(MaNV,HoTen,MaLuong) select MaNV,HoTen,MaLuong from TTNVCoBan where MaNV='" + textBox3.Text + "'";
            if ((!cls.kttrungkhoa(textBox3.Text, "select MaNV from CongKhoiDieuHanh")))
            {
                if (textBox3.Text != "")
                {
                    cls.thucthiketnoi(ins);
                    tTNVCoBanDataGridView.Refresh();
                }
                else MessageBox.Show("Bạn chưa nhập Mã nhân viên");
            }
            else
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string updata = " update CongKhoiDieuHanh set TenPhong = (select top(1) TenPhong from PhongBan a,TTNVCoBan b where a.MaPhong=b.MaPhong and a.MaPhong=N'" + comboBox3.Text + "' group by TenPhong) where MaNV='" + textBox3.Text + "'";

            cls.thucthiketnoi(updata);
            tTNVCoBanDataGridView.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string update = "update TTNVCoBan set MaBoPhan=N'" + comboBox2.Text + "',MaPhong=N'" + comboBox3.Text + "',HoTen=N'" + textBox4.Text + "',MaLuong=N'" + comboBox4.Text + "',NgaySinh='" + dateTimePicker1.Text + "',GioiTinh=N'" + comboBox1.Text + "',TTHonNhan=N'" + textBox8.Text + "',CMTND=N'" + textBox9.Text + "',NoiCap=N'" + textBox11.Text + "',ChucVu=N'" + textBox12.Text + "',LoaiHD=N'" + textBox14.Text + "',ThoiGian=N'" + textBox15.Text + "',NgayKy='" + dateTimePicker3.Text + "',NgayHetHan='" + dateTimePicker4.Text + "',GhiChu=N'" + textBox19.Text + "' where MaNV=N'" + textBox3.Text + "'";
            cls.thucthiketnoi(update);
            tTNVCoBanDataGridView.Refresh();
            cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
            MessageBox.Show("Sửa thảnh công");
          
            string upd = "update CongKhoiDieuHanh set HoTen=N'" + textBox4.Text + "',MaLuong=N'" + comboBox4.Text + "' where MaNV=N'" + textBox3.Text + "'";
            cls.thucthiketnoi(upd);
            cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
            string ds = "update CongKhoiDieuHanh set TenPhong = (select top(1) TenPhong from PhongBan a,TTNVCoBan b where a.MaPhong=b.MaPhong and a.MaPhong=N'" + comboBox3.Text + "' group by TenPhong) where MaNV='" + textBox3.Text + "'";

            cls.thucthiketnoi(ds);
            tTNVCoBanDataGridView.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string insert = "insert into NVThoiViec(HoTen,CMTND,LyDo) select HoTen,CMTND,GhiChu from TTNVCoBan where MaNV='" + textBox3.Text + "'";
            {
                cls.thucthiketnoi(insert);
                cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
            }
            MessageBox.Show("Thêm thành công dữ liệu vào bảng NVThoiViec");


            string delete = "delete from TTNVCoBan where MaNV=N'" + textBox3.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(tTNVCoBanDataGridView, "select * from TTNVCoBan");
            }
            MessageBox.Show("Đã xóa dữ liệu ");


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNVCoban.FillCombo("select p.MaPhong from BoPhan b,PhongBan p where b.MaBoPhan=p.MaBoPhan and p.MaBoPhan=N'" + comboBox2.SelectedValue + "'", comboBox3, "MaPhong", "MaPhong");
            comboBox3.DisplayMember = "MaPhong";
            comboBox3.ValueMember = "MaPhong";
        }

        private void tTNVCoBanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                comboBox2.Text = tTNVCoBanDataGridView.Rows[hang].Cells[0].Value.ToString();
                comboBox3.Text = tTNVCoBanDataGridView.Rows[hang].Cells[1].Value.ToString();
                textBox3.Text = tTNVCoBanDataGridView.Rows[hang].Cells[2].Value.ToString();
                textBox4.Text = tTNVCoBanDataGridView.Rows[hang].Cells[3].Value.ToString();
                comboBox4.Text = tTNVCoBanDataGridView.Rows[hang].Cells[4].Value.ToString();

                dateTimePicker1.Text = tTNVCoBanDataGridView.Rows[hang].Cells[5].Value.ToString();
                comboBox1.Text = tTNVCoBanDataGridView.Rows[hang].Cells[6].Value.ToString();
                textBox8.Text = tTNVCoBanDataGridView.Rows[hang].Cells[7].Value.ToString();
                textBox9.Text = tTNVCoBanDataGridView.Rows[hang].Cells[8].Value.ToString();
                textBox11.Text = tTNVCoBanDataGridView.Rows[hang].Cells[9].Value.ToString();
                textBox12.Text = tTNVCoBanDataGridView.Rows[hang].Cells[10].Value.ToString();
                textBox14.Text = tTNVCoBanDataGridView.Rows[hang].Cells[11].Value.ToString();
                textBox15.Text = tTNVCoBanDataGridView.Rows[hang].Cells[12].Value.ToString();
                dateTimePicker3.Text = tTNVCoBanDataGridView.Rows[hang].Cells[13].Value.ToString();
                dateTimePicker4.Text = tTNVCoBanDataGridView.Rows[hang].Cells[14].Value.ToString();
                textBox19.Text = tTNVCoBanDataGridView.Rows[hang].Cells[15].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }
}
