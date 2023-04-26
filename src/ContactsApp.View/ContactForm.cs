using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ContactsApp.View;

/// <summary>
/// Форма добавления и редактирования контакта <see cref="Contact"/>.
/// </summary>
public partial class ContactForm : Form
{
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
    /// Конструктор класса <see cref="ContactForm"/>.
    /// </summary>
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

    /// <summary>
    /// Обновляет поля для заполнения контакта.
    /// </summary>
    private void UpdateForm()
    {
        FullNameTextBox.Text = _contact.FullName;
        EmailTextBox.Text = _contact.Email;
        PhoneNumberTextBox.Text = _contact.PhoneNumber;
        DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
        VkIdTextBox.Text = _contact.VkId;
    }

    /// <summary>
    /// Проверяет присутствуют ли ошибки в заполнении полей контакта.
    /// </summary>
    /// <returns>
    ///     <b>true</b>: если нет ошибок при вводе данных. <para/>
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
    /// Добавляет строку для отображения её в сообщении об ошибке.
    /// </summary>
    /// <param name="errorMessage">Строка с сообщением об ошибке.</param>
    /// <returns>
    ///     Пустую строку, если сообщения об ошибке нет. <para/>
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
    /// Открывает окно About при нажатии клавиши F1.
    /// </summary>
    private void ContactForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var form = new AboutForm();
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

    private void ContactForm_Shown(object sender, EventArgs e)
    {
        comboBox1.Width = 50;
        comboBox1.DropDownWidth = 100;

        comboBox1.Items.Add(new DropDownItem("Red"));
        comboBox1.Items.Add(new DropDownItem("Green"));
        comboBox1.Items.Add(new DropDownItem("Blue"));
    }

    //private static readonly ImageList FlagList = new ImageList();
    //private static readonly List<KeyValuePair<string, string>> Countries = new List<KeyValuePair<string, string>>();

    //private void Foo()
    //{
    //    FlagList.Images.Add(new Bitmap(Properties.Resources.AD));
    //    FlagList.Images.Add(new Bitmap(Properties.Resources.AE));
    //    FlagList.Images.Add(new Bitmap(Properties.Resources.AF));

    //    Countries.Add(new KeyValuePair<string, string>("AD", "Andorra"));
    //    Countries.Add(new KeyValuePair<string, string>("AE", "United Arab Emirates"));
    //    Countries.Add(new KeyValuePair<string, string>("AF", "Afghanistan"));

    //    CountriesComboBox.Items.Clear();

    //    CountriesComboBox.DataSource = Countries;
    //    CountriesComboBox.DisplayMember = "Value";
    //    CountriesComboBox.ValueMember = "Key";

    //    CountriesComboBox.DrawMode = DrawMode.OwnerDrawVariable;
    //    CountriesComboBox.DrawItem += Bar;
    //    CountriesComboBox.ItemHeight = 20;
    //}

    //private void Bar(object sender, DrawItemEventArgs e)
    //{
    //    // Set the textBrush color to Windows Text.
    //    Brush textBrush = SystemBrushes.MenuText;

    //    if (e.Index == -1)
    //        return;

    //    // Highlight the combobox item when the mouse cursor hovers over the item in the dropdown list.
    //    //if (e.Index == _MouseIndex)
    //    //{
    //    //    e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
    //    //    textBrush = SystemBrushes.HighlightText;
    //    //}
    //    //else
    //    //{
    //    //    // Highlight the combobox item when slected in the dropdown list.
    //    //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    //    //    {
    //    //        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
    //    //        textBrush = SystemBrushes.HighlightText;
    //    //    }
    //    //    else
    //    //    {
    //    //        // Restore background colour to deafult when the mouse leaves the item.
    //    //        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
    //    //    }
    //    //}

    //    // Draw the string i.e populate the combobox with the list of the text names
    //    // for the User groups & User Accounts

    //    e.Graphics.DrawString(Countries[e.Index].Value.ToString(),
    //        e.Font, textBrush, e.Bounds.Left + 20, e.Bounds.Top);

