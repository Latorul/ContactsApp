namespace ContactsApp.View;

public partial class ContactForm : Form
{
    private string _fullnameError = string.Empty;
    private string _emailError = string.Empty;
    private string _phoneNumberError = string.Empty;
    private string _dateOfBirthError = string.Empty;
    private string _vkIdError = string.Empty;


    private Contact _contact = new Contact();

    public ContactForm()
    {
        InitializeComponent();

        _contact.FullName = "FullName";
        _contact.Email = "Email";
        _contact.PhoneNumber = "12345678";
        _contact.DateOfBirth = new DateTime(2002, 10, 16);
        _contact.VkId = "VkId";

        UpdateForm();
    }

    private void UpdateForm()
    {
        FullNameTextBox.Text = _contact.FullName;
        EmailTextBox.Text = _contact.Email;
        PhoneNumberTextBox.Text = _contact.PhoneNumber;
        DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
        VkIdTextBox.Text = _contact.VkId;
    }


    private bool CheckFormOnErrors()
    {
        string erroeMessage = string.Empty;

        erroeMessage += AddToErrorMessage(_fullnameError);
        erroeMessage += AddToErrorMessage(_emailError);
        erroeMessage += AddToErrorMessage(_phoneNumberError);
        erroeMessage += AddToErrorMessage(_dateOfBirthError);
        erroeMessage += AddToErrorMessage(_vkIdError);

        if (erroeMessage != string.Empty)
        {
            MessageBox.Show(erroeMessage);
            return false;
        }

        return true;
    }

    private string AddToErrorMessage(string errorMessage)
    {
        if (errorMessage != string.Empty)
        {
            return errorMessage + "\n";
        }

        return string.Empty;
    }

    private void FullNameTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FullNameTextBox.BackColor = Color.White;
            _contact.FullName = FullNameTextBox.Text;

            _fullnameError = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _fullnameError = ex.Message;

            FullNameTextBox.BackColor = Color.LightPink;
        }
    }

    private void EmailTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            EmailTextBox.BackColor = Color.White;
            _contact.Email = EmailTextBox.Text;

            _emailError = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _emailError = ex.Message;

            EmailTextBox.BackColor = Color.LightPink;
        }
    }

    private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            PhoneNumberTextBox.BackColor = Color.White;
            _contact.PhoneNumber = PhoneNumberTextBox.Text;

            _phoneNumberError = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _phoneNumberError = ex.Message;

            PhoneNumberTextBox.BackColor = Color.LightPink;
        }
    }

    private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;

            _dateOfBirthError = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _dateOfBirthError = ex.Message;
        }
    }

    private void VkIdTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            VkIdTextBox.BackColor = Color.White;
            _contact.VkId = VkIdTextBox.Text;

            _vkIdError = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _vkIdError = ex.Message;

            VkIdTextBox.BackColor = Color.LightPink;
        }
    }







    private void ContactForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        if (CheckFormOnErrors())
            Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
        AddPhotoButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_photo_32x32_grey;
        AddPhotoButton.BackColor = Color.White;
    }
}
