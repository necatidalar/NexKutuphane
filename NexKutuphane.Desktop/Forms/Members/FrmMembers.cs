using NexKutuphane.Contracts.Members;
using NexKutuphane.Desktop.Services;

namespace NexKutuphane.Desktop.Forms.Members;

public partial class FrmMembers : Form
{
    private readonly MemberApiClient _memberApiClient;
    private List<MemberListResponse> _allMembers = new();

    public FrmMembers()
    {
        InitializeComponent();

        _memberApiClient = new MemberApiClient();
    }

    private async void FrmMembers_Load(object sender, EventArgs e)
    {
        await LoadMembersAsync();
    }

    private async Task LoadMembersAsync()
    {
        try
        {
            SetLoading(true);

            var result = await _memberApiClient.GetAllAsync();

            if (result is null)
            {
                MessageBox.Show(
                    "API cevabı alınamadı. API projesinin çalıştığından emin olun.",
                    "Bağlantı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!result.BasariliMi)
            {
                MessageBox.Show(
                    result.Mesaj,
                    "API Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _allMembers = result.Veri ?? new List<MemberListResponse>();

            BindGrid(_allMembers);
            UpdateSummary(_allMembers.Count);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Üye listesi yüklenirken hata oluştu:\n{ex.Message}",
                "Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void BindGrid(List<MemberListResponse> members)
    {
        dgvMembers.AutoGenerateColumns = false;
        dgvMembers.DataSource = null;
        dgvMembers.DataSource = members;
    }

    private void UpdateSummary(int count)
    {
        lblSummary.Text = $"Toplam {count} üye listelendi.";
    }

    private void SetLoading(bool isLoading)
    {
        btnRefresh.Enabled = !isLoading;
        btnAdd.Enabled = !isLoading;
        btnEdit.Enabled = !isLoading;
        btnDelete.Enabled = !isLoading;
        txtSearch.Enabled = !isLoading;

        lblStatus.Text = isLoading ? "Üyeler yükleniyor..." : "Hazır";
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var searchText = txtSearch.Text.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            BindGrid(_allMembers);
            UpdateSummary(_allMembers.Count);
            return;
        }

        var filteredMembers = _allMembers
            .Where(x =>
                x.AdSoyad.ToLower().Contains(searchText) ||
                (x.OkulNo != null && x.OkulNo.ToLower().Contains(searchText)) ||
                (x.Telefon != null && x.Telefon.ToLower().Contains(searchText)) ||
                (x.Eposta != null && x.Eposta.ToLower().Contains(searchText)) ||
                (x.UyeTuruAdi != null && x.UyeTuruAdi.ToLower().Contains(searchText)) ||
                (x.SinifAdi != null && x.SinifAdi.ToLower().Contains(searchText)) ||
                (x.SubeAdi != null && x.SubeAdi.ToLower().Contains(searchText)) ||
                (x.BolumAdi != null && x.BolumAdi.ToLower().Contains(searchText)) ||
                (x.AlanAdi != null && x.AlanAdi.ToLower().Contains(searchText)) ||
                x.Durum.ToLower().Contains(searchText))
            .ToList();

        BindGrid(filteredMembers);
        lblSummary.Text = $"Arama sonucu {filteredMembers.Count} üye listelendi.";
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        await LoadMembersAsync();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            "Üye ekleme ekranı sonraki adımda eklenecek.",
            "NexKütüphane",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        var selectedMember = GetSelectedMember();

        if (selectedMember is null)
        {
            MessageBox.Show(
                "Lütfen düzenlemek için bir üye seçin.",
                "Uyarı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        MessageBox.Show(
            $"Seçilen üye: {selectedMember.AdSoyad}\nDüzenleme ekranı sonraki adımda eklenecek.",
            "NexKütüphane",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        var selectedMember = GetSelectedMember();

        if (selectedMember is null)
        {
            MessageBox.Show(
                "Lütfen silmek için bir üye seçin.",
                "Uyarı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        var confirm = MessageBox.Show(
            $"{selectedMember.AdSoyad} adlı üyeyi pasife almak istiyor musunuz?",
            "Silme Onayı",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
        {
            return;
        }

        var result = await _memberApiClient.DeleteAsync(selectedMember.Id);

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
            MessageBox.Show(
                result.Mesaj,
                "Silme Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        MessageBox.Show(
            result.Mesaj,
            "Başarılı",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        await LoadMembersAsync();
    }

    private MemberListResponse? GetSelectedMember()
    {
        if (dgvMembers.CurrentRow?.DataBoundItem is MemberListResponse selectedMember)
        {
            return selectedMember;
        }

        return null;
    }

    private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        var selectedMember = GetSelectedMember();

        if (selectedMember is null)
        {
            return;
        }

        MessageBox.Show(
            $"Üye Detayı\n\nAd Soyad: {selectedMember.AdSoyad}\nOkul No: {selectedMember.OkulNo}\nÜye Türü: {selectedMember.UyeTuruAdi}\nSınıf/Şube: {selectedMember.SinifAdi}/{selectedMember.SubeAdi}\nBölüm: {selectedMember.BolumAdi}\nAlan: {selectedMember.AlanAdi}\nDurum: {selectedMember.Durum}",
            "Üye Detayı",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}