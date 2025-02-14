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
        private async Task SignIn()
        {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.UrlServer = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(58, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // LoginBox
            // 
            this.LoginBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginBox.Location = new System.Drawing.Point(62, 116);
            this.LoginBox.Margin = new System.Windows.Forms.Padding(4);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(308, 31);
            this.LoginBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PasswordBox.Location = new System.Drawing.Point(62, 226);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(308, 31);
            this.PasswordBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Location = new System.Drawing.Point(94, 314);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(242, 74);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::kursach_client.Properties.Resources.settings_icon;
            this.pictureBox1.Location = new System.Drawing.Point(348, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.pictureBox1);
            this.LoginPanel.Controls.Add(this.loginButton);
            this.LoginPanel.Controls.Add(this.PasswordBox);
            this.LoginPanel.Controls.Add(this.LoginBox);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(6);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(444, 544);
            this.LoginPanel.TabIndex = 7;
            this.LoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginPanel_Paint);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.pictureBox2);
            this.SettingsPanel.Controls.Add(this.saveSettingsButton);
            this.SettingsPanel.Controls.Add(this.addressBox);
            this.SettingsPanel.Controls.Add(this.UrlServer);
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(6);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(438, 532);
            this.SettingsPanel.TabIndex = 7;
            this.SettingsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsPanel_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::kursach_client.Properties.Resources.back_icon;
            this.pictureBox2.Location = new System.Drawing.Point(24, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 101;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveSettingsButton.Location = new System.Drawing.Point(80, 336);
            this.saveSettingsButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(274, 76);
            this.saveSettingsButton.TabIndex = 2;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // addressBox
            // 
            this.addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressBox.Location = new System.Drawing.Point(50, 204);
            this.addressBox.Margin = new System.Windows.Forms.Padding(6);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(330, 44);
            this.addressBox.TabIndex = 100;
            this.addressBox.Enter += new System.EventHandler(this.addressBox_Enter);
            this.addressBox.Leave += new System.EventHandler(this.addressBox_Leave);
            // 
            // UrlServer
            // 
            this.UrlServer.AutoSize = true;
            this.UrlServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UrlServer.Location = new System.Drawing.Point(44, 146);
            this.UrlServer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UrlServer.Name = "UrlServer";
            this.UrlServer.Size = new System.Drawing.Size(161, 37);
            this.UrlServer.TabIndex = 1;
            this.UrlServer.Text = "Api-server";
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(422, 470);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(448, 541);
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
            finally
            {
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
            //var registrForm = new RegistrationForm();
            //this.Hide();
            //registrForm.ShowDialog();
            //if (registrForm.DialogResult == DialogResult.OK)
            //{
            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
            //this.Show();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

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

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}