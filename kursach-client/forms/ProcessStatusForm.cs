using kursach_client.model;
using kursach_client.model.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ProcessStatus = kursach_client.model.dto.ProcessStatus;

namespace kursach_client.forms
{
    public partial class ProcessStatusForm : Form
    {
        private LoadData loadData;
        private List<ProcessStatus> processStatus;

        public ProcessStatusForm()
        {
            loadData = new LoadData();
            InitializeComponent();
            loadProcessStatus();
        }

        private async Task loadProcessStatus() {
            try
            {
                processStatus = await loadData.GetAllProcessStatusesAsync();
                DisplayProcessStatuses(processStatus);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessStatusForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayProcessStatuses(List<ProcessStatus> processes)
        {
            // Очищаем FlowLayoutPanel
            statusFlowLayout.Controls.Clear();

            foreach (var process in processes)
            {
                // Создаем панель для отображения статуса
                var panel = new Panel
                {
                    Width = statusFlowLayout.Width - 25, // Учитываем прокрутку
                    Height = 50,
                    Margin = new Padding(5),
                    BackColor = GetStatusColor(process.status) // Цвет панели в зависимости от статуса
                };

                // Добавляем текстовое описание на панель
                // Добавляем текстовое описание на панель
                var label = new Label
                {
                    Text = $"{process.name}",
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
        
                    Padding = new Padding(10),
                    MaximumSize = new Size(panel.Width - 20, 0), // Ограничиваем ширину текста
                    AutoEllipsis = false // Убираем многоточие
        };

                label.TextAlign = ContentAlignment.MiddleLeft; // Выравнивание текста по левому краю
                label.AutoSize = true; // Позволяем высоте увеличиваться автоматически

                panel.Controls.Add(label);

                // Добавляем панель в FlowLayoutPanel
                statusFlowLayout.Controls.Add(panel);
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
    }
}
