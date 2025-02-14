using kursach_client.model;
using kursach_client.model.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace kursach_client.forms
{
    public partial class AdminForm : Form
    {

        private bool isLogOut = false;
        private UserResponse user;
        private LoadData loadData;
        private Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox searchNameTextBox;
        private TextBox searchPositionTextBox;
        private DateTimePicker searchDatePicker;
        private Button searchButton;
        private Chart donutChart1;
        private Button updateButton;
        private TimeSpan goodTimeSession;
        private TimeSpan badTimeSession;
        private TimeSpan neutralTimeSession;


        public AdminForm()
        {
            InitializeComponent();
            loadData = new LoadData();
            displayUserData();
            InitializeUI();
        }

        private void InitializeUI()
        {

            this.Resize += (s, e) =>
            {
                logoutButton.Location = new Point(this.ClientSize.Width - logoutButton.Width - 10, 10);
                labelName.Location = new Point(logoutButton.Location.X - labelName.Width - 15, logoutButton.Location.Y);
                SettingsButton.Location = new Point(this.ClientSize.Width - SettingsButton.Width - 10, logoutButton.Height + 15);

                labelPosition.Location = new Point(logoutButton.Location.X - labelPosition.Width - 15, labelName.Location.Y + labelPosition.Height + 5);
                StatusButton.Location = new Point(10, 10);
                userControlButton.Location = new Point(StatusButton.Width + 10, 10);
                trackingSettingsButton.Location = new Point(userControlButton.Location.X + userControlButton.Width, 10);

            };

            int topElementsHeight = SettingsButton.Bottom + 20; // Учитываем высоту кнопок + отступ

            // Основная панель
            mainPanel = new Panel
            {
                Location = new Point(0, topElementsHeight),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - topElementsHeight),
                BackColor = Color.LightGray
            };
            this.Controls.Add(mainPanel);

            // Обновление размеров при изменении размера окна
            this.Resize += (s, e) =>
            {
                mainPanel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - topElementsHeight);
            };

            // TableLayoutPanel
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            TableLayoutPanel tableLayout2 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Строка поиска
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // FlowLayoutPanel занимает оставшееся место
            tableLayout2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // 60% для панели с процессами
            tableLayout2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            
            mainPanel.Controls.Add(tableLayout);

            // FlowLayoutPanel для строки поиска
            FlowLayoutPanel searchPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(15), // Увеличенные внутренние отступы
                WrapContents = true
            };

          
            tableLayout.Controls.Add(searchPanel, 0, 0);
            donutChart1 = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            tableLayout2.Controls.Add(donutChart1, 1, 0);// Первая строка
            // FlowLayoutPanel для отображения сессий
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Width = tableLayout.Width,
                
                AutoScroll = true
            };
            tableLayout2.Controls.Add(flowLayoutPanel, 0, 0);
            tableLayout.Controls.Add(tableLayout2, 0, 1);

            // Поля поиска
            searchNameTextBox = new TextBox
            {
                Text = "Поиск по имени пользователя",
                Width = 250,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                Margin = new Padding(5)
            };

            searchNameTextBox.GotFocus += (s, e) =>
            {
                if (searchNameTextBox.Text == "Поиск по имени пользователя")
                {
                    searchNameTextBox.Text = "";
                    searchNameTextBox.ForeColor = Color.Black;
                    searchNameTextBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            };
            searchNameTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchNameTextBox.Text))
                {
                    searchNameTextBox.Text = "Поиск по имени пользователя";
                    searchNameTextBox.ForeColor = Color.Gray;
                    searchNameTextBox.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
            };

            searchPanel.Controls.Add(searchNameTextBox);

            searchPositionTextBox = new TextBox
            {
                Text = "Поиск по должности пользователя",
                Width = 250,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                Margin = new Padding(5)
            };

            searchPositionTextBox.GotFocus += (s, e) =>
            {
                if (searchPositionTextBox.Text == "Поиск по должности пользователя")
                {
                    searchPositionTextBox.Text = "";
                    searchPositionTextBox.ForeColor = Color.Black;
                    searchPositionTextBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            };
            searchPositionTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchPositionTextBox.Text))
                {
                    searchPositionTextBox.Text = "Поиск по должности пользователя";
                    searchPositionTextBox.ForeColor = Color.Gray;
                    searchPositionTextBox.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
            };

            searchPanel.Controls.Add(searchPositionTextBox);

            FlowLayoutPanel datePanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown, // Располагаем элементы вертикально
                Margin = new Padding(5),
                BackColor = Color.Transparent // Опционально: прозрачный фон
            };

            // CheckBox
            CheckBox dateCheckBox = new CheckBox
            {
                Text = "Поиск по дате",
                AutoSize = true,
                Margin = new Padding(0, -10, 5, 0) // Сдвигаем вверх
            };
            datePanel.Controls.Add(dateCheckBox);

            // DateTimePicker
            DateTimePicker searchDatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 120,
                Enabled = false, // Деактивируем, пока чекбокс не включён
                Margin = new Padding(0, -10, 0, 0) // Сдвигаем вниз
            };
            datePanel.Controls.Add(searchDatePicker);
            searchPanel.Controls.Add(datePanel);

            // Обработчик изменения состояния чекбокса
            dateCheckBox.CheckedChanged += (s, e) =>
            {
                searchDatePicker.Enabled = dateCheckBox.Checked;
            };

            searchButton = new Button
            {
                Text = "Поиск",
                Height = searchNameTextBox.Height,
                Width = 100,
                Margin = new Padding(5)
            };
            searchButton.Click += (s, e) => SearchSessions(dateCheckBox.Checked ? searchDatePicker.Value : (DateTime?)null);
            searchPanel.Controls.Add(searchButton);

            updateButton = new Button
            {
                Text = "Обновить",
                Height = searchNameTextBox.Height,
                Width = 100,
                Margin = new Padding(5)
            };
            updateButton.Click += (s, e) => LoadSessions(null,null, DateTime.Now);
            searchPanel.Controls.Add(updateButton);

            LoadSessions(null,null,DateTime.Now);
        }

        private async void LoadSessions(string name, string position, DateTime? date)
        {
            try
            {
                flowLayoutPanel.SuspendLayout();
                flowLayoutPanel.Controls.Clear();
                goodTimeSession = TimeSpan.Zero;
                badTimeSession = TimeSpan.Zero;
                neutralTimeSession = TimeSpan.Zero;
                var sessions = await loadData.GetSessionsAsync(name, position, date);

                foreach (var session in sessions)
                {
                    goodTimeSession += session.GOOD;
                    badTimeSession += session.BAD;
                    neutralTimeSession += session.NEUTRAL;
                    AddSessionCard(
                        session.User.Name,
                        session.User.Position,
                        session.StartSession,
                        session.EndSession,
                        session.Id,
                        session.GOOD,
                        session.BAD,
                        session.NEUTRAL
                    );
                }
                SetupDonutChart(donutChart1, goodTimeSession, badTimeSession, neutralTimeSession, goodTimeSession + badTimeSession + neutralTimeSession).Wait();

            }
            finally
            {
                flowLayoutPanel.ResumeLayout();
            }
        }

        private void SearchSessions(DateTime? v)
        {
            string name = (string.IsNullOrWhiteSpace(searchNameTextBox.Text) || searchNameTextBox.Text == "Поиск по имени пользователя")
              ? null
              : searchNameTextBox.Text.ToLower();
            string position = (string.IsNullOrWhiteSpace(searchPositionTextBox.Text) || searchPositionTextBox.Text == "Поиск по должности пользователя")
                ? null
                : searchPositionTextBox.Text.ToLower();
            DateTime? date = v;

            LoadSessions(name, position, date);

        }

        private void DisplayProcessesPanel(List<ProcessDTO> processes, string sessionUserName, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            int topElementsHeight = SettingsButton.Bottom + 20; // Учитываем высоту кнопок + отступ


            Panel headerPanel = new Panel
            {
                Location = new Point(0, topElementsHeight+20),
                Height = 40,
                Width = this.Width,
                BackColor = Color.LightGray,
                Padding = new Padding(5)
            };
            this.Controls.Add(headerPanel);

            // Кнопка закрытия
            Button closeButton = new Button
            {
                Text = "✖",
                Width = 30,
                Height = 30,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Left | AnchorStyles.Top, // Закрепляем слева и сверху

                Location = new Point(10, 10) // Позиция в левом верхнем углу
            };
            
            headerPanel.Controls.Add(closeButton);

            // Подпись сессии
            Label sessionLabel = new Label
            {
                Text = $"Сессия пользователя: {sessionUserName}, Начало: {startDate:yyyy-MM-dd HH:mm:ss}, Конец: {(endDate.HasValue ? endDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Не завершена")}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top, // Закрепляем слева и сверху

                Location = new Point(closeButton.Right + 10, 10) // Рядом с кнопкой
            };
            headerPanel.Controls.Add(sessionLabel);
            // Создаем новую панель процессов поверх основной
            Panel processesPanel = new Panel
            {
                Location = new Point(0, topElementsHeight+60),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - topElementsHeight-60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(processesPanel);
            processesPanel.BringToFront();

            closeButton.Click += (s, e) =>
            {
                this.Controls.Remove(headerPanel);
                this.Controls.Remove(processesPanel);
            };

            // TableLayoutPanel для размещения панели с процессами и диаграммы
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.White
            };
           

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // 60% для панели с процессами
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // 40% для диаграммы
            processesPanel.Controls.Add(tableLayout);

            

            

            // FlowLayoutPanel для отображения процессов (левая часть)
            FlowLayoutPanel processesFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            tableLayout.Controls.Add(processesFlowPanel, 0, 0);


            Chart donutChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            tableLayout.Controls.Add(donutChart, 1, 0);

            // Счетчики времени для диаграммы
            TimeSpan goodTime = TimeSpan.Zero;
            TimeSpan badTime = TimeSpan.Zero;
            TimeSpan neutralTime = TimeSpan.Zero;

            foreach (var process in processes)
            {
                // Рассчитать общее время использования процесса
                TimeSpan totalTime = process.usageTimes != null && process.usageTimes.Count > 0
                    ? TimeSpan.FromTicks(process.usageTimes
                        .Sum(usage => (usage.endTime.HasValue ? usage.endTime.Value : DateTime.Now) // Если конец отсутствует, используем текущую дату
                                       .Ticks - usage.startTime.Ticks))
                    : TimeSpan.Zero;

                // Обновляем счетчики для диаграммы
                switch (process.ProcessStatus.status)
                {
                    case "GOOD":
                        goodTime += totalTime;
                        break;
                    case "BAD":
                        badTime += totalTime;
                        break;
                    case "NEUTRAL":
                        neutralTime += totalTime;
                        break;
                }

                // Рассчитываем высоту панели процесса
                int baseHeight = 120; // Базовая высота
                int intervalHeight = 20; // Высота на один интервал
                int processPanelHeight = baseHeight + (process.usageTimes.Count * intervalHeight);

                // Создаем панель процесса
                CustomPanel processPanel = new CustomPanel
                {
                    Width = processesFlowPanel.Width-40,
                    Height = processPanelHeight,
                    Margin = new Padding(10),
                    BorderColor = GetStatusColor(process.ProcessStatus.status),
                    BackColor = Color.White
                };

                // Добавляем информацию о процессе
                Label nameLabel = new Label
                {
                    Text = $"Название: {process.ProcessName}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                processPanel.Controls.Add(nameLabel);

                Label statusLabel = new Label
                {
                    Text = $"Статус: {process.ProcessStatus.status}",
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(10, 35),
                    AutoSize = true
                };
                processPanel.Controls.Add(statusLabel);

                Label timeLabel = new Label
                {
                    Text = $"Общее время: {totalTime:hh\\:mm\\:ss}",
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(10, 60),
                    AutoSize = true
                };
                processPanel.Controls.Add(timeLabel);

                Button deleteButton = new Button
                {
                    Text = "Удалить",
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(processPanel.Width - 100, 10),
                    Size = new Size(90, 30)
                };
                deleteButton.Click += async (s, e) =>
                {
                    var confirmResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить этот процесс?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                            if (await loadData.DeleteProcessAsync(process.Id))
                            {

                                processesFlowPanel.Controls.Remove(processPanel);

                                // Вычитаем время процесса из общего времени
                                switch (process.ProcessStatus.status)
                                {
                                    case "GOOD":
                                        goodTime -= totalTime;
                                        break;
                                    case "BAD":
                                        badTime -= totalTime;
                                        break;
                                    case "NEUTRAL":
                                        neutralTime -= totalTime;
                                        break;
                                }

                                // Перерисовываем диаграмму
                                SetupDonutChart(donutChart, goodTime, badTime, neutralTime, goodTime + badTime + neutralTime).Wait();
                            }
                            
                    }
                }; processPanel.Controls.Add(deleteButton);

                // Добавляем интервалы использования
                int yOffset = 90;
                Label startInterval = new Label
                {
                    Text = $"Интервалы использования:",
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(10, yOffset),
                    AutoSize = true
                };
                processPanel.Controls.Add(startInterval);
                yOffset += intervalHeight;
                int i = 1;
                foreach (var interval in process.usageTimes)
                {
                    Label intervalLabel = new Label
                    {
                        Text = $"{i}: {interval.startTime:HH:mm:ss} - {interval.endTime:HH:mm:ss}",
                        Font = new Font("Segoe UI", 9),
                        Location = new Point(10, yOffset),
                        AutoSize = true
                    };
                    processPanel.Controls.Add(intervalLabel);
                    yOffset += intervalHeight;
                    i++;
                }

                processesFlowPanel.Controls.Add(processPanel);
            }


            // Настройка диаграммы
            SetupDonutChart(donutChart, goodTime, badTime, neutralTime, goodTime + badTime + neutralTime).Wait();
            headerPanel.BringToFront();

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

            //legend.Position = new ElementPosition(10, 40, 80, 10); // (X, Y, Width, Height)

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
            chart.BackColor = Color.Transparent;

        }

        private async void LoadSessionProcesses(Guid sessionId, string sessionUserName, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            try
            {
                var processes = await loadData.GetProcessesBySessionIdAsync(sessionId);

                if (processes != null && processes.Count > 0)
                {
                    
                    DisplayProcessesPanel(processes,sessionUserName,startDate,endDate);
                }
                else
                {
                    MessageBox.Show("Процессы для выбранной сессии не найдены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки процессов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void AddSessionCard(string name, string position, DateTimeOffset startDate, DateTimeOffset? endDate, Guid sessionId, TimeSpan good,TimeSpan bad, TimeSpan neutral)
        {
            CustomPanel sessionCard = new CustomPanel
            {
                Width = flowLayoutPanel.Width - 30,
                Height = 120,
                Dock = DockStyle.Top,
                Margin = new Padding(5),
                BorderColor = Color.LightSeaGreen,
                BackColor = Color.Honeydew,
                BorderSize = 4,
                Tag = sessionId
            };

            sessionCard.Click += (sender, e) =>
            {
                LoadSessionProcesses(sessionId,name,startDate, endDate);
            };

            Label nameLabel = new Label
            {
                Text = $"Имя: {name}",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            sessionCard.Controls.Add(nameLabel);

            Label positionLabel = new Label
            {
                Text = $"Должность: {position}",
                AutoSize = true,
                Location = new Point(10, 30)
            };
            sessionCard.Controls.Add(positionLabel);

            Label dateLabel = new Label
            {
                Text = $"Сессия: {startDate.ToString("yyyy-MM-dd")} - {(endDate.HasValue ? endDate.Value.ToString("yyyy-MM-dd") : "Не завершена")}",
                AutoSize = true,
                Location = new Point(10, 50)
            };
            sessionCard.Controls.Add(dateLabel);

            TimeSpan? duration = null;
            if (endDate.HasValue)
            {
                duration = endDate.Value - startDate;
            }
            Label durationLabel = new Label
            {
                Text = $"Продолжительность: {(duration.HasValue ? duration.Value.ToString(@"hh\:mm\:ss") : "В процессе")}",
                AutoSize = true,
                Location = new Point(10, 70)
            };
            sessionCard.Controls.Add(durationLabel);
            
            Label statusLabel = new Label
            {
                Text = $"GOOD: {good.ToString(@"hh\:mm\:ss")}; BAD: {bad.ToString(@"hh\:mm\:ss")}; NEUTRAL: {neutral.ToString(@"hh\:mm\:ss")}",
                AutoSize = true,
                Location = new Point(10, 90)
            };
            sessionCard.Controls.Add(statusLabel);

            Button deleteButton = new Button
            {
                Text = "Удалить",
                Location = new Point(sessionCard.Width - 80, 10),
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            deleteButton.Click += async (sender, e) =>
            {
                var check = MessageBox.Show(
                                               "Вы уверены, что хотите удалить эту сессию?",
                                               "Подтверждение удаления",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

                if (check == DialogResult.Yes)
                {
                    bool result = await loadData.DeleteSessionByIdAsync(sessionId);
                    if (result)
                    {
                        goodTimeSession -= good;
                        badTimeSession -= bad;
                        neutralTimeSession -= neutral;
                        flowLayoutPanel.Controls.Remove(sessionCard);
                        SetupDonutChart(donutChart1, goodTimeSession, badTimeSession, neutralTimeSession, goodTimeSession + badTimeSession + neutralTimeSession).Wait();

                    }
                }
            };
            sessionCard.Controls.Add(deleteButton);

            flowLayoutPanel.Controls.Add(sessionCard);
        }

       

        public async void displayUserData()
        {
            try
            {
                user = await loadData.getUserData();

                labelName.Text = user.Name;
                labelPosition.Text = user.Position;
                logoutButton.Location = new Point(this.ClientSize.Width - logoutButton.Width - 10, 10);
                labelName.Location = new Point(logoutButton.Location.X - labelName.Width - 15, logoutButton.Location.Y);
                SettingsButton.Location = new Point(this.ClientSize.Width - SettingsButton.Width - 10, logoutButton.Height + 15);

                labelPosition.Location = new Point(logoutButton.Location.X - labelPosition.Width - 15, labelName.Location.Y + labelPosition.Height + 5);
                StatusButton.Location = new Point(10, 10);
                userControlButton.Location = new Point(StatusButton.Width + 10, 10);
                trackingSettingsButton.Location = new Point(userControlButton.Location.X + userControlButton.Width, 10);

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }



        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "GOOD":
                    return Color.FromArgb(46, 204, 113); // Зеленый
                case "BAD":
                    return Color.FromArgb(231, 76, 60); // Красный
                case "NEUTRAL":
                    return Color.FromArgb(149, 165, 166); // Серый
                default:
                    return Color.LightGray; // Цвет по умолчанию
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            isLogOut = true;
            this.Close();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLogOut)
            {
                Application.Exit();
            }
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            AdminProccesStatus adminProccesStatus = new AdminProccesStatus();
            adminProccesStatus.Show();
        }

        private void userControl_Click(object sender, EventArgs e)
        {
            UserControlForm userControlForm = new UserControlForm(user.Id);
            userControlForm.Show();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            WorkerSettingsForm settingsForm = new WorkerSettingsForm(user);
            var dialogResult = settingsForm.ShowDialog(); // Ждем закрытия формы

            // После закрытия формы выполняем запрос на обновление
            if (dialogResult == DialogResult.OK) // Если настройки были изменены и сохранены
            {
                displayUserData();
            }
        }

        private void trackingSettingsButton_Click(object sender, EventArgs e)
        {
            ControlTrackingSettingsForm controlTrackingSettingsForm = new ControlTrackingSettingsForm();
            controlTrackingSettingsForm.Show();
        }
    }
}
