namespace NexKutuphane.Desktop.Forms.Dashboard;

partial class FrmDashboard
{
    private System.ComponentModel.IContainer components = null;

    private TableLayoutPanel tableCards;
    private Panel cardBooks;
    private Panel cardAvailable;
    private Panel cardLoaned;
    private Panel cardLate;
    private Label lblBooksTitle;
    private Label lblBooksValue;
    private Label lblAvailableTitle;
    private Label lblAvailableValue;
    private Label lblLoanedTitle;
    private Label lblLoanedValue;
    private Label lblLateTitle;
    private Label lblLateValue;
    private Label lblWelcome;
    private Label lblDescription;
    private Panel pnlInfo;

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
        lblWelcome = new Label();
        lblDescription = new Label();
        tableCards = new TableLayoutPanel();
        cardBooks = new Panel();
        lblBooksValue = new Label();
        lblBooksTitle = new Label();
        cardAvailable = new Panel();
        lblAvailableValue = new Label();
        lblAvailableTitle = new Label();
        cardLoaned = new Panel();
        lblLoanedValue = new Label();
        lblLoanedTitle = new Label();
        cardLate = new Panel();
        lblLateValue = new Label();
        lblLateTitle = new Label();
        pnlInfo = new Panel();

        tableCards.SuspendLayout();
        cardBooks.SuspendLayout();
        cardAvailable.SuspendLayout();
        cardLoaned.SuspendLayout();
        cardLate.SuspendLayout();
        pnlInfo.SuspendLayout();
        SuspendLayout();

        // lblWelcome
        lblWelcome.Dock = DockStyle.Top;
        lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.FromArgb(17, 24, 39);
        lblWelcome.Location = new Point(24, 24);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(992, 45);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "NexKütüphane Dashboard";
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;

        // lblDescription
        lblDescription.Dock = DockStyle.Top;
        lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        lblDescription.ForeColor = Color.FromArgb(75, 85, 99);
        lblDescription.Location = new Point(24, 69);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(992, 35);
        lblDescription.TabIndex = 1;
        lblDescription.Text = "Kütüphane özet bilgileri ve hızlı erişim alanları burada görüntülenecek.";
        lblDescription.TextAlign = ContentAlignment.MiddleLeft;

        // tableCards
        tableCards.ColumnCount = 4;
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableCards.Controls.Add(cardBooks, 0, 0);
        tableCards.Controls.Add(cardAvailable, 1, 0);
        tableCards.Controls.Add(cardLoaned, 2, 0);
        tableCards.Controls.Add(cardLate, 3, 0);
        tableCards.Dock = DockStyle.Top;
        tableCards.Location = new Point(24, 104);
        tableCards.Name = "tableCards";
        tableCards.RowCount = 1;
        tableCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableCards.Size = new Size(992, 135);
        tableCards.TabIndex = 2;

        // cardBooks
        cardBooks.BackColor = Color.White;
        cardBooks.Controls.Add(lblBooksValue);
        cardBooks.Controls.Add(lblBooksTitle);
        cardBooks.Dock = DockStyle.Fill;
        cardBooks.Margin = new Padding(0, 0, 12, 0);
        cardBooks.Name = "cardBooks";
        cardBooks.Padding = new Padding(18);
        cardBooks.TabIndex = 0;

        // lblBooksTitle
        lblBooksTitle.Dock = DockStyle.Top;
        lblBooksTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblBooksTitle.ForeColor = Color.FromArgb(75, 85, 99);
        lblBooksTitle.Location = new Point(18, 18);
        lblBooksTitle.Name = "lblBooksTitle";
        lblBooksTitle.Size = new Size(218, 30);
        lblBooksTitle.TabIndex = 0;
        lblBooksTitle.Text = "Toplam Kitap";

        // lblBooksValue
        lblBooksValue.Dock = DockStyle.Fill;
        lblBooksValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblBooksValue.ForeColor = Color.FromArgb(37, 99, 235);
        lblBooksValue.Location = new Point(18, 48);
        lblBooksValue.Name = "lblBooksValue";
        lblBooksValue.Size = new Size(218, 69);
        lblBooksValue.TabIndex = 1;
        lblBooksValue.Text = "0";
        lblBooksValue.TextAlign = ContentAlignment.MiddleLeft;

        // cardAvailable
        cardAvailable.BackColor = Color.White;
        cardAvailable.Controls.Add(lblAvailableValue);
        cardAvailable.Controls.Add(lblAvailableTitle);
        cardAvailable.Dock = DockStyle.Fill;
        cardAvailable.Margin = new Padding(0, 0, 12, 0);
        cardAvailable.Name = "cardAvailable";
        cardAvailable.Padding = new Padding(18);
        cardAvailable.TabIndex = 1;

