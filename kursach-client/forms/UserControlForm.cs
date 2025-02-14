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
using System.Windows.Forms;

namespace kursach_client.forms
{
    public partial class UserControlForm : Form
    {
        
        private LoadData loadData;
        private FlowLayoutPanel userFlowLayout;
        private long userId;
        Dictionary<String, string> roleList = new Dictionary<String, string>() { {"WORKER", "Работник" }, { "ADMIN", "Администратор" } };
        Dictionary<String, string> roleListRevers = new Dictionary<String, string>() { { "Работник", "WORKER" }, { "Администратор", "ADMIN" } };

        public UserControlForm(long userId)
        {
            this.userId = userId;
            loadData = new LoadData();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "Управление пользователями";
            this.Size = new Size(600, 500);
            this.Padding = new Padding(10);
            this.BackColor = Color.White;

            // Кнопка перехода на форму создания пользователя
            var createUserButton = new Button
            {
                Text = "Создать пользователя",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            createUserButton.Click += (s, e) => OpenRegistrationForm();

            // FlowLayoutPanel для списка пользователей
            userFlowLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0),
                BackColor = Color.White
            };

            // Добавляем элементы на форму
            this.Controls.Add(userFlowLayout);
            this.Controls.Add(createUserButton);

            // Загружаем пользователей
            LoadUsers();
        }

        private async void LoadUsers()
        {
            try
            {
                var users = await loadData.GetUsersAsync();
                userFlowLayout.Controls.Clear();

                foreach (var user in users)
                {
                    var panel = CreateUserPanel(user);
                    userFlowLayout.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CustomPanel CreateUserPanel(UserResponse user)
        {
            var panel = new CustomPanel
            {
                Width = userFlowLayout.Width - 40,
                Height = 180,
                BorderColor = GetRoleColor(user.Role),
                Margin = new Padding(10), // Отступы между панелями
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10) // Внутренние отступы в панели
            };

            // Поле для отображения имени пользователя
            var nameLabel = new Label
            {
                Text = $"Имя: {user.Name}",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Margin = new Padding(0, 5, 0, 10),
                AutoSize = true
            };

            // Метка для должности
            var positionTitleLabel = new Label
            {
                Text = "Должность:",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Margin = new Padding(0, 5, 0, 10), // Отступ снизу
                AutoSize = true
            };

            // Поле для редактирования должности
            var positionTextBox = new TextBox
            {
                Text = user.Position,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(0, 5, 0, 10), // Отступ снизу
            };

            // Метка для роли
            var roleTitleLabel = new Label
            {
                Text = "Роль:",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Margin = new Padding(0, 5, 0, 10), // Отступ снизу
                AutoSize = true
            };

            // Выпадающий список для редактирования роли
            var roleComboBox = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                 Margin = new Padding(0, 5, 0, 10), // Отступ снизу
                Enabled = user.Id != userId // Отключаем редактирование, если это текущий пользователь
            };
            roleComboBox.Items.AddRange(new[] { "Администратор", "Работник" });
            roleComboBox.SelectedItem = roleList[user.Role];

            // Кнопка сохранения изменений
            var saveButton = new Button
            {
                Text = "Сохранить",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Margin = new Padding(5)
            };
            saveButton.Click += async (s, e) =>
            {
                user.Position = positionTextBox.Text;
                user.Role = roleListRevers[roleComboBox.SelectedItem.ToString()];
                await SaveUserChanges(user);
                panel.BorderColor = GetRoleColor(user.Role);
                panel.Invalidate();
            };

            // Кнопка удаления пользователя
            var deleteButton = new Button
            {
                Text = "Удалить",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Margin = new Padding(5),
                Enabled = user.Id != userId // Отключаем удаление, если это текущий пользователь
            };
            deleteButton.Click += async (s, e) =>
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {user.Name}?", "Подтверждение удаления",
      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    await DeleteUser(user);
                    userFlowLayout.Controls.Remove(panel);
                }
            };

            // Добавляем элементы в панель в правильном порядке
            panel.Controls.Add(saveButton);
            panel.Controls.Add(deleteButton);
            panel.Controls.Add(roleComboBox);
            panel.Controls.Add(roleTitleLabel);
            panel.Controls.Add(positionTextBox);
            panel.Controls.Add(positionTitleLabel);
            panel.Controls.Add(nameLabel);

            return panel;
        }

        private Color GetRoleColor(string role)
        {
            return role == "ADMIN" ? Color.Red : Color.Blue;
        }

        private async Task SaveUserChanges(UserResponse user)
        {
            try
            {
                UpdateUserByAdminRequest response = await loadData.UpdateUserAsync(new UpdateUserByAdminRequest(user.Id, user.Position, user.Role));
                if (response != null)
                {
                    
                    MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения изменений!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteUser(UserResponse user)
        {
            try
            {
                var response = await loadData.DeleteUserAsync(user.Id);
                if (response)
                {
                    MessageBox.Show("Пользователь удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка удаления пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenRegistrationForm()
        {
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            LoadUsers(); // Обновить список пользователей после создания нового
        }

        private void UserControlForm_Load(object sender, EventArgs e)
        {

        }
    }
    
    
}
