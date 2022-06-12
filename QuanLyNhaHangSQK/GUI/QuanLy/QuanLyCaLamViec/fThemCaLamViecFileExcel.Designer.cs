
namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyCaLamViec
{
    partial class fThemCaLamViecFileExcel
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
            this.dtgvCaLamViecFile = new System.Windows.Forms.DataGridView();
            this.caLamViecBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.MaCLV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCLV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCaLamViecFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caLamViecBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.dtgvCaLamViecFile);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 0;
            // 
            // dtgvCaLamViecFile
            // 
            this.dtgvCaLamViecFile.AutoGenerateColumns = false;
            this.dtgvCaLamViecFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCaLamViecFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCaLamViecFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCLV,
            this.TenCLV,
            this.GioBD,
            this.GioKT,
            this.GhiChu});
            this.dtgvCaLamViecFile.DataSource = this.caLamViecBindingSource;
            this.dtgvCaLamViecFile.Location = new System.Drawing.Point(3, 3);
            this.dtgvCaLamViecFile.Name = "dtgvCaLamViecFile";
            this.dtgvCaLamViecFile.RowHeadersWidth = 51;
            this.dtgvCaLamViecFile.RowTemplate.Height = 24;
            this.dtgvCaLamViecFile.Size = new System.Drawing.Size(770, 377);
            this.dtgvCaLamViecFile.TabIndex = 0;
            // 
            // caLamViecBindingSource
            // 
            this.caLamViecBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.CaLamViec);
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
            this.btnHuy.Location = new System.Drawing.Point(643, 386);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShadowDecoration.Parent = this.btnHuy;
            this.btnHuy.Size = new System.Drawing.Size(130, 37);
            this.btnHuy.TabIndex = 8;
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
            this.btnLuu.Location = new System.Drawing.Point(507, 386);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(130, 37);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // MaCLV
            // 
            this.MaCLV.DataPropertyName = "MaCLV";
            this.MaCLV.HeaderText = "MaCLV";
            this.MaCLV.MinimumWidth = 6;
            this.MaCLV.Name = "MaCLV";
            // 
            // TenCLV
            // 
            this.TenCLV.DataPropertyName = "TenCLV";
            this.TenCLV.HeaderText = "TenCLV";
            this.TenCLV.MinimumWidth = 6;
            this.TenCLV.Name = "TenCLV";
            // 
            // GioBD
            // 
            this.GioBD.DataPropertyName = "GioBatDau";
            this.GioBD.HeaderText = "GioBatDau";
            this.GioBD.MinimumWidth = 6;
            this.GioBD.Name = "GioBD";
            // 
            // GioKT
            // 
            this.GioKT.DataPropertyName = "GioKetThuc";
            this.GioKT.HeaderText = "GioKetThuc";
            this.GioKT.MinimumWidth = 6;
            this.GioKT.Name = "GioKT";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "GhiChu";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            // 
            // fThemCaLamViecFileExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fThemCaLamViecFileExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThemCaLamViecFileExcel";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCaLamViecFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caLamViecBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvCaLamViecFile;
        private System.Windows.Forms.BindingSource caLamViecBindingSource;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCLV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCLV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}