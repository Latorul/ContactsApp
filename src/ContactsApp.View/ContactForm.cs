namespace ContactsApp.View;

/// <summary>
/// Форма добавления и редактирования контакта <see cref="Contact"/>.
/// </summary>
public partial class ContactForm : Form
{
    /// <summary>
    /// Список с информацией о всех странах.
    /// </summary>
    private readonly List<CountryInfo> _countriesInfo;

    /// <summary>
    /// Текущий номер телефона.
    /// </summary>
    private string _currentPhoneNumber = string.Empty;

    /// <summary>
    /// Сообщение об ошибке в ФИО.
    /// </summary>
    private string _fullnameError = string.Empty;

    /// <summary>
    /// Сообщение об ошибке в электронной почте.
    /// </summary>
    private string _emailError = string.Empty;

    /// <summary>
    /// Сообщение об ошибке в номере телефона.
    /// </summary>
    private string _phoneNumberError = string.Empty;

    /// <summary>
    /// Сообщение об ошибке в дате рождения.
    /// </summary>
    private string _dateOfBirthError = string.Empty;

    /// <summary>
    /// Сообщение об ошибке в ссылке на ВКонтакте.
    /// </summary>
    private string _vkIdError = string.Empty;

    /// <summary>
    /// Добавляемый или редактируемый контакт.
    /// </summary>
    private Contact _contact = new Contact();

    /// <summary>
    /// Возвращает и задаёт выбранный контакт.
    /// </summary>
    public Contact Contact
    {
        get => _contact;
        set
        {
            _contact = (Contact)value.Clone();
            if (_contact != null)
            {
                FullNameTextBox.Text = _contact.FullName;
                EmailTextBox.Text = _contact.Email;
                PhoneNumberTextBox.Text = _contact.PhoneNumber;
                DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
                VkIdTextBox.Text = _contact.VkId;
            }
        }
    }


    /// <summary>
    /// Конструктор класса <see cref="ContactForm"/>.
    /// </summary>
    public ContactForm()
    {
        InitializeComponent();

        _countriesInfo = CountryInfo.LoadInfo();
        foreach (var item in _countriesInfo)
        {
            CountrySelectorComboBox.Items.Add(new CountryDropDownItem(item));
        }
        CountrySelectorComboBox.SelectedIndex = 0;

        UpdateForm();
    }

    /// <summary>
    /// Обновляет страну текущего контакта.
    /// </summary>
    private void ContactForm_Load(object sender, EventArgs e)
    {
        var code = Contact.PhoneNumber.Substring(0, Contact.PhoneNumber.IndexOf(' '));
        var currentCountry = _countriesInfo.Where(с => с.PhoneCode == code).First();
        var index = _countriesInfo.IndexOf(currentCountry);
        CountrySelectorComboBox.SelectedItem = CountrySelectorComboBox.Items[index];

        PhoneNumberTextBox.Text = Contact.PhoneNumber;
    }

    /// <summary>
    /// Обновляет поля для заполнения контакта.
    /// </summary>
    private void UpdateForm()
    {
        _currentPhoneNumber = _contact.PhoneNumber;
        
        FullNameTextBox.Text = _contact.FullName;
        EmailTextBox.Text = _contact.Email;
        PhoneNumberTextBox.Text = _contact.PhoneNumber;
        DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
        VkIdTextBox.Text = _contact.VkId;
    }

    /// <summary>
    /// Добавляет строку для отображения её в сообщении об ошибке.
    /// </summary>
    /// <param name="errorMessage">Строка с сообщением об ошибке.</param>
    /// <returns>
    ///     Пустую строку, если сообщения об ошибке нет. <br/>
    ///     Строку с сообщением и переходом на новую строку.
    /// </returns>
    private string AddToErrorMessage(string errorMessage)
    {
        if (errorMessage != string.Empty)
        {
            return errorMessage + "\n";
        }

        return string.Empty;
    }

    /// <summary>
    /// Присваивает введённое значение в поле FullName. 
    /// </summary>
    private void FullNameTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.FullName = FullNameTextBox.Text;

