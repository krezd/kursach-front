using kursach_client.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class ControlTrackingSettingsForm : Form
    {
       
        private NumericUpDown sendTimeMin;
        private NumericUpDown scanTimeSec;
        private Button saveButton;
        private LoadData loadData;

        public ControlTrackingSettingsForm()
        {
            loadData = new LoadData();
            loadData.LoadTrackingSettings();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Настройки формы
            this.Text = "Настройки отслеживания";
            this.Size = new Size(300, 200);
            this.Padding = new Padding(10);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Метка для времени отправки данных
            var sendDataLabel = new Label
            {
                Text = "Время отправки данных (в минутах):",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(5)
            };

            // Поле для ввода времени отправки данных
            sendTimeMin = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 1,
                Maximum = 30, 
                Value = Properties.Settings.Default.sendTimeMin, // Значение по умолчанию
                Increment = 1,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            // Метка для времени сканирования
            var scanIntervalLabel = new Label
            {
                Text = "Время сканирования (в секундах):",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            // Поле для ввода времени сканирования
            scanTimeSec = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 1,
                Maximum = 30, 
                Value = Properties.Settings.Default.scanTimeSec, // Значение по умолчанию
                Increment = 1,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            // Кнопка сохранения
            saveButton = new Button
            {
                Text = "Сохранить настройки",
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Height = 40,
                Margin = new Padding(100),
                FlatStyle = FlatStyle.Standard
            };
            saveButton.Click += SaveButton_Click;

            // Добавление элементов на форму
            this.Controls.Add(saveButton);
            this.Controls.Add(scanTimeSec);
            this.Controls.Add(scanIntervalLabel);
            this.Controls.Add(sendTimeMin);
            this.Controls.Add(sendDataLabel);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int sendDataInterval = (int)sendTimeMin.Value;
            int scanInterval = (int)scanTimeSec.Value;
            loadData.UpdateTrackingSettings(sendDataInterval, scanInterval);
            

        }
        private void ControlTrackingSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
