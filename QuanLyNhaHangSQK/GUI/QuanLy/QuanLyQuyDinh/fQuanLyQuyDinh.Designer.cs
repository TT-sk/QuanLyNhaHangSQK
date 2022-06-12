
namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyQuyDinh
{
    partial class fQuanLyQuyDinh
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpnQuyDinh = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnThem = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTieuDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnThemQD = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).BeginInit();
            this.pnThem.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 40;
            this.guna2Elipse2.TargetControl = this.guna2Panel1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.QuyDinhs;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.pnThem);
            this.guna2Panel1.Controls.Add(this.btnThem);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.flpnQuyDinh);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1520, 699);
            this.guna2Panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(108, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quy định";
            // 
            // flpnQuyDinh
            // 
            this.flpnQuyDinh.AutoScroll = true;
            this.flpnQuyDinh.BackColor = System.Drawing.Color.Transparent;
            this.flpnQuyDinh.Location = new System.Drawing.Point(305, 170);
            this.flpnQuyDinh.Name = "flpnQuyDinh";
            this.flpnQuyDinh.Size = new System.Drawing.Size(910, 455);
            this.flpnQuyDinh.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.ThemKh11;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(1195, 144);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(20, 20);
            this.btnThem.TabIndex = 2;
            this.btnThem.TabStop = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnThem
            // 
            this.pnThem.BackColor = System.Drawing.Color.White;
            this.pnThem.Controls.Add(this.btnThemQD);
            this.pnThem.Controls.Add(this.label2);
            this.pnThem.Controls.Add(this.label3);
            this.pnThem.Controls.Add(this.txtNoiDung);
            this.pnThem.Controls.Add(this.txtTieuDe);
            this.pnThem.Controls.Add(this.guna2HtmlLabel4);
            this.pnThem.Controls.Add(this.guna2HtmlLabel3);
            this.pnThem.Location = new System.Drawing.Point(828, 144);
            this.pnThem.Name = "pnThem";
            this.pnThem.ShadowDecoration.Parent = this.pnThem;
            this.pnThem.Size = new System.Drawing.Size(361, 0);
            this.pnThem.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(25, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 2);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(25, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 2);
            this.label3.TabIndex = 9;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderThickness = 0;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoiDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.DisabledState.Parent = this.txtNoiDung;
            this.txtNoiDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.FocusedState.Parent = this.txtNoiDung;
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoiDung.ForeColor = System.Drawing.Color.Black;
            this.txtNoiDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.HoverState.Parent = this.txtNoiDung;
            this.txtNoiDung.Location = new System.Drawing.Point(17, 110);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PasswordChar = '\0';
            this.txtNoiDung.PlaceholderText = "Nhập câu trả lời của ban.";
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.ShadowDecoration.Parent = this.txtNoiDung;
            this.txtNoiDung.Size = new System.Drawing.Size(257, 66);
            this.txtNoiDung.TabIndex = 7;
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.BorderThickness = 0;
            this.txtTieuDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTieuDe.DefaultText = "";
            this.txtTieuDe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTieuDe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTieuDe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTieuDe.DisabledState.Parent = this.txtTieuDe;
            this.txtTieuDe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTieuDe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTieuDe.FocusedState.Parent = this.txtTieuDe;
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTieuDe.ForeColor = System.Drawing.Color.Black;
            this.txtTieuDe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTieuDe.HoverState.Parent = this.txtTieuDe;
            this.txtTieuDe.Location = new System.Drawing.Point(17, 41);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.PasswordChar = '\0';
            this.txtTieuDe.PlaceholderText = "Nhập câu trả lời của ban.";
            this.txtTieuDe.SelectedText = "";
            this.txtTieuDe.ShadowDecoration.Parent = this.txtTieuDe;
            this.txtTieuDe.Size = new System.Drawing.Size(257, 36);
            this.txtTieuDe.TabIndex = 6;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(17, 83);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(74, 21);
            this.guna2HtmlLabel4.TabIndex = 4;
            this.guna2HtmlLabel4.Text = "Nội dung";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(17, 14);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(60, 21);
            this.guna2HtmlLabel3.TabIndex = 5;
            this.guna2HtmlLabel3.Text = "Tiêu đề";
            // 
            // btnThemQD
            // 
            this.btnThemQD.BorderRadius = 5;
            this.btnThemQD.CheckedState.Parent = this.btnThemQD;
            this.btnThemQD.CustomImages.Parent = this.btnThemQD;
            this.btnThemQD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemQD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemQD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemQD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemQD.DisabledState.Parent = this.btnThemQD;
            this.btnThemQD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThemQD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemQD.ForeColor = System.Drawing.Color.White;
            this.btnThemQD.HoverState.Parent = this.btnThemQD;
            this.btnThemQD.Location = new System.Drawing.Point(280, 139);
            this.btnThemQD.Name = "btnThemQD";
            this.btnThemQD.ShadowDecoration.Parent = this.btnThemQD;
            this.btnThemQD.Size = new System.Drawing.Size(74, 37);
            this.btnThemQD.TabIndex = 0;
            this.btnThemQD.Text = "Thêm";
            this.btnThemQD.Click += new System.EventHandler(this.btnThemQD_Click);
            // 
            // fQuanLyQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.ThuNgan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1544, 723);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fQuanLyQuyDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fQuanLyQuyDinh";
            this.Load += new System.EventHandler(this.fQuanLyQuyDinh_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).EndInit();
            this.pnThem.ResumeLayout(false);
            this.pnThem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpnQuyDinh;
        private Guna.UI2.WinForms.Guna2Panel pnThem;
        private System.Windows.Forms.PictureBox btnThem;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnThemQD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private Guna.UI2.WinForms.Guna2TextBox txtTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}