using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using  System.Windows.Forms.Integration;
using System.Windows.Interop;
using Gecko;
using Gecko.Interop;

namespace GeckoBrowserWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint flags);

        public MainWindow()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize("Firefox");            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            GeckoWebBrowser browser = new GeckoWebBrowser();
            host.Child = browser;
            GridWeb.Children.Add(host);
            browser.Navigate("http://46.27.80.41/sistematurnos/terminal/Terminal-1");
            //Process p = new Process();            
            //p = Process.Start("chrome.exe");            
            //SetWindowPos(p.MainWindowHandle, new IntPtr(-1), 0, 0, 0, 0, 0x0002 | 0x0001);                        
        }
    }
}
