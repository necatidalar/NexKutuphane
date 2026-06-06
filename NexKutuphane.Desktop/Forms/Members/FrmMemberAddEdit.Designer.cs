namespace NexKutuphane.Desktop.Forms.Members;

partial class FrmMemberAddEdit
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlHeader;
    private Panel pnlFooter;
    private TableLayoutPanel tableMain;

    private Label lblTitle;
    private Label lblDescription;
    private Label lblStatus;

    private Label lblFirstName;
    private Label lblLastName;
    private Label lblSchoolNo;
    private Label lblIdentityNo;
    private Label lblBirthDate;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblMemberType;
    private Label lblClass;
    private Label lblBranch;
    private Label lblDepartment;
    private Label lblArea;
    private Label lblStatusCombo;
    private Label lblGuardianName;
    private Label lblGuardianPhone;
    private Label lblGuardianRelation;
    private Label lblAddress;
    private Label lblMemberDescription;

    private TextBox txtFirstName;
    private TextBox txtLastName;
    private TextBox txtSchoolNo;
    private TextBox txtIdentityNo;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private TextBox txtGuardianName;
    private TextBox txtGuardianPhone;
    private TextBox txtGuardianRelation;
    private TextBox txtAddress;
    private TextBox txtDescription;

    private DateTimePicker dtpBirthDate;

    private ComboBox cmbMemberType;
    private ComboBox cmbClass;
    private ComboBox cmbBranch;
    private ComboBox cmbDepartment;
    private ComboBox cmbArea;
    private ComboBox cmbStatus;

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
        lblFirstName = new Label();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        txtLastName = new TextBox();
        lblSchoolNo = new Label();
        txtSchoolNo = new TextBox();
        lblIdentityNo = new Label();
        txtIdentityNo = new TextBox();
        lblBirthDate = new Label();
        dtpBirthDate = new DateTimePicker();
        lblPhone = new Label();
        txtPhone = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblMemberType = new Label();
        cmbMemberType = new ComboBox();
        lblClass = new Label();
        cmbClass = new ComboBox();
        lblBranch = new Label();
        cmbBranch = new ComboBox();
        lblDepartment = new Label();
        cmbDepartment = new ComboBox();
        lblArea = new Label();
        cmbArea = new ComboBox();
        lblStatusCombo = new Label();
        cmbStatus = new ComboBox();
        chkActive = new CheckBox();
        lblGuardianName = new Label();
        txtGuardianName = new TextBox();
        lblGuardianPhone = new Label();
        txtGuardianPhone = new TextBox();
        lblGuardianRelation = new Label();
        txtGuardianRelation = new TextBox();
        lblAddress = new Label();
        txtAddress = new TextBox();
        lblMemberDescription = new Label();
        txtDescription = new TextBox();
        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        tableMain.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblDescription);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(20, 12, 20, 12);
        pnlHeader.Size = new Size(900, 82);
        pnlHeader.TabIndex = 0;
        // 
        // lblDescription
        // 
        lblDescription.Dock = DockStyle.Top;
        lblDescription.Font = new Font("Segoe UI", 9.5F);
        lblDescription.ForeColor = Color.FromArgb(75, 85, 99);
        lblDescription.Location = new Point(20, 47);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(860, 24);
        lblDescription.TabIndex = 1;
        lblDescription.Text = "Öğrenci, öğretmen, personel veya dış üye bilgilerini girin.";
        lblDescription.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
        lblTitle.Location = new Point(20, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(860, 35);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Üye Ekle";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.White;
        pnlFooter.Controls.Add(lblStatus);
        pnlFooter.Controls.Add(btnCancel);
        pnlFooter.Controls.Add(btnSave);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 626);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(20, 12, 20, 12);
        pnlFooter.Size = new Size(900, 64);
        pnlFooter.TabIndex = 2;
        // 
        // lblStatus
        // 
        lblStatus.Dock = DockStyle.Left;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.FromArgb(75, 85, 99);
        lblStatus.Location = new Point(20, 12);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(260, 40);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "Hazır";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancel.BackColor = Color.FromArgb(107, 114, 128);
        btnCancel.FlatAppearance.BorderSize = 0;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(669, 16);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(100, 34);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "İptal";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.BackColor = Color.FromArgb(37, 99, 235);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(780, 16);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(100, 34);
        btnSave.TabIndex = 2;
        btnSave.Text = "Kaydet";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // tableMain
        // 
        tableMain.BackColor = Color.FromArgb(243, 244, 246);
        tableMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        tableMain.ColumnCount = 4;
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableMain.Controls.Add(lblFirstName, 0, 0);
        tableMain.Controls.Add(txtFirstName, 1, 0);
        tableMain.Controls.Add(lblLastName, 2, 0);
        tableMain.Controls.Add(txtLastName, 3, 0);
        tableMain.Controls.Add(lblSchoolNo, 0, 1);
        tableMain.Controls.Add(txtSchoolNo, 1, 1);
        tableMain.Controls.Add(lblIdentityNo, 2, 1);
        tableMain.Controls.Add(txtIdentityNo, 3, 1);
        tableMain.Controls.Add(lblBirthDate, 0, 2);
        tableMain.Controls.Add(dtpBirthDate, 1, 2);
        tableMain.Controls.Add(lblPhone, 2, 2);
        tableMain.Controls.Add(txtPhone, 3, 2);
        tableMain.Controls.Add(lblEmail, 0, 3);
        tableMain.Controls.Add(txtEmail, 1, 3);
        tableMain.Controls.Add(lblMemberType, 2, 3);
        tableMain.Controls.Add(cmbMemberType, 3, 3);
        tableMain.Controls.Add(lblClass, 0, 4);
        tableMain.Controls.Add(cmbClass, 1, 4);
        tableMain.Controls.Add(lblBranch, 2, 4);
        tableMain.Controls.Add(cmbBranch, 3, 4);
        tableMain.Controls.Add(lblDepartment, 0, 5);
        tableMain.Controls.Add(cmbDepartment, 1, 5);
        tableMain.Controls.Add(lblArea, 2, 5);
        tableMain.Controls.Add(cmbArea, 3, 5);
        tableMain.Controls.Add(lblStatusCombo, 0, 6);
        tableMain.Controls.Add(cmbStatus, 1, 6);
        tableMain.Controls.Add(chkActive, 3, 6);
        tableMain.Controls.Add(lblGuardianName, 0, 7);
        tableMain.Controls.Add(txtGuardianName, 1, 7);
        tableMain.Controls.Add(lblGuardianPhone, 2, 7);
        tableMain.Controls.Add(txtGuardianPhone, 3, 7);
        tableMain.Controls.Add(lblGuardianRelation, 0, 8);
        tableMain.Controls.Add(txtGuardianRelation, 1, 8);
        tableMain.Controls.Add(lblAddress, 0, 9);
        tableMain.Controls.Add(txtAddress, 1, 9);
        tableMain.Controls.Add(lblMemberDescription, 0, 10);
        tableMain.Controls.Add(txtDescription, 1, 10);
        tableMain.Dock = DockStyle.Fill;
        tableMain.Location = new Point(0, 82);
        tableMain.Name = "tableMain";
        tableMain.Padding = new Padding(20, 18, 20, 18);
        tableMain.RowCount = 11;
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableMain.Size = new Size(900, 544);
        tableMain.TabIndex = 1;
        ConfigureLabel(lblFirstName, "Ad *");
        ConfigureLabel(lblLastName, "Soyad *");
        ConfigureLabel(lblSchoolNo, "Okul No");
        ConfigureLabel(lblIdentityNo, "Kimlik No");
        ConfigureLabel(lblBirthDate, "Doğum Tarihi");
        ConfigureLabel(lblPhone, "Telefon");
        ConfigureLabel(lblEmail, "E-posta");
        ConfigureLabel(lblMemberType, "Üye Türü");
        ConfigureLabel(lblClass, "Sınıf");
        ConfigureLabel(lblBranch, "Şube");
        ConfigureLabel(lblDepartment, "Bölüm");
        ConfigureLabel(lblArea, "Alan");
        ConfigureLabel(lblStatusCombo, "Durum *");
        ConfigureLabel(lblGuardianName, "Veli Ad Soyad");
        ConfigureLabel(lblGuardianPhone, "Veli Telefon");
        ConfigureLabel(lblGuardianRelation, "Veli Yakınlık");
        ConfigureLabel(lblAddress, "Adres");
        ConfigureLabel(lblMemberDescription, "Açıklama");

        ConfigureTextBox(txtFirstName);
        ConfigureTextBox(txtLastName);
        ConfigureTextBox(txtSchoolNo);
        ConfigureTextBox(txtIdentityNo);
        ConfigureTextBox(txtPhone);
        ConfigureTextBox(txtEmail);
        ConfigureTextBox(txtGuardianName);
        ConfigureTextBox(txtGuardianPhone);
        ConfigureTextBox(txtGuardianRelation);

        ConfigureComboBox(cmbMemberType);
        ConfigureComboBox(cmbClass);
        ConfigureComboBox(cmbBranch);
        ConfigureComboBox(cmbDepartment);
        ConfigureComboBox(cmbArea);
        ConfigureComboBox(cmbStatus);
        // 
        // lblFirstName
        // 
        lblFirstName.Location = new Point(23, 18);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(100, 23);
        lblFirstName.TabIndex = 0;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(168, 21);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(100, 23);
        txtFirstName.TabIndex = 1;
        // 
        // lblLastName
        // 
        lblLastName.Location = new Point(453, 18);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(100, 23);
        lblLastName.TabIndex = 2;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(598, 21);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(100, 23);
        txtLastName.TabIndex = 3;
        // 
        // lblSchoolNo
        // 
        lblSchoolNo.Location = new Point(23, 64);
        lblSchoolNo.Name = "lblSchoolNo";
        lblSchoolNo.Size = new Size(100, 23);
        lblSchoolNo.TabIndex = 4;
        // 
        // txtSchoolNo
        // 
        txtSchoolNo.Location = new Point(168, 67);
        txtSchoolNo.Name = "txtSchoolNo";
        txtSchoolNo.Size = new Size(100, 23);
        txtSchoolNo.TabIndex = 5;
        // 
        // lblIdentityNo
        // 
        lblIdentityNo.Location = new Point(453, 64);
        lblIdentityNo.Name = "lblIdentityNo";
        lblIdentityNo.Size = new Size(100, 23);
        lblIdentityNo.TabIndex = 6;
        // 
        // txtIdentityNo
        // 
        txtIdentityNo.Location = new Point(598, 67);
        txtIdentityNo.Name = "txtIdentityNo";
        txtIdentityNo.Size = new Size(100, 23);
        txtIdentityNo.TabIndex = 7;
        // 
        // lblBirthDate
        // 
        lblBirthDate.Location = new Point(23, 110);
        lblBirthDate.Name = "lblBirthDate";
        lblBirthDate.Size = new Size(100, 23);
        lblBirthDate.TabIndex = 8;
        // 
        // dtpBirthDate
        // 
        dtpBirthDate.Dock = DockStyle.Fill;
        dtpBirthDate.Font = new Font("Segoe UI", 10F);
        dtpBirthDate.Format = DateTimePickerFormat.Short;
        dtpBirthDate.Location = new Point(165, 116);
        dtpBirthDate.Margin = new Padding(0, 6, 10, 6);
        dtpBirthDate.Name = "dtpBirthDate";
        dtpBirthDate.ShowCheckBox = true;
        dtpBirthDate.Size = new Size(275, 25);
        dtpBirthDate.TabIndex = 9;
        // 
        // lblPhone
        // 
        lblPhone.Location = new Point(453, 110);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(100, 23);
        lblPhone.TabIndex = 10;
        // 
        // txtPhone
        // 
        txtPhone.Location = new Point(598, 113);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(100, 23);
        txtPhone.TabIndex = 11;
        // 
        // lblEmail
        // 
        lblEmail.Location = new Point(23, 156);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(100, 23);
        lblEmail.TabIndex = 12;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(168, 159);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(100, 23);
        txtEmail.TabIndex = 13;
        // 
        // lblMemberType
        // 
        lblMemberType.Location = new Point(453, 156);
        lblMemberType.Name = "lblMemberType";
        lblMemberType.Size = new Size(100, 23);
        lblMemberType.TabIndex = 14;
        // 
        // cmbMemberType
        // 
        cmbMemberType.Location = new Point(598, 159);
        cmbMemberType.Name = "cmbMemberType";
        cmbMemberType.Size = new Size(121, 23);
        cmbMemberType.TabIndex = 15;
        // 
        // lblClass
        // 
        lblClass.Location = new Point(23, 202);
        lblClass.Name = "lblClass";
        lblClass.Size = new Size(100, 23);
        lblClass.TabIndex = 16;
        // 
        // cmbClass
        // 
        cmbClass.Location = new Point(168, 205);
        cmbClass.Name = "cmbClass";
        cmbClass.Size = new Size(121, 23);
        cmbClass.TabIndex = 17;
        // 
        // lblBranch
        // 
        lblBranch.Location = new Point(453, 202);
        lblBranch.Name = "lblBranch";
        lblBranch.Size = new Size(100, 23);
        lblBranch.TabIndex = 18;
        // 
        // cmbBranch
        // 
        cmbBranch.Location = new Point(598, 205);
        cmbBranch.Name = "cmbBranch";
        cmbBranch.Size = new Size(121, 23);
        cmbBranch.TabIndex = 19;
        // 
        // lblDepartment
        // 
        lblDepartment.Location = new Point(23, 248);
        lblDepartment.Name = "lblDepartment";
        lblDepartment.Size = new Size(100, 23);
        lblDepartment.TabIndex = 20;
        // 
        // cmbDepartment
        // 
        cmbDepartment.Location = new Point(168, 251);
        cmbDepartment.Name = "cmbDepartment";
        cmbDepartment.Size = new Size(121, 23);
        cmbDepartment.TabIndex = 21;
        cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
        // 
        // lblArea
        // 
        lblArea.Location = new Point(453, 248);
        lblArea.Name = "lblArea";
        lblArea.Size = new Size(100, 23);
        lblArea.TabIndex = 22;
        // 
        // cmbArea
        // 
        cmbArea.Location = new Point(598, 251);
        cmbArea.Name = "cmbArea";
        cmbArea.Size = new Size(121, 23);
        cmbArea.TabIndex = 23;
        // 
        // lblStatusCombo
        // 
        lblStatusCombo.Location = new Point(23, 294);
        lblStatusCombo.Name = "lblStatusCombo";
        lblStatusCombo.Size = new Size(100, 23);
        lblStatusCombo.TabIndex = 24;
        // 
        // cmbStatus
        // 
        cmbStatus.Location = new Point(168, 297);
        cmbStatus.Name = "cmbStatus";
        cmbStatus.Size = new Size(121, 23);
        cmbStatus.TabIndex = 25;
        // 
        // chkActive
        // 
        chkActive.AutoSize = true;
        chkActive.Dock = DockStyle.Fill;
        chkActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        chkActive.ForeColor = Color.FromArgb(55, 65, 81);
        chkActive.Location = new Point(595, 304);
        chkActive.Margin = new Padding(0, 10, 10, 6);
        chkActive.Name = "chkActive";
        chkActive.Size = new Size(275, 30);
        chkActive.TabIndex = 26;
        chkActive.Text = "Aktif kayıt";
        // 
        // lblGuardianName
        // 
        lblGuardianName.Location = new Point(23, 340);
        lblGuardianName.Name = "lblGuardianName";
        lblGuardianName.Size = new Size(100, 23);
        lblGuardianName.TabIndex = 27;
        // 
        // txtGuardianName
        // 
        txtGuardianName.Location = new Point(168, 343);
        txtGuardianName.Name = "txtGuardianName";
        txtGuardianName.Size = new Size(100, 23);
        txtGuardianName.TabIndex = 28;
        // 
        // lblGuardianPhone
        // 
        lblGuardianPhone.Location = new Point(453, 340);
        lblGuardianPhone.Name = "lblGuardianPhone";
        lblGuardianPhone.Size = new Size(100, 23);
        lblGuardianPhone.TabIndex = 29;
        // 
        // txtGuardianPhone
        // 
        txtGuardianPhone.Location = new Point(598, 343);
        txtGuardianPhone.Name = "txtGuardianPhone";
        txtGuardianPhone.Size = new Size(100, 23);
        txtGuardianPhone.TabIndex = 30;
        // 
        // lblGuardianRelation
        // 
        lblGuardianRelation.Location = new Point(23, 386);
        lblGuardianRelation.Name = "lblGuardianRelation";
        lblGuardianRelation.Size = new Size(100, 23);
        lblGuardianRelation.TabIndex = 31;
        // 
        // txtGuardianRelation
        // 
        txtGuardianRelation.Location = new Point(168, 389);
        txtGuardianRelation.Name = "txtGuardianRelation";
        txtGuardianRelation.Size = new Size(100, 23);
        txtGuardianRelation.TabIndex = 32;
        // 
        // lblAddress
        // 
        lblAddress.Location = new Point(23, 432);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(100, 23);
        lblAddress.TabIndex = 33;
        // 
        // txtAddress
        // 
        tableMain.SetColumnSpan(txtAddress, 3);
        txtAddress.Dock = DockStyle.Fill;
        txtAddress.Font = new Font("Segoe UI", 10F);
        txtAddress.Location = new Point(165, 438);
        txtAddress.Margin = new Padding(0, 6, 10, 6);
        txtAddress.Multiline = true;
        txtAddress.Name = "txtAddress";
        txtAddress.ScrollBars = ScrollBars.Vertical;
        txtAddress.Size = new Size(705, 70);
        txtAddress.TabIndex = 34;
        // 
        // lblMemberDescription
        // 
        lblMemberDescription.Location = new Point(23, 514);
        lblMemberDescription.Name = "lblMemberDescription";
        lblMemberDescription.Size = new Size(100, 12);
        lblMemberDescription.TabIndex = 35;
        // 
        // txtDescription
        // 
        tableMain.SetColumnSpan(txtDescription, 3);
        txtDescription.Dock = DockStyle.Fill;
        txtDescription.Font = new Font("Segoe UI", 10F);
        txtDescription.Location = new Point(165, 520);
        txtDescription.Margin = new Padding(0, 6, 10, 6);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = ScrollBars.Vertical;
        txtDescription.Size = new Size(705, 1);
        txtDescription.TabIndex = 36;
        // 
        // FrmMemberAddEdit
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 244, 246);
        ClientSize = new Size(900, 690);
        Controls.Add(tableMain);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmMemberAddEdit";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Üye Ekle / Düzenle";
        Load += FrmMemberAddEdit_Load;
        pnlHeader.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        tableMain.ResumeLayout(false);
        tableMain.PerformLayout();
        ResumeLayout(false);
    }

    private static void ConfigureLabel(Label label, string text)
    {
        label.AutoSize = false;
        label.Dock = DockStyle.Fill;
        label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        label.ForeColor = Color.FromArgb(31, 41, 55);
        label.BackColor = Color.Transparent;
        label.Margin = new Padding(0, 6, 10, 6);
        label.Padding = new Padding(0, 0, 4, 0);
        label.Text = text;
        label.TextAlign = ContentAlignment.MiddleLeft;
        label.Visible = true;
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