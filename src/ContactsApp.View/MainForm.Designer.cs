namespace ContactsApp.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TableLayoutPanel = new TableLayoutPanel();
            ContactPanel = new Panel();
            NotifyPanel = new Panel();
            BirthdayPeopleLabel = new Label();
            BirthdayNotifyLabel = new Label();
            CloseNotifyPictureBox = new PictureBox();
            NotifyPictureBox = new PictureBox();
            VkTextBox = new TextBox();
            VkLabel = new Label();
            DateOfBirthLabel = new Label();
            DateOfBirthTextBox = new TextBox();
            PhoneNumberTextBox = new TextBox();
            PhoneNumberLabel = new Label();
            EmailTextBox = new TextBox();
            EmailLabel = new Label();
            FullNameTextBox = new TextBox();
            FullNameLabel = new Label();
            ProfilePictureBox = new PictureBox();
            MenuPanel = new Panel();
            ButtonsTableLayoutPanel = new TableLayoutPanel();
            RemoveContactButton = new PictureBox();
            EditContactButton = new PictureBox();
            AddContactButton = new PictureBox();
            SearchTextBox = new TextBox();
            FindLabel = new Label();
            ContactsListBox = new ListBox();
            TableLayoutPanel.SuspendLayout();
            ContactPanel.SuspendLayout();
            NotifyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CloseNotifyPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NotifyPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
            MenuPanel.SuspendLayout();
            ButtonsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RemoveContactButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EditContactButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AddContactButton).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.ColumnCount = 2;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Controls.Add(ContactPanel, 1, 0);
            TableLayoutPanel.Controls.Add(MenuPanel, 0, 0);
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Location = new Point(0, 0);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 1;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TableLayoutPanel.Size = new Size(800, 450);
            TableLayoutPanel.TabIndex = 0;
            // 
            // ContactPanel
            // 
            ContactPanel.Controls.Add(NotifyPanel);
            ContactPanel.Controls.Add(VkTextBox);
            ContactPanel.Controls.Add(VkLabel);
            ContactPanel.Controls.Add(DateOfBirthLabel);
            ContactPanel.Controls.Add(DateOfBirthTextBox);
            ContactPanel.Controls.Add(PhoneNumberTextBox);
            ContactPanel.Controls.Add(PhoneNumberLabel);
            ContactPanel.Controls.Add(EmailTextBox);
            ContactPanel.Controls.Add(EmailLabel);
            ContactPanel.Controls.Add(FullNameTextBox);
            ContactPanel.Controls.Add(FullNameLabel);
            ContactPanel.Controls.Add(ProfilePictureBox);
            ContactPanel.Dock = DockStyle.Fill;
            ContactPanel.Location = new Point(253, 3);
            ContactPanel.Name = "ContactPanel";
            ContactPanel.Size = new Size(544, 444);
            ContactPanel.TabIndex = 1;
            // 
            // NotifyPanel
            // 
            NotifyPanel.BackColor = Color.FromArgb(245, 245, 255);
            NotifyPanel.Controls.Add(BirthdayPeopleLabel);
            NotifyPanel.Controls.Add(BirthdayNotifyLabel);
            NotifyPanel.Controls.Add(CloseNotifyPictureBox);
            NotifyPanel.Controls.Add(NotifyPictureBox);
            NotifyPanel.Dock = DockStyle.Bottom;
            NotifyPanel.Location = new Point(0, 369);
            NotifyPanel.Name = "NotifyPanel";
            NotifyPanel.Size = new Size(544, 75);
            NotifyPanel.TabIndex = 0;
            // 
            // BirthdayPeopleLabel
            // 
            BirthdayPeopleLabel.AutoSize = true;
            BirthdayPeopleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BirthdayPeopleLabel.ForeColor = Color.FromArgb(0, 144, 255);
            BirthdayPeopleLabel.Location = new Point(78, 40);
            BirthdayPeopleLabel.Name = "BirthdayPeopleLabel";
            BirthdayPeopleLabel.Size = new Size(176, 15);
            BirthdayPeopleLabel.TabIndex = 3;
            BirthdayPeopleLabel.Text = "Новикова, Кондратьева и др.";
            // 
            // BirthdayNotifyLabel
            // 
            BirthdayNotifyLabel.AutoSize = true;
            BirthdayNotifyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BirthdayNotifyLabel.ForeColor = Color.FromArgb(0, 144, 255);
            BirthdayNotifyLabel.Location = new Point(78, 20);
            BirthdayNotifyLabel.Name = "BirthdayNotifyLabel";
            BirthdayNotifyLabel.Size = new Size(140, 15);
            BirthdayNotifyLabel.TabIndex = 2;
            BirthdayNotifyLabel.Text = "Today is the Birthday of:";
            // 
            // CloseNotifyPictureBox
            // 
            CloseNotifyPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseNotifyPictureBox.Image = Properties.Resources.close_32x32;
            CloseNotifyPictureBox.Location = new Point(509, 3);
            CloseNotifyPictureBox.Name = "CloseNotifyPictureBox";
            CloseNotifyPictureBox.Size = new Size(32, 32);
            CloseNotifyPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            CloseNotifyPictureBox.TabIndex = 1;
            CloseNotifyPictureBox.TabStop = false;
            CloseNotifyPictureBox.Click += CloseNotifyPictureBox_Click;
            // 
            // NotifyPictureBox
            // 
            NotifyPictureBox.Image = Properties.Resources.info_48x48;
            NotifyPictureBox.Location = new Point(3, 3);
            NotifyPictureBox.Name = "NotifyPictureBox";
            NotifyPictureBox.Size = new Size(69, 69);
            NotifyPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            NotifyPictureBox.TabIndex = 0;
            NotifyPictureBox.TabStop = false;
            // 
            // VkTextBox
            // 
            VkTextBox.Location = new Point(109, 240);
            VkTextBox.Name = "VkTextBox";
            VkTextBox.Size = new Size(200, 23);
            VkTextBox.TabIndex = 7;
            VkTextBox.Text = "https://vk.com/";
            VkTextBox.KeyPress += VkTextBox_KeyPress;
            // 
            // VkLabel
            // 
            VkLabel.AutoSize = true;
            VkLabel.Location = new Point(109, 222);
            VkLabel.Margin = new Padding(3, 10, 3, 0);
            VkLabel.Name = "VkLabel";
            VkLabel.Size = new Size(24, 15);
            VkLabel.TabIndex = 10;
            VkLabel.Text = "VK:";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Location = new Point(109, 168);
            DateOfBirthLabel.Margin = new Padding(3, 10, 3, 0);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(76, 15);
            DateOfBirthLabel.TabIndex = 8;
            DateOfBirthLabel.Text = "Date of Birth:";
            // 
            // DateOfBirthTextBox
            // 
            DateOfBirthTextBox.Location = new Point(109, 186);
            DateOfBirthTextBox.Name = "DateOfBirthTextBox";
            DateOfBirthTextBox.Size = new Size(200, 23);
            DateOfBirthTextBox.TabIndex = 6;
            DateOfBirthTextBox.Text = "01.04.2023";
            DateOfBirthTextBox.KeyPress += DateOfBirthTextBox_KeyPress;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(109, 132);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(200, 23);
            PhoneNumberTextBox.TabIndex = 5;
            PhoneNumberTextBox.Text = "+7 (900) 000-00-00";
            PhoneNumberTextBox.KeyPress += PhoneNumberTextBox_KeyPress;
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(109, 114);
            PhoneNumberLabel.Margin = new Padding(3, 10, 3, 0);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(88, 15);
            PhoneNumberLabel.TabIndex = 6;
            PhoneNumberLabel.Text = "PhoneNumber:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmailTextBox.Location = new Point(109, 78);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(432, 23);
            EmailTextBox.TabIndex = 4;
            EmailTextBox.Text = "novikova.anna@e.mail";
            EmailTextBox.KeyPress += EmailTextBox_KeyPress;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(109, 60);
            EmailLabel.Margin = new Padding(3, 10, 3, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(44, 15);
            EmailLabel.TabIndex = 4;
            EmailLabel.Text = "E-mail:";
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FullNameTextBox.Location = new Point(109, 24);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(432, 23);
            FullNameTextBox.TabIndex = 3;
            FullNameTextBox.Text = "Новикова Анна";
            FullNameTextBox.KeyPress += FullNameTextBox_KeyPress;
            // 
            // FullNameLabel
            // 
            FullNameLabel.AutoSize = true;
            FullNameLabel.Location = new Point(109, 6);
            FullNameLabel.Name = "FullNameLabel";
            FullNameLabel.Size = new Size(64, 15);
            FullNameLabel.TabIndex = 2;
            FullNameLabel.Text = "Full Name:";
            // 
            // ProfilePictureBox
            // 
            ProfilePictureBox.Image = Properties.Resources.photo_placeholder_100x100;
            ProfilePictureBox.Location = new Point(3, 3);
            ProfilePictureBox.Name = "ProfilePictureBox";
            ProfilePictureBox.Size = new Size(100, 100);
            ProfilePictureBox.TabIndex = 1;
            ProfilePictureBox.TabStop = false;
            // 
            // MenuPanel
            // 
            MenuPanel.Controls.Add(ButtonsTableLayoutPanel);
            MenuPanel.Controls.Add(SearchTextBox);
            MenuPanel.Controls.Add(FindLabel);
            MenuPanel.Controls.Add(ContactsListBox);
            MenuPanel.Dock = DockStyle.Fill;
            MenuPanel.Location = new Point(3, 3);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(244, 444);
            MenuPanel.TabIndex = 2;
            // 
            // ButtonsTableLayoutPanel
            // 
            ButtonsTableLayoutPanel.ColumnCount = 3;
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsTableLayoutPanel.Controls.Add(RemoveContactButton, 2, 0);
            ButtonsTableLayoutPanel.Controls.Add(EditContactButton, 1, 0);
            ButtonsTableLayoutPanel.Controls.Add(AddContactButton, 0, 0);
            ButtonsTableLayoutPanel.Dock = DockStyle.Bottom;
            ButtonsTableLayoutPanel.Location = new Point(0, 409);
            ButtonsTableLayoutPanel.Name = "ButtonsTableLayoutPanel";
            ButtonsTableLayoutPanel.RowCount = 1;
            ButtonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ButtonsTableLayoutPanel.Size = new Size(244, 35);
            ButtonsTableLayoutPanel.TabIndex = 1;
            // 
            // RemoveContactButton
            // 
            RemoveContactButton.Dock = DockStyle.Fill;
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_grey;
            RemoveContactButton.Location = new Point(162, 0);
            RemoveContactButton.Margin = new Padding(0);
            RemoveContactButton.Name = "RemoveContactButton";
            RemoveContactButton.Size = new Size(82, 35);
            RemoveContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            RemoveContactButton.TabIndex = 2;
            RemoveContactButton.TabStop = false;
            RemoveContactButton.MouseEnter += RemoveContactButton_MouseEnter;
            RemoveContactButton.MouseLeave += RemoveContactButton_MouseLeave;
            // 
            // EditContactButton
            // 
            EditContactButton.Dock = DockStyle.Fill;
            EditContactButton.Image = Properties.Resources.edit_contact_32x32_grey;
            EditContactButton.Location = new Point(81, 0);
            EditContactButton.Margin = new Padding(0);
            EditContactButton.Name = "EditContactButton";
            EditContactButton.Size = new Size(81, 35);
            EditContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            EditContactButton.TabIndex = 1;
            EditContactButton.TabStop = false;
            EditContactButton.Click += EditContactButton_Click;
            EditContactButton.MouseEnter += EditContactButton_MouseEnter;
            EditContactButton.MouseLeave += EditContactButton_MouseLeave;
            // 
            // AddContactButton
            // 
            AddContactButton.Dock = DockStyle.Fill;
            AddContactButton.Image = Properties.Resources.add_contact_32x32_grey;
            AddContactButton.Location = new Point(0, 0);
            AddContactButton.Margin = new Padding(0);
            AddContactButton.Name = "AddContactButton";
            AddContactButton.Size = new Size(81, 35);
            AddContactButton.SizeMode = PictureBoxSizeMode.CenterImage;
            AddContactButton.TabIndex = 0;
            AddContactButton.TabStop = false;
            AddContactButton.Click += AddContactButton_Click;
            AddContactButton.MouseEnter += AddContactButton_MouseEnter;
            AddContactButton.MouseLeave += AddContactButton_MouseLeave;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(45, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(199, 23);
            SearchTextBox.TabIndex = 1;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(3, 6);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(33, 15);
            FindLabel.TabIndex = 3;
            FindLabel.Text = "Find:";
            // 
            // ContactsListBox
            // 
            ContactsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ContactsListBox.FormattingEnabled = true;
            ContactsListBox.IntegralHeight = false;
            ContactsListBox.ItemHeight = 15;
            ContactsListBox.Items.AddRange(new object[] { "Новикова Анна", "Кондратьева Александра", "Кошелева Ангелина", "Воронина Нина", "Игнатов Дмитрий", "Евдокимова Полина", "Ефимов Илья", "Трофимов Савва", "Степанова Елизавета", "Черных Арсений", "Малышев Владислав", "Маслова Александра", "Нечаев Тимофей", "Золотарев Демид", "Попов Артём", "Маркова Милана" });
            ContactsListBox.Location = new Point(0, 32);
            ContactsListBox.Name = "ContactsListBox";
            ContactsListBox.Size = new Size(244, 375);
            ContactsListBox.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(TableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new Size(584, 396);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            KeyDown += MainForm_KeyDown;
            TableLayoutPanel.ResumeLayout(false);
            ContactPanel.ResumeLayout(false);
            ContactPanel.PerformLayout();
            NotifyPanel.ResumeLayout(false);
            NotifyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CloseNotifyPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NotifyPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            MenuPanel.ResumeLayout(false);
            MenuPanel.PerformLayout();
            ButtonsTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RemoveContactButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EditContactButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)AddContactButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TableLayoutPanel;
        private TableLayoutPanel ButtonsTableLayoutPanel;
        private Panel ContactPanel;
        private Panel NotifyPanel;
        private Panel MenuPanel;
        private ListBox ContactsListBox;
        private PictureBox RemoveContactButton;
        private PictureBox EditContactButton;
        private PictureBox AddContactButton;
        private PictureBox CloseNotifyPictureBox;
        private PictureBox NotifyPictureBox;
        private PictureBox ProfilePictureBox;
        private TextBox SearchTextBox;
        private TextBox VkTextBox;
        private TextBox PhoneNumberTextBox;
        private TextBox EmailTextBox;
        private TextBox DateOfBirthTextBox;
        private TextBox FullNameTextBox;
        private Label FindLabel;
        private Label BirthdayPeopleLabel;
        private Label BirthdayNotifyLabel;
        private Label VkLabel;
        private Label DateOfBirthLabel;
        private Label PhoneNumberLabel;
        private Label EmailLabel;
        private Label FullNameLabel;
    }
}