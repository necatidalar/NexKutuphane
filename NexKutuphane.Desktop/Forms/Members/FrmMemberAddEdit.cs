using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Members;
using NexKutuphane.Desktop.Services;
using System.Runtime.InteropServices;

namespace NexKutuphane.Desktop.Forms.Members;

public partial class FrmMemberAddEdit : Form
{
    private readonly int? _memberId;
    private readonly MemberApiClient _memberApiClient;

    private MemberLookupsResponse? _lookups;
    private MemberDetailResponse? _memberDetail;

    public FrmMemberAddEdit(int? memberId = null)
    {
        InitializeComponent();

        _memberId = memberId;
        _memberApiClient = new MemberApiClient();

        Text = _memberId.HasValue ? "Üye Düzenle" : "Üye Ekle";
        lblTitle.Text = _memberId.HasValue ? "Üye Düzenle" : "Yeni Üye Ekle";
        btnSave.Text = _memberId.HasValue ? "Güncelle" : "Kaydet";
    }

    private async void FrmMemberAddEdit_Load(object sender, EventArgs e)
    {
        await LoadLookupsAsync();

        if (_memberId.HasValue)
        {
            await LoadMemberDetailAsync(_memberId.Value);
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

            var result = await _memberApiClient.GetLookupsAsync();

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
                    "Seçim Listesi Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            _lookups = result.Veri;

            FillCombo(cmbMemberType, _lookups.UyeTurleri, "Üye türü seçiniz");
            FillCombo(cmbClass, _lookups.Siniflar, "Sınıf seçiniz");
            FillCombo(cmbBranch, _lookups.Subeler, "Şube seçiniz");
            FillCombo(cmbDepartment, _lookups.Bolumler, "Bölüm seçiniz");
            FillCombo(cmbStatus, _lookups.Durumlar, "Durum seçiniz");

            FillAreaCombo(null);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private async Task LoadMemberDetailAsync(int memberId)
    {
        var result = await _memberApiClient.GetByIdAsync(memberId);

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
                "Üye Bulunamadı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
            return;
        }

        _memberDetail = result.Veri;

        txtFirstName.Text = _memberDetail.Ad;
        txtLastName.Text = _memberDetail.Soyad;
        txtSchoolNo.Text = _memberDetail.OkulNo;
        txtIdentityNo.Text = _memberDetail.KimlikNo;
        txtPhone.Text = _memberDetail.Telefon;
        txtEmail.Text = _memberDetail.Eposta;
        txtAddress.Text = _memberDetail.Adres;
        txtGuardianName.Text = _memberDetail.VeliAdSoyad;
        txtGuardianPhone.Text = _memberDetail.VeliTelefon;
        txtGuardianRelation.Text = _memberDetail.VeliYakinlik;
        txtDescription.Text = _memberDetail.Aciklama;

        if (_memberDetail.DogumTarihi.HasValue)
        {
            dtpBirthDate.Checked = true;
            dtpBirthDate.Value = _memberDetail.DogumTarihi.Value;
        }
        else
        {
            dtpBirthDate.Checked = false;
        }

        SetComboSelectedValue(cmbMemberType, _memberDetail.UyeTuruId);
        SetComboSelectedValue(cmbClass, _memberDetail.SinifId);
        SetComboSelectedValue(cmbBranch, _memberDetail.SubeId);
        SetComboSelectedValue(cmbDepartment, _memberDetail.BolumId);

        FillAreaCombo(_memberDetail.BolumId);
        SetComboSelectedValue(cmbArea, _memberDetail.AlanId);

        SetComboSelectedValue(cmbStatus, _memberDetail.DurumId);

        chkActive.Checked = _memberDetail.AktifMi;
    }

    private void SetDefaultValues()
    {
        dtpBirthDate.Checked = false;
        chkActive.Checked = true;
        SetComboSelectedValue(cmbStatus, 1);
    }

    private static void FillCombo(
        ComboBox comboBox,
        List<MemberLookupItemResponse> items,
        string defaultText)
    {
        var list = new List<LookupItem>
        {
            new(null, defaultText, null)
        };

        list.AddRange(items.Select(x => new LookupItem(x.Id, x.Ad, x.ParentId)));

        comboBox.DataSource = list;
        comboBox.DisplayMember = nameof(LookupItem.Text);
        comboBox.ValueMember = nameof(LookupItem.Id);
    }

    private void FillAreaCombo(int? departmentId)
    {
        if (_lookups is null)
        {
            return;
        }

        var areas = _lookups.Alanlar;

        if (departmentId.HasValue)
        {
            areas = areas
                .Where(x => x.ParentId == departmentId.Value)
                .ToList();
        }

        FillCombo(cmbArea, areas, "Alan seçiniz");
    }

    private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_memberDetail is not null)
        {
            return;
        }

