namespace NexKutuphane.Desktop.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlMenu;
    private Panel pnlLogo;
    private Panel pnlTop;
    private Panel pnlContent;

    private Label lblLogo;
    private Label lblSubLogo;
    private Label lblPageTitle;
    private Label lblUserInfo;

    private Button btnDashboard;
    private Button btnBooks;
    private Button btnMembers;
    private Button btnLoans;
    private Button btnReports;
    private Button btnSettings;
    private Button btnAdmin;
    private Button btnExit;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlMenu = new Panel();
        btnExit = new Button();
        btnAdmin = new Button();
        btnSettings = new Button();
        btnReports = new Button();
        btnLoans = new Button();
        btnMembers = new Button();
        btnBooks = new Button();
        btnDashboard = new Button();
        pnlLogo = new Panel();
        lblSubLogo = new Label();
        lblLogo = new Label();
        pnlTop = new Panel();
        lblUserInfo = new Label();
        lblPageTitle = new Label();
        pnlContent = new Panel();

        pnlMenu.SuspendLayout();
        pnlLogo.SuspendLayout();
        pnlTop.SuspendLayout();
        SuspendLayout();

        // pnlMenu
        pnlMenu.BackColor = Color.FromArgb(17, 24, 39);
        pnlMenu.Controls.Add(btnExit);
        pnlMenu.Controls.Add(btnAdmin);
        pnlMenu.Controls.Add(btnSettings);
        pnlMenu.Controls.Add(btnReports);
        pnlMenu.Controls.Add(btnLoans);
        pnlMenu.Controls.Add(btnMembers);
        pnlMenu.Controls.Add(btnBooks);
        pnlMenu.Controls.Add(btnDashboard);
        pnlMenu.Controls.Add(pnlLogo);
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Location = new Point(0, 0);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(240, 720);
        pnlMenu.TabIndex = 0;

        // pnlLogo
        pnlLogo.Controls.Add(lblSubLogo);
        pnlLogo.Controls.Add(lblLogo);
        pnlLogo.Dock = DockStyle.Top;
        pnlLogo.Location = new Point(0, 0);
        pnlLogo.Name = "pnlLogo";
        pnlLogo.Size = new Size(240, 100);
        pnlLogo.TabIndex = 0;

        // lblLogo
        lblLogo.AutoSize = false;
        lblLogo.Dock = DockStyle.Top;
        lblLogo.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblLogo.ForeColor = Color.White;
        lblLogo.Location = new Point(0, 18);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(240, 35);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "NexKütüphane";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;

        // lblSubLogo
        lblSubLogo.AutoSize = false;
        lblSubLogo.Dock = DockStyle.Top;
        lblSubLogo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblSubLogo.ForeColor = Color.FromArgb(156, 163, 175);
        lblSubLogo.Location = new Point(0, 53);
        lblSubLogo.Name = "lblSubLogo";
        lblSubLogo.Size = new Size(240, 25);
        lblSubLogo.TabIndex = 1;
        lblSubLogo.Text = "Kütüphane Yönetim Sistemi";
        lblSubLogo.TextAlign = ContentAlignment.MiddleCenter;

        // btnDashboard
        btnDashboard.BackColor = Color.FromArgb(37, 99, 235);
        btnDashboard.Dock = DockStyle.Top;
        btnDashboard.FlatAppearance.BorderSize = 0;
        btnDashboard.FlatStyle = FlatStyle.Flat;
        btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnDashboard.ForeColor = Color.White;
        btnDashboard.Location = new Point(0, 100);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Padding = new Padding(18, 0, 0, 0);
        btnDashboard.Size = new Size(240, 52);
        btnDashboard.TabIndex = 1;
        btnDashboard.Text = "Dashboard";
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnDashboard.UseVisualStyleBackColor = false;
        btnDashboard.Click += btnDashboard_Click;

        // btnBooks
        btnBooks.BackColor = Color.FromArgb(31, 41, 55);
        btnBooks.Dock = DockStyle.Top;
        btnBooks.FlatAppearance.BorderSize = 0;
        btnBooks.FlatStyle = FlatStyle.Flat;
        btnBooks.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnBooks.ForeColor = Color.White;
        btnBooks.Location = new Point(0, 152);
        btnBooks.Name = "btnBooks";
        btnBooks.Padding = new Padding(18, 0, 0, 0);
        btnBooks.Size = new Size(240, 52);
        btnBooks.TabIndex = 2;
        btnBooks.Text = "Kitap İşlemleri";
        btnBooks.TextAlign = ContentAlignment.MiddleLeft;
        btnBooks.UseVisualStyleBackColor = false;
        btnBooks.Click += btnBooks_Click;

        // btnMembers
        btnMembers.BackColor = Color.FromArgb(31, 41, 55);
        btnMembers.Dock = DockStyle.Top;
        btnMembers.FlatAppearance.BorderSize = 0;
        btnMembers.FlatStyle = FlatStyle.Flat;
        btnMembers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnMembers.ForeColor = Color.White;
        btnMembers.Location = new Point(0, 204);
        btnMembers.Name = "btnMembers";
        btnMembers.Padding = new Padding(18, 0, 0, 0);
        btnMembers.Size = new Size(240, 52);
        btnMembers.TabIndex = 3;
        btnMembers.Text = "Üye İşlemleri";
        btnMembers.TextAlign = ContentAlignment.MiddleLeft;
        btnMembers.UseVisualStyleBackColor = false;
        btnMembers.Click += btnMembers_Click;

        // btnLoans
        btnLoans.BackColor = Color.FromArgb(31, 41, 55);
        btnLoans.Dock = DockStyle.Top;
        btnLoans.FlatAppearance.BorderSize = 0;
        btnLoans.FlatStyle = FlatStyle.Flat;
        btnLoans.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLoans.ForeColor = Color.White;
        btnLoans.Location = new Point(0, 256);
        btnLoans.Name = "btnLoans";
        btnLoans.Padding = new Padding(18, 0, 0, 0);
        btnLoans.Size = new Size(240, 52);
        btnLoans.TabIndex = 4;
        btnLoans.Text = "Ödünç / İade";
        btnLoans.TextAlign = ContentAlignment.MiddleLeft;
        btnLoans.UseVisualStyleBackColor = false;
        btnLoans.Click += btnLoans_Click;

        // btnReports
        btnReports.BackColor = Color.FromArgb(31, 41, 55);
        btnReports.Dock = DockStyle.Top;
        btnReports.FlatAppearance.BorderSize = 0;
        btnReports.FlatStyle = FlatStyle.Flat;
        btnReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnReports.ForeColor = Color.White;
        btnReports.Location = new Point(0, 308);
        btnReports.Name = "btnReports";
        btnReports.Padding = new Padding(18, 0, 0, 0);
        btnReports.Size = new Size(240, 52);
        btnReports.TabIndex = 5;
        btnReports.Text = "Raporlar";
        btnReports.TextAlign = ContentAlignment.MiddleLeft;
        btnReports.UseVisualStyleBackColor = false;
        btnReports.Click += btnReports_Click;

        // btnSettings
        btnSettings.BackColor = Color.FromArgb(31, 41, 55);
        btnSettings.Dock = DockStyle.Top;
        btnSettings.FlatAppearance.BorderSize = 0;
        btnSettings.FlatStyle = FlatStyle.Flat;
        btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSettings.ForeColor = Color.White;
        btnSettings.Location = new Point(0, 360);
        btnSettings.Name = "btnSettings";
        btnSettings.Padding = new Padding(18, 0, 0, 0);
        btnSettings.Size = new Size(240, 52);
        btnSettings.TabIndex = 6;
        btnSettings.Text = "Ayarlar";
        btnSettings.TextAlign = ContentAlignment.MiddleLeft;
        btnSettings.UseVisualStyleBackColor = false;
        btnSettings.Click += btnSettings_Click;

        // btnAdmin
        btnAdmin.BackColor = Color.FromArgb(31, 41, 55);
        btnAdmin.Dock = DockStyle.Top;
        btnAdmin.FlatAppearance.BorderSize = 0;
        btnAdmin.FlatStyle = FlatStyle.Flat;
        btnAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAdmin.ForeColor = Color.White;
        btnAdmin.Location = new Point(0, 412);
        btnAdmin.Name = "btnAdmin";
        btnAdmin.Padding = new Padding(18, 0, 0, 0);
        btnAdmin.Size = new Size(240, 52);
        btnAdmin.TabIndex = 7;
        btnAdmin.Text = "Yönetim";
        btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
        btnAdmin.UseVisualStyleBackColor = false;
        btnAdmin.Click += btnAdmin_Click;

        // btnExit
        btnExit.BackColor = Color.FromArgb(127, 29, 29);
        btnExit.Dock = DockStyle.Bottom;
        btnExit.FlatAppearance.BorderSize = 0;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnExit.ForeColor = Color.White;
        btnExit.Location = new Point(0, 668);
        btnExit.Name = "btnExit";
        btnExit.Padding = new Padding(18, 0, 0, 0);
        btnExit.Size = new Size(240, 52);
        btnExit.TabIndex = 8;
        btnExit.Text = "Çıkış";
        btnExit.TextAlign = ContentAlignment.MiddleLeft;
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += btnExit_Click;

        // pnlTop
        pnlTop.BackColor = Color.White;
        pnlTop.Controls.Add(lblUserInfo);
        pnlTop.Controls.Add(lblPageTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(240, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1040, 70);
        pnlTop.TabIndex = 1;

        // lblPageTitle
        lblPageTitle.AutoSize = false;
        lblPageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblPageTitle.ForeColor = Color.FromArgb(17, 24, 39);
        lblPageTitle.Location = new Point(24, 0);
        lblPageTitle.Name = "lblPageTitle";
        lblPageTitle.Size = new Size(400, 70);
        lblPageTitle.TabIndex = 0;
        lblPageTitle.Text = "Dashboard";
        lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;

        // lblUserInfo
        lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblUserInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        lblUserInfo.ForeColor = Color.FromArgb(75, 85, 99);
        lblUserInfo.Location = new Point(735, 0);
        lblUserInfo.Name = "lblUserInfo";
        lblUserInfo.Size = new Size(280, 70);
        lblUserInfo.TabIndex = 1;
        lblUserInfo.Text = "Aktif Kullanıcı: Admin";
        lblUserInfo.TextAlign = ContentAlignment.MiddleRight;

        // pnlContent
        pnlContent.BackColor = Color.FromArgb(243, 244, 246);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(240, 70);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(18);
        pnlContent.Size = new Size(1040, 650);
        pnlContent.TabIndex = 2;

        // FrmMain
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 244, 246);
        ClientSize = new Size(1280, 720);
        Controls.Add(pnlContent);
        Controls.Add(pnlTop);
        Controls.Add(pnlMenu);
        MinimumSize = new Size(1100, 650);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NexKütüphane";
        WindowState = FormWindowState.Maximized;

        pnlMenu.ResumeLayout(false);
        pnlLogo.ResumeLayout(false);
        pnlTop.ResumeLayout(false);
        ResumeLayout(false);
    }
}