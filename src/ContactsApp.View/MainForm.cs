﻿namespace ContactsApp.View;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    #region ContactTextBox_KeyPress

    private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void DateOfBirthTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void VkTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    #endregion

    #region ContactButtons_Click

    private void AddContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        form.ShowDialog();
    }

    private void EditContactButton_Click(object sender, EventArgs e)
    {
        var form = new ContactForm();
        form.ShowDialog();
    }

    private void RemoveContactButton_Click(object sender, EventArgs e)
    {
        //todo
    }

    private void CloseNotifyPictureBox_Click(object sender, EventArgs e)
    {
        NotifyPanel.Visible = false;
    }

    #endregion

    #region ContactButtons_MouseEvents

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

    #endregion

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }
    }
}