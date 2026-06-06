using NexKutuphane.Desktop.Forms.Books;
using NexKutuphane.Desktop.Forms.Dashboard;
using NexKutuphane.Desktop.Forms.Members;

namespace NexKutuphane.Desktop.Forms;

public partial class FrmMain : Form
{
    private Form? _activeForm;

    public FrmMain()
    {
        InitializeComponent();

        OpenChildForm(new FrmDashboard());
    }

    private void OpenChildForm(Form childForm)
    {
        _activeForm?.Close();

        _activeForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;

        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(childForm);

        childForm.Show();
    }

    private void SetActiveButton(Button activeButton)
    {
        foreach (Control control in pnlMenu.Controls)
        {
            if (control is Button button)
            {
                button.BackColor = Color.FromArgb(31, 41, 55);
                button.ForeColor = Color.White;
            }
        }

        activeButton.BackColor = Color.FromArgb(37, 99, 235);
        activeButton.ForeColor = Color.White;
    }

    private void ShowComingSoon(string moduleName)
    {
        MessageBox.Show(
            $"{moduleName} ekranı sonraki adımlarda eklenecek.",
            "NexKütüphane",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnDashboard_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnDashboard);
        lblPageTitle.Text = "Dashboard";
        OpenChildForm(new FrmDashboard());
    }

    private void btnBooks_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnBooks);
        lblPageTitle.Text = "Kitap İşlemleri";
        OpenChildForm(new FrmBooks());
    }

    private void btnMembers_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnMembers);
        lblPageTitle.Text = "Üye İşlemleri";
        OpenChildForm(new FrmMembers());
    }

    private void btnLoans_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnLoans);
        lblPageTitle.Text = "Ödünç / İade İşlemleri";
        ShowComingSoon("Ödünç / İade İşlemleri");
    }

    private void btnReports_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnReports);
        lblPageTitle.Text = "Raporlar";
        ShowComingSoon("Raporlar");
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnSettings);
        lblPageTitle.Text = "Ayarlar";
        ShowComingSoon("Ayarlar");
    }

    private void btnAdmin_Click(object sender, EventArgs e)
    {
        SetActiveButton(btnAdmin);
        lblPageTitle.Text = "Yönetim";
        ShowComingSoon("Yönetim");
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "Uygulamadan çıkmak istiyor musunuz?",
            "Çıkış",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            Application.Exit();
        }
    }
}