            _fullnameError = string.Empty;
            FullNameTextBox.BackColor = Color.White;
        }
        catch (ArgumentException ex)
        {
            _fullnameError = ex.Message;

            FullNameTextBox.BackColor = Color.LightPink;
        }
    }

    /// <summary>
    /// Присваивает введённое значение в поле Email. 
    /// </summary>
    private void EmailTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.Email = EmailTextBox.Text;

            _emailError = string.Empty;
            EmailTextBox.BackColor = Color.White;
        }
        catch (ArgumentException ex)
        {
            _emailError = ex.Message;

            EmailTextBox.BackColor = Color.LightPink;
        }
    }

    /// <summary>
    /// Присваивает введённое значение в поле PhoneNumber. 
    /// </summary>
    private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CheckOnPhoneCodeEdit();
            _contact.PhoneNumber = PhoneNumberTextBox.Text;

            _phoneNumberError = string.Empty;
            PhoneNumberTextBox.BackColor = Color.White;
        }
        catch (ArgumentException ex)
        {
            _phoneNumberError = ex.Message;

            PhoneNumberTextBox.BackColor = Color.LightPink;
        }
    }

    /// <summary>
    /// Изменяет телефонный код страны при выборе из CountrySelectorComboBox.
    /// </summary>
    private void CountrySelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PhoneNumberTextBox.Text = CountrySelectorComboBox.SelectedItem.ToString() + " (";
    }

    /// <summary>
    /// Присваивает введённое значение в поле DateOfBirth. 
    /// </summary>
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

    /// <summary>
    /// Присваивает введённое значение в поле VkId. 
    /// </summary>
    private void VkIdTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.VkId = VkIdTextBox.Text;

            _vkIdError = string.Empty;
            VkIdTextBox.BackColor = Color.White;
        }
        catch (ArgumentException ex)
        {
            _vkIdError = ex.Message;

            VkIdTextBox.BackColor = Color.LightPink;
        }
    }

    /// <summary>
    /// Проверяет присутствуют ли ошибки в заполнении полей контакта.
    /// </summary>
    /// <returns>
    ///     <b>true</b>: если нет ошибок при вводе данных. <br/>
    ///     <b>false</b>: если есть ошибки при вводе данных.
    /// </returns>
    private bool CheckFormOnErrors()
    {
        string errorMessage = string.Empty;

        errorMessage += AddToErrorMessage(_fullnameError);
        errorMessage += AddToErrorMessage(_emailError);
        errorMessage += AddToErrorMessage(_phoneNumberError);
        errorMessage += AddToErrorMessage(_dateOfBirthError);
        errorMessage += AddToErrorMessage(_vkIdError);

        if (errorMessage != string.Empty)
        {
            MessageBox.Show(errorMessage);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Проверяет номер телефона на изменение кода страны.
    /// Если пользователь пытается его изменить, то изменения не применяются.
    /// </summary>
    private void CheckOnPhoneCodeEdit()
    {
        var item = CountrySelectorComboBox.SelectedItem;

        var correctPhoneCode = item.ToString() + " (";
        var currentPhoneCode = new string(
            PhoneNumberTextBox.Text
                .Take(item.ToString()!.Length + 2)
                .ToArray());

        if (correctPhoneCode != currentPhoneCode)
        {
            PhoneNumberTextBox.Text = _currentPhoneNumber;
            PhoneNumberTextBox.SelectionStart = PhoneNumberTextBox.Text.Length;
        }
    }

    /// <summary>
    /// Позволяет ввести в поле для номера телефона только цифры
    /// и разделительные символы ')' '-' ' '.
    /// </summary>
    private bool IsAllowedChar(KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) &&
            !char.IsDigit(e.KeyChar) &&
            e.KeyChar != ')' &&
            e.KeyChar != '-' &&
            e.KeyChar != ' ')
            return true;

        if (e.KeyChar == ')'
            && PhoneNumberTextBox.Text.IndexOf(')') > -1)
            return true;

        return false;
    }

    /// <summary>
    /// Сохраняет номер телефона до изменения.
    /// </summary>
    private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = IsAllowedChar(e);

        _currentPhoneNumber = PhoneNumberTextBox.Text;
    }

    /// <summary>
    /// Открывает окно About при нажатии клавиши F1.
    /// </summary>
    private void ContactForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }
    }

    /// <summary>
    /// Закрывает окно с сохранением изменений.
    /// </summary>
    private void OkButton_Click(object sender, EventArgs e)
    {
        if (CheckFormOnErrors())
            Close();
    }

    /// <summary>
    /// Закрывает окно без сохранения изменений.
    /// </summary>
    private void CancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// При наведении курсора перекрашивает кнопку добавления фотографии в синий цвет.
    /// </summary>
    private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
        AddPhotoButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    /// <summary>
    /// При выведении курсора перекрашивает кнопку добавления фотографии в белый цвет.
    /// </summary>
    private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
    {
        AddPhotoButton.Image = Properties.Resources.add_photo_32x32_grey;
        AddPhotoButton.BackColor = Color.White;
    }
}