using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace kursach_client.model
{
    public class ActiveProcessTracker
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
  
        public string GetActiveProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();
            GetWindowThreadProcessId(hwnd, out uint processId);

            try
            {
                Process process = Process.GetProcessById((int)processId);
                if (process.ProcessName == "msedge" || process.ProcessName == "chrome" || process.ProcessName == "firefox"
                    || process.ProcessName == "yandex"
                )
                {
                    AutomationElement element = AutomationElement.FromHandle(hwnd);
                    var children = element.FindAll(TreeScope.Descendants, Condition.TrueCondition);
           

                    foreach (AutomationElement child in children)
                    {
                        if (child.Current.ControlType == ControlType.Edit)
                        {
                            Uri url = new Uri(((ValuePattern)child.GetCurrentPattern(ValuePattern.Pattern)).Current.Value);
                            return url.Host.ToString();
                        }
                    }
                    element = null;
                    
                }
                else
                {
                    string processPath = process.MainModule.FileName;

                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(processPath);
                    string processDescription = fileVersionInfo.FileDescription;

                    // Если описание доступно, возвращаем его, иначе возвращаем стандартное имя процесса
                    return !string.IsNullOrEmpty(processDescription) ? processDescription : process.ProcessName;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
