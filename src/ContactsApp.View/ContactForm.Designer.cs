namespace ContactsApp.View
{
    partial class ContactForm
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
            VkIdTextBox = new TextBox();
            VkLabel = new Label();
            DateOfBirthLabel = new Label();
            PhoneNumberTextBox = new TextBox();
            PhoneNumberLabel = new Label();
            EmailTextBox = new TextBox();
            EmailLabel = new Label();
            FullNameTextBox = new TextBox();
            FullNameLabel = new Label();
            ProfilePictureBox = new PictureBox();
            ButtonsPanel = new Panel();
            CancelButton = new Button();
            OkButton = new Button();
            AddPhotoButton = new PictureBox();
            DateOfBirthDateTimePicker = new DateTimePicker();
            comboBox1 = new CountrySelector();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
            ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddPhotoButton).BeginInit();
            SuspendLayout();
            // 
            // VkIdTextBox
            // 
            VkIdTextBox.Location = new Point(118, 249);
            VkIdTextBox.Name = "VkIdTextBox";
            VkIdTextBox.Size = new Size(200, 23);
            VkIdTextBox.TabIndex = 5;
            VkIdTextBox.TextChanged += VkIdTextBox_TextChanged;
            // 
            // VkLabel
            // 
            VkLabel.AutoSize = true;
            VkLabel.Location = new Point(118, 231);
            VkLabel.Margin = new Padding(3, 10, 3, 0);
            VkLabel.Name = "VkLabel";
            VkLabel.Size = new Size(24, 15);
            VkLabel.TabIndex = 21;
            VkLabel.Text = "VK:";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Location = new Point(118, 177);
            DateOfBirthLabel.Margin = new Padding(3, 10, 3, 0);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(76, 15);
            DateOfBirthLabel.TabIndex = 19;
            DateOfBirthLabel.Text = "Date of Birth:";
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(118, 141);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(200, 23);
            PhoneNumberTextBox.TabIndex = 3;
            PhoneNumberTextBox.TextChanged += PhoneNumberTextBox_TextChanged;
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(118, 123);
            PhoneNumberLabel.Margin = new Padding(3, 10, 3, 0);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(88, 15);
            PhoneNumberLabel.TabIndex = 17;
            PhoneNumberLabel.Text = "PhoneNumber:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmailTextBox.Location = new Point(118, 87);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(400, 23);
            EmailTextBox.TabIndex = 2;
            EmailTextBox.TextChanged += EmailTextBox_TextChanged;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(118, 69);
            EmailLabel.Margin = new Padding(3, 10, 3, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(44, 15);
            EmailLabel.TabIndex = 15;
            EmailLabel.Text = "E-mail:";
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FullNameTextBox.Location = new Point(118, 33);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(400, 23);
            FullNameTextBox.TabIndex = 1;
            FullNameTextBox.TextChanged += FullNameTextBox_TextChanged;
            // 
            // FullNameLabel
            // 
            FullNameLabel.AutoSize = true;
            FullNameLabel.Location = new Point(118, 15);
            FullNameLabel.Name = "FullNameLabel";
            FullNameLabel.Size = new Size(64, 15);
            FullNameLabel.TabIndex = 13;
            FullNameLabel.Text = "Full Name:";
            // 
            // ProfilePictureBox
            // 
            ProfilePictureBox.Image = Properties.Resources.photo_placeholder_100x100;
            ProfilePictureBox.Location = new Point(12, 12);
            ProfilePictureBox.Name = "ProfilePictureBox";
            ProfilePictureBox.Size = new Size(100, 100);
            ProfilePictureBox.TabIndex = 12;
            ProfilePictureBox.TabStop = false;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.BackColor = Color.WhiteSmoke;
            ButtonsPanel.Controls.Add(CancelButton);
            ButtonsPanel.Controls.Add(OkButton);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 332);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(530, 47);
            ButtonsPanel.TabIndex = 24;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(443, 12);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(362, 12);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 7;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // AddPhotoButton
            // 
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_grey;
            AddPhotoButton.Location = new Point(12, 112);
            AddPhotoButton.Name = "AddPhotoButton";
            AddPhotoButton.Size = new Size(100, 50);
            AddPhotoButton.SizeMode = PictureBoxSizeMode.CenterImage;
            AddPhotoButton.TabIndex = 6;
            AddPhotoButton.TabStop = false;
            AddPhotoButton.MouseEnter += AddPhotoButton_MouseEnter;
            AddPhotoButton.MouseLeave += AddPhotoButton_MouseLeave;
            // 
            // DateOfBirthDateTimePicker
            // 
            DateOfBirthDateTimePicker.Location = new Point(118, 195);
            DateOfBirthDateTimePicker.Name = "DateOfBirthDateTimePicker";
            DateOfBirthDateTimePicker.Size = new Size(200, 23);
            DateOfBirthDateTimePicker.TabIndex = 4;
            DateOfBirthDateTimePicker.ValueChanged += DateOfBirthDateTimePicker_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(372, 143);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(47, 24);
            comboBox1.TabIndex = 25;
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(530, 379);
            Controls.Add(comboBox1);
            Controls.Add(DateOfBirthDateTimePicker);
            Controls.Add(AddPhotoButton);
            Controls.Add(ButtonsPanel);
            Controls.Add(VkIdTextBox);
            Controls.Add(VkLabel);
            Controls.Add(DateOfBirthLabel);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(EmailTextBox);
            Controls.Add(EmailLabel);
            Controls.Add(FullNameTextBox);
            Controls.Add(FullNameLabel);
            Controls.Add(ProfilePictureBox);
            KeyPreview = true;
            MaximumSize = new Size(546, 418);
            MinimumSize = new Size(546, 418);
            Name = "ContactForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Shown += ContactForm_Shown;
            KeyDown += ContactForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AddPhotoButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel ButtonsPanel;
        private PictureBox ProfilePictureBox;
        private PictureBox AddPhotoButton;
        private Button CancelButton;
        private Button OkButton;
        private TextBox FullNameTextBox;
        private TextBox EmailTextBox;
        private TextBox PhoneNumberTextBox;
        private TextBox VkIdTextBox;
        private DateTimePicker DateOfBirthDateTimePicker;
        private Label VkLabel;
        private Label DateOfBirthLabel;
        private Label PhoneNumberLabel;
        private Label EmailLabel;
        private Label FullNameLabel;
        private CountrySelector comboBox1;
    }
}