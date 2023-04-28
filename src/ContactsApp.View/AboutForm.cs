namespace ContactsApp.View;

/// <summary>
/// Информационная форма.
/// </summary>
public partial class AboutForm : Form
{
    /// <summary>
    /// Конструктор класса <see cref="AboutForm"/>.
    /// </summary>
    public AboutForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// При нажатии на надпись открывает ссылку на GitHub автора.
    /// </summary>
    private void GithubLlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        GithubLlinkLabel.LinkVisited = true;

        Process.Start(
            new ProcessStartInfo
            {
                FileName = "https://github.com/Latorul",
                UseShellExecute = true
            });
    }

    /// <summary>
    /// При нажатии на надпись открывает ссылку на источник иконок.
    /// </summary>
    private void IconsReferenceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        IconsReferenceLinkLabel.LinkVisited = true;

        Process.Start(
            new ProcessStartInfo
            {
                FileName = "https://icons8.ru/",
                UseShellExecute = true
            });
    }

    /// <summary>
    /// При нажатии на надпись открывает ссылку на источник информации о странах и флагах.
    /// </summary>
    private void CountriesReferenceLinkLabel_LinkClicked(
        object sender, LinkLabelLinkClickedEventArgs e)
    {
        CountriesReferenceLinkLabel.LinkVisited = true;

        Process.Start(
            new ProcessStartInfo
            {
                FileName = "https://openai.com/",
                UseShellExecute = true
            });
    }

    /// <summary>
    /// Закрывает окно.
    /// </summary>
    private void OkButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Запрещает редактирования текста в поле LicenseTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void LicenseTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }
}