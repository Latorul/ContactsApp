namespace ContactsApp.View;

/// <summary>
/// Главное окно приложения.
/// </summary>
public partial class MainForm : Form
{
    /// <summary>
    /// Максимальная длина строки с перечислением людей, у которых сегодня день рождения. 
    /// </summary>
    private const int MaxBirthdayContactsMessageLength = 50;

    /// <summary>
    /// Хранит список всех контактов. 
    /// </summary>
    private readonly Project _project;

    /// <summary>
    /// Отображаемый список контактов.
    /// </summary>
    private List<Contact> _currentContacts;


    /// <summary>
    /// Конструктор класса <see cref="MainForm"/>.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();

        _project = ProjectManager.LoadProject();

#if DEBUG
        ContactFactory.DateTime = new RealDateTime();
        ContactFactory.Random = new Randomizer();
        if (_project.Contacts.Count == 0)
            ContactFactory.GenerateContacts(_project);
#endif
        _currentContacts = _project.Contacts;
    }

    /// <summary>
    /// Обновляет информацию при открытии программы.
    /// </summary>
    private void MainForm_Shown(object sender, EventArgs e)
    {
        UpdateListBox();
        ClearSelectedContact();
        UpdateBirthdayContactNotify();
    }

    /// <summary>
    /// При закрытии окна спрашивает подтверждение закрытия программы.
    /// </summary>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        ProjectManager.SaveProject(_project);

        if (MessageBox.Show("Do you really want to exit?", "Close?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }

    /// <summary>
    /// Добавляет новый контакт с введёнными пользователем данными.
    /// </summary>
    private void AddContact()
    {
        var form = new ContactForm
        {
            Contact = new Contact("", "", "+93 (000) 000 00", DateTime.Today, "")
        };

        if (form.ShowDialog() == DialogResult.OK)
        {
            Contact updatedContact = form.Contact;
            _project.Contacts.Add(updatedContact);
        }
    }

    /// <summary>
    /// Изменяет данные выбранного контакта на введённые пользователем.
    /// </summary>
    /// <param name="index">Индекс выбранного контакта в ContactsListBox.</param>
    private void EditContact(int index)
    {
        Contact selectedContact = _currentContacts[index];
        var form = new ContactForm
        {
            Contact = selectedContact
        };

        if (form.ShowDialog() == DialogResult.OK)
        {
            Contact updatedContact = form.Contact;

            _project.Contacts.Remove(selectedContact);
            _project.Contacts.Add(updatedContact);
        }
    }

    /// <summary>
    /// Удаляет выбранный контакт.
    /// </summary>
    /// <param name="index">Индекс выбранного контакта в списке ContactsListBox.</param>
    private void RemoveContact(int index)
    {
        if (MessageBox.Show(
                $"Do you really want to remove {_currentContacts[index].FullName}?",
                "Remove contact?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            return;
        }

        _project.Contacts.Remove(_currentContacts[index]);
        _currentContacts.RemoveAt(index);
        ClearSelectedContact();
    }

    /// <summary>
    /// Обновляет список контактов в ContactsListBox.
    /// </summary>
    private void UpdateListBox()
    {
        ContactsListBox.Items.Clear();

        _currentContacts =
            _project.SortByFullName(
                _project.SearchBySubstring(_project.Contacts, SearchTextBox.Text));
        foreach (Contact contact in _currentContacts)
        {
            ContactsListBox.Items.Add(contact.FullName);
        }
    }

    /// <summary>
    /// Очищает информацию о выбранном контакте в правой панели.
    /// </summary>
    private void ClearSelectedContact()
    {
        FullNameTextBox.Text = string.Empty;
        EmailTextBox.Text = string.Empty;
        PhoneNumberTextBox.Text = string.Empty;
        DateOfBirthTextBox.Text = string.Empty;
        VkIdTextBox.Text = string.Empty;
    }

    /// <summary>
    /// Обновляет информацию о выбранном контакте в правой панели.
    /// </summary>
    /// <param name="index">Индекс выбранного контакта в списке ContactsListBox.</param>
    private void UpdateSelectedContact(int index)
    {
        var contact = _currentContacts[index];

        FullNameTextBox.Text = contact.FullName;
        EmailTextBox.Text = contact.Email;
        PhoneNumberTextBox.Text = contact.PhoneNumber;
        DateOfBirthTextBox.Text = contact.DateOfBirth.ToLongDateString();
        VkIdTextBox.Text = contact.VkId;
    }

    /// <summary>
    /// Обрабатывает изменение выбора контакта в списке ContactsListBox.
    /// </summary>
    private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ContactsListBox.SelectedIndex == -1)
            ClearSelectedContact();
        else
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
    }

    /// <summary>
    /// Задаёт подстроку для фильтрации контактов.
    /// </summary>
    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        UpdateListBox();
    }

    /// <summary>
    /// Обновляет информацию в оповещении о днях рождениях.
    /// </summary>
    private void UpdateBirthdayContactNotify()
    {
        List<Contact> birthdayContact =
            _project.SortByFullName(
                _project.SearchBirthDayContacts(_project.Contacts, DateTime.Today));

        if (birthdayContact.Count == 0)
        {
            NotifyPanel.Visible = false;
            return;
        }

        BirthdayContactsLabel.Text = CreateBirthdayNotifyMessage(birthdayContact);
    }

    /// <summary>
    /// Заполняет строку с напоминанием о днях рождениях контактов.
    /// </summary>
    /// <param name="birthdayContacts">Список контактов, у которых сегодня день рождения.</param>
    /// <returns>Строка со списком контактов, у которых сегодня день рождения.</returns>
    private string CreateBirthdayNotifyMessage(List<Contact> birthdayContacts)
    {
        string message = string.Empty;
        int i;
        for (i = 0; i < birthdayContacts.Count; i++)
        {
            if (message.Length >= MaxBirthdayContactsMessageLength)
            {
                break;
            }

            message += birthdayContacts[i].FullName + ", ";
        }

        message = message.Remove(message.Length - 2);
        if (i < birthdayContacts.Count)
            message += " и др.";

        return message;
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки добавления контакта. 
    /// </summary>
    private void AddContactButton_Click(object sender, EventArgs e)
    {
        AddContact();
        UpdateListBox();
        ProjectManager.SaveProject(_project);
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки редактирования контакта. 
    /// </summary>
    private void EditContactButton_Click(object sender, EventArgs e)
    {
        if (ContactsListBox.SelectedIndex == -1)
            return;

        EditContact(ContactsListBox.SelectedIndex);
        UpdateListBox();
        ProjectManager.SaveProject(_project);
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки удаления контакта. 
    /// </summary>
    private void RemoveContactButton_Click(object sender, EventArgs e)
    {
        if (ContactsListBox.SelectedIndex == -1)
            return;

        RemoveContact(ContactsListBox.SelectedIndex);
        UpdateListBox();
        ProjectManager.SaveProject(_project);
    }

    /// <summary>
    /// Закрывает панель с оповещением о контактах, у которых сегодня день рождения. 
    /// </summary>
    private void CloseNotifyPictureBox_Click(object sender, EventArgs e)
    {
        NotifyPanel.Visible = false;
    }

    /// <summary>
    /// Открывает окно About при нажатии клавиши F1.
    /// </summary>
    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }

    /// <summary>
    /// Запрещает редактирования текста в поле FullNameTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void FullNameTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// Запрещает редактирования текста в поле EmailTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void EmailTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// Запрещает редактирования текста в поле PhoneNumberTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void PhoneNumberTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// Запрещает редактирования текста в поле DateOfBirthTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void DateOfBirthTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// Запрещает редактирования текста в поле VkIdTextBox.
    /// Исключения: сочетание клавиш Ctrl + C и Ctrl + A.  
    /// </summary>
    private void VkIdTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    /// <summary>
    /// При наведении курсора перекрашивает кнопку добавления контакта в синий цвет.
    /// </summary>
    private void AddContactButton_MouseEnter(object sender, EventArgs e)
    {
        AddContactButton.Image = Properties.Resources.add_contact_32x32;
        AddContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    /// <summary>
    /// При наведении курсора перекрашивает кнопку редактирования контакта в синий цвет.
    /// </summary>
    private void EditContactButton_MouseEnter(object sender, EventArgs e)
    {
        EditContactButton.Image = Properties.Resources.edit_contact_32x32;
        EditContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    /// <summary>
    /// При наведении курсора перекрашивает кнопку удаления контакта в красный цвет.
    /// </summary>
    private void RemoveContactButton_MouseEnter(object sender, EventArgs e)
    {
        RemoveContactButton.Image = Properties.Resources.remove_contact_32x32;
        RemoveContactButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
    }

    /// <summary>
    /// При выведении курсора перекрашивает кнопку добавления контакта в белый цвет.
    /// </summary>
    private void AddContactButton_MouseLeave(object sender, EventArgs e)
    {
        AddContactButton.Image = Properties.Resources.add_contact_32x32_grey;
        AddContactButton.BackColor = Color.White;
    }

    /// <summary>
    /// При выведении курсора перекрашивает кнопку редактирования контакта в белый цвет.
    /// </summary>
    private void EditContactButton_MouseLeave(object sender, EventArgs e)
    {
        EditContactButton.Image = Properties.Resources.edit_contact_32x32_grey;
        EditContactButton.BackColor = Color.White;
    }

    /// <summary>
    /// При выведении курсора перекрашивает кнопку удаления контакта в белый цвет.
    /// </summary>
    private void RemoveContactButton_MouseLeave(object sender, EventArgs e)
    {
        RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_grey;
        RemoveContactButton.BackColor = Color.White;
    }
}