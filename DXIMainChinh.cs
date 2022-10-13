using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLNhanVien_Nhom7
{
    public partial class DXIMainChinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public DXIMainChinh()
        {
            InitializeComponent();
        }
        public int k = 1;
        public static string quyen;
  

        private void Quanly_Click(object sender, EventArgs e)
        {

        }

        private void Phongbann_Click(object sender, EventArgs e)
        {
            FPhongBan fdmk = new FPhongBan();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdmk.TopLevel = false;
            fdmk.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdmk);
            fdmk.Show();
        }

        private void DXIMainChinh_Load(object sender, EventArgs e)
        {
            if (quyen == "Admin")
            {
                Element2.Enabled = true;
                Element3.Enabled = true;
                Element4.Enabled = true;
                Adminn.Enabled = true;
            }
            else if (quyen == "user")
            {
                Element2.Enabled = true;
                Element3.Enabled = true;
                Element4.Enabled = true;
                Adminn.Enabled = false;
            }
        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            FDangNhap dangnhap = new FDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            dangnhap.Show();
        }

        private void DoiMatkhauu_Click(object sender, EventArgs e)
        {
            FDoiMatKhau fdmk = new FDoiMatKhau();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdmk.TopLevel = false;
            fdmk.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdmk);
            fdmk.Show();
        }

        private void Adminn_Click(object sender, EventArgs e)
        {
            FDangKi dangKi = new FDangKi();
            this.Hide();
            dangKi.ShowDialog();
            dangKi.Show();
        }

        private void Nhansu_Click(object sender, EventArgs e)
        {
            FNVCoban fdcb = new FNVCoban();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdcb.TopLevel = false;
            fdcb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdcb);
            fdcb.Show();
        }

        private void Thongtin_Click(object sender, EventArgs e)
        {
            FThongtincanhan fdpb = new FThongtincanhan();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void BoPhan_Click(object sender, EventArgs e)
        {
            FBoPhan fdpb = new FBoPhan();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            FBangCong fdpb = new FBangCong();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void BangluongCTy_Click(object sender, EventArgs e)
        {
            fLuong fdpb = new fLuong();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void chedo_Click(object sender, EventArgs e)
        {
            FChedo fdpb = new FChedo();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void XinViec_Click(object sender, EventArgs e)
        {
            FHosoSViec fdpb = new FHosoSViec();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void Baocao_Click(object sender, EventArgs e)
        {
            BanCongNV banCongNV = new BanCongNV();
            panel_show.Show();
            panel_show.Controls.Clear();
            banCongNV.TopLevel = false;
            banCongNV.Dock = DockStyle.Fill;
            panel_show.Controls.Add(banCongNV);
            banCongNV.Show();
        }

        private void TraCuu_Click(object sender, EventArgs e)
        {
            FTimkiem fdpb = new FTimkiem();
            panel_show.Show();
            panel_show.Controls.Clear();
            fdpb.TopLevel = false;
            fdpb.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fdpb);
            fdpb.Show();
        }

        private void TroGiup_Click(object sender, EventArgs e)
        {

        }

        private void panel_show_Click(object sender, EventArgs e)
        {

        }
    }
}
