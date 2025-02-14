using kursach_client.model;
using kursach_client.model.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class AdminProccesStatus : Form
    {
        private Dictionary<long, CustomPanel> processPanels = new Dictionary<long, CustomPanel>();
        private LoadData loadData;
        private List<ProcessStatus> processStatus;
        private FlowLayoutPanel processFlowLayout;
        private Button addProcessButton;

        public AdminProccesStatus()
        {
            loadData = new LoadData();

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "Управление статусами процессов";
            this.Size = new Size(500, 500);
            this.Padding = new Padding(10);
            this.BackColor = Color.White;

            // Поле для ввода названия процесса с подсказкой
            var processNameTextBox = new TextBox
            {
                Text = "Введите название процесса",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                Margin = new Padding(0, 0, 0, 10),
                Height = 30
            };
            processNameTextBox.GotFocus += (s, e) =>
            {
                if (processNameTextBox.Text == "Введите название процесса")
                {
                    processNameTextBox.Text = "";
                    processNameTextBox.ForeColor = Color.Black;
                    processNameTextBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            };
            processNameTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(processNameTextBox.Text))
                {
                    processNameTextBox.Text = "Введите название процесса";
                    processNameTextBox.ForeColor = Color.Gray;
                    processNameTextBox.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
            };

            // Выпадающий список для статуса
            var statusComboBox = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(0, 0, 0, 10),
                Height = 30
            };
            statusComboBox.Items.AddRange(new[] { "GOOD", "BAD", "NEUTRAL" });
            statusComboBox.SelectedItem = "NEUTRAL";

            // Кнопка "Добавить"
            addProcessButton = new Button
            {
                Text = "Добавить процесс",
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Standard
            };
            addProcessButton.FlatAppearance.BorderSize = 0;
            addProcessButton.Click += (s, e) => AddProcessButton_Click(processNameTextBox.Text, statusComboBox.SelectedItem.ToString());

            // FlowLayoutPanel для списка процессов
            processFlowLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0),
                BackColor = Color.White
            };

            // Контейнер для полей и кнопки
            var controlsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(240, 240, 240)
            };
            controlsPanel.Controls.Add(addProcessButton);
            controlsPanel.Controls.Add(statusComboBox);
            controlsPanel.Controls.Add(processNameTextBox);

            // Добавляем элементы на форму
            this.Controls.Add(processFlowLayout);
            this.Controls.Add(controlsPanel);

            // Загружаем процессы
            LoadProcesses();
        }

        private async Task LoadProcesses()
        {
            try
            {
                processStatus = await loadData.GetAllProcessStatusesAsync();
                processFlowLayout.Controls.Clear();
                processPanels.Clear();

                foreach (var process in processStatus)
                {
                    var panel = CreateProcessPanel(process);
                    processPanels[process.id] = panel;
                    processFlowLayout.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void DisplayProcesses()
        {
            processFlowLayout.Controls.Clear();

            foreach (var process in processStatus)
            {
                // Создаем панель для процесса
                var panel = new CustomPanel
                {

                    Width = processFlowLayout.Width - 28,
                    Height = 100,
                    BorderColor = GetStatusColor(process.status),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.None,
                    Padding = new Padding(5)
                };

                // Поле для ввода названия процесса
                var processNameTextBox = new Label
                {
                    Text = process.name,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10),
                    Margin = new Padding(10)
                };

                // Выпадающий список для статуса
                var statusComboBox = new ComboBox
                {
                    Dock = DockStyle.Top,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Margin = new Padding(5)
                };
                statusComboBox.Items.AddRange(new[] { "GOOD", "BAD", "NEUTRAL" });
                statusComboBox.SelectedItem = process.status;

                // Кнопка "Сохранить"
                var saveButton = new Button
                {
                    Text = "Сохранить",
                    Dock = DockStyle.Bottom,
                    Height = 30,
                    Margin = new Padding(5)
                };
                saveButton.Click += (s, e) => SaveProcessChanges(process, processNameTextBox.Text, statusComboBox.SelectedItem.ToString());



                // Добавляем элементы на панель
                panel.Controls.Add(saveButton);
                panel.Controls.Add(statusComboBox);
                panel.Controls.Add(processNameTextBox);

                // Добавляем панель в FlowLayoutPanel
                processFlowLayout.Controls.Add(panel);
            }
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
        private async Task AddProcessButton_Click(string name, string status)
        {
            var newProcessStatus = await loadData.CreateProcessStatusAsync(name, status);
            if (newProcessStatus != null)
            {
                AddProcessPanel(newProcessStatus);
            }
        }

        private void AdminProccesStatus_Load(object sender, EventArgs e)
        {

        }

        private CustomPanel CreateProcessPanel(ProcessStatus process)
        {
            var panel = new CustomPanel
            {
                Width = processFlowLayout.Width - 28,
                Height = 100,
                BorderColor = GetStatusColor(process.status),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(5)
            };

            var processNameTextBox = new Label
            {
                Text = process.name,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            var statusComboBox = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(5)
            };
            statusComboBox.Items.AddRange(new[] { "GOOD", "BAD", "NEUTRAL" });
            statusComboBox.SelectedItem = process.status;

            var saveButton = new Button
            {
                Text = "Сохранить",
                Dock = DockStyle.Bottom,
                Height = 30,
                Margin = new Padding(5)
            };
            saveButton.Click += (s, e) => SaveProcessChanges(process, processNameTextBox.Text, statusComboBox.SelectedItem.ToString());

            panel.Controls.Add(saveButton);
            panel.Controls.Add(statusComboBox);
            panel.Controls.Add(processNameTextBox);

            return panel;
        }

        private async Task SaveProcessChanges(ProcessStatus process, string newName, string newStatus)
        {
            process.name = newName;
            process.status = newStatus;

            bool response = await loadData.UpdateProcessStatusAsync(process);

            if (response && processPanels.ContainsKey(process.id))
            {
                var panel = processPanels[process.id];
                UpdateProcessPanel(panel, process);
            }
        }

        private void UpdateProcessPanel(CustomPanel panel, ProcessStatus process)
        {
            // Обновление панели с новым состоянием
            foreach (Control control in panel.Controls)
            {
                if (control is Label processNameLabel)
                {
                    processNameLabel.Text = process.name;
                }
                else if (control is ComboBox statusComboBox)
                {
                    statusComboBox.SelectedItem = process.status;
                }
            }
            panel.BorderColor = GetStatusColor(process.status);
            panel.Invalidate();
        }

        private void AddProcessPanel(ProcessStatus process)
        {
            var panel = CreateProcessPanel(process);
            processPanels[process.id] = panel;
            processFlowLayout.Controls.Add(panel);
        }
    }
}
