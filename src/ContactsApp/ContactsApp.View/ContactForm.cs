namespace ContactsApp.View;

public partial class ContactForm : Form
{
    public ContactForm()
    {
        InitializeComponent();
    }

    #region ContactButtons_Click

    private void AddPhotoButton_Click(object sender, EventArgs e)
    {
        //todo
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    #endregion

    #region AddPhotoButton_MouseEvents

    private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_contact_32x32;
        AddPhotoButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
    }

    private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_contact_32x32_grey;
        AddPhotoButton.BackColor = Color.White;
    }

    #endregion

    private void ContactForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }
}
