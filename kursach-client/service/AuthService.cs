using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.service
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }

    public class RegistrRequest
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string position { get; set; }
        public string role { get; set; }
    }
    public class AuthService
    {
        private readonly HttpClient httpClient;
        public AuthService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Properties.Settings.Default.ServerURL);

        }

        public async Task<bool> Auth(String username, string password) {

            var authRequest = new AuthRequest
            {
                username = username,
                password = password
            };

            var jsonRequest = JsonConvert.SerializeObject(authRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("api/auth", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonResponse);

                    Properties.Settings.Default.Token = authResponse.Token;
                    Properties.Settings.Default.Role = authResponse.Role;
                    Properties.Settings.Default.Save();
                    

                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(errorContent, "Ошибка аутентификации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public async Task<bool> Registr(string fio, string username, string password, string comfirmPas, string position,string role)
        {

            var registrRequest = new RegistrRequest
            {
                name = fio,
                username = username,
                password = password,
                confirmPassword = comfirmPas,
                position = position,
                role = role
            };

            var jsonRequest = JsonConvert.SerializeObject(registrRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("api/register", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(errorContent, "Ошибка аутентификации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
