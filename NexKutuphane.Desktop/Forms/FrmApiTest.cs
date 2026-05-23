using NexKutuphane.Desktop.Services;

namespace NexKutuphane.Desktop.Forms;

public partial class FrmApiTest : Form
{
    private readonly BookApiClient _bookApiClient;

    public FrmApiTest()
    {
        InitializeComponent();

        _bookApiClient = new BookApiClient();
    }

    private async void btnTestBooks_Click(object sender, EventArgs e)
    {
        btnTestBooks.Enabled = false;
        lstBooks.Items.Clear();

        var result = await _bookApiClient.GetAllAsync();

        if (result is null)
        {
            MessageBox.Show(
                "API cevabı alınamadı.",
                "Bağlantı Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            btnTestBooks.Enabled = true;
            return;
        }

        if (!result.BasariliMi)
        {
            MessageBox.Show(
                result.Mesaj,
                "API Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            btnTestBooks.Enabled = true;
            return;
        }

        if (result.Veri is null || result.Veri.Count == 0)
        {
            lstBooks.Items.Add("Kitap bulunamadı.");
            btnTestBooks.Enabled = true;
            return;
        }

        foreach (var book in result.Veri)
        {
            lstBooks.Items.Add($"{book.Id} - {book.KitapAdi} - {book.Yazarlar}");
        }

        btnTestBooks.Enabled = true;
    }
}