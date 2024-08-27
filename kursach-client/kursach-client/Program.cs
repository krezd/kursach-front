using kursach_client.model;
using kursach_client.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Auth())
                Application.Run(new UserForm());

        }
        static bool Auth()
        {
            var authService = new AuthService();
            var dialog = new AuthForm(authService);
            dialog.ShowDialog();
            return dialog.DialogResult == DialogResult.OK;
        }

    }
}
