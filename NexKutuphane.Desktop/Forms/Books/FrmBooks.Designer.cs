namespace NexKutuphane.Desktop.Forms.Books;

partial class FrmBooks
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlTop;
    private Panel pnlActions;
    private Panel pnlBottom;
    private Label lblTitle;
    private Label lblDescription;
    private Label lblSearch;
    private Label lblSummary;
    private Label lblStatus;
    private TextBox txtSearch;
    private Button btnRefresh;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private DataGridView dgvBooks;

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
        pnlTop = new Panel();
        lblDescription = new Label();
        lblTitle = new Label();
        pnlActions = new Panel();
        btnDelete = new Button();
        btnEdit = new Button();
        btnAdd = new Button();
        btnRefresh = new Button();
        txtSearch = new TextBox();
        lblSearch = new Label();
        dgvBooks = new DataGridView();
        pnlBottom = new Panel();
        lblStatus = new Label();
        lblSummary = new Label();

        pnlTop.SuspendLayout();
        pnlActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // pnlTop
        pnlTop.BackColor = Color.White;
        pnlTop.Controls.Add(lblDescription);
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(18, 18);
        pnlTop.Name = "pnlTop";
        pnlTop.Padding = new Padding(18, 12, 18, 12);
        pnlTop.Size = new Size(1004, 86);
        pnlTop.TabIndex = 0;

        // lblTitle
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
        lblTitle.Location = new Point(18, 12);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(968, 38);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Kitap İşlemleri";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;

        // lblDescription
        lblDescription.Dock = DockStyle.Top;
        lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        lblDescription.ForeColor = Color.FromArgb(75, 85, 99);
        lblDescription.Location = new Point(18, 50);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(968, 24);
        lblDescription.TabIndex = 1;
        lblDescription.Text = "Kitapları listeleyebilir, arayabilir, yenileyebilir ve sonraki adımlarda ekleme/düzenleme işlemlerini yapabilirsiniz.";
        lblDescription.TextAlign = ContentAlignment.MiddleLeft;

        // pnlActions
        pnlActions.BackColor = Color.White;
        pnlActions.Controls.Add(btnDelete);
        pnlActions.Controls.Add(btnEdit);
        pnlActions.Controls.Add(btnAdd);
        pnlActions.Controls.Add(btnRefresh);
        pnlActions.Controls.Add(txtSearch);
        pnlActions.Controls.Add(lblSearch);
        pnlActions.Dock = DockStyle.Top;
        pnlActions.Location = new Point(18, 116);
        pnlActions.Name = "pnlActions";
        pnlActions.Padding = new Padding(18, 14, 18, 14);
        pnlActions.Size = new Size(1004, 72);
        pnlActions.TabIndex = 1;

        // lblSearch
        lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblSearch.ForeColor = Color.FromArgb(55, 65, 81);
        lblSearch.Location = new Point(18, 23);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(55, 25);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Ara:";
        lblSearch.TextAlign = ContentAlignment.MiddleLeft;

        // txtSearch
        txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.Location = new Point(79, 22);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Kitap adı, yazar, barkod, demirbaş no, ISBN, kategori veya yayınevi ara...";
        txtSearch.Size = new Size(465, 25);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;

        // btnRefresh
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.BackColor = Color.FromArgb(75, 85, 99);
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(560, 19);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(95, 32);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "Yenile";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;

        // btnAdd
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.BackColor = Color.FromArgb(37, 99, 235);
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAdd.ForeColor = Color.White;
        btnAdd.Location = new Point(661, 19);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(95, 32);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Ekle";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;

        // btnEdit
        btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnEdit.BackColor = Color.FromArgb(245, 158, 11);
        btnEdit.FlatAppearance.BorderSize = 0;
        btnEdit.FlatStyle = FlatStyle.Flat;
        btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEdit.ForeColor = Color.White;
        btnEdit.Location = new Point(762, 19);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(95, 32);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "Düzenle";
        btnEdit.UseVisualStyleBackColor = false;
        btnEdit.Click += btnEdit_Click;

        // btnDelete
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.BackColor = Color.FromArgb(220, 38, 38);
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDelete.ForeColor = Color.White;
        btnDelete.Location = new Point(863, 19);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(95, 32);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "Sil";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;

        // dgvBooks
        dgvBooks.AllowUserToAddRows = false;
        dgvBooks.AllowUserToDeleteRows = false;
        dgvBooks.AllowUserToResizeRows = false;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBooks.BackgroundColor = Color.White;
        dgvBooks.BorderStyle = BorderStyle.None;
        dgvBooks.ColumnHeadersHeight = 38;
        dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvBooks.Dock = DockStyle.Fill;
        dgvBooks.EnableHeadersVisualStyles = false;
        dgvBooks.GridColor = Color.FromArgb(229, 231, 235);
        dgvBooks.Location = new Point(18, 200);
        dgvBooks.MultiSelect = false;
        dgvBooks.Name = "dgvBooks";
        dgvBooks.ReadOnly = true;
        dgvBooks.RowHeadersVisible = false;
        dgvBooks.RowTemplate.Height = 34;
        dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.Size = new Size(1004, 390);
        dgvBooks.TabIndex = 2;
        dgvBooks.CellDoubleClick += dgvBooks_CellDoubleClick;

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            HeaderText = "ID",
            Name = "colId",
            FillWeight = 45
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "KitapAdi",
            HeaderText = "Kitap Adı",
            Name = "colKitapAdi",
            FillWeight = 180
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Yazarlar",
            HeaderText = "Yazar",
            Name = "colYazarlar",
            FillWeight = 150
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Barkod",
            HeaderText = "Barkod",
            Name = "colBarkod",
            FillWeight = 110
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DemirbasNo",
            HeaderText = "Demirbaş No",
            Name = "colDemirbasNo",
            FillWeight = 110
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "KategoriAdi",
            HeaderText = "Kategori",
            Name = "colKategori",
            FillWeight = 110
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "YayineviAdi",
            HeaderText = "Yayınevi",
            Name = "colYayinevi",
            FillWeight = 140
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "StokAdedi",
            HeaderText = "Stok",
            Name = "colStok",
            FillWeight = 60
        });

        dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Durum",
            HeaderText = "Durum",
            Name = "colDurum",
            FillWeight = 80
        });

        dgvBooks.Columns.Add(new DataGridViewCheckBoxColumn
        {
            DataPropertyName = "AktifMi",
            HeaderText = "Aktif",
            Name = "colAktif",
            FillWeight = 55
        });

        // pnlBottom
        pnlBottom.BackColor = Color.White;
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(18, 590);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Padding = new Padding(18, 0, 18, 0);
        pnlBottom.Size = new Size(1004, 42);
        pnlBottom.TabIndex = 3;

        // lblSummary
        lblSummary.Dock = DockStyle.Left;
        lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblSummary.ForeColor = Color.FromArgb(75, 85, 99);
        lblSummary.Location = new Point(18, 0);
        lblSummary.Name = "lblSummary";
        lblSummary.Size = new Size(420, 42);
        lblSummary.TabIndex = 0;
        lblSummary.Text = "Toplam 0 kitap listelendi.";
        lblSummary.TextAlign = ContentAlignment.MiddleLeft;

        // lblStatus
        lblStatus.Dock = DockStyle.Right;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblStatus.ForeColor = Color.FromArgb(75, 85, 99);
        lblStatus.Location = new Point(766, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(220, 42);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "Hazır";
        lblStatus.TextAlign = ContentAlignment.MiddleRight;

        // FrmBooks
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 244, 246);
        ClientSize = new Size(1040, 650);
        Controls.Add(dgvBooks);
        Controls.Add(pnlBottom);
        Controls.Add(pnlActions);
        Controls.Add(pnlTop);
        Name = "FrmBooks";
        Padding = new Padding(18);
        Text = "Kitap İşlemleri";
        Load += FrmBooks_Load;

        pnlTop.ResumeLayout(false);
        pnlActions.ResumeLayout(false);
        pnlActions.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }
}