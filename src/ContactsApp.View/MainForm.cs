using ContactsApp.Model;
using System;

namespace ContactsApp.View;

public partial class MainForm : Form
{
    private Project _project = new Project();

    public MainForm()
    {
        InitializeComponent();
    }

    private void UpdateListBox()
    {
        ContactsListBox.Items.Clear();

        foreach (Contact contact in _project.Contacts)
        {
            ContactsListBox.Items.Add(contact.FullName);
        }
    }

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

    private void UpdateSelectedContact(int index)
    {
        FullNameTextBox.Text = _project.Contacts[index].FullName;
        EmailTextBox.Text = _project.Contacts[index].Email;
        PhoneNumberTextBox.Text = _project.Contacts[index].PhoneNumber;
        DateOfBirthTextBox.Text = _project.Contacts[index].DateOfBirth.ToString();
        VkTextBox.Text = _project.Contacts[index].VkId;
    }

    private void ClearSelectedContact()
    {
        FullNameTextBox.Text = string.Empty;
        EmailTextBox.Text = string.Empty;
        PhoneNumberTextBox.Text = string.Empty;
        DateOfBirthTextBox.Text = string.Empty;
        VkTextBox.Text = string.Empty;
    }

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }

    private void AddContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            AddContact();
            UpdateListBox();
        }
    }

    private void EditContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        form.ShowDialog();
    }

    private void RemoveContactButton_Click(object sender, EventArgs e)
    {
        RemoveContact(ContactsListBox.SelectedIndex);
        UpdateListBox();
    }

    private void CloseNotifyPictureBox_Click(object sender, EventArgs e)
    {
        NotifyPanel.Visible = false;
    }

    private void FullNameTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    private void EmailTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    private void PhoneNumberTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    private void DateOfBirthTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    private void VkTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (!(e.Control && e.KeyCode == Keys.C) &&
            !(e.Control && e.KeyCode == Keys.A))
        {
            e.SuppressKeyPress = true;
        }
    }

    private void AddContactButton_MouseEnter(object sender, EventArgs e)
    {
        AddContactButton.Image = Properties.Resources.add_contact_32x32;
        AddContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    private void EditContactButton_MouseEnter(object sender, EventArgs e)
    {
        EditContactButton.Image = Properties.Resources.edit_contact_32x32;
        EditContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
    }

    private void RemoveContactButton_MouseEnter(object sender, EventArgs e)
    {
        RemoveContactButton.Image = Properties.Resources.remove_contact_32x32;
        RemoveContactButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
    }

    private void AddContactButton_MouseLeave(object sender, EventArgs e)
    {
        AddContactButton.Image = Properties.Resources.add_contact_32x32_grey;
        AddContactButton.BackColor = Color.White;
    }

    private void EditContactButton_MouseLeave(object sender, EventArgs e)
    {
        EditContactButton.Image = Properties.Resources.edit_contact_32x32_grey;
        EditContactButton.BackColor = Color.White;
    }

    private void RemoveContactButton_MouseLeave(object sender, EventArgs e)
    {
        RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_grey;
        RemoveContactButton.BackColor = Color.White;
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        UpdateListBox();
    }

    private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ContactsListBox.SelectedIndex == -1)
            ClearSelectedContact();
        else
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Do you really want to exit?", "Close?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }
}
