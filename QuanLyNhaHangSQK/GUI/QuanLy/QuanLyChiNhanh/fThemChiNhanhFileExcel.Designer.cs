
namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyChiNhanh
{
    partial class fThemChiNhanhFileExcel
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
            this.dtgvChiNhanhFile = new System.Windows.Forms.DataGridView();
            this.chiNhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DiaChiCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTKNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoaiCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiNhanhFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.dtgvChiNhanhFile);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 426);
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
            this.btnHuy.Location = new System.Drawing.Point(1010, 386);
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
            this.btnLuu.Location = new System.Drawing.Point(874, 386);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(130, 37);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dtgvChiNhanhFile
            // 
            this.dtgvChiNhanhFile.AutoGenerateColumns = false;
            this.dtgvChiNhanhFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChiNhanhFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiNhanhFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTY,
            this.TenCN,
            this.DienThoaiCN,
            this.Email,
            this.SoTKNH,
            this.TenNH,
            this.DiaChiCN});
            this.dtgvChiNhanhFile.DataSource = this.chiNhanhBindingSource;
            this.dtgvChiNhanhFile.Location = new System.Drawing.Point(3, 3);
            this.dtgvChiNhanhFile.Name = "dtgvChiNhanhFile";
            this.dtgvChiNhanhFile.RowHeadersWidth = 51;
            this.dtgvChiNhanhFile.RowTemplate.Height = 24;
            this.dtgvChiNhanhFile.Size = new System.Drawing.Size(1137, 377);
            this.dtgvChiNhanhFile.TabIndex = 0;
            // 
            // chiNhanhBindingSource
            // 
            this.chiNhanhBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.ChiNhanh);
            // 
            // DiaChiCN
            // 
            this.DiaChiCN.DataPropertyName = "DiaChiCN";
            this.DiaChiCN.HeaderText = "DiaChiCN";
            this.DiaChiCN.MinimumWidth = 6;
            this.DiaChiCN.Name = "DiaChiCN";
            // 
            // TenNH
            // 
            this.TenNH.DataPropertyName = "TenNH";
            this.TenNH.HeaderText = "TenNH";
            this.TenNH.MinimumWidth = 6;
            this.TenNH.Name = "TenNH";
            // 
            // SoTKNH
            // 
            this.SoTKNH.DataPropertyName = "SoTKNH";
            this.SoTKNH.HeaderText = "SoTKNH";
            this.SoTKNH.MinimumWidth = 6;
            this.SoTKNH.Name = "SoTKNH";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // DienThoaiCN
            // 
            this.DienThoaiCN.DataPropertyName = "DienThoaiCN";
            this.DienThoaiCN.HeaderText = "DienThoaiCN";
            this.DienThoaiCN.MinimumWidth = 6;
            this.DienThoaiCN.Name = "DienThoaiCN";
            // 
            // TenCN
            // 
            this.TenCN.DataPropertyName = "TenCN";
            this.TenCN.HeaderText = "TenCN";
            this.TenCN.MinimumWidth = 6;
            this.TenCN.Name = "TenCN";
            // 
            // MaCTY
            // 
            this.MaCTY.DataPropertyName = "MaCTY";
            this.MaCTY.HeaderText = "MaCTY";
            this.MaCTY.MinimumWidth = 6;
            this.MaCTY.Name = "MaCTY";
            // 
            // fThemChiNhanhFileExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1167, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fThemChiNhanhFileExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fThemChiNhanhFileExcel";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiNhanhFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvChiNhanhFile;
        private System.Windows.Forms.BindingSource chiNhanhBindingSource;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoaiCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTKNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiCN;
    }
}