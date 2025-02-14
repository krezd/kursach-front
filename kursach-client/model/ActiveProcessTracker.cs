using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using Interop.UIAutomationClient;
using Interop.UIAutomationCore;
using System.Xml.Linq;

namespace kursach_client.model
{
    public class ActiveProcessTracker
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        const int WM_KEYDOWN = 0x0100;
        const int VK_CONTROL = 0x11;
        const int VK_L = 0x4C;

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
                    /*
                     var addressBar = element.FindFirst(System.Windows.Automation.TreeScope.Descendants,
                                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text));
                     if (addressBar != null && addressBar.TryGetCurrentPattern(ValuePattern.Pattern, out object valuePatternObj))
                     {
                         var valuePattern = (ValuePattern)valuePatternObj;
                         Uri url = new Uri(valuePattern.Current.Value);
                         return url.Host.ToString();
                     }*/

                    return FindUrl(process);
                }
                else
                {
                    string processPath = process.MainModule.FileName;

                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(processPath);
                    string processDescription = fileVersionInfo.FileDescription;

                    return !string.IsNullOrEmpty(processDescription) ? processDescription : process.ProcessName;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string FindUrl(Process process)
        {

            var handle = process.MainWindowHandle;

            var uiaObject = new CUIAutomation();
            var browserElement = uiaObject.ElementFromHandle(handle);

            var controlTypePropertyId = 30003; // UIA_PropertyIds.UIA_ControlTypePropertyId
            var editControlTypeId = 50004; // UIA_ControlTypeIds.UIA_EditControlTypeId

            var editControlypeCondition = uiaObject.CreatePropertyCondition(controlTypePropertyId, editControlTypeId);

            var walker = uiaObject.CreateTreeWalker(editControlypeCondition);
            var urlBar = walker.GetFirstChildElement(browserElement);

            var valuePatternId = 10002; // UIA_PatternIds.UIA_ValuePatternId;
            var valuePattern = urlBar.GetCurrentPattern(valuePatternId) as IUIAutomationValuePattern;

            var uriString = valuePattern?.CurrentValue;
            if (Uri.TryCreate(uriString, new UriKind(), out var uri))
                return uri.Host.ToString();

            return null;
        }
    }
}
