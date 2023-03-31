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
            VkTextBox = new TextBox();
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
            DateOfBirthTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
            ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AddPhotoButton).BeginInit();
            SuspendLayout();
            // 
            // VkTextBox
            // 
            VkTextBox.Location = new Point(118, 249);
            VkTextBox.Name = "VkTextBox";
            VkTextBox.Size = new Size(200, 23);
            VkTextBox.TabIndex = 22;
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
            PhoneNumberTextBox.TabIndex = 18;
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
            EmailTextBox.TabIndex = 16;
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
            FullNameTextBox.TabIndex = 14;
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
            CancelButton.Location = new Point(443, 12);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(362, 12);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // AddPhotoButton
            // 
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_gray;
            AddPhotoButton.Location = new Point(12, 112);
            AddPhotoButton.Name = "AddPhotoButton";
            AddPhotoButton.Size = new Size(100, 50);
            AddPhotoButton.SizeMode = PictureBoxSizeMode.CenterImage;
            AddPhotoButton.TabIndex = 25;
            AddPhotoButton.TabStop = false;
            AddPhotoButton.Click += AddPhotoButton_Click;
            AddPhotoButton.MouseEnter += AddPhotoButton_MouseEnter;
            AddPhotoButton.MouseLeave += AddPhotoButton_MouseLeave;
            // 
            // DateOfBirthTextBox
            // 
            DateOfBirthTextBox.Location = new Point(118, 195);
            DateOfBirthTextBox.Name = "DateOfBirthTextBox";
            DateOfBirthTextBox.Size = new Size(200, 23);
            DateOfBirthTextBox.TabIndex = 26;
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(530, 379);
            Controls.Add(DateOfBirthTextBox);
            Controls.Add(AddPhotoButton);
            Controls.Add(ButtonsPanel);
            Controls.Add(VkTextBox);
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
            KeyDown += ContactForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AddPhotoButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox VkTextBox;
        private Label VkLabel;
        private Label DateOfBirthLabel;
        private TextBox PhoneNumberTextBox;
        private Label PhoneNumberLabel;
        private TextBox EmailTextBox;
        private Label EmailLabel;
        private TextBox FullNameTextBox;
        private Label FullNameLabel;
        private PictureBox ProfilePictureBox;
        private Panel ButtonsPanel;
        private Button CancelButton;
        private Button OkButton;
        private PictureBox AddPhotoButton;
        private TextBox DateOfBirthTextBox;
    }
}