    //    // IF Statements below are used to determine which icon to display in the drop down list, depending on
    //    // whether the comboxo item is a User Group or User Account name.
    //    //if (Countries[e.Index].Key == "UserGroup")
    //    //{
    //    //    // Image list index '0' represents the icon image for the User Group.
    //    //    e.Graphics.DrawImage(imageListEmailRecipients.Images[0], e.Bounds.Left, e.Bounds.Top);
    //    //}
    //    //
    //    //if (emailRecipientsUserList[e.Index].Key == "Username")
    //    //{
    //    //    // Image list index '0' represents the icon image for the User Account.
    //    //    e.Graphics.DrawImage(imageListEmailRecipients.Images[1], e.Bounds.Left, e.Bounds.Top);
    //    //}

    //    switch (Countries[e.Index].Key)
    //    {
    //        case "AD":
    //            e.Graphics.DrawImage(FlagList.Images[0], e.Bounds.Left, e.Bounds.Top);
    //            break;

    //        case "AE":
    //            e.Graphics.DrawImage(FlagList.Images[1], e.Bounds.Left, e.Bounds.Top);
    //            break;

    //        case "AF":
    //            e.Graphics.DrawImage(FlagList.Images[2], e.Bounds.Left, e.Bounds.Top);
    //            break;

    //        default:
    //            break;
    //    }
    //}

    //private void ContactForm_Shown(object sender, EventArgs e)
    //{
    //    Foo();
    //}


