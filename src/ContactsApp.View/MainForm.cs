namespace ContactsApp.View;

/// <summary>
/// Главное окно приложения.
/// </summary>
public partial class MainForm : Form
{
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
        //GenerateContacts();
        _currentContacts = _project.Contacts;
    }

    /// <summary>
    /// Обновляет информацию при открытии программы.
    /// </summary>
    private void MainForm_Shown(object sender, EventArgs e)
    {
        UpdateListBox();
        ClearSelectedContact();
        UpdateBirthdayPeopleNotify();
    }

    /// <summary>
    /// При закрытии окна спрашивает подтверждение закрытия программы.
    /// </summary>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        ProjectManager.SaveProject(_project);

        if (MessageBox.Show("Do you really want to exit?",
                "Close?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }

    /// <summary>
    /// Добавляет контакты для проверки работоспособности программы.
    /// </summary>
    private void GenerateContacts()
    {
        _project.Contacts.Add(
            new Contact()
            {
                FullName = "Филатов Мирон",
                Email = "1",
                PhoneNumber = "1",
                DateOfBirth = DateTime.Today,
                VkId = "1"
            });
        _project.Contacts.Add(
            new Contact()
            {
                FullName = "Ткачев Артём",
                Email = "2",
                PhoneNumber = "2",
                DateOfBirth = DateTime.Today,
                VkId = "2"
            });
        _project.Contacts.Add(
            new Contact()
            {
                FullName = "Козин Марк",
                Email = "3",
                PhoneNumber = "3",
                DateOfBirth = DateTime.Today,
                VkId = "3"
            });
        _project.Contacts.Add(
            new Contact()
            {
                FullName = "Журавлев Владимир",
                Email = "4",
                PhoneNumber = "4",
                DateOfBirth = DateTime.Today,
                VkId = "4"
            });
        _project.Contacts.Add(
            new Contact()
            {
                FullName = "Белоусов Андрей",
                Email = "5",
                PhoneNumber = "5",
                DateOfBirth = DateTime.Today,
                VkId = "5"
            });
    }

    /// <summary>
    /// Добавляет новый контакт с введёнными пользователем данными.
    /// </summary>
    private void AddContact()
    {
        ContactForm form = new ContactForm();
        form.Contact = new Contact();
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
        Contact selectedContact = _project.Contacts[index];

        ContactForm form = new ContactForm();
        form.Contact = selectedContact;
        if (form.ShowDialog() == DialogResult.OK)
        {
            Contact updatedContact = form.Contact;
            _project.Contacts.Remove(_currentContacts[index]);
            _project.Contacts.Add(updatedContact);
        }
        else
        {
            form.Contact = selectedContact;
        }
    }

    /// <summary>
    /// Удаляет выбранный контакт.
    /// </summary>
    /// <param name="index">Индекс выбранного контакта в списке ContactsListBox.</param>
    private void RemoveContact(int index)
    {
        if (index == -1)
            return;

        if (MessageBox.Show($"Do you really want to remove {_currentContacts[index].FullName}?",
                "Remove contact?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            return;

        ClearSelectedContact();
        _project.Contacts.Remove(_currentContacts[index]);
        _currentContacts.RemoveAt(index);
    }

    //Обновляет отображаемую информацию

    /// <summary>
    /// Обновляет список контактов в ContactsListBox.
    /// </summary>
    private void UpdateListBox()
    {
        ContactsListBox.Items.Clear();
        _currentContacts = _project.SortByFullName(_currentContacts);

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
        FullNameTextBox.Text = _currentContacts[index].FullName;
        EmailTextBox.Text = _currentContacts[index].Email;
        PhoneNumberTextBox.Text = _currentContacts[index].PhoneNumber;
        DateOfBirthTextBox.Text = _currentContacts[index].DateOfBirth.ToString();
        VkIdTextBox.Text = _currentContacts[index].VkId;
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
        _currentContacts = _project.FindBySubstring(_project.Contacts, SearchTextBox.Text);
        UpdateListBox();
    }

    /// <summary>
    /// Обновляет информацию в оповещении о днях рождениях.
    /// </summary>
    private void UpdateBirthdayPeopleNotify()
    {
        List<Contact> birthdayPeople = _project.SortByFullName(_project.FindBirthDayContacts(_project.Contacts));

        if (birthdayPeople.Count == 0)
        {
            NotifyPanel.Visible = false;
            return;
        }

        BirthdayPeopleLabel.Text = string.Empty;

        foreach (Contact contact in birthdayPeople)
        {
            if (BirthdayPeopleLabel.Text.Length >= 50)
            {
                BirthdayPeopleLabel.Text = BirthdayPeopleLabel.Text.Remove(BirthdayPeopleLabel.Text.Length - 2, 1);
                BirthdayPeopleLabel.Text += "и др.";
                return;
            }

            BirthdayPeopleLabel.Text += contact.FullName + ", ";
        }
    }

    //Обработка нажатий на кнопки

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

    //Обработка нажатия клавиш

    /// <summary>
    /// Открывает окно About при нажатии клавиши F1.
    /// </summary>
    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            AboutForm form = new AboutForm();
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

    //Смена цвета при наведении курсора на кнопку

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

    //Смена цвета при выведении курсора с кнопки

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