using System.Linq;
using System.Windows;
using System.Windows.Forms; 

namespace ScreenTest
{
    public partial class MainWindow : Window
    {
        private Screen smallestScreen;
        private Screen largestScreen;

        public MainWindow()
        {
            InitializeComponent();

            Screen[] screens = Screen.AllScreens;
            smallestScreen = screens.OrderBy(s => s.Bounds.Width * s.Bounds.Height).First();
            largestScreen = screens.OrderByDescending(s => s.Bounds.Width * s.Bounds.Height).First();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowOnScreen(smallestScreen);
        }

        private void SetWindowOnScreen(Screen screen)
        {
            this.WindowState = WindowState.Normal;
            this.Left = screen.Bounds.Left;
            this.Top = screen.Bounds.Top;
            this.Width = screen.Bounds.Width;
            this.Height = screen.Bounds.Height;
            this.WindowState = WindowState.Maximized;
        }

        private void btnMoveSmallest_Click(object sender, RoutedEventArgs e)
        {
            SetWindowOnScreen(smallestScreen);
        }

        private void btnMoveLargest_Click(object sender, RoutedEventArgs e)
        {
            SetWindowOnScreen(largestScreen);
        }
    }
}
