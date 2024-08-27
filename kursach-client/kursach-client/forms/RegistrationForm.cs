using kursach_client.service;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class RegistrationForm : Form
    {
        private readonly AuthService authService;

        public RegistrationForm(AuthService authService)
        {
            InitializeComponent();
            this.authService = authService;
            DialogResult = DialogResult.None;
            RoleBox.SelectedIndex = 2;
            RoleBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task RegistrIn()
        {
            var FIO = FIOBox.Text;
            var login = LoginBox.Text;
            var password = PasswordBox.Text;
            var comfirmPassword = ConfirmPasBox.Text;
            var position = PositionBox.Text;
            var role = RoleBox.Text;

            if (!(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)|| string.IsNullOrEmpty(FIO)|| string.IsNullOrEmpty(comfirmPassword) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(role)))
            {

                if (password.Equals(comfirmPassword))
                {
                    var result = authService.Registr(FIO, login, password, comfirmPassword, position, role);

                    if (await result)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else {
                    MessageBox.Show("Пароли не совпадают", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
 
        }

        private async void RegistrationButton_Click(object sender, EventArgs e)
        {
            await RegistrIn();
        }

        private async void PasswordTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await RegistrIn();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      
       
    }
}