        FillAreaCombo(GetSelectedId(cmbDepartment));
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

        if (_memberId.HasValue)
        {
            await UpdateMemberAsync();
        }
        else
        {
            await CreateMemberAsync();
        }
    }

    private async Task CreateMemberAsync()
    {
        var request = new MemberCreateRequest
        {
            Ad = txtFirstName.Text.Trim(),
            Soyad = txtLastName.Text.Trim(),
            OkulNo = NormalizeNullable(txtSchoolNo.Text),
            KimlikNo = NormalizeNullable(txtIdentityNo.Text),
            DogumTarihi = dtpBirthDate.Checked ? dtpBirthDate.Value.Date : null,
            Telefon = NormalizeNullable(txtPhone.Text),
            Eposta = NormalizeNullable(txtEmail.Text),
            Adres = NormalizeNullable(txtAddress.Text),
            DurumId = GetSelectedId(cmbStatus) ?? 1,
            UyeTuruId = GetSelectedId(cmbMemberType),
            SinifId = GetSelectedId(cmbClass),
            SubeId = GetSelectedId(cmbBranch),
            BolumId = GetSelectedId(cmbDepartment),
            AlanId = GetSelectedId(cmbArea),
            VeliAdSoyad = NormalizeNullable(txtGuardianName.Text),
            VeliTelefon = NormalizeNullable(txtGuardianPhone.Text),
            VeliYakinlik = NormalizeNullable(txtGuardianRelation.Text),
            Aciklama = NormalizeNullable(txtDescription.Text)
        };

        SetLoading(true);

        var result = await _memberApiClient.CreateAsync(request);

        SetLoading(false);

        HandleSaveResult(result, "Üye başarıyla eklendi.");
    }

    private async Task UpdateMemberAsync()
    {
        if (!_memberId.HasValue)
        {
            return;
        }

        var request = new MemberUpdateRequest
        {
            Ad = txtFirstName.Text.Trim(),
            Soyad = txtLastName.Text.Trim(),
            OkulNo = NormalizeNullable(txtSchoolNo.Text),
            KimlikNo = NormalizeNullable(txtIdentityNo.Text),
            DogumTarihi = dtpBirthDate.Checked ? dtpBirthDate.Value.Date : null,
            Telefon = NormalizeNullable(txtPhone.Text),
            Eposta = NormalizeNullable(txtEmail.Text),
            Adres = NormalizeNullable(txtAddress.Text),
            DurumId = GetSelectedId(cmbStatus) ?? 1,
            UyeTuruId = GetSelectedId(cmbMemberType),
            SinifId = GetSelectedId(cmbClass),
            SubeId = GetSelectedId(cmbBranch),
            BolumId = GetSelectedId(cmbDepartment),
            AlanId = GetSelectedId(cmbArea),
            VeliAdSoyad = NormalizeNullable(txtGuardianName.Text),
            VeliTelefon = NormalizeNullable(txtGuardianPhone.Text),
            VeliYakinlik = NormalizeNullable(txtGuardianRelation.Text),
            Aciklama = NormalizeNullable(txtDescription.Text),
            AktifMi = chkActive.Checked
        };

        SetLoading(true);

        var result = await _memberApiClient.UpdateAsync(_memberId.Value, request);

        SetLoading(false);

        HandleSaveResult(result, "Üye başarıyla güncellendi.");
    }

    private void HandleSaveResult(ApiResponse<MemberDetailResponse>? result, string defaultSuccessMessage)
    {
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
            var errorMessage = result.Mesaj;

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

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            errors.Add("Ad zorunludur.");
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            errors.Add("Soyad zorunludur.");
        }

        if (txtFirstName.Text.Length > 100)
        {
            errors.Add("Ad en fazla 100 karakter olabilir.");
        }

        if (txtLastName.Text.Length > 100)
        {
            errors.Add("Soyad en fazla 100 karakter olabilir.");
        }

        if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains('@'))
        {
            errors.Add("E-posta adresi geçerli görünmüyor.");
        }

        if (GetSelectedId(cmbStatus) is null)
        {
            errors.Add("Durum seçilmelidir.");
        }

        return errors;
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

    private static int? GetSelectedId(ComboBox comboBox)
    {
        if (comboBox.SelectedItem is LookupItem item)
        {
            return item.Id;
        }

        return null;
    }

    private static string? NormalizeNullable(string? value)
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
        public LookupItem(int? id, string text, int? parentId)
        {
            Id = id;
            Text = text;
            ParentId = parentId;
        }

        public int? Id { get; }

        public string Text { get; }

        public int? ParentId { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}