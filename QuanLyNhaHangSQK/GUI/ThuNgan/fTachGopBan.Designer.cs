
namespace QuanLyNhaHangSQK.GUI
{
    partial class fTachGopBan
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtgvMenuMoi = new System.Windows.Forms.DataGridView();
            this.colMaMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaTienDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTienDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenLai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbbBanMoi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbKhuVucBanMoi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtgvMenuHienTai = new System.Windows.Forms.DataGridView();
            this.MaMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chuyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtKhuVucBanCu = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBanCu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTraLaiMot = new System.Windows.Forms.Button();
            this.btnChuyenMot = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuHienTai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.guna2Panel2);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Controls.Add(this.btnTraLaiMot);
            this.panel1.Controls.Add(this.btnChuyenMot);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1351, 499);
            this.panel1.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.dtgvMenuMoi);
            this.guna2Panel2.Controls.Add(this.cbbBanMoi);
            this.guna2Panel2.Controls.Add(this.cbbKhuVucBanMoi);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Location = new System.Drawing.Point(699, 37);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(642, 391);
            this.guna2Panel2.TabIndex = 15;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // dtgvMenuMoi
            // 
            this.dtgvMenuMoi.AutoGenerateColumns = false;
            this.dtgvMenuMoi.ColumnHeadersHeight = 29;
            this.dtgvMenuMoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMA,
            this.ColTenMA,
            this.ColSoLuong,
            this.giaTienDataGridViewTextBoxColumn1,
            this.tongTienDataGridViewTextBoxColumn1,
            this.ChuyenLai});
            this.dtgvMenuMoi.DataSource = this.menuBindingSource1;
            this.dtgvMenuMoi.Location = new System.Drawing.Point(5, 87);
            this.dtgvMenuMoi.Name = "dtgvMenuMoi";
            this.dtgvMenuMoi.RowHeadersWidth = 51;
            this.dtgvMenuMoi.RowTemplate.Height = 24;
            this.dtgvMenuMoi.Size = new System.Drawing.Size(634, 301);
            this.dtgvMenuMoi.TabIndex = 37;
            // 
            // colMaMA
            // 
            this.colMaMA.DataPropertyName = "MaMA";
            this.colMaMA.HeaderText = "Mã món";
            this.colMaMA.MinimumWidth = 6;
            this.colMaMA.Name = "colMaMA";
            this.colMaMA.Width = 65;
            // 
            // ColTenMA
            // 
            this.ColTenMA.DataPropertyName = "TenMA";
            this.ColTenMA.HeaderText = "Tên món";
            this.ColTenMA.MinimumWidth = 6;
            this.ColTenMA.Name = "ColTenMA";
            this.ColTenMA.ReadOnly = true;
            this.ColTenMA.Width = 190;
            // 
            // ColSoLuong
            // 
            this.ColSoLuong.DataPropertyName = "SoLuong";
            this.ColSoLuong.HeaderText = "Số lượng";
            this.ColSoLuong.MinimumWidth = 6;
            this.ColSoLuong.Name = "ColSoLuong";
            this.ColSoLuong.ReadOnly = true;
            this.ColSoLuong.Width = 70;
            // 
            // giaTienDataGridViewTextBoxColumn1
            // 
            this.giaTienDataGridViewTextBoxColumn1.DataPropertyName = "GiaTien";
            this.giaTienDataGridViewTextBoxColumn1.HeaderText = "Giá tiền";
            this.giaTienDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.giaTienDataGridViewTextBoxColumn1.Name = "giaTienDataGridViewTextBoxColumn1";
            this.giaTienDataGridViewTextBoxColumn1.ReadOnly = true;
            this.giaTienDataGridViewTextBoxColumn1.Width = 97;
            // 
            // tongTienDataGridViewTextBoxColumn1
            // 
            this.tongTienDataGridViewTextBoxColumn1.DataPropertyName = "TongTien";
            this.tongTienDataGridViewTextBoxColumn1.HeaderText = "Tổng tiền";
            this.tongTienDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.tongTienDataGridViewTextBoxColumn1.Name = "tongTienDataGridViewTextBoxColumn1";
            this.tongTienDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tongTienDataGridViewTextBoxColumn1.Width = 97;
            // 
            // ChuyenLai
            // 
            this.ChuyenLai.HeaderText = "Chuyển";
            this.ChuyenLai.MinimumWidth = 6;
            this.ChuyenLai.Name = "ChuyenLai";
            this.ChuyenLai.Width = 61;
            // 
            // menuBindingSource1
            // 
            this.menuBindingSource1.DataSource = typeof(QuanLyNhaHangSQK.DTO.Menu);
            // 
            // cbbBanMoi
            // 
            this.cbbBanMoi.BackColor = System.Drawing.Color.Transparent;
            this.cbbBanMoi.BorderColor = System.Drawing.Color.Black;
            this.cbbBanMoi.BorderRadius = 10;
            this.cbbBanMoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbBanMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBanMoi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBanMoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBanMoi.FocusedState.Parent = this.cbbBanMoi;
            this.cbbBanMoi.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.cbbBanMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbBanMoi.HoverState.Parent = this.cbbBanMoi;
            this.cbbBanMoi.ItemHeight = 30;
            this.cbbBanMoi.Items.AddRange(new object[] {
            "Bàn 2"});
            this.cbbBanMoi.ItemsAppearance.Parent = this.cbbBanMoi;
            this.cbbBanMoi.Location = new System.Drawing.Point(91, 45);
            this.cbbBanMoi.Name = "cbbBanMoi";
            this.cbbBanMoi.ShadowDecoration.Parent = this.cbbBanMoi;
            this.cbbBanMoi.Size = new System.Drawing.Size(352, 36);
            this.cbbBanMoi.TabIndex = 37;
            // 
            // cbbKhuVucBanMoi
            // 
            this.cbbKhuVucBanMoi.BackColor = System.Drawing.Color.Transparent;
            this.cbbKhuVucBanMoi.BorderColor = System.Drawing.Color.Black;
            this.cbbKhuVucBanMoi.BorderRadius = 10;
            this.cbbKhuVucBanMoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbKhuVucBanMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhuVucBanMoi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhuVucBanMoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhuVucBanMoi.FocusedState.Parent = this.cbbKhuVucBanMoi;
            this.cbbKhuVucBanMoi.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.cbbKhuVucBanMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbKhuVucBanMoi.HoverState.Parent = this.cbbKhuVucBanMoi;
            this.cbbKhuVucBanMoi.ItemHeight = 30;
            this.cbbKhuVucBanMoi.Items.AddRange(new object[] {
            "Khu vực 2"});
            this.cbbKhuVucBanMoi.ItemsAppearance.Parent = this.cbbKhuVucBanMoi;
            this.cbbKhuVucBanMoi.Location = new System.Drawing.Point(91, 3);
            this.cbbKhuVucBanMoi.Name = "cbbKhuVucBanMoi";
            this.cbbKhuVucBanMoi.ShadowDecoration.Parent = this.cbbKhuVucBanMoi;
            this.cbbKhuVucBanMoi.Size = new System.Drawing.Size(352, 36);
            this.cbbKhuVucBanMoi.TabIndex = 38;
            this.cbbKhuVucBanMoi.SelectedIndexChanged += new System.EventHandler(this.cbbKhuVucBanMoi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bàn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Khu vực:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.dtgvMenuHienTai);
            this.guna2Panel1.Controls.Add(this.txtKhuVucBanCu);
            this.guna2Panel1.Controls.Add(this.txtBanCu);
            this.guna2Panel1.Controls.Add(this.label7);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Location = new System.Drawing.Point(6, 37);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(642, 391);
            this.guna2Panel1.TabIndex = 15;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // dtgvMenuHienTai
            // 
            this.dtgvMenuHienTai.AutoGenerateColumns = false;
            this.dtgvMenuHienTai.ColumnHeadersHeight = 29;
            this.dtgvMenuHienTai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMA,
            this.TenMa,
            this.SoLuong,
            this.GiaTien,
            this.ThanhTien,
            this.Chuyen});
            this.dtgvMenuHienTai.DataSource = this.menuBindingSource;
            this.dtgvMenuHienTai.Location = new System.Drawing.Point(5, 87);
            this.dtgvMenuHienTai.Name = "dtgvMenuHienTai";
            this.dtgvMenuHienTai.RowHeadersWidth = 51;
            this.dtgvMenuHienTai.RowTemplate.Height = 24;
            this.dtgvMenuHienTai.Size = new System.Drawing.Size(634, 301);
            this.dtgvMenuHienTai.TabIndex = 37;
            // 
            // MaMA
            // 
            this.MaMA.DataPropertyName = "MaMA";
            this.MaMA.HeaderText = "Mã món";
            this.MaMA.MinimumWidth = 6;
            this.MaMA.Name = "MaMA";
            this.MaMA.ReadOnly = true;
            this.MaMA.Width = 65;
            // 
            // TenMa
            // 
            this.TenMa.DataPropertyName = "TenMA";
            this.TenMa.HeaderText = "Tên món";
            this.TenMa.MinimumWidth = 6;
            this.TenMa.Name = "TenMa";
            this.TenMa.ReadOnly = true;
            this.TenMa.Width = 190;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 70;
            // 
            // GiaTien
            // 
            this.GiaTien.DataPropertyName = "GiaTien";
            this.GiaTien.HeaderText = "Giá tiền";
            this.GiaTien.MinimumWidth = 6;
            this.GiaTien.Name = "GiaTien";
            this.GiaTien.ReadOnly = true;
            this.GiaTien.Width = 97;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "TongTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            this.ThanhTien.Width = 97;
            // 
            // Chuyen
            // 
            this.Chuyen.HeaderText = "Chuyển";
            this.Chuyen.MinimumWidth = 6;
            this.Chuyen.Name = "Chuyen";
            this.Chuyen.Width = 61;
            // 
            // menuBindingSource
            // 
            this.menuBindingSource.DataSource = typeof(QuanLyNhaHangSQK.DTO.Menu);
            this.menuBindingSource.CurrentChanged += new System.EventHandler(this.menuBindingSource_CurrentChanged);
            // 
            // txtKhuVucBanCu
            // 
            this.txtKhuVucBanCu.BorderColor = System.Drawing.Color.Black;
            this.txtKhuVucBanCu.BorderRadius = 10;
            this.txtKhuVucBanCu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKhuVucBanCu.DefaultText = "Khu vực 1";
            this.txtKhuVucBanCu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKhuVucBanCu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKhuVucBanCu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKhuVucBanCu.DisabledState.Parent = this.txtKhuVucBanCu;
            this.txtKhuVucBanCu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKhuVucBanCu.Enabled = false;
            this.txtKhuVucBanCu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKhuVucBanCu.FocusedState.Parent = this.txtKhuVucBanCu;
            this.txtKhuVucBanCu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtKhuVucBanCu.ForeColor = System.Drawing.Color.Black;
            this.txtKhuVucBanCu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKhuVucBanCu.HoverState.Parent = this.txtKhuVucBanCu;
            this.txtKhuVucBanCu.Location = new System.Drawing.Point(90, 3);
            this.txtKhuVucBanCu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtKhuVucBanCu.Name = "txtKhuVucBanCu";
            this.txtKhuVucBanCu.PasswordChar = '\0';
            this.txtKhuVucBanCu.PlaceholderText = "";
            this.txtKhuVucBanCu.SelectedText = "";
            this.txtKhuVucBanCu.SelectionStart = 9;
            this.txtKhuVucBanCu.ShadowDecoration.Parent = this.txtKhuVucBanCu;
            this.txtKhuVucBanCu.Size = new System.Drawing.Size(352, 36);
            this.txtKhuVucBanCu.TabIndex = 35;
            // 
            // txtBanCu
            // 
            this.txtBanCu.BorderColor = System.Drawing.Color.Black;
            this.txtBanCu.BorderRadius = 10;
            this.txtBanCu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBanCu.DefaultText = "Bàn 1";
            this.txtBanCu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBanCu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBanCu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBanCu.DisabledState.Parent = this.txtBanCu;
            this.txtBanCu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBanCu.Enabled = false;
            this.txtBanCu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBanCu.FocusedState.Parent = this.txtBanCu;
            this.txtBanCu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtBanCu.ForeColor = System.Drawing.Color.Black;
            this.txtBanCu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBanCu.HoverState.Parent = this.txtBanCu;
            this.txtBanCu.Location = new System.Drawing.Point(90, 45);
            this.txtBanCu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBanCu.Name = "txtBanCu";
            this.txtBanCu.PasswordChar = '\0';
            this.txtBanCu.PlaceholderText = "";
            this.txtBanCu.SelectedText = "";
            this.txtBanCu.SelectionStart = 5;
            this.txtBanCu.ShadowDecoration.Parent = this.txtBanCu;
            this.txtBanCu.Size = new System.Drawing.Size(352, 36);
            this.txtBanCu.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "Bàn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Khu vực:";
            // 
            // btnTraLaiMot
            // 
            this.btnTraLaiMot.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.Chuyen4_1mui1;
            this.btnTraLaiMot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTraLaiMot.Location = new System.Drawing.Point(654, 229);
            this.btnTraLaiMot.Name = "btnTraLaiMot";
            this.btnTraLaiMot.Size = new System.Drawing.Size(39, 39);
            this.btnTraLaiMot.TabIndex = 14;
            this.btnTraLaiMot.UseVisualStyleBackColor = true;
            this.btnTraLaiMot.Click += new System.EventHandler(this.btnTraLaiMot_Click);
            // 
            // btnChuyenMot
            // 
            this.btnChuyenMot.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.Chuyen3_1mui1;
            this.btnChuyenMot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChuyenMot.Location = new System.Drawing.Point(654, 184);
            this.btnChuyenMot.Name = "btnChuyenMot";
            this.btnChuyenMot.Size = new System.Drawing.Size(39, 39);
            this.btnChuyenMot.TabIndex = 14;
            this.btnChuyenMot.UseVisualStyleBackColor = true;
            this.btnChuyenMot.Click += new System.EventHandler(this.btnChuyenMot_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btnTrangChu2;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1234, 454);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 40);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.MouseLeave += new System.EventHandler(this.btnThoat_MouseLeave);
            this.btnThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnThoat_MouseMove);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btnTrangChu2;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(1124, 454);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(104, 40);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.MouseLeave += new System.EventHandler(this.btnLuu_MouseLeave);
            this.btnLuu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLuu_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.BanCoNg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(41, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tách bàn";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.panel1;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fTachGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.ThuNgan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1375, 523);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fTachGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTachGopBan";
            this.Load += new System.EventHandler(this.fTachGopBan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMenuHienTai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnChuyenMot;
        private System.Windows.Forms.Button btnTraLaiMot;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtKhuVucBanCu;
        private Guna.UI2.WinForms.Guna2TextBox txtBanCu;
        private Guna.UI2.WinForms.Guna2ComboBox cbbBanMoi;
        private Guna.UI2.WinForms.Guna2ComboBox cbbKhuVucBanMoi;
        private System.Windows.Forms.BindingSource menuBindingSource;
        private System.Windows.Forms.DataGridView dtgvMenuMoi;
        private System.Windows.Forms.DataGridView dtgvMenuHienTai;
        private System.Windows.Forms.BindingSource menuBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaTienDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTienDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChuyenLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chuyen;
        private System.Windows.Forms.Timer timer1;
    }
}