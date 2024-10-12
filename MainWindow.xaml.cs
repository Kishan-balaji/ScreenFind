using System;
// using System.Collections.Generic;
using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
using System.Windows;
// using System.Windows.Controls;
// using System.Windows.Data;
// using System.Windows.Documents;
// using System.Windows.Input;
// using System.Windows.Media;
// using System.Windows.Media.Imaging;
// using System.Windows.Navigation;
// using System.Windows.Shapes;
using System.Windows.Interop;
using System.Windows.Forms;

namespace ScreenTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    private const int SWP_NOZORDER = 0x0004;
    private const int SWP_FRAMECHANGED = 0x0020;
	private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            OpenOnSmallestMonitor();
        }

        
        private void OpenOnSmallestMonitor()
        {
            var smallestMonitor = Screen.AllScreens.OrderBy(s => s.Bounds.Width * s.Bounds.Height).FirstOrDefault();

            if (smallestMonitor != null)
            {
                MoveToMonitor(smallestMonitor);
            }
        }

        
        private void MoveToLargestMonitor_Click(object sender, RoutedEventArgs e)
        {
            var largestMonitor = Screen.AllScreens.OrderByDescending(s => s.Bounds.Width * s.Bounds.Height).FirstOrDefault();

            if (largestMonitor != null)
            {
                MoveToMonitor(largestMonitor);
            }
        }

        private void MoveToSmallestMonitor_Click(object sender, RoutedEventArgs e)
        {
            OpenOnSmallestMonitor(); 
        }
        private void MoveToMonitor(Screen monitor)
        {
            var handle = new WindowInteropHelper(this).Handle;
            var workingArea = monitor.WorkingArea;  
            SetWindowPos(handle, IntPtr.Zero, workingArea.Left, workingArea.Top,workingArea.Width, workingArea.Height,SWP_NOZORDER | SWP_FRAMECHANGED);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,int X, int Y, int cx, int cy, uint uFlags);
    
    }
}
