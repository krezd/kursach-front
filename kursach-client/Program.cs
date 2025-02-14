using kursach_client.model;
using kursach_client.service;
using kursach_client.forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_client
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (true)
            {
                if (Auth())
                {
                    if (Properties.Settings.Default.Role.ToString() == "WORKER") {
                        Application.Run(new WorkerForm());
                    }


                    if (Properties.Settings.Default.Role.ToString() == "ADMIN")
                    {
                        Application.Run(new AdminForm());
                    }

                    if (Properties.Settings.Default.Token.ToString() != "")
                    {
                        HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri(Properties.Settings.Default.ServerURL);
                        signOut(httpClient);
                    }
                }
                else
                {
                    break;
                }
            }


        }
        static bool Auth()
        {
            var authService = new AuthService();
            var dialog = new AuthForm(authService);
            dialog.ShowDialog();
            return dialog.DialogResult == DialogResult.OK;
        }

        static async void signOut(HttpClient httpClient)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/signout");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.Token);

            HttpResponseMessage response = await httpClient.SendAsync(request);

            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.Save();
        }

    }
}