    ////// Create an image list that will be used for the combobox icons
    ////readonly static ImageList imageListEmailRecipients = new ImageList();
    ////
    ////// Create an List that will be used to store the user account and user group names from the two different data tables.
    ////public static readonly List<KeyValuePair<string, string>> emailRecipientsUserList = new List<KeyValuePair<string, string>>();
    ////
    /////// <summary>
    ///// This method is used to create a list to hold the values pulled from two different data tables.
    ///// The information pulled provides the list with the names of the User Groups & User Accounts.
    ///// Note: When the Windows Form closes, the closing method runs the command 'emailRecipientsUserList.Clear()'
    ///// in order to ensure that the list is cleared and does not continue to build up with dulicate entries each
    ///// time the form is opened.
    ///// </summary>
    ////private void PopulateUsersGroupsList()
    ////{
    ////    // Add the two images to the image list, images are loaded from the properties resources folder.
    ////    // These images will be used as icons to display in the combobox.
    ////    imageListEmailRecipients.Images.Add((Image)(new Bitmap(Properties.Resources.UserGroup2)));
    ////    imageListEmailRecipients.Images.Add((Image)(new Bitmap(Properties.Resources.UserAccount)));
    ////
    ////    // Add a default string to the list for the combobox default value, prompting the user to make their selection
    ////    // before the open up the dropdown combobox.
    ////    emailRecipientsUserList.Add(new KeyValuePair<string, string>("", "--Select--"));
    ////
    ////    // Add each User Group from the data table to the list. KeyValuePairs are used so we can differentiate
    ////    // between the User Groups list and User Accounts list.
    ////    for (int i = 0; i < DB_UserGroups.userGroupsDataTable.Rows.Count; i++)
    ////    {
    ////        emailRecipientsUserList.Add(new KeyValuePair<string, string>("UserGroup", DB_UserGroups.userGroupsDataTable.Rows[i]["UserGroup"].ToString()));
    ////    }
    ////
    ////    // Add each User Account from the data table to the list. KeyValuePairs are used so we can differentiate
    ////    // between the User Groups list and User Accounts list.
    ////    for (int i = 0; i < DB_Users.userAccountsDataTable.Rows.Count; i++)
    ////    {
    ////        //emailRecipientsUserList.Add(DB_Users.userAccountsDataTable.Rows[i]["Username"].ToString());
    ////        emailRecipientsUserList.Add(new KeyValuePair<string, string>("Username", DB_Users.userAccountsDataTable.Rows[i]["Username"].ToString()));
    ////    }
    ////    // Run the method below that will populate the combobox with the User Groups & User Accounts from the list.
    ////    AddUsersGroupsComboboxPopulate();
    ////}
    ////
    /////// <summary>
    /////// Method used to populate the combobox using the 'emailRecipientsUserList' created from the method above. 
    /////// </summary>
    ////private void AddUsersGroupsComboboxPopulate()
    ////{
    ////    // Clear the comobox before re-populating.
    ////    AddUserGroupCombobox.Items.Clear();
    ////
    ////    // Map the combobox's data source to the 'emailRecipientsUserList' source.
    ////    this.AddUserGroupCombobox.DataSource = emailRecipientsUserList;
    ////    // Confirure the combobox to the show the 'Value' portion ONLY from the KeyValuePair 
    ////    // value set found in the 'emailRecipientsUserList'.
    ////    this.AddUserGroupCombobox.DisplayMember = "Value";
    ////    // Configure the combobox to utilise the Key from the 'emailRecipientsUserList' as its member value.
    ////    this.AddUserGroupCombobox.ValueMember = "Key";
    ////
    ////    // Set the combobox to owner draw mode - otherwise you cannot change the output style to your own format.
    ////    AddUserGroupCombobox.DrawMode = DrawMode.OwnerDrawFixed;
    ////    // Instruct the combobox to draw itself using the 'AddUserGroupCombobox_DrawItem' method below.
    ////    AddUserGroupCombobox.DrawItem += AddUserGroupCombobox_DrawItem;
    ////    // Set the default height for each of the items displayed in the combobox.
    ////    AddUserGroupCombobox.ItemHeight = 20;
    ////}
    ////
    ////// Mouse index used to reference the position of the cursor when navigating up and down the combobox list.
    ////private readonly int _MouseIndex = -1;
    ////
    /////// <summary>
    ///// This method is used to draw the items from the 'emailRecipientsUserList' into the combobox, 
    ///// using an owner draw custom format so we can show the the User Group & User
    ///// Account icons adjacent their relevant names in the combobox list.
    ///// 
    ///// In the method above, we created the 'emailRecipientsUserList' that contains data columns
    ///// from two different data tables, the first datatable holds the names of the User Groups and the second
    ///// holds the User Accounts. We're utilizing the KeyValuePair in order to provide a
    ///// means of applying some logic to the population of our combobox in order to differentiate 
    ///// between a User Group and a User Account. This allows us to dynamically
    ///// assign the relevant icon display, adjacent each of the items in the combobox list.
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    ////private void AddUserGroupCombobox_DrawItem(object sender, DrawItemEventArgs e)
    ////{
    ////    // Set the textBrush color to Windows Text.
    ////    Brush textBrush = SystemBrushes.WindowText;
    ////
    ////    if (e.Index > -1)
    ////    {
    ////        // Highlight the combobox item when the mouse cursor hovers over the item in the dropdown list.
    ////        if (e.Index == _MouseIndex)
    ////        {
    ////            e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
    ////            textBrush = SystemBrushes.HighlightText;
    ////        }
    ////        else
    ////        {
    ////            // Highlight the combobox item when slected in the dropdown list.
    ////            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    ////            {
    ////                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
    ////                textBrush = SystemBrushes.HighlightText;
    ////            }
    ////            else
    ////            {
    ////                // Restore background colour to deafult when the mouse leaves the item.
    ////                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
    ////            }
    ////        }
    ////        // Draw the string i.e populate the combobox with the list of the text names
    ////        // for the User groups & User Accounts
    ////        e.Graphics.DrawString(emailRecipientsUserList[e.Index].Value.ToString(), e.Font, textBrush, e.Bounds.Left + 20, e.Bounds.Top);
    ////
    ////        // IF Statements below are used to determine which icon to display in the drop down list, depending on
    ////        // whether the comboxo item is a User Group or User Account name.
    ////        if (emailRecipientsUserList[e.Index].Key == "UserGroup")
    ////        {
    ////            // Image list index '0' represents the icon image for the User Group.
    ////            e.Graphics.DrawImage(imageListEmailRecipients.Images[0], e.Bounds.Left, e.Bounds.Top);
    ////        }
    ////
    ////        if (emailRecipientsUserList[e.Index].Key == "Username")
    ////        {
    ////            // Image list index '0' represents the icon image for the User Account.
    ////            e.Graphics.DrawImage(imageListEmailRecipients.Images[1], e.Bounds.Left, e.Bounds.Top);
    ////        }
    ////    }
    ////}
}