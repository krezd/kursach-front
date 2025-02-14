using kursach_client.model;
using kursach_client.model.dto;
using kursach_client.service;
using Newtonsoft.Json.Serialization;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace kursach_client.forms
{

    public partial class WorkerForm : Form
    {
        private ProcessActivityTracker _tracker;
        private CancellationTokenSource _cts;
        private bool _isTracking = false;
        private Guid _sessionId;
        private DateTimeOffset _startTime;
        private DateTimeOffset _endTime;
        private SessionService _sessionService;
        private bool isLogOut = false;
        private UserResponse user;
        private List<SessionDTO> sessionDTO;
        private LoadData loadData;
        private DataGridView usageDataGridView;


        public WorkerForm()
        {
            InitializeComponent();
            loadData = new LoadData();
            displayUserData();
            displayUserSessions();
            _sessionService = new SessionService();
            this.Resize += WorkerForm_Resize;
            InitializeUsageDataGridView();
            WorkerForm_Resize(this, EventArgs.Empty);
        }


        private void InitializeUsageDataGridView()
        {
            usageDataGridView = new DataGridView
            {
                Dock = DockStyle.Bottom,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            ConfigureDataGridView(usageDataGridView);
            // Настройка колонок
            usageDataGridView.Columns.Add("StartTime", "Время начала");
            usageDataGridView.Columns.Add("EndTime", "Время окончания");
            usageDataGridView.Columns.Add("Duration", "Длительность");
            usageDataGridView.Visible = false;
            // Добавляем DataGridView на панель процессов
            processPanel.Controls.Add(usageDataGridView);
            usageDataGridView.BringToFront(); // Убедимся, что оно сверху
        }


        public async void displayUserSessions()
        {

            try
            {
                sessionDTO = await loadData.GetUserSessions();
                ConfigureDataGridView(dataGridView1);
                LoadSessionsToGrid(sessionDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public async void displayUserSessionsByDate(DateTime dateTime)
        {

            try
            {
                sessionDTO = await loadData.GetSessionsByDateAsync(dateTime);
                ConfigureDataGridView(dataGridView1);
                LoadSessionsToGrid(sessionDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void ConfigureDataGridView(DataGridView dataGridView)
        {
            // Общие настройки

            dataGridView.BackgroundColor = Color.White; // Светлый фон
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
            dataGridView.Cursor = Cursors.Hand;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250);


            // Стили для строк
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // Основной цвет строк
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255); // Цвет строки при выделении
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Чередование цветов строк
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // Чётные строки

            // Стили для заголовков
            dataGridView.EnableHeadersVisualStyles = false; // Отключение стандартного стиля заголовков
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 250); // Нежный фон заголовков
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Удаление линий сетки между ячейками
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Только горизонтальные линии
            dataGridView.GridColor = Color.FromArgb(220, 220, 220); // Линии разделения строк

            // Отключение заголовков строк (левый столбец)
            dataGridView.RowHeadersVisible = false;

            // Автоматическое растягивание столбцов
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Установка минимальной высоты строки для лучшего отображения
            dataGridView.RowTemplate.Height = 35;

            // Лёгкие отступы в ячейках
            dataGridView.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }

        private void LoadSessionsToGrid(List<SessionDTO> sessions)
        {
            var sessionViews = sessions.Select(session => new
            {
                session.Id,
                StartDate = session.StartSession.ToString("dd.MM.yyyy HH:mm"),

                EndDate = session.EndSession.HasValue
                ? session.EndSession.Value.ToString("dd.MM.yyyy HH:mm")
                : "В процессе",
                Duration = session.EndSession.HasValue
                 ? (session.EndSession.Value - session.StartSession).ToString(@"hh\:mm\:ss")
        : "Не завершено"
            }).ToList();

            dataGridView1.DataSource = sessionViews;

            // Настраиваем видимость столбцов
            dataGridView1.Columns["Id"].Visible = false; // Скрываем колонку с ID
            dataGridView1.Columns["StartDate"].HeaderText = "Начало сессии";
            dataGridView1.Columns["EndDate"].HeaderText = "Окончание сессии";
            dataGridView1.Columns["Duration"].HeaderText = "Продолжительность";
        }

        private void LoadProcessesToGrid(List<ProcessDTO> processes)
        {
            // Формируем данные для отображения в таблице
            var processViews = processes.Select(process => new
            {
                ProcessName = process.ProcessName != "" ? process.ProcessName : "Нет данных",
                Status = process.ProcessStatus.status, // Преобразуем статус в строку
                TimeSpent = process.usageTimes != null && process.usageTimes.Count > 0
                    ? TimeSpan.FromTicks(process.usageTimes
                        .Sum(usage => (usage.endTime.HasValue ? usage.endTime.Value : DateTime.Now) // Если конец отсутствует, используем текущую дату
                                       .Ticks - usage.startTime.Ticks))
                        .ToString(@"hh\:mm\:ss")
                    : "Нет данных",
                UsageTimes = process.usageTimes
            }).ToList();

            // Устанавливаем источник данных для DataGridView
            processDataGrid.DataSource = processViews;
            processDataGrid.ClearSelection();


            processDataGrid.Columns["ProcessName"].HeaderText = "Имя процесса";
            processDataGrid.Columns["Status"].HeaderText = "Статус";
            processDataGrid.Columns["TimeSpent"].HeaderText = "Время в процессе";
            //processDataGrid.Columns["UsageTimes"].Visible = false;


            foreach (DataGridViewRow row in processDataGrid.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                if (status == "GOOD")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
                }
                else if (status == "BAD")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
                }
                else if (status == "NEUTRAL")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(149, 165, 166);
                }
            }

        }

        public async void displayUserData()
        {
            try
            {
                user = await loadData.getUserData();


                labelName.Text = user.Name;
                labelPosition.Text = user.Position;
                logoutButton.Location = new Point(this.ClientSize.Width - logoutButton.Width - 10, 10);
                workerSettingsButton.Location = new Point(this.ClientSize.Width - workerSettingsButton.Width - 10, logoutButton.Height + 15);
                statusButton.Location = new Point(this.ClientSize.Width - statusButton.Width - 6, workerSettingsButton.Height*2 + 10);

                labelName.Location = new Point(logoutButton.Location.X - labelName.Width - 15, logoutButton.Location.Y);
                labelPosition.Location = new Point(logoutButton.Location.X - labelPosition.Width - 15, labelName.Location.Y + labelPosition.Height + 5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
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
            catch (OperationCanceledException) { }
            finally
            {
                _isTracking = false;

            }
        }

        public async Task stopTracking()
        {
            if (_cts != null)
            {

                _cts.Cancel();
                await _tracker.StopTrackingAsync();
                _cts.Dispose();
                _cts = null;
                _tracker = null;
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
                    if (await createSession())
                    {
                        await loadData.LoadTrackingSettings();

                        trackingButton.Text = "Завершить отслеживание";
                        await StartTrackingAsync();
                    }


                }
            }

        private void WorkerForm_Load(object sender, EventArgs e)
        {

        }

        private void WorkerForm_Resize(object sender, EventArgs e)
        {
            processPanel.Height = (int)(this.ClientSize.Height * 2.2 / 3.0);

            processPanel.Dock = DockStyle.Bottom;
        }

        private async Task<bool> createSession()
        {
            _sessionId = Guid.NewGuid();
            _startTime = DateTimeOffset.Now;
            return await _sessionService.CreateSessionAsync(_sessionId, _startTime); ;
        }

        public async Task stopSessionAsync()
        {
            _endTime = DateTimeOffset.Now;
            await _sessionService.StopSessionAsync(_sessionId, _startTime, _endTime);
        }


        private void ShowProcessPanel()
        {

            processPanel.Visible = true;
            processPanel.BringToFront();
        }


        private void WorkerForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (_isTracking)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await _tracker.StopTrackingAsync();
                        await stopSessionAsync();
                    }
                    catch (Exception ex)
                    { }
                    finally
                    {
                        Application.Exit();
                    }
                }).Wait();
            }
            else if (!isLogOut)
            {
                Application.Exit();
            }

        }





        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            if (_isTracking)
            {
                MessageBox.Show("Завершите сессию", "Ошибка завершения сессии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isLogOut = true;
            this.Close();
        }

        private void workerSettingsButton_Click(object sender, EventArgs e)
        {
            WorkerSettingsForm settingsForm = new WorkerSettingsForm(user);
            var dialogResult = settingsForm.ShowDialog(); // Ждем закрытия формы

            // После закрытия формы выполняем запрос на обновление
            if (dialogResult == DialogResult.OK) // Если настройки были изменены и сохранены
            {
                displayUserData();
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void updateSessionButton_Click(object sender, EventArgs e)
        {
            displayUserSessions();
        }

        private void searchByDateButton_Click(object sender, EventArgs e)
        {
            displayUserSessionsByDate(dateTimePicker1.Value);
        }

        private async void LoadProcessesForSession(Guid sessionId)
        {
            try
            {
                // Запрос данных процессов
                var processes = await loadData.GetProcessesBySessionIdAsync(sessionId);

                // Заполняем таблицу процессов
                ConfigureDataGridView(processDataGrid);
                LoadProcessesToGrid(processes);
                var (goodTime, badTime, neutralTime) = await CalculateTimes(processes);
                await SetupDonutChart(chart1, goodTime, badTime, neutralTime, goodTime + badTime + neutralTime);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                Guid sessionId = (Guid)selectedRow.Cells["Id"].Value;


                LoadProcessesForSession(sessionId);

                ShowProcessPanel();
                SessionNameLabel.Text = "Сессия: " + selectedRow.Cells["StartDate"].Value + " - " + selectedRow.Cells["EndDate"].Value;
            }
        }

        private async Task<(TimeSpan goodTime, TimeSpan badTime, TimeSpan neutralTime)> CalculateTimes(List<ProcessDTO> processes)
        {

            // Общее время
            var totalGoodTime = processes
                .Where(p => p.ProcessStatus.status == "GOOD")
                .SelectMany(p => p.usageTimes)
                .Where(usage => usage.endTime != null) // Игнорируем записи с null
                .Aggregate(TimeSpan.Zero, (sum, usage) => sum + (usage.endTime.Value - usage.startTime));

            var totalBadTime = processes
                .Where(p => p.ProcessStatus.status == "BAD")
                .SelectMany(p => p.usageTimes)
                .Where(usage => usage.endTime != null) // Игнорируем записи с null
                .Aggregate(TimeSpan.Zero, (sum, usage) => sum + (usage.endTime.Value - usage.startTime));

            var totalNeutralTime = processes
                .Where(p => p.ProcessStatus.status == "NEUTRAL")
                .SelectMany(p => p.usageTimes)
                .Where(usage => usage.endTime != null) // Игнорируем записи с null
                .Aggregate(TimeSpan.Zero, (sum, usage) => sum + (usage.endTime.Value - usage.startTime));

            return (totalGoodTime, totalBadTime, totalNeutralTime);
        }

        private async Task SetupDonutChart(Chart chart, TimeSpan goodTime, TimeSpan badTime, TimeSpan neutralTime, TimeSpan totalTime)
        {
            // Очищаем старые данные
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            // Настройка области диаграммы
            var chartArea = new ChartArea("DonutArea")
            {
                BackColor = Color.Transparent // Прозрачный фон
            };
            chartArea.Position = new ElementPosition(10, 10, 80, 80);
            chart.ChartAreas.Add(chartArea);

            // Добавление серии для диаграммы
            var series = new Series("TimeUsage")
            {
                ChartType = SeriesChartType.Doughnut, // Тип диаграммы - пончик
                ChartArea = "DonutArea",
                IsValueShownAsLabel = false // Убираем подписи с диаграммы
            };
            series["DoughnutRadius"] = "12"; // Устанавливает ширину пончика

            // Добавление данных
            if (goodTime > TimeSpan.Zero)
            {
                series.Points.AddXY("", goodTime.TotalMinutes);
                series.Points.Last().Color = Color.FromArgb(46, 204, 113);
                series.Points.Last().LegendText = $"Good: {goodTime:hh\\:mm\\:ss}";
            }

            if (badTime > TimeSpan.Zero)
            {
                series.Points.AddXY("", badTime.TotalMinutes);
                series.Points.Last().Color = Color.FromArgb(231, 76, 60);
                series.Points.Last().LegendText = $"Bad: {badTime:hh\\:mm\\:ss}";
            }

            if (neutralTime > TimeSpan.Zero)
            {
                series.Points.AddXY("", neutralTime.TotalMinutes);
                series.Points.Last().Color = Color.FromArgb(149, 165, 166);
                series.Points.Last().LegendText = $"Neutral: {neutralTime:hh\\:mm\\:ss}";
            }

            chart.Series.Add(series);

            // Настройка легенды
            var legend = new Legend("StatusLegend")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                Font = new Font("Segou UI", 10),
                LegendStyle = LegendStyle.Row
            };
            chart.Legends.Add(legend);

            // Добавление общего времени в центре диаграммы
            var title = new Title
            {
                Text = $"Общее время: {totalTime:hh\\:mm\\:ss}",
                Font = new Font("Segou UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Docking = Docking.Top,
                Alignment = ContentAlignment.MiddleCenter
            };
            chart.Titles.Add(title);

            // Дополнительные настройки внешнего вида
            chart.BackColor = Color.White;

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            processPanel.Visible = false;
            usageDataGridView.Visible = false; // Делаем таблицу видимой
        }

        private void processDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedProcess = processDataGrid.Rows[e.RowIndex].DataBoundItem as dynamic;
                var usageTimes = selectedProcess?.UsageTimes;

                if (usageTimes != null)
                {
                    DisplayUsageIntervalsInGrid(usageTimes);
                    usageDataGridView.Visible = true; 

                }
            }
        }

        private void DisplayUsageIntervalsInGrid(List<ProcessUsage> usageTimes)
        {
            // Очищаем DataGridView
            usageDataGridView.Rows.Clear();

            // Добавляем данные интервалов
            foreach (var usage in usageTimes)
            {
                var startTime = usage.startTime.ToString("dd.MM.yyyy HH:mm:ss");
                var endTime = usage.endTime.HasValue ? usage.endTime.Value.ToString("dd.MM.yyyy HH:mm:ss") : "В процессе";
                var duration = usage.endTime.HasValue
                    ? (usage.endTime.Value - usage.startTime).ToString(@"hh\:mm\:ss")
                    : "Не завершено";

                usageDataGridView.Rows.Add(startTime, endTime, duration);
            }
        }


        private void processPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            ProcessStatusForm processFrom = new ProcessStatusForm();
            processFrom.Show();
        }
    }
}
