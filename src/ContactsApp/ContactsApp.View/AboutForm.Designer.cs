namespace ContactsApp.View
{
    partial class AboutForm
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
            OkButton = new Button();
            IconsReferenceLinkLabel = new LinkLabel();
            IconsReferenceLabel = new Label();
            LicenseTextBox = new TextBox();
            GithubLlinkLabel = new LinkLabel();
            GithubLabel = new Label();
            AuthorEmailLabel = new Label();
            EmailLabel = new Label();
            FullNameLabel = new Label();
            AuthorLabel = new Label();
            VersionLabel = new Label();
            ProgramNameLabel = new Label();
            ButtonsPanel = new Panel();
            ButtonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.Location = new Point(438, 12);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // IconsReferenceLinkLabel
            // 
            IconsReferenceLinkLabel.AutoSize = true;
            IconsReferenceLinkLabel.Location = new Point(219, 320);
            IconsReferenceLinkLabel.Name = "IconsReferenceLinkLabel";
            IconsReferenceLinkLabel.Size = new Size(68, 15);
            IconsReferenceLinkLabel.TabIndex = 38;
            IconsReferenceLinkLabel.TabStop = true;
            IconsReferenceLinkLabel.Text = "icons8.com";
            IconsReferenceLinkLabel.LinkClicked += IconsReferenceLinkLabel_LinkClicked;
            // 
            // IconsReferenceLabel
            // 
            IconsReferenceLabel.AutoSize = true;
            IconsReferenceLabel.Location = new Point(16, 320);
            IconsReferenceLabel.Name = "IconsReferenceLabel";
            IconsReferenceLabel.Size = new Size(207, 15);
            IconsReferenceLabel.TabIndex = 37;
            IconsReferenceLabel.Text = "All used images are downloaded from";
            // 
            // LicenseTextBox
            // 
            LicenseTextBox.Location = new Point(16, 160);
            LicenseTextBox.Multiline = true;
            LicenseTextBox.Name = "LicenseTextBox";
            LicenseTextBox.ScrollBars = ScrollBars.Vertical;
            LicenseTextBox.Size = new Size(497, 157);
            LicenseTextBox.TabIndex = 36;
            // 
            // GithubLlinkLabel
            // 
            GithubLlinkLabel.AutoSize = true;
            GithubLlinkLabel.Location = new Point(109, 130);
            GithubLlinkLabel.Name = "GithubLlinkLabel";
            GithubLlinkLabel.Size = new Size(151, 15);
            GithubLlinkLabel.TabIndex = 35;
            GithubLlinkLabel.TabStop = true;
            GithubLlinkLabel.Text = "https://github.com/Latorul";
            GithubLlinkLabel.LinkClicked += GithubLlinkLabel_LinkClicked;
            // 
            // GithubLabel
            // 
            GithubLabel.AutoSize = true;
            GithubLabel.Location = new Point(16, 130);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new Size(46, 15);
            GithubLabel.TabIndex = 34;
            GithubLabel.Text = "Github:";
            // 
            // AuthorEmailLabel
            // 
            AuthorEmailLabel.AutoSize = true;
            AuthorEmailLabel.Location = new Point(109, 105);
            AuthorEmailLabel.Name = "AuthorEmailLabel";
            AuthorEmailLabel.Size = new Size(171, 15);
            AuthorEmailLabel.TabIndex = 33;
            AuthorEmailLabel.Text = "ivanov.artem.andr@gmail.com";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(16, 105);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(44, 15);
            EmailLabel.TabIndex = 32;
            EmailLabel.Text = "E-mail:";
            // 
            // FullNameLabel
            // 
            FullNameLabel.AutoSize = true;
            FullNameLabel.Location = new Point(109, 80);
            FullNameLabel.Name = "FullNameLabel";
            FullNameLabel.Size = new Size(78, 15);
            FullNameLabel.TabIndex = 31;
            FullNameLabel.Text = "Artem Ivanov";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new Point(16, 80);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(47, 15);
            AuthorLabel.TabIndex = 30;
            AuthorLabel.Text = "Author:";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(16, 45);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(31, 15);
            VersionLabel.TabIndex = 29;
            VersionLabel.Text = "v 1.0";
            // 
            // ProgramNameLabel
            // 
            ProgramNameLabel.AutoSize = true;
            ProgramNameLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            ProgramNameLabel.Location = new Point(12, 14);
            ProgramNameLabel.Name = "ProgramNameLabel";
            ProgramNameLabel.Size = new Size(147, 30);
            ProgramNameLabel.TabIndex = 28;
            ProgramNameLabel.Text = "ContactsApp";
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.BackColor = Color.WhiteSmoke;
            ButtonsPanel.Controls.Add(OkButton);
            ButtonsPanel.Dock = DockStyle.Bottom;
            ButtonsPanel.Location = new Point(0, 361);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(525, 47);
            ButtonsPanel.TabIndex = 27;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(525, 408);
            Controls.Add(IconsReferenceLinkLabel);
            Controls.Add(IconsReferenceLabel);
            Controls.Add(LicenseTextBox);
            Controls.Add(GithubLlinkLabel);
            Controls.Add(GithubLabel);
            Controls.Add(AuthorEmailLabel);
            Controls.Add(EmailLabel);
            Controls.Add(FullNameLabel);
            Controls.Add(AuthorLabel);
            Controls.Add(VersionLabel);
            Controls.Add(ProgramNameLabel);
            Controls.Add(ButtonsPanel);
            Name = "AboutForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Shown += AboutForm_Shown;
            ButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkButton;
        private LinkLabel IconsReferenceLinkLabel;
        private Label IconsReferenceLabel;
        private TextBox LicenseTextBox;
        private LinkLabel GithubLlinkLabel;
        private Label GithubLabel;
        private Label AuthorEmailLabel;
        private Label EmailLabel;
        private Label FullNameLabel;
        private Label AuthorLabel;
        private Label VersionLabel;
        private Label ProgramNameLabel;
        private Panel ButtonsPanel;
    }
}