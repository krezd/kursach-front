using kursach_client.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.service
{
    public class ProcessService
    {
        private System.Threading.Timer _timer;
        private readonly HttpRequestBuilder _httpRequestBuilder;
        private ProcessActivityTracker _tracker;
        private Guid _guid;


        public ProcessService( ProcessActivityTracker tracker, Guid guid)
        {
            _httpRequestBuilder = new HttpRequestBuilder();
            _tracker = tracker;
            _guid = guid;
        }


        public async Task StartAsync()
        {
            _timer = new System.Threading.Timer(async _ => await SendProcessDataAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        public void Stop()
        {
            _timer?.Dispose();
        }

        private async Task SendProcessDataAsync()
        {
            try
            {
                // Получаем и очищаем данные о процессах
                var processUsageTimes = _tracker.GetProcessUsageTimes();

                // Сериализуем данные в JSON
                var jsonData = JsonConvert.SerializeObject(processUsageTimes.Select(kvp => new
                {
                    processName = kvp.Key,
                    timeSpend = kvp.Value.TotalSeconds 
                }).ToList());

                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpRequestBuilder.SendPostRequestAsync("/api/process/"+_guid+"/list", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ошибка отправки данных о процессах на сервер.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке данных о процессах: {ex.Message}");
            }
        }
    }
}
