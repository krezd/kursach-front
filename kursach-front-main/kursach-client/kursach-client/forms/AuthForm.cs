using kursach_client.forms;
using kursach_client.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.model
{
    public class AuthForm : Form
    {
        private Label label1;
        private Label label2;
        private TextBox LoginBox;
        private TextBox PasswordBox;
        private Button loginButton;
        private Label label3;
        private PictureBox pictureBox1;
        private Panel LoginPanel;
        private Panel SettingsPanel;
        private Button saveSettingsButton;
        private Label UrlServer;
        private TextBox addressBox;
        private PictureBox pictureBox2;
        private readonly AuthService authService;        
        public AuthForm(AuthService authService)
        {
            InitializeComponent();
            this.authService = authService;
            DialogResult = DialogResult.None;
            SetPlaceholder();
            ShowLoginPanel();
        }
        private async Task SignIn() {
            var login = LoginBox.Text;
            var password = PasswordBox.Text;
            if (!(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)))
            {
                var result = authService.Auth(login, password);

                if (await result)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.UrlServer = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.LoginPanel.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // LoginBox
            // 
            this.LoginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginBox.Location = new System.Drawing.Point(31, 58);
            this.LoginBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(156, 20);
            this.LoginBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PasswordBox.Location = new System.Drawing.Point(31, 113);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(156, 20);
            this.PasswordBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Location = new System.Drawing.Point(47, 157);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(121, 37);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(70, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Регистрация";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::kursach_client.Properties.Resources.gearpng_parspng_com_5;
            this.pictureBox1.Location = new System.Drawing.Point(174, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.pictureBox1);
            this.LoginPanel.Controls.Add(this.label3);
            this.LoginPanel.Controls.Add(this.loginButton);
            this.LoginPanel.Controls.Add(this.PasswordBox);
            this.LoginPanel.Controls.Add(this.LoginBox);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(222, 272);
            this.LoginPanel.TabIndex = 7;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.pictureBox2);
            this.SettingsPanel.Controls.Add(this.saveSettingsButton);
            this.SettingsPanel.Controls.Add(this.UrlServer);
            this.SettingsPanel.Controls.Add(this.addressBox);
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(219, 266);
            this.SettingsPanel.TabIndex = 7;
            this.SettingsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsPanel_Paint);
            // 
            // addressBox
            // 
            this.addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressBox.Location = new System.Drawing.Point(25, 102);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(167, 26);
            this.addressBox.TabIndex = 100;
            this.addressBox.Enter += new System.EventHandler(this.addressBox_Enter);
            this.addressBox.Leave += new System.EventHandler(this.addressBox_Leave);
            // 
            // UrlServer
            // 
            this.UrlServer.AutoSize = true;
            this.UrlServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UrlServer.Location = new System.Drawing.Point(22, 73);
            this.UrlServer.Name = "UrlServer";
            this.UrlServer.Size = new System.Drawing.Size(80, 20);
            this.UrlServer.TabIndex = 1;
            this.UrlServer.Text = "Api-server";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveSettingsButton.Location = new System.Drawing.Point(40, 168);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(137, 38);
            this.saveSettingsButton.TabIndex = 2;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::kursach_client.Properties.Resources._4765130;
            this.pictureBox2.Location = new System.Drawing.Point(12, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 101;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(221, 267);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(237, 306);
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                await SignIn();
            }
            finally { 
            Cursor = Cursors.Default;
            }
            
        }

        private async void PasswordTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await SignIn();
        }

        private void ShowLoginPanel()
        {
            LoginPanel.Visible = true;
            SettingsPanel.Visible = false;
        }

        private void ShowSettingsPanel()
        {
            LoginPanel.Visible = false;
            SettingsPanel.Visible = true;
        }


        private void label3_Click(object sender, EventArgs e)
        {
            var registrForm = new RegistrationForm(authService);
            this.Hide();
            registrForm.ShowDialog();
            if (registrForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            this.Show();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Cursor = Cursors.Hand;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Cursor = Cursors.Hand;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowSettingsPanel();
        }

        private void SettingsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(addressBox.Text))
            {
                addressBox.Text = Properties.Settings.Default.ServerURL;
                addressBox.ForeColor = Color.Gray; 
            }
        }

        private void addressBox_Enter(object sender, EventArgs e)
        {
            if (addressBox.Text == Properties.Settings.Default.ServerURL)
            {
                addressBox.Text = Properties.Settings.Default.ServerURL; 
                addressBox.ForeColor = Color.Black; 
            }
        }

        private void addressBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addressBox.Text))
            {
                SetPlaceholder(); 
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerURL = addressBox.Text;
            Properties.Settings.Default.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowLoginPanel();
        }
    }
}
