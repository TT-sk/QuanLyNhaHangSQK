
namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhuVuc
{
    partial class fThemKhuVucFileExcel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.dtgvKhuVucFile = new System.Windows.Forms.DataGridView();
            this.MaKV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khuVucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhuVucFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khuVucBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.dtgvKhuVucFile);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 278);
            this.panel1.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.CheckedState.Parent = this.btnHuy;
            this.btnHuy.CustomImages.Parent = this.btnHuy;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.DisabledState.Parent = this.btnHuy;
            this.btnHuy.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.HoverState.Parent = this.btnHuy;
            this.btnHuy.Location = new System.Drawing.Point(352, 238);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShadowDecoration.Parent = this.btnHuy;
            this.btnHuy.Size = new System.Drawing.Size(130, 37);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.CheckedState.Parent = this.btnLuu;
            this.btnLuu.CustomImages.Parent = this.btnLuu;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.DisabledState.Parent = this.btnLuu;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.Parent = this.btnLuu;
            this.btnLuu.Location = new System.Drawing.Point(216, 238);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(130, 37);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dtgvKhuVucFile
            // 
            this.dtgvKhuVucFile.AutoGenerateColumns = false;
            this.dtgvKhuVucFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhuVucFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKV,
            this.TenKV});
            this.dtgvKhuVucFile.DataSource = this.khuVucBindingSource;
            this.dtgvKhuVucFile.Location = new System.Drawing.Point(3, 3);
            this.dtgvKhuVucFile.Name = "dtgvKhuVucFile";
            this.dtgvKhuVucFile.RowHeadersWidth = 51;
            this.dtgvKhuVucFile.RowTemplate.Height = 24;
            this.dtgvKhuVucFile.Size = new System.Drawing.Size(482, 229);
            this.dtgvKhuVucFile.TabIndex = 0;
            // 
            // MaKV
            // 
            this.MaKV.DataPropertyName = "MaKV";
            this.MaKV.HeaderText = "MaKV";
            this.MaKV.MinimumWidth = 6;
            this.MaKV.Name = "MaKV";
            this.MaKV.Width = 125;
            // 
            // TenKV
            // 
            this.TenKV.DataPropertyName = "TenKV";
            this.TenKV.HeaderText = "TenKV";
            this.TenKV.MinimumWidth = 6;
            this.TenKV.Name = "TenKV";
            this.TenKV.Width = 300;
            // 
            // khuVucBindingSource
            // 
            this.khuVucBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.KhuVuc);
            // 
            // fThemKhuVucFileExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(512, 302);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fThemKhuVucFileExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThemKhuVucFileExcel";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhuVucFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khuVucBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvKhuVucFile;
        private System.Windows.Forms.BindingSource khuVucBindingSource;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKV;
    }
}