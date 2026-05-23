using NexKutuphane.Contracts.Books;
using NexKutuphane.Desktop.Services;

namespace NexKutuphane.Desktop.Forms.Books;

public partial class FrmBooks : Form
{
    private readonly BookApiClient _bookApiClient;
    private List<BookListResponse> _allBooks = new();

    public FrmBooks()
    {
        InitializeComponent();

        _bookApiClient = new BookApiClient();
    }

    private async void FrmBooks_Load(object sender, EventArgs e)
    {
        await LoadBooksAsync();
    }

    private async Task LoadBooksAsync()
    {
        try
        {
            SetLoading(true);

            var result = await _bookApiClient.GetAllAsync();

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

            _allBooks = result.Veri ?? new List<BookListResponse>();

            BindGrid(_allBooks);
            UpdateSummary();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Kitap listesi yüklenirken hata oluştu:\n{ex.Message}",
                "Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void BindGrid(List<BookListResponse> books)
    {
        dgvBooks.AutoGenerateColumns = false;
        dgvBooks.DataSource = null;
        dgvBooks.DataSource = books;
    }

    private void UpdateSummary()
    {
        lblSummary.Text = $"Toplam {_allBooks.Count} kitap listelendi.";
    }

    private void SetLoading(bool isLoading)
    {
        btnRefresh.Enabled = !isLoading;
        btnAdd.Enabled = !isLoading;
        btnEdit.Enabled = !isLoading;
        btnDelete.Enabled = !isLoading;
        txtSearch.Enabled = !isLoading;

        lblStatus.Text = isLoading ? "Kitaplar yükleniyor..." : "Hazır";
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var searchText = txtSearch.Text.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            BindGrid(_allBooks);
            return;
        }

        var filteredBooks = _allBooks
            .Where(x =>
                x.KitapAdi.ToLower().Contains(searchText) ||
                (x.Yazarlar != null && x.Yazarlar.ToLower().Contains(searchText)) ||
                (x.Barkod != null && x.Barkod.ToLower().Contains(searchText)) ||
                (x.DemirbasNo != null && x.DemirbasNo.ToLower().Contains(searchText)) ||
                (x.ISBN != null && x.ISBN.ToLower().Contains(searchText)) ||
                (x.KategoriAdi != null && x.KategoriAdi.ToLower().Contains(searchText)) ||
                (x.YayineviAdi != null && x.YayineviAdi.ToLower().Contains(searchText)))
            .ToList();

        BindGrid(filteredBooks);
        lblSummary.Text = $"Arama sonucu {filteredBooks.Count} kitap listelendi.";
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        await LoadBooksAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        using var form = new FrmBookAddEdit();

        var result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            await LoadBooksAsync();
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        var selectedBook = GetSelectedBook();

        if (selectedBook is null)
        {
            MessageBox.Show(
                "Lütfen düzenlemek için bir kitap seçin.",
                "Uyarı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        using var form = new FrmBookAddEdit(selectedBook.Id);

        var result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            await LoadBooksAsync();
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        var selectedBook = GetSelectedBook();

        if (selectedBook is null)
        {
            MessageBox.Show(
                "Lütfen silmek için bir kitap seçin.",
                "Uyarı",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        var confirm = MessageBox.Show(
            $"{selectedBook.KitapAdi} adlı kitabı pasife almak istiyor musunuz?",
            "Silme Onayı",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
        {
            return;
        }

        var result = await _bookApiClient.DeleteAsync(selectedBook.Id);

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

        await LoadBooksAsync();
    }

    private BookListResponse? GetSelectedBook()
    {
        if (dgvBooks.CurrentRow?.DataBoundItem is BookListResponse selectedBook)
        {
            return selectedBook;
        }

        return null;
    }

    private async void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        var selectedBook = GetSelectedBook();

        if (selectedBook is null)
        {
            return;
        }

        using var form = new FrmBookAddEdit(selectedBook.Id);

        var result = form.ShowDialog();

        if (result == DialogResult.OK)
        {
            await LoadBooksAsync();
        }
    }
}