using kursach_client.model;
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
    public class SessionService
    {

        private readonly HttpRequestBuilder _httpRequestBuilder;
        
        public SessionService()
        {
            _httpRequestBuilder = new HttpRequestBuilder();
        }

        public async Task<bool> CreateSessionAsync(Guid _sessionId, DateTimeOffset startTime)
        {
            // Создание объекта данных сессии
            var sessionData = new SessionRequest
            {
                id = _sessionId,
                startSession = startTime,
                endSession = null
            };

            // Преобразование объекта данных в JSON
            var jsonContent = new StringContent(JsonConvert.SerializeObject(sessionData), Encoding.UTF8, "application/json");

            try
            {
                // Отправка POST-запроса для создания сессии
                var response = await _httpRequestBuilder.SendPostRequestAsync("/api/session", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error creating session. Status code: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occurred: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public async Task StopSessionAsync(Guid _sessionId, DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            var sessionData = new SessionRequest
            {
                id = _sessionId,
                startSession = startTime,
                endSession = stopTime
            };

            
            var jsonContent = new StringContent(JsonConvert.SerializeObject(sessionData), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(sessionData));
            try
            {
                var response = await _httpRequestBuilder.SendPutRequestAsync("/api/session", jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error stoping session. Status code: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occurred: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



    }
}
