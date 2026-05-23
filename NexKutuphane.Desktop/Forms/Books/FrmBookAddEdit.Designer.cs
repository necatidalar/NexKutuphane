namespace NexKutuphane.Desktop.Forms.Books;

partial class FrmBookAddEdit
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Panel pnlFooter;
    private TableLayoutPanel tableMain;

    private Label lblTitle;
    private Label lblDescription;
    private Label lblStatus;

    private Label lblBookName;
    private Label lblBarcode;
    private Label lblDemirbasNo;
    private Label lblIsbn;
    private Label lblYayinYili;
    private Label lblBaskiYili;
    private Label lblSayfaSayisi;
    private Label lblStock;
    private Label lblStatusCombo;
    private Label lblPublisher;
    private Label lblCategory;
    private Label lblOriginalLanguage;
    private Label lblTranslationLanguage;
    private Label lblTranslator;
    private Label lblAuthors;
    private Label lblBookDescription;

    private TextBox txtBookName;
    private TextBox txtBarcode;
    private TextBox txtDemirbasNo;
    private TextBox txtIsbn;
    private TextBox txtYayinYili;
    private TextBox txtBaskiYili;
    private TextBox txtSayfaSayisi;
    private TextBox txtStock;
    private TextBox txtTranslator;
    private TextBox txtDescription;

    private ComboBox cmbStatus;
    private ComboBox cmbPublisher;
    private ComboBox cmbCategory;
    private ComboBox cmbOriginalLanguage;
    private ComboBox cmbTranslationLanguage;

    private CheckedListBox checkedListAuthors;

    private CheckBox chkTranslation;
    private CheckBox chkActive;

    private Button btnSave;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new Panel();
        lblDescription = new Label();
        lblTitle = new Label();
        pnlFooter = new Panel();
        lblStatus = new Label();
        btnCancel = new Button();
        btnSave = new Button();
        tableMain = new TableLayoutPanel();

        lblBookName = new Label();
        lblBarcode = new Label();
        lblDemirbasNo = new Label();
        lblIsbn = new Label();
        lblYayinYili = new Label();
        lblBaskiYili = new Label();
        lblSayfaSayisi = new Label();
        lblStock = new Label();
        lblStatusCombo = new Label();
        lblPublisher = new Label();
        lblCategory = new Label();
        lblOriginalLanguage = new Label();
        lblTranslationLanguage = new Label();
        lblTranslator = new Label();
        lblAuthors = new Label();
        lblBookDescription = new Label();

        txtBookName = new TextBox();
        txtBarcode = new TextBox();
        txtDemirbasNo = new TextBox();
        txtIsbn = new TextBox();
        txtYayinYili = new TextBox();
        txtBaskiYili = new TextBox();
        txtSayfaSayisi = new TextBox();
        txtStock = new TextBox();
        txtTranslator = new TextBox();
        txtDescription = new TextBox();

        cmbStatus = new ComboBox();
        cmbPublisher = new ComboBox();
        cmbCategory = new ComboBox();
        cmbOriginalLanguage = new ComboBox();
        cmbTranslationLanguage = new ComboBox();

        checkedListAuthors = new CheckedListBox();

        chkTranslation = new CheckBox();
        chkActive = new CheckBox();

        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        tableMain.SuspendLayout();
        SuspendLayout();

        // pnlHeader
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblDescription);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(20, 12, 20, 12);
        pnlHeader.Size = new Size(860, 82);
        pnlHeader.TabIndex = 0;

        // lblTitle
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
        lblTitle.Location = new Point(20, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(820, 35);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Kitap Ekle";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;

        // lblDescription
        lblDescription.Dock = DockStyle.Top;
        lblDescription.Font = new Font("Segoe UI", 9.5F);
        lblDescription.ForeColor = Color.FromArgb(75, 85, 99);
        lblDescription.Location = new Point(20, 47);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(820, 24);
        lblDescription.TabIndex = 1;
        lblDescription.Text = "Kitap bilgilerini eksiksiz doldurun. Yazar seçimi zorunludur.";
        lblDescription.TextAlign = ContentAlignment.MiddleLeft;

        // pnlFooter
        pnlFooter.BackColor = Color.White;
        pnlFooter.Controls.Add(lblStatus);
        pnlFooter.Controls.Add(btnCancel);
        pnlFooter.Controls.Add(btnSave);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 618);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(20, 12, 20, 12);
        pnlFooter.Size = new Size(860, 64);
        pnlFooter.TabIndex = 2;

        // lblStatus
        lblStatus.Dock = DockStyle.Left;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.FromArgb(75, 85, 99);
        lblStatus.Location = new Point(20, 12);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(260, 40);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "Hazır";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;

        // btnCancel
        btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancel.BackColor = Color.FromArgb(107, 114, 128);
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(629, 16);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(100, 34);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "İptal";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;

        // btnSave
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(740, 16);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(100, 34);
        btnSave.TabIndex = 2;
        btnSave.Text = "Kaydet";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;

        // tableMain
        tableMain.BackColor = Color.FromArgb(243, 244, 246);
        tableMain.ColumnCount = 4;
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableMain.Controls.Add(lblBookName, 0, 0);
        tableMain.Controls.Add(txtBookName, 1, 0);
        tableMain.Controls.Add(lblBarcode, 2, 0);
        tableMain.Controls.Add(txtBarcode, 3, 0);

        tableMain.Controls.Add(lblDemirbasNo, 0, 1);
        tableMain.Controls.Add(txtDemirbasNo, 1, 1);
        tableMain.Controls.Add(lblIsbn, 2, 1);
        tableMain.Controls.Add(txtIsbn, 3, 1);

        tableMain.Controls.Add(lblYayinYili, 0, 2);
        tableMain.Controls.Add(txtYayinYili, 1, 2);
        tableMain.Controls.Add(lblBaskiYili, 2, 2);
        tableMain.Controls.Add(txtBaskiYili, 3, 2);

        tableMain.Controls.Add(lblSayfaSayisi, 0, 3);
        tableMain.Controls.Add(txtSayfaSayisi, 1, 3);
        tableMain.Controls.Add(lblStock, 2, 3);
        tableMain.Controls.Add(txtStock, 3, 3);

        tableMain.Controls.Add(lblStatusCombo, 0, 4);
        tableMain.Controls.Add(cmbStatus, 1, 4);
        tableMain.Controls.Add(lblPublisher, 2, 4);
        tableMain.Controls.Add(cmbPublisher, 3, 4);

        tableMain.Controls.Add(lblCategory, 0, 5);
        tableMain.Controls.Add(cmbCategory, 1, 5);
        tableMain.Controls.Add(lblOriginalLanguage, 2, 5);
        tableMain.Controls.Add(cmbOriginalLanguage, 3, 5);

        tableMain.Controls.Add(chkTranslation, 1, 6);
        tableMain.Controls.Add(lblTranslationLanguage, 2, 6);
        tableMain.Controls.Add(cmbTranslationLanguage, 3, 6);

        tableMain.Controls.Add(lblTranslator, 0, 7);
        tableMain.Controls.Add(txtTranslator, 1, 7);
        tableMain.Controls.Add(chkActive, 3, 7);

        tableMain.Controls.Add(lblAuthors, 0, 8);
        tableMain.Controls.Add(checkedListAuthors, 1, 8);

        tableMain.Controls.Add(lblBookDescription, 0, 9);
        tableMain.Controls.Add(txtDescription, 1, 9);

        tableMain.Dock = DockStyle.Fill;
        tableMain.Location = new Point(0, 82);
        tableMain.Name = "tableMain";
        tableMain.Padding = new Padding(20, 18, 20, 18);
        tableMain.RowCount = 10;
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableMain.Size = new Size(860, 536);
        tableMain.TabIndex = 1;

        ConfigureLabel(lblBookName, "Kitap Adı *");
        ConfigureLabel(lblBarcode, "Barkod");
        ConfigureLabel(lblDemirbasNo, "Demirbaş No");
        ConfigureLabel(lblIsbn, "ISBN");
        ConfigureLabel(lblYayinYili, "Yayın Yılı");
        ConfigureLabel(lblBaskiYili, "Baskı Yılı");
        ConfigureLabel(lblSayfaSayisi, "Sayfa Sayısı");
        ConfigureLabel(lblStock, "Stok *");
        ConfigureLabel(lblStatusCombo, "Durum");
        ConfigureLabel(lblPublisher, "Yayınevi");
        ConfigureLabel(lblCategory, "Kategori");
        ConfigureLabel(lblOriginalLanguage, "Orijinal Dil");
        ConfigureLabel(lblTranslationLanguage, "Çeviri Dili");
        ConfigureLabel(lblTranslator, "Çevirmen");
        ConfigureLabel(lblAuthors, "Yazarlar *");
        ConfigureLabel(lblBookDescription, "Açıklama");

        ConfigureTextBox(txtBookName);
        ConfigureTextBox(txtBarcode);
        ConfigureTextBox(txtDemirbasNo);
        ConfigureTextBox(txtIsbn);
        ConfigureTextBox(txtYayinYili);
        ConfigureTextBox(txtBaskiYili);
        ConfigureTextBox(txtSayfaSayisi);
        ConfigureTextBox(txtStock);
        ConfigureTextBox(txtTranslator);

        ConfigureComboBox(cmbStatus);
        ConfigureComboBox(cmbPublisher);
        ConfigureComboBox(cmbCategory);
        ConfigureComboBox(cmbOriginalLanguage);
        ConfigureComboBox(cmbTranslationLanguage);

        // txtDescription
        txtDescription.Dock = DockStyle.Fill;
        txtDescription.Font = new Font("Segoe UI", 10F);
        txtDescription.Margin = new Padding(0, 6, 10, 6);
        txtDescription.Multiline = true;
        txtDescription.ScrollBars = ScrollBars.Vertical;
        tableMain.SetColumnSpan(txtDescription, 3);

        // checkedListAuthors
        checkedListAuthors.CheckOnClick = true;
        checkedListAuthors.Dock = DockStyle.Fill;
        checkedListAuthors.Font = new Font("Segoe UI", 10F);
        checkedListAuthors.Margin = new Padding(0, 6, 10, 6);
        tableMain.SetColumnSpan(checkedListAuthors, 3);

        // chkTranslation
        chkTranslation.AutoSize = true;
        chkTranslation.Dock = DockStyle.Fill;
        chkTranslation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        chkTranslation.ForeColor = Color.FromArgb(55, 65, 81);
        chkTranslation.Margin = new Padding(0, 10, 10, 6);
        chkTranslation.Name = "chkTranslation";
        chkTranslation.Text = "Bu kitap çeviri eser";
        chkTranslation.CheckedChanged += chkTranslation_CheckedChanged;

        // chkActive
        chkActive.AutoSize = true;
        chkActive.Dock = DockStyle.Fill;
        chkActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        chkActive.ForeColor = Color.FromArgb(55, 65, 81);
        chkActive.Margin = new Padding(0, 10, 10, 6);
        chkActive.Name = "chkActive";
        chkActive.Text = "Aktif kayıt";

        // FrmBookAddEdit
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 244, 246);
        ClientSize = new Size(860, 682);
        Controls.Add(tableMain);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmBookAddEdit";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Kitap Ekle / Düzenle";
        Load += FrmBookAddEdit_Load;

        pnlHeader.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        tableMain.ResumeLayout(false);
        tableMain.PerformLayout();
        ResumeLayout(false);
    }

    private static void ConfigureLabel(Label label, string text)
    {
        label.Dock = DockStyle.Fill;
        label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        label.ForeColor = Color.FromArgb(55, 65, 81);
        label.Margin = new Padding(0, 6, 10, 6);
        label.Text = text;
        label.TextAlign = ContentAlignment.MiddleLeft;
    }

    private static void ConfigureTextBox(TextBox textBox)
    {
        textBox.Dock = DockStyle.Fill;
        textBox.Font = new Font("Segoe UI", 10F);
        textBox.Margin = new Padding(0, 6, 10, 6);
    }

    private static void ConfigureComboBox(ComboBox comboBox)
    {
        comboBox.Dock = DockStyle.Fill;
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.Font = new Font("Segoe UI", 10F);
        comboBox.Margin = new Padding(0, 6, 10, 6);
    }
}