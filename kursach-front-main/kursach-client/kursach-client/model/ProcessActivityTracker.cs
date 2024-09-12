using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.model
{
    public class ProcessActivityTracker
    {
        private readonly Dictionary<string, TimeSpan> _processUsageTimes;
        private string _currentProcessName;
        private DateTime _lastActiveTime;
        private System.Threading.Timer _timer;
        private readonly ActiveProcessTracker _activeProcessTracker;
        private HttpRequestBuilder _httpRequestBuilder;
        private Guid _sessionId;

        private bool isServerLive = true;

        public ProcessActivityTracker(Guid sessionId)
        {
            _processUsageTimes = new Dictionary<string, TimeSpan>();
            _activeProcessTracker = new ActiveProcessTracker();
            _httpRequestBuilder = new HttpRequestBuilder();
            _sessionId = sessionId;
        }

        public async Task StartTrackingAsync(CancellationToken cancellationToken)
        {
            _lastActiveTime = DateTime.Now;

            _timer = new System.Threading.Timer(async _ => await SendProcessDataAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            while (!cancellationToken.IsCancellationRequested)
            {
                string activeProcessName = _activeProcessTracker.GetActiveProcessName();

                if (activeProcessName != _currentProcessName)
                {
                    if (_currentProcessName != null)
                    {
                        TimeSpan timeSpent = DateTime.Now - _lastActiveTime;
                        if (_processUsageTimes.ContainsKey(_currentProcessName))
                        {
                            _processUsageTimes[_currentProcessName] += timeSpent;
                        }
                        else
                        {
                            _processUsageTimes[_currentProcessName] = timeSpent;
                        }
                    }

                    _currentProcessName = activeProcessName;
                    _lastActiveTime = DateTime.Now;
                }

                await Task.Delay(1000, cancellationToken); 
            }

            if (_currentProcessName != null)
            {
                TimeSpan timeSpent = DateTime.Now - _lastActiveTime;
                if (_processUsageTimes.ContainsKey(_currentProcessName))
                {
                    _processUsageTimes[_currentProcessName] += timeSpent;
                }
                else
                {
                    _processUsageTimes[_currentProcessName] = timeSpent;
                }
            }
        }
        public async Task StopTrackingAsync()
        {
           _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _timer?.Dispose();
           if(isServerLive) await SendProcessDataAsync();
            isServerLive = true;
        }
        //TODO настроить передачу времени, провера бага с открытием anyDesk, посмотреть почему процессы передаются отрывками (один процесс передается с разными записями в бд)
        private async Task SendProcessDataAsync()
        {
            try
            {
                // Получаем и очищаем данные о процессах
                var processUsageTimes = GetProcessUsageTimes();

                // Сериализуем данные в JSON
                var jsonData = JsonConvert.SerializeObject(processUsageTimes.Select(kvp => new
                {
                    processName = kvp.Key,
                    timeSpend = kvp.Value.TotalSeconds
                }).ToList());

                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpRequestBuilder.SendPostRequestAsync("/api/process/" + _sessionId + "/list", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Данные отравлены на сервер");
                }
                isServerLive = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке данных о процессах: {ex.Message}");
                isServerLive = false;
            }
            
        }

        public Dictionary<string, TimeSpan> GetProcessUsageTimes()
        {
            var currentUsageTimes = new Dictionary<string, TimeSpan>(_processUsageTimes);
            _processUsageTimes.Clear();
            return currentUsageTimes;
        }
    }
}
