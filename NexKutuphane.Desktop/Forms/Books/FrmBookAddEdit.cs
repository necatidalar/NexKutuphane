using NexKutuphane.Contracts.Authors;
using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Categories;
using NexKutuphane.Contracts.Languages;
using NexKutuphane.Contracts.Publishers;
using NexKutuphane.Desktop.Services;

namespace NexKutuphane.Desktop.Forms.Books;

public partial class FrmBookAddEdit : Form
{
    private readonly int? _bookId;

    private readonly BookApiClient _bookApiClient;
    private readonly AuthorApiClient _authorApiClient;
    private readonly PublisherApiClient _publisherApiClient;
    private readonly CategoryApiClient _categoryApiClient;
    private readonly LanguageApiClient _languageApiClient;

    private BookDetailResponse? _bookDetail;

    public FrmBookAddEdit(int? bookId = null)
    {
        InitializeComponent();

        _bookId = bookId;

        _bookApiClient = new BookApiClient();
        _authorApiClient = new AuthorApiClient();
        _publisherApiClient = new PublisherApiClient();
        _categoryApiClient = new CategoryApiClient();
        _languageApiClient = new LanguageApiClient();

        Text = _bookId.HasValue ? "Kitap Düzenle" : "Kitap Ekle";
        lblTitle.Text = _bookId.HasValue ? "Kitap Düzenle" : "Yeni Kitap Ekle";
        btnSave.Text = _bookId.HasValue ? "Güncelle" : "Kaydet";
    }

    private async void FrmBookAddEdit_Load(object sender, EventArgs e)
    {
        await LoadLookupsAsync();

        if (_bookId.HasValue)
        {
            await LoadBookDetailAsync(_bookId.Value);
        }
        else
        {
            SetDefaultValues();
        }
    }

    private async Task LoadLookupsAsync()
    {
        try
        {
            SetLoading(true);

            await LoadAuthorsAsync();
            await LoadPublishersAsync();
            await LoadCategoriesAsync();
            await LoadLanguagesAsync();
            LoadStatuses();
        }
        finally
        {
            SetLoading(false);
        }
    }

    private async Task LoadAuthorsAsync()
    {
        var result = await _authorApiClient.GetAllAsync();

        checkedListAuthors.Items.Clear();

        if (result?.BasariliMi == true && result.Veri is not null)
        {
            foreach (AuthorListResponse author in result.Veri.Where(x => x.AktifMi))
            {
                checkedListAuthors.Items.Add(new LookupItem(author.Id, author.AdSoyad));
            }
        }
    }

    private async Task LoadPublishersAsync()
    {
        var result = await _publisherApiClient.GetAllAsync();

        var items = new List<LookupItem>
        {
            new(null, "Yayınevi seçiniz")
        };

        if (result?.BasariliMi == true && result.Veri is not null)
        {
            items.AddRange(result.Veri
                .Where(x => x.AktifMi)
                .Select(x => new LookupItem(x.Id, x.YayineviAdi)));
        }

        cmbPublisher.DataSource = items;
        cmbPublisher.DisplayMember = nameof(LookupItem.Text);
        cmbPublisher.ValueMember = nameof(LookupItem.Id);
    }

    private async Task LoadCategoriesAsync()
    {
        var result = await _categoryApiClient.GetAllAsync();

        var items = new List<LookupItem>
        {
            new(null, "Kategori seçiniz")
        };

        if (result?.BasariliMi == true && result.Veri is not null)
        {
            items.AddRange(result.Veri
                .Where(x => x.AktifMi)
                .Select(x => new LookupItem(x.Id, x.KategoriAdi)));
        }

        cmbCategory.DataSource = items;
        cmbCategory.DisplayMember = nameof(LookupItem.Text);
        cmbCategory.ValueMember = nameof(LookupItem.Id);
    }

