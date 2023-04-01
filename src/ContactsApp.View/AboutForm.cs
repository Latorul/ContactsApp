using System.Diagnostics;

namespace ContactsApp.View;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    #region LinkLabel_Click

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

    #endregion
}