        // lblAvailableTitle
        lblAvailableTitle.Dock = DockStyle.Top;
        lblAvailableTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAvailableTitle.ForeColor = Color.FromArgb(75, 85, 99);
        lblAvailableTitle.Location = new Point(18, 18);
        lblAvailableTitle.Name = "lblAvailableTitle";
        lblAvailableTitle.Size = new Size(218, 30);
        lblAvailableTitle.TabIndex = 0;
        lblAvailableTitle.Text = "Mevcut Kitap";

        // lblAvailableValue
        lblAvailableValue.Dock = DockStyle.Fill;
        lblAvailableValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblAvailableValue.ForeColor = Color.FromArgb(22, 163, 74);
        lblAvailableValue.Location = new Point(18, 48);
        lblAvailableValue.Name = "lblAvailableValue";
        lblAvailableValue.Size = new Size(218, 69);
        lblAvailableValue.TabIndex = 1;
        lblAvailableValue.Text = "0";
        lblAvailableValue.TextAlign = ContentAlignment.MiddleLeft;

        // cardLoaned
        cardLoaned.BackColor = Color.White;
        cardLoaned.Controls.Add(lblLoanedValue);
        cardLoaned.Controls.Add(lblLoanedTitle);
        cardLoaned.Dock = DockStyle.Fill;
        cardLoaned.Margin = new Padding(0, 0, 12, 0);
        cardLoaned.Name = "cardLoaned";
        cardLoaned.Padding = new Padding(18);
        cardLoaned.TabIndex = 2;

        // lblLoanedTitle
        lblLoanedTitle.Dock = DockStyle.Top;
        lblLoanedTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblLoanedTitle.ForeColor = Color.FromArgb(75, 85, 99);
        lblLoanedTitle.Location = new Point(18, 18);
        lblLoanedTitle.Name = "lblLoanedTitle";
        lblLoanedTitle.Size = new Size(218, 30);
        lblLoanedTitle.TabIndex = 0;
        lblLoanedTitle.Text = "Ödünçteki Kitap";

        // lblLoanedValue
        lblLoanedValue.Dock = DockStyle.Fill;
        lblLoanedValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblLoanedValue.ForeColor = Color.FromArgb(245, 158, 11);
        lblLoanedValue.Location = new Point(18, 48);
        lblLoanedValue.Name = "lblLoanedValue";
        lblLoanedValue.Size = new Size(218, 69);
        lblLoanedValue.TabIndex = 1;
        lblLoanedValue.Text = "0";
        lblLoanedValue.TextAlign = ContentAlignment.MiddleLeft;

        // cardLate
        cardLate.BackColor = Color.White;
        cardLate.Controls.Add(lblLateValue);
        cardLate.Controls.Add(lblLateTitle);
        cardLate.Dock = DockStyle.Fill;
        cardLate.Margin = new Padding(0);
        cardLate.Name = "cardLate";
        cardLate.Padding = new Padding(18);
        cardLate.TabIndex = 3;

        // lblLateTitle
        lblLateTitle.Dock = DockStyle.Top;
        lblLateTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblLateTitle.ForeColor = Color.FromArgb(75, 85, 99);
        lblLateTitle.Location = new Point(18, 18);
        lblLateTitle.Name = "lblLateTitle";
        lblLateTitle.Size = new Size(218, 30);
        lblLateTitle.TabIndex = 0;
        lblLateTitle.Text = "Geciken İade";

        // lblLateValue
        lblLateValue.Dock = DockStyle.Fill;
        lblLateValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblLateValue.ForeColor = Color.FromArgb(220, 38, 38);
        lblLateValue.Location = new Point(18, 48);
        lblLateValue.Name = "lblLateValue";
        lblLateValue.Size = new Size(218, 69);
        lblLateValue.TabIndex = 1;
        lblLateValue.Text = "0";
        lblLateValue.TextAlign = ContentAlignment.MiddleLeft;

        // pnlInfo
        pnlInfo.BackColor = Color.White;
        pnlInfo.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 11F, FontStyle.Regular),
            ForeColor = Color.FromArgb(75, 85, 99),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Sonraki adımda kitap listeleme ekranı bu ana ekran yapısına bağlanacak."
        });
        pnlInfo.Dock = DockStyle.Fill;
        pnlInfo.Location = new Point(24, 259);
        pnlInfo.Margin = new Padding(0);
        pnlInfo.Name = "pnlInfo";
        pnlInfo.Size = new Size(992, 367);
        pnlInfo.TabIndex = 3;

        // FrmDashboard
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 244, 246);
        ClientSize = new Size(1040, 650);
        Controls.Add(pnlInfo);
        Controls.Add(tableCards);
        Controls.Add(lblDescription);
        Controls.Add(lblWelcome);
        Name = "FrmDashboard";
        Padding = new Padding(24);
        Text = "Dashboard";

        tableCards.ResumeLayout(false);
        cardBooks.ResumeLayout(false);
        cardAvailable.ResumeLayout(false);
        cardLoaned.ResumeLayout(false);
        cardLate.ResumeLayout(false);
        pnlInfo.ResumeLayout(false);
        ResumeLayout(false);
    }
}