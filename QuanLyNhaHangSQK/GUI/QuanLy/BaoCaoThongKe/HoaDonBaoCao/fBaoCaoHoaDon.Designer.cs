
namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.HoaDonBaoCao
{
    partial class fBaoCaoHoaDon
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
            this.reportHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BaoCaoHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportHoaDon
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BaoCaoHoaDonBindingSource;
            this.reportHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.reportHoaDon.LocalReport.ReportEmbeddedResource = "QuanLyNhaHangSQK.Report.BaoCaoHoaDon.rdlc";
            this.reportHoaDon.Location = new System.Drawing.Point(94, 12);
            this.reportHoaDon.Name = "reportHoaDon";
            this.reportHoaDon.ServerReport.BearerToken = null;
            this.reportHoaDon.Size = new System.Drawing.Size(981, 635);
            this.reportHoaDon.TabIndex = 1;
            // 
            // BaoCaoHoaDonBindingSource
            // 
            this.BaoCaoHoaDonBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.BaoCaoHoaDon);
            // 
            // fBaoCaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1168, 659);
            this.Controls.Add(this.reportHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fBaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fBaoCaoHoaDon";
            this.Load += new System.EventHandler(this.fBaoCaoHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportHoaDon;
        private System.Windows.Forms.BindingSource BaoCaoHoaDonBindingSource;
    }
}