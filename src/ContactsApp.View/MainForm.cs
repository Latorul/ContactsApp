﻿namespace ContactsApp.View;

/// <summary>
/// Главное окно приложения.
/// </summary>
public partial class MainForm : Form
{
    /// <summary>
    /// Хранит список всех контактов. 
    /// </summary>
    private readonly Project _project = new Project();


    /// <summary>
    /// Конструктор класса <see cref="MainForm"/>.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Добавляет новый контакт.
    /// </summary>
    private void AddContact()
    {
        _project.Contacts.Add(new Contact(
            "fullName",
            "email",
            "1234567890",
            DateTime.Today,
            "vkId"
        ));
    }

    /// <summary>
    /// Обновляет список контактов в ContactsListBox.
    /// </summary>
    private void UpdateListBox()
    {
        ContactsListBox.Items.Clear();

        foreach (Contact contact in _project.Contacts)
        {
            ContactsListBox.Items.Add(contact.FullName);
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

        if (MessageBox.Show($"Do you really want to remove {_project.Contacts[index].FullName}?",
                "Remove contact?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            return;

        _project.Contacts.RemoveAt(index);
    }

    /// <summary>
    /// Обновляет информацию о выбранном контакте в правой панели.
    /// </summary>
    /// <param name="index">Индекс выбранного контакта в списке ContactsListBox.</param>
    private void UpdateSelectedContact(int index)
    {
        FullNameTextBox.Text = _project.Contacts[index].FullName;
        EmailTextBox.Text = _project.Contacts[index].Email;
        PhoneNumberTextBox.Text = _project.Contacts[index].PhoneNumber;
        DateOfBirthTextBox.Text = _project.Contacts[index].DateOfBirth.ToString();
        VkIdTextBox.Text = _project.Contacts[index].VkId;
    }

    /// <summary>
    /// Очищает информацию о выбранном контакте в правой панели.
    /// </summary>
    private void ClearSelectedContact()
    {
        //todo очищать контакт при удалении всех
        FullNameTextBox.Text = string.Empty;
        EmailTextBox.Text = string.Empty;
        PhoneNumberTextBox.Text = string.Empty;
        DateOfBirthTextBox.Text = string.Empty;
        VkIdTextBox.Text = string.Empty;
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
    /// Обновляет информацию при открытии программы.
    /// </summary>
    private void MainForm_Shown(object sender, EventArgs e)
    {
        UpdateListBox();
        ClearSelectedContact();
    }

    /// <summary>
    /// При закрытии окна спрашивает подтверждение закрытия программы.
    /// </summary>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Do you really want to exit?",
                "Close?",
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }

    //Обработка нажатий на кнопки

    /// <summary>
    /// Обрабатывает нажатие кнопки добавления контакта. 
    /// </summary>
    private void AddContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            AddContact();
            UpdateListBox();
        }
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки редактирования контакта. 
    /// </summary>
    private void EditContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        form.ShowDialog();
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки удаления контакта. 
    /// </summary>
    private void RemoveContactButton_Click(object sender, EventArgs e)
    {
        RemoveContact(ContactsListBox.SelectedIndex);
        UpdateListBox();
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