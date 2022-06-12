
namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.DoanhSo
{
    partial class fBaoCaoDoanhSo
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
            this.reportDoanhSo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.baoCaoDoanhSoThuChiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhSoThuChiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDoanhSo
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.baoCaoDoanhSoThuChiBindingSource;
            this.reportDoanhSo.LocalReport.DataSources.Add(reportDataSource1);
            this.reportDoanhSo.LocalReport.ReportEmbeddedResource = "QuanLyNhaHangSQK.Report.BaoCaoDoanhSo.rdlc";
            this.reportDoanhSo.Location = new System.Drawing.Point(94, 12);
            this.reportDoanhSo.Name = "reportDoanhSo";
            this.reportDoanhSo.ServerReport.BearerToken = null;
            this.reportDoanhSo.Size = new System.Drawing.Size(981, 635);
            this.reportDoanhSo.TabIndex = 0;
            // 
            // baoCaoDoanhSoThuChiBindingSource
            // 
            this.baoCaoDoanhSoThuChiBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.BaoCaoDoanhSoThuChi);
            // 
            // fBaoCaoDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1168, 659);
            this.Controls.Add(this.reportDoanhSo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fBaoCaoDoanhSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fBaoCaoDoanhSo";
            this.Load += new System.EventHandler(this.fBaoCaoDoanhSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhSoThuChiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportDoanhSo;
        private System.Windows.Forms.BindingSource baoCaoDoanhSoThuChiBindingSource;
    }
}