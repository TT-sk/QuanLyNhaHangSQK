
namespace QuanLyNhaHangSQK.GUI.QuanLy.BaoCaoThongKe.DoanhSo
{
    partial class fBieuDoDoanhSo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.cBieuDoDoanhSo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.cBieuDoDoanhSo)).BeginInit();
            this.SuspendLayout();
            // 
            // cBieuDoDoanhSo
            // 
            chartArea1.Name = "ChartArea1";
            this.cBieuDoDoanhSo.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cBieuDoDoanhSo.Legends.Add(legend1);
            this.cBieuDoDoanhSo.Location = new System.Drawing.Point(94, 12);
            this.cBieuDoDoanhSo.Name = "cBieuDoDoanhSo";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=LightToDark, LabelStyle=Top";
            series1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.Label = "#TOTAL{C00}";
            series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.Legend = "Legend1";
            series1.Name = "Tổng thu";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "DrawingStyle=LightToDark, LabelStyle=Top";
            series2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            series2.IsValueShownAsLabel = true;
            series2.Label = "#TOTAL{C00}";
            series2.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Legend = "Legend1";
            series2.Name = "Tổng chi";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "DrawingStyle=LightToDark, LabelStyle=Top";
            series3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            series3.IsValueShownAsLabel = true;
            series3.Label = "#TOTAL{C00}";
            series3.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series3.Legend = "Legend1";
            series3.Name = "Lãi suất";
            this.cBieuDoDoanhSo.Series.Add(series1);
            this.cBieuDoDoanhSo.Series.Add(series2);
            this.cBieuDoDoanhSo.Series.Add(series3);
            this.cBieuDoDoanhSo.Size = new System.Drawing.Size(981, 635);
            this.cBieuDoDoanhSo.TabIndex = 0;
            this.cBieuDoDoanhSo.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Blue;
            title1.Name = "Title1";
            title1.Text = "BIỂU ĐỒ DOANH SỐ";
            this.cBieuDoDoanhSo.Titles.Add(title1);
            // 
            // fBieuDoDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1168, 659);
            this.Controls.Add(this.cBieuDoDoanhSo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fBieuDoDoanhSo";
            this.Text = "fBieuDoDoanhSo";
            this.Load += new System.EventHandler(this.fBieuDoDoanhSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cBieuDoDoanhSo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cBieuDoDoanhSo;
    }
}