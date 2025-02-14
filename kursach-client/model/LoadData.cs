using kursach_client.model.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using kursach_client.service;
using System.Security.Policy;

namespace kursach_client.model
{
    public class LoadData
    {
        private HttpRequestBuilder _httpRequestBuilder;

        public LoadData()
        {
            _httpRequestBuilder = new HttpRequestBuilder();
        }


        public async Task<UserResponse> getUserData()
        {

            string url = "api/user/getMyUserData";

            var response = await _httpRequestBuilder.SendGetRequestAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<UserResponse>(jsonData);

                return user;
            }
            else
            {
                throw new Exception($"Ошибка получения данных: {response.ReasonPhrase}");
            }
        }

        public async Task<TrackingSettings> LoadTrackingSettings()
        {
            try
            {
                var response = await _httpRequestBuilder.SendGetRequestAsync("api/settings");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var settings = JsonConvert.DeserializeObject<TrackingSettings>(json);

                    Properties.Settings.Default.sendTimeMin = settings.sendTimeMin;
                    Properties.Settings.Default.scanTimeSec = settings.scanTimeSec;
                    Properties.Settings.Default.Save();
                    return settings;
                }
                else
                {
                    MessageBox.Show("Ошибка загрузки настроек трекинга", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Исключение при загрузке настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<TrackingSettings> UpdateTrackingSettings(int sendTimeMin, int scanTimeSec)
        {
            try
            {
                var payload = new
                {
                    sendTimeMin = sendTimeMin,
                    scanTimeSec = scanTimeSec
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");


                var response = await _httpRequestBuilder.SendPutRequestAsync("api/settings", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var settings = JsonConvert.DeserializeObject<TrackingSettings>(json);

                    Properties.Settings.Default.sendTimeMin = settings.sendTimeMin;
                    Properties.Settings.Default.scanTimeSec = settings.scanTimeSec;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Настройки обновлены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return settings;
                }
                else
                {
                    MessageBox.Show("Ошибка обновлении настроек трекинга", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Исключение при обновлении настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<SessionDTO>> GetSessionsByDateAsync(DateTime selectedDate)
        {
            string formattedDate = selectedDate.ToString("yyyy-MM-dd"); // Форматируем дату
            string url = $"api/session/mySessionByDate?date={formattedDate}"; // Добавляем дату в запрос

            try
            {
                var response = await _httpRequestBuilder.SendGetRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var sessions = JsonConvert.DeserializeObject<List<SessionDTO>>(jsonData);
                    return sessions;
                }
                else
                {
                    MessageBox.Show("Ошибка получения данных: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<SessionDTO>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SessionDTO>();
            }
        }

        public async Task<bool> DeleteSessionByIdAsync(Guid sessionId)
        {
            string url = $"api/session/{sessionId}";

            try
            {
                var response = await _httpRequestBuilder.SendDeleteRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ошибка удаления сессии: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public async Task<List<SesssionDtoAdmin>> GetSessionsAsync(string name, string position, DateTime? date)
        {
            string url = "api/session/search?";
            if (!string.IsNullOrEmpty(name))
            {
                url += $"name={Uri.EscapeDataString(name)}&";
            }
            if (!string.IsNullOrEmpty(position))
            {
                url += $"position={Uri.EscapeDataString(position)}&";
            }
            if (date.HasValue)
            {
                url += $"date={date.Value.ToString("yyyy-MM-dd")}";
            }

            try
            {
                var response = await _httpRequestBuilder.SendGetRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var sessions = JsonConvert.DeserializeObject<List<SesssionDtoAdmin>>(jsonData);
                    return sessions;
                }
                else
                {
                    MessageBox.Show("Ошибка получения данных: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<SesssionDtoAdmin>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SesssionDtoAdmin>();
            }
        }



        public async Task<List<SessionDTO>> GetUserSessions()
        {
            string url = "api/session/mySession";

            var response = await _httpRequestBuilder.SendGetRequestAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                // Десериализация в список SessionDTO
                var sessions = JsonConvert.DeserializeObject<List<SessionDTO>>(jsonData);

                return sessions ?? new List<SessionDTO>();
            }
            else
            {
                throw new Exception($"Ошибка получения сессий: {response.ReasonPhrase}");
            }
        }

        public async Task<List<ProcessDTO>> GetProcessesBySessionIdAsync(Guid sessionId)
        {
            var response = await _httpRequestBuilder.SendGetRequestAsync($"api/process/?sessionId={sessionId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProcessDTO>>(json);
            }
            else
            {
                throw new Exception($"Ошибка загрузки процессов: {response.ReasonPhrase}");
            }
        }

        public async Task<List<UserResponse>> GetUsersAsync()
        {
            var response = await _httpRequestBuilder.SendGetRequestAsync($"api/user");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserResponse>>(json);
            }
            else
            {
                throw new Exception($"Ошибка загрузки пользователей: {response.ReasonPhrase}");
            }
        }

        public async Task<List<ProcessStatus>> GetAllProcessStatusesAsync()
        {
            string url = "/api/processStatus/all";

            try
            {
                var response = await _httpRequestBuilder.SendGetRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var processStatuses = JsonConvert.DeserializeObject<List<ProcessStatus>>(jsonData);
                    return processStatuses;
                }
                else
                {
                    MessageBox.Show("Ошибка получения статусов процессов: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<ProcessStatus>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ProcessStatus>();
            }
        }


        public async Task<bool> UpdateProcessStatusAsync(ProcessStatus processStatus)
        {
            string url = "/api/processStatus";


            var jsonPayload = JsonConvert.SerializeObject(processStatus);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpRequestBuilder.SendPutRequestAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ошибка обновления статуса процесса: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<ProcessStatus> CreateProcessStatusAsync(string name, string status)
        {
            string url = "/api/processStatus";

            var payload = new
            {
                name = name,
                status = status
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpRequestBuilder.SendPostRequestAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var createdProcessStatus = JsonConvert.DeserializeObject<ProcessStatus>(jsonResponse);
                    return createdProcessStatus;
                }
                else
                {
                    MessageBox.Show("Ошибка создания статуса процесса: " + response.StatusCode + ": " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<UpdateUserByAdminRequest> UpdateUserAsync(UpdateUserByAdminRequest request)
        {
            string url = "/api/user/updateByAdmin";


            var jsonPayload = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpRequestBuilder.SendPutRequestAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var newUser = JsonConvert.DeserializeObject<UpdateUserByAdminRequest>(jsonResponse);
                    return newUser;
                }
                else
                {
                    MessageBox.Show("Ошибка обновления пользователя: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(long userId)
        {
            string url = $"/api/user/{userId}";

            try
            {
                var response = await _httpRequestBuilder.SendDeleteRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ошибка удаления пользователя: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> DeleteProcessAsync(long processId)
        {
            string url = $"/api/process/{processId}";

            try
            {
                var response = await _httpRequestBuilder.SendDeleteRequestAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ошибка удаления процесса: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //public async Task<bool> DeleteProcessStatusAsync(long processId)
        //{
        //    string url = $"/api/processStatus/{processId}";

        //    try
        //    {
        //        var response = await _httpRequestBuilder.SendDeleteRequestAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Ошибка удаления статуса процесса: " + response.ReasonPhrase, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Исключение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}


    }
}
