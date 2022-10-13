using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLNhanVien_Nhom7
{
    public partial class BanCongNV : Form
    {
        public BanCongNV()
        {
            InitializeComponent();
        }
        private void BanCongNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNSDataSet.TTNVCoBan' table. You can move, or remove it, as needed.
            this.tTNVCoBanTableAdapter.Fill(this.qLNSDataSet.TTNVCoBan);


            this.reportViewer1.RefreshReport();
          
     
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void tTNVCoBanBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
