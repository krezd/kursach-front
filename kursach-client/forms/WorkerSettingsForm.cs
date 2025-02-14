using kursach_client.model;
using kursach_client.model.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class WorkerSettingsForm : Form
    {
        private UserResponse user;
        private HttpRequestBuilder _httpRequestBuilder;
        public WorkerSettingsForm(UserResponse userResponse)
        {
            InitializeComponent();
            this.user = userResponse;
            this._httpRequestBuilder = new HttpRequestBuilder();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void WorkerSettingsForm_Load(object sender, EventArgs e)
        {
            SetPlaceholder(); // Устанавливаем placeholder
            saveChangesButton.Focus(); // Устанавливаем фокус на кнопку

        }
        private async Task UpdateUserDataAsync()
        {
            var requestData = new UpdateUserRequest
            {
                name = FIOBox.Text,
                username = LoginBox.Text,
                oldPassword = PasswordBox.Text,
                newPassword = string.IsNullOrWhiteSpace(NewPasBox.Text) ? null : NewPasBox.Text,
                confirmNewPassword = string.IsNullOrWhiteSpace(ConfirmPassBox.Text) ? null : ConfirmPassBox.Text
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Отправляем PUT-запрос на сервер
            var httpRequestBuilder = new HttpRequestBuilder();
            var response = await httpRequestBuilder.SendPutRequestAsync("/api/user/updateByWorker", httpContent);

            // Обработка ответа
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Данные успешно обновлены");
                DialogResult = DialogResult.OK;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Ошибка обновления данных: {error}");
            }
        }
        private void FIOBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FIOBox_Enter(object sender, EventArgs e)
        {
            // Очищаем текст только если он совпадает с user.Name и имеет серый цвет
            if (FIOBox.Text == user.Name && FIOBox.ForeColor == Color.Gray)
            {
                FIOBox.Text = user.Name;
                FIOBox.ForeColor = Color.Black;
            }
        }

        private void FIOBox_Leave(object sender, EventArgs e)
        {
            // Если поле пустое, устанавливаем placeholder
            if (string.IsNullOrWhiteSpace(FIOBox.Text))
            {
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            // Устанавливаем placeholder, если текст пустой
            FIOBox.Text = user.Name;
            FIOBox.ForeColor = Color.Gray;
        }


        private async void saveChangesButton_Click(object sender, EventArgs e)
        {

            if (PasswordBox.Text != "" && LoginBox.Text != "")
            {
                LoginLabel.ForeColor = Color.Black;
                PassLabel.ForeColor = Color.Black;

                try
                {
                    await UpdateUserDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                LoginLabel.ForeColor = Color.Red;
                PassLabel.ForeColor = Color.Red;
            }

        }
    }
}
