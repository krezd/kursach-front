using kursach_client.model;
using kursach_client.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class WorkerForm : Form
    {
        private ProcessActivityTracker _tracker;
        private CancellationTokenSource _cts;
        private bool _isTracking = false;
        private Guid _sessionId;
        private DateTime _startTime;
        private DateTime _endTime;
        private SessionService _sessionService;

        public WorkerForm()
        {
            InitializeComponent();
           _sessionService = new SessionService();
        }


        private async Task StartTrackingAsync()
        {
            if (_isTracking)
            {
                return;
            }
            
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            _tracker = new ProcessActivityTracker(_sessionId);

            try
            {
                _isTracking = true;
                await _tracker.StartTrackingAsync(token);
            }
            catch (OperationCanceledException){}
            finally
            {
                _isTracking = false;
                _cts.Dispose();
                _tracker = null;
            }
        }

        public async Task stopTracking()
        {
            if (_cts != null)
            {
                await _tracker.StopTrackingAsync();
                _cts.Cancel();
            }
        }

        private async void trackingButton_Click(object sender, EventArgs e)
        {
            if (_isTracking)
            {
                await stopSessionAsync();
                await stopTracking();
                trackingButton.Text = "Начать отслеживание";
            }
            else
            {
                if (await createSession()) {
                    // Начать отслеживание
                    trackingButton.Text = "Завершить отслеживание";
                    await StartTrackingAsync();
                }
               
   
            }
        }
       
        private void WorkerForm_Load(object sender, EventArgs e)
        {

        }

        private async Task<bool> createSession() {
            _sessionId = Guid.NewGuid();
            _startTime = DateTime.Now;
            return await _sessionService.CreateSessionAsync(_sessionId, _startTime); ;
        }

        public async Task stopSessionAsync() {
            _endTime = DateTime.Now;
            await _sessionService.StopSessionAsync(_sessionId, _startTime, _endTime);
        }



        private void WorkerForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
             if (_isTracking)
    {
        // Запуск асинхронной задачи для завершения сессии
        Task.Run(async () =>
        {
            try
            {
                await _tracker.StopTrackingAsync();
                await stopSessionAsync();
            }
            catch (Exception ex)
            {
                // Логирование или обработка исключений
                // Logger.Error(ex, "Ошибка при завершении сессии");
            }
            finally
            {
                // Завершение приложения
                Application.Exit();
            }
        }).Wait(); // Ожидание завершения задачи (может быть опционально, если не мешает пользователю)
    }
        }
    }
}
