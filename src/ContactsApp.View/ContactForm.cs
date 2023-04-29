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
    /// Содержит сообщения об ошибках для каждого из полей.
    /// </summary>
    private readonly Dictionary<string, string> _errors = new()
    {
        {nameof(Model.Contact.FullName), string.Empty },
        {nameof(Model.Contact.Email), string.Empty},
        {nameof(Model.Contact.PhoneNumber), string.Empty },
        {nameof(Model.Contact.DateOfBirth), string.Empty },
        {nameof(Model.Contact.VkId), string.Empty},
    };

    /// <summary>
    /// Текущий номер телефона.
    /// </summary>
    private string _currentPhoneNumber = string.Empty;

    /// <summary>
    /// Стандартный цвет полей для заполнения.
    /// </summary>
    private static readonly Color DefaultBackgroundColor = Color.White;

    /// <summary>
    /// Цвет ошибки полей для заполнения.
    /// </summary>
    private static readonly Color ErrorBackgroundColor = Color.LightPink;

    /// <summary>
    /// Добавляемый или редактируемый контакт.
    /// </summary>
    private Contact _contact = new();

    /// <summary>
    /// Возвращает и задаёт выбранный контакт.
    /// </summary>
    public Contact Contact
    {
        get => _contact;
        set
        {
            _contact = (Contact)value.Clone();
            
            FullNameTextBox.Text = _contact.FullName;
            EmailTextBox.Text = _contact.Email;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
            VkIdTextBox.Text = _contact.VkId;
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
    /// Присваивает введённое значение в поле FullName. 
    /// </summary>
    private void FullNameTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.FullName = FullNameTextBox.Text;

            _errors[nameof(Contact.FullName)] = string.Empty;
            FullNameTextBox.BackColor = DefaultBackgroundColor;
        }
        catch (ArgumentException ex)
        {
            _errors[nameof(Contact.FullName)] = ex.Message;

            FullNameTextBox.BackColor = ErrorBackgroundColor;
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

            _errors[nameof(Contact.Email)] = string.Empty;
            EmailTextBox.BackColor = DefaultBackgroundColor;
        }
        catch (ArgumentException ex)
        {
            _errors[nameof(Contact.Email)] = ex.Message;

            EmailTextBox.BackColor = ErrorBackgroundColor;
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

            _errors[nameof(Contact.PhoneNumber)] = string.Empty;
            PhoneNumberTextBox.BackColor = DefaultBackgroundColor;
        }
        catch (ArgumentException ex)
        {
            _errors[nameof(Contact.PhoneNumber)] = ex.Message;

            PhoneNumberTextBox.BackColor = ErrorBackgroundColor;
        }
    }

    /// <summary>
    /// Изменяет телефонный код страны при выборе из CountrySelectorComboBox.
    /// </summary>
    private void CountrySelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PhoneNumberTextBox.Text = CountrySelectorComboBox.SelectedItem + " (";
    }

    /// <summary>
    /// Присваивает введённое значение в поле DateOfBirth. 
    /// </summary>
    private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;

            _errors[nameof(Contact.DateOfBirth)] = string.Empty;
        }
        catch (ArgumentException ex)
        {
            _errors[nameof(Contact.DateOfBirth)] = ex.Message;
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

            _errors[nameof(Contact.VkId)] = string.Empty;
            VkIdTextBox.BackColor = DefaultBackgroundColor;
        }
        catch (ArgumentException ex)
        {
            _errors[nameof(Contact.VkId)] = ex.Message;

            VkIdTextBox.BackColor = ErrorBackgroundColor;
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

        foreach (var error in _errors)
        {
            errorMessage += AddToErrorMessage(error.Value);
        }

        if (errorMessage != string.Empty)
        {
            MessageBox.Show(errorMessage);
            return false;
        }

        return true;
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
        if (!string.IsNullOrEmpty(errorMessage))
        {
            return "• " + errorMessage + "\n";
        }

        return string.Empty;
    }

    /// <summary>
    /// Проверяет номер телефона на изменение кода страны.
    /// Если пользователь пытается его изменить, то изменения не применяются.
    /// </summary>
    private void CheckOnPhoneCodeEdit()
    {
        var item = CountrySelectorComboBox.SelectedItem;

        var correctPhoneCode = item + " (";
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
        //Запрещает нажатие любых клавиш, кроме цифр, клавиш управления и ')', '-', ' '
        if (!char.IsControl(e.KeyChar) &&
            !char.IsDigit(e.KeyChar) &&
            e.KeyChar != ')' &&
            e.KeyChar != '-' &&
            e.KeyChar != ' ')
            return true;

        //Запрещает ввод второй ')' в PhoneNumberTextBox
        if (e.KeyChar == ')' &&
            PhoneNumberTextBox.Text.IndexOf(')') > -1)
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
            AboutForm form = new();
            form.ShowDialog();
        }
    }

    /// <summary>
    /// Закрывает окно с сохранением изменений.
    /// </summary>
    private void OkButton_Click(object sender, EventArgs e)
    {
        if (CheckFormOnErrors())
        {
            DialogResult = DialogResult.OK;
            Close();
        }
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