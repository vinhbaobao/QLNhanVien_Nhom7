namespace QLNhanVien_Nhom7
{
    partial class BanCongNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tTNVCoBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNSDataSet = new QLNhanVien_Nhom7.QLNSDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tTNVCoBanTableAdapter = new QLNhanVien_Nhom7.QLNSDataSetTableAdapters.TTNVCoBanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tTNVCoBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tTNVCoBanBindingSource
            // 
            this.tTNVCoBanBindingSource.DataMember = "TTNVCoBan";
            this.tTNVCoBanBindingSource.DataSource = this.qLNSDataSet;
            // 
            // qLNSDataSet
            // 
            this.qLNSDataSet.DataSetName = "QLNSDataSet";
            this.qLNSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tTNVCoBanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhanVien_Nhom7.r.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(798, 441);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tTNVCoBanTableAdapter
            // 
            this.tTNVCoBanTableAdapter.ClearBeforeFill = true;
            // 
            // BanCongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BanCongNV";
            this.Text = "BanCongNV";
            this.Load += new System.EventHandler(this.BanCongNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tTNVCoBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QLNSDataSet qLNSDataSet;
        private System.Windows.Forms.BindingSource tTNVCoBanBindingSource;
        private QLNSDataSetTableAdapters.TTNVCoBanTableAdapter tTNVCoBanTableAdapter;
    }
}