    private async Task LoadLanguagesAsync()
    {
        var result = await _languageApiClient.GetAllAsync();

        var items = new List<LookupItem>
        {
            new(null, "Dil seçiniz")
        };

        if (result?.BasariliMi == true && result.Veri is not null)
        {
            items.AddRange(result.Veri
                .Where(x => x.AktifMi)
                .Select(x => new LookupItem(x.Id, x.DilAdi)));
        }

        cmbOriginalLanguage.DataSource = new List<LookupItem>(items);
        cmbOriginalLanguage.DisplayMember = nameof(LookupItem.Text);
        cmbOriginalLanguage.ValueMember = nameof(LookupItem.Id);

        cmbTranslationLanguage.DataSource = new List<LookupItem>(items);
        cmbTranslationLanguage.DisplayMember = nameof(LookupItem.Text);
        cmbTranslationLanguage.ValueMember = nameof(LookupItem.Id);
    }

    private void LoadStatuses()
    {
        var statuses = new List<LookupItem>
        {
            new(1, "Müsait"),
            new(2, "Ödünçte"),
            new(3, "Rezerve"),
            new(4, "Kayıp"),
            new(5, "Hasarlı"),
            new(6, "Pasif")
        };

        cmbStatus.DataSource = statuses;
        cmbStatus.DisplayMember = nameof(LookupItem.Text);
        cmbStatus.ValueMember = nameof(LookupItem.Id);
    }

