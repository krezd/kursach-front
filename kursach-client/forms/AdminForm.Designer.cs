namespace kursach_client.forms
{
    partial class AdminForm
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.StatusButton = new System.Windows.Forms.Button();
            this.userControlButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.trackingSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Location = new System.Drawing.Point(1943, 34);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(181, 57);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Выйти";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoEllipsis = true;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelName.Location = new System.Drawing.Point(1805, 38);
            this.labelName.Name = "labelName";
            this.labelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelName.Size = new System.Drawing.Size(108, 39);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "name";
            // 
            // labelPosition
            // 
            this.labelPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPosition.AutoEllipsis = true;
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPosition.Location = new System.Drawing.Point(1794, 92);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPosition.Size = new System.Drawing.Size(119, 33);
            this.labelPosition.TabIndex = 4;
            this.labelPosition.Text = "Position";
            // 
            // StatusButton
            // 
            this.StatusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusButton.Location = new System.Drawing.Point(12, 12);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(245, 65);
            this.StatusButton.TabIndex = 5;
            this.StatusButton.Text = "Статусы процессов";
            this.StatusButton.UseVisualStyleBackColor = true;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // userControlButton
            // 
            this.userControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlButton.Location = new System.Drawing.Point(278, 12);
            this.userControlButton.Name = "userControlButton";
            this.userControlButton.Size = new System.Drawing.Size(245, 65);
            this.userControlButton.TabIndex = 6;
            this.userControlButton.Text = "Управление пользователями";
            this.userControlButton.UseVisualStyleBackColor = true;
            this.userControlButton.Click += new System.EventHandler(this.userControl_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(1943, 119);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(181, 66);
            this.SettingsButton.TabIndex = 7;
            this.SettingsButton.Text = "Настройки пользователя";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // trackingSettingsButton
            // 
            this.trackingSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackingSettingsButton.Location = new System.Drawing.Point(539, 12);
            this.trackingSettingsButton.Name = "trackingSettingsButton";
            this.trackingSettingsButton.Size = new System.Drawing.Size(299, 65);
            this.trackingSettingsButton.TabIndex = 8;
            this.trackingSettingsButton.Text = "Управление настройками отслеживания";
            this.trackingSettingsButton.UseVisualStyleBackColor = true;
            this.trackingSettingsButton.Click += new System.EventHandler(this.trackingSettingsButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2145, 959);
            this.Controls.Add(this.trackingSettingsButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.userControlButton);
            this.Controls.Add(this.StatusButton);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.logoutButton);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Button userControlButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button trackingSettingsButton;
    }
}