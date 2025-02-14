namespace kursach_client.forms
{
    partial class WorkerSettingsForm
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
            this.NewPasBox = new System.Windows.Forms.TextBox();
            this.NewPassLabel = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.FIOBox = new System.Windows.Forms.TextBox();
            this.FIOlabel = new System.Windows.Forms.Label();
            this.ConfirmPassBox = new System.Windows.Forms.TextBox();
            this.ConfirmPassLabel = new System.Windows.Forms.Label();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewPasBox
            // 
            this.NewPasBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPasBox.Location = new System.Drawing.Point(72, 430);
            this.NewPasBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewPasBox.Name = "NewPasBox";
            this.NewPasBox.PasswordChar = '*';
            this.NewPasBox.Size = new System.Drawing.Size(448, 31);
            this.NewPasBox.TabIndex = 15;
            // 
            // NewPassLabel
            // 
            this.NewPassLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPassLabel.AutoSize = true;
            this.NewPassLabel.Location = new System.Drawing.Point(66, 390);
            this.NewPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NewPassLabel.Name = "NewPassLabel";
            this.NewPassLabel.Size = new System.Drawing.Size(154, 25);
            this.NewPassLabel.TabIndex = 14;
            this.NewPassLabel.Text = "Новый пароль";
            this.NewPassLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordBox.Location = new System.Drawing.Point(72, 318);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(448, 31);
            this.PasswordBox.TabIndex = 13;
            // 
            // PassLabel
            // 
            this.PassLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PassLabel.AutoSize = true;
            this.PassLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PassLabel.Location = new System.Drawing.Point(66, 278);
            this.PassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PassLabel.Size = new System.Drawing.Size(86, 25);
            this.PassLabel.TabIndex = 12;
            this.PassLabel.Text = "Пароль";
            // 
            // LoginBox
            // 
            this.LoginBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBox.Location = new System.Drawing.Point(72, 212);
            this.LoginBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(448, 31);
            this.LoginBox.TabIndex = 11;
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.LoginLabel.Location = new System.Drawing.Point(66, 170);
            this.LoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginLabel.Size = new System.Drawing.Size(71, 25);
            this.LoginLabel.TabIndex = 10;
            this.LoginLabel.Text = "Логин";
            // 
            // FIOBox
            // 
            this.FIOBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FIOBox.Location = new System.Drawing.Point(72, 110);
            this.FIOBox.Margin = new System.Windows.Forms.Padding(4);
            this.FIOBox.Name = "FIOBox";
            this.FIOBox.Size = new System.Drawing.Size(448, 31);
            this.FIOBox.TabIndex = 9;
            this.FIOBox.TextChanged += new System.EventHandler(this.FIOBox_TextChanged);
            this.FIOBox.Enter += new System.EventHandler(this.FIOBox_Enter);
            this.FIOBox.Leave += new System.EventHandler(this.FIOBox_Leave);
            // 
            // FIOlabel
            // 
            this.FIOlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FIOlabel.AutoSize = true;
            this.FIOlabel.Location = new System.Drawing.Point(66, 68);
            this.FIOlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FIOlabel.Name = "FIOlabel";
            this.FIOlabel.Size = new System.Drawing.Size(61, 25);
            this.FIOlabel.TabIndex = 8;
            this.FIOlabel.Text = "ФИО";
            // 
            // ConfirmPassBox
            // 
            this.ConfirmPassBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmPassBox.Location = new System.Drawing.Point(72, 543);
            this.ConfirmPassBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPassBox.Name = "ConfirmPassBox";
            this.ConfirmPassBox.PasswordChar = '*';
            this.ConfirmPassBox.Size = new System.Drawing.Size(448, 31);
            this.ConfirmPassBox.TabIndex = 17;
            // 
            // ConfirmPassLabel
            // 
            this.ConfirmPassLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmPassLabel.AutoSize = true;
            this.ConfirmPassLabel.Location = new System.Drawing.Point(66, 503);
            this.ConfirmPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConfirmPassLabel.Name = "ConfirmPassLabel";
            this.ConfirmPassLabel.Size = new System.Drawing.Size(248, 25);
            this.ConfirmPassLabel.TabIndex = 16;
            this.ConfirmPassLabel.Text = "Подтверждение пароля";
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(151, 627);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(273, 56);
            this.saveChangesButton.TabIndex = 18;
            this.saveChangesButton.Text = "Сохранить изменения";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // WorkerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(604, 738);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.ConfirmPassBox);
            this.Controls.Add(this.ConfirmPassLabel);
            this.Controls.Add(this.NewPasBox);
            this.Controls.Add(this.NewPassLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.FIOBox);
            this.Controls.Add(this.FIOlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WorkerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки пользователя";
            this.Load += new System.EventHandler(this.WorkerSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewPasBox;
        private System.Windows.Forms.Label NewPassLabel;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox FIOBox;
        private System.Windows.Forms.Label FIOlabel;
        private System.Windows.Forms.TextBox ConfirmPassBox;
        private System.Windows.Forms.Label ConfirmPassLabel;
        private System.Windows.Forms.Button saveChangesButton;
    }
}