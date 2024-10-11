using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenFind
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
        private void NewWindow(object sender, RoutedEventArgs e)
        {
            int width = int.Parse(PromptForInput("Enter window width:"));
            int height = int.Parse(PromptForInput("Enter window height:"));

            var newWindow = new Window
            {
                Width = width,
                Height = height,
                Title = $"New Window (Width: {width}, Height: {height})"
            };
            //newWindow.Loaded += (sender, args) =>
            //{
            //    newWindow.Title = $"New Window (Width: {newWindow.ActualWidth}, Height: {newWindow.ActualHeight})";
            //};
            newWindow.Content = new Label { Content = $"Resoltuion: {width} x {height}", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            // MinimizeAllWindows();
            newWindow.Show();
            MinimizeAllWindows();
        }

        // private void FindSmallest(object sender, RoutedEventArgs e)
        // {
        //     Window? smallestWindow = Application.Current.Windows.Cast<Window>().Where(w => w != this).OrderBy(w => w.ActualWidth * w.ActualHeight).FirstOrDefault();
        //     var otherWindows = Application.Current.Windows.Cast<Window>().Where(w => w != this).ToList();
        //     if (otherWindows.Count == 0)
        //     {
        //         System.Windows.MessageBox.Show("No screens found", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        //         return; 
        //     }
        //     foreach (Window window in Application.Current.Windows)
        //     {
        //         if (window != this && window != smallestWindow)
        //         {
        //             window.Hide();
        //         }
        //     }
        // }

        private void FindSmallest(object sender, RoutedEventArgs e)
        {
        Window? smallestWindow = Application.Current.Windows.Cast<Window>()
                                                        .Where(w => w != this)
                                                        .OrderBy(w => w.ActualWidth * w.ActualHeight)
                                                        .FirstOrDefault();
        var otherWindows = Application.Current.Windows.Cast<Window>()
                                                        .Where(w => w != this)
                                                        .ToList();

        if (otherWindows.Count == 0)
        {
            System.Windows.MessageBox.Show("No screens found", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            return; 
        }

        foreach (Window window in otherWindows)
        {
            // if (window != this)
            // {
            // window.WindowState = WindowState.Minimized;
            // }
        }

        // Bring forth the smallest window (if found)
        if (smallestWindow != null)
        {
            smallestWindow.WindowState = WindowState.Normal;
            smallestWindow.Activate();
        }
        }
        private void MinimizeAllWindows()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this)
                {
                    window.WindowState = WindowState.Minimized;
                }
            }
        }

        private string PromptForInput(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Input", "");
        }
    }
}