    private async Task LoadBookDetailAsync(int bookId)
    {
        var result = await _bookApiClient.GetByIdAsync(bookId);

        if (result is null)
        {
            MessageBox.Show(
                "API cevabı alınamadı.",
                "Bağlantı Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            Close();
            return;
        }

        if (!result.BasariliMi || result.Veri is null)
        {
            MessageBox.Show(
                result.Mesaj,
                "Kitap Bulunamadı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
            return;
        }

        _bookDetail = result.Veri;

        txtBookName.Text = _bookDetail.KitapAdi;
        txtBarcode.Text = _bookDetail.Barkod;
        txtDemirbasNo.Text = _bookDetail.DemirbasNo;
        txtIsbn.Text = _bookDetail.ISBN;
        txtYayinYili.Text = _bookDetail.YayinYili?.ToString();
        txtBaskiYili.Text = _bookDetail.BaskiYili?.ToString();
        txtSayfaSayisi.Text = _bookDetail.SayfaSayisi?.ToString();
        txtStock.Text = _bookDetail.StokAdedi.ToString();
        txtTranslator.Text = _bookDetail.CevirmenAdi;
        txtDescription.Text = _bookDetail.Aciklama;

        SetComboSelectedValue(cmbStatus, _bookDetail.DurumId);
        SetComboSelectedValue(cmbPublisher, _bookDetail.YayineviId);
        SetComboSelectedValue(cmbCategory, _bookDetail.KategoriId);
        SetComboSelectedValue(cmbOriginalLanguage, _bookDetail.OrijinalDilId);
        SetComboSelectedValue(cmbTranslationLanguage, _bookDetail.CeviriDilId);

        chkTranslation.Checked = _bookDetail.CeviriMi;
        chkActive.Checked = _bookDetail.AktifMi;

        SetSelectedAuthors(_bookDetail.Yazarlar.Select(x => x.Id).ToList());

        UpdateTranslationControls();
    }

    private void SetDefaultValues()
    {
        txtStock.Text = "1";
        chkActive.Checked = true;
        SetComboSelectedValue(cmbStatus, 1);
        UpdateTranslationControls();
    }

    private void SetSelectedAuthors(List<int> authorIds)
    {
        for (int i = 0; i < checkedListAuthors.Items.Count; i++)
        {
            if (checkedListAuthors.Items[i] is LookupItem item && item.Id.HasValue)
            {
                checkedListAuthors.SetItemChecked(i, authorIds.Contains(item.Id.Value));
            }
        }
    }

    private static void SetComboSelectedValue(ComboBox comboBox, int? value)
    {
        if (!value.HasValue)
        {
            comboBox.SelectedIndex = 0;
            return;
        }

        foreach (var item in comboBox.Items)
        {
            if (item is LookupItem lookupItem && lookupItem.Id == value.Value)
            {
                comboBox.SelectedItem = lookupItem;
                return;
            }
        }

        comboBox.SelectedIndex = 0;
    }

    private void chkTranslation_CheckedChanged(object sender, EventArgs e)
    {
        UpdateTranslationControls();
    }

    private void UpdateTranslationControls()
    {
        cmbTranslationLanguage.Enabled = chkTranslation.Checked;
        txtTranslator.Enabled = chkTranslation.Checked;

        if (!chkTranslation.Checked)
        {
            cmbTranslationLanguage.SelectedIndex = 0;
            txtTranslator.Clear();
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        var errors = ValidateForm();

        if (errors.Any())
        {
            MessageBox.Show(
                string.Join(Environment.NewLine, errors),
                "Eksik veya Hatalı Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (_bookId.HasValue)
        {
            await UpdateBookAsync();
        }
        else
        {
            await CreateBookAsync();
        }
    }

    private async Task CreateBookAsync()
    {
        var request = new BookCreateRequest
        {
            KitapAdi = txtBookName.Text.Trim(),
            Barkod = NormalizeNullable(txtBarcode.Text),
            DemirbasNo = NormalizeNullable(txtDemirbasNo.Text),
            ISBN = NormalizeNullable(txtIsbn.Text),
            YayinYili = ParseNullableInt(txtYayinYili.Text),
            BaskiYili = ParseNullableInt(txtBaskiYili.Text),
            SayfaSayisi = ParseNullableInt(txtSayfaSayisi.Text),
            StokAdedi = ParseRequiredInt(txtStock.Text),
            DurumId = GetSelectedId(cmbStatus) ?? 1,
            Aciklama = NormalizeNullable(txtDescription.Text),
            YayineviId = GetSelectedId(cmbPublisher),
            KategoriId = GetSelectedId(cmbCategory),
            OrijinalDilId = GetSelectedId(cmbOriginalLanguage),
            CeviriDilId = chkTranslation.Checked ? GetSelectedId(cmbTranslationLanguage) : null,
            CevirmenAdi = chkTranslation.Checked ? NormalizeNullable(txtTranslator.Text) : null,
            CeviriMi = chkTranslation.Checked,
            YazarIdleri = GetSelectedAuthorIds()
        };

        SetLoading(true);

        var result = await _bookApiClient.CreateAsync(request);

        SetLoading(false);

        HandleSaveResult(result, "Kitap başarıyla eklendi.");
    }

    private async Task UpdateBookAsync()
    {
        if (!_bookId.HasValue)
        {
            return;
        }

        var request = new BookUpdateRequest
        {
            KitapAdi = txtBookName.Text.Trim(),
            Barkod = NormalizeNullable(txtBarcode.Text),
            DemirbasNo = NormalizeNullable(txtDemirbasNo.Text),
            ISBN = NormalizeNullable(txtIsbn.Text),
            YayinYili = ParseNullableInt(txtYayinYili.Text),
            BaskiYili = ParseNullableInt(txtBaskiYili.Text),
            SayfaSayisi = ParseNullableInt(txtSayfaSayisi.Text),
            StokAdedi = ParseRequiredInt(txtStock.Text),
            DurumId = GetSelectedId(cmbStatus) ?? 1,
            Aciklama = NormalizeNullable(txtDescription.Text),
            YayineviId = GetSelectedId(cmbPublisher),
            KategoriId = GetSelectedId(cmbCategory),
            OrijinalDilId = GetSelectedId(cmbOriginalLanguage),
            CeviriDilId = chkTranslation.Checked ? GetSelectedId(cmbTranslationLanguage) : null,
            CevirmenAdi = chkTranslation.Checked ? NormalizeNullable(txtTranslator.Text) : null,
            CeviriMi = chkTranslation.Checked,
            AktifMi = chkActive.Checked,
            YazarIdleri = GetSelectedAuthorIds()
        };

        SetLoading(true);

        var result = await _bookApiClient.UpdateAsync(_bookId.Value, request);

        SetLoading(false);

        HandleSaveResult(result, "Kitap başarıyla güncellendi.");
    }

    private void HandleSaveResult(object? resultObject, string defaultSuccessMessage)
    {
        dynamic? result = resultObject;

        if (result is null)
        {
            MessageBox.Show(
                "API cevabı alınamadı.",
                "Bağlantı Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (!result.BasariliMi)
        {
            string errorMessage = result.Mesaj;

            if (result.Hatalar is not null && result.Hatalar.Count > 0)
            {
                errorMessage += Environment.NewLine + string.Join(Environment.NewLine, result.Hatalar);
            }

            MessageBox.Show(
                errorMessage,
                "Kayıt Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        MessageBox.Show(
            string.IsNullOrWhiteSpace(result.Mesaj) ? defaultSuccessMessage : result.Mesaj,
            "Başarılı",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private List<string> ValidateForm()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(txtBookName.Text))
        {
            errors.Add("Kitap adı zorunludur.");
        }

        if (txtBookName.Text.Length > 200)
        {
            errors.Add("Kitap adı en fazla 200 karakter olabilir.");
        }

        if (!string.IsNullOrWhiteSpace(txtYayinYili.Text) && !int.TryParse(txtYayinYili.Text, out _))
        {
            errors.Add("Yayın yılı sayısal olmalıdır.");
        }

        if (!string.IsNullOrWhiteSpace(txtBaskiYili.Text) && !int.TryParse(txtBaskiYili.Text, out _))
        {
            errors.Add("Baskı yılı sayısal olmalıdır.");
        }

        if (!string.IsNullOrWhiteSpace(txtSayfaSayisi.Text) && !int.TryParse(txtSayfaSayisi.Text, out _))
        {
            errors.Add("Sayfa sayısı sayısal olmalıdır.");
        }

        if (string.IsNullOrWhiteSpace(txtStock.Text) || !int.TryParse(txtStock.Text, out int stock))
        {
            errors.Add("Stok adedi zorunlu ve sayısal olmalıdır.");
        }
        else if (stock < 0)
        {
            errors.Add("Stok adedi 0'dan küçük olamaz.");
        }

        if (!GetSelectedAuthorIds().Any())
        {
            errors.Add("En az bir yazar seçilmelidir.");
        }

        if (chkTranslation.Checked && GetSelectedId(cmbTranslationLanguage) is null)
        {
            errors.Add("Çeviri kitaplarda çeviri dili seçilmelidir.");
        }

        return errors;
    }

    private List<int> GetSelectedAuthorIds()
    {
        return checkedListAuthors.CheckedItems
            .OfType<LookupItem>()
            .Where(x => x.Id.HasValue)
            .Select(x => x.Id!.Value)
            .ToList();
    }

    private static int? GetSelectedId(ComboBox comboBox)
    {
        if (comboBox.SelectedItem is LookupItem item)
        {
            return item.Id;
        }

        return null;
    }

    private static int? ParseNullableInt(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return int.TryParse(value.Trim(), out int result)
            ? result
            : null;
    }

    private static int ParseRequiredInt(string value)
    {
        return int.TryParse(value.Trim(), out int result)
            ? result
            : 0;
    }

    private static string? NormalizeNullable(string value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void SetLoading(bool isLoading)
    {
        btnSave.Enabled = !isLoading;
        btnCancel.Enabled = !isLoading;
        lblStatus.Text = isLoading ? "İşlem yapılıyor..." : "Hazır";
    }

    private sealed class LookupItem
    {
        public LookupItem(int? id, string text)
        {
            Id = id;
            Text = text;
        }

        public int? Id { get; }

        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}