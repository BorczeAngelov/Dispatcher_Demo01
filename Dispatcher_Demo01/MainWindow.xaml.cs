using System;
using System.Windows;

namespace Dispatcher_Demo01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1Seconds_Click(object sender, RoutedEventArgs e)
        {
            LogBegin(nameof(Button1Seconds));
        }

        private void Button3Seconds_Click(object sender, RoutedEventArgs e)
        {
            LogBegin(nameof(Button3Seconds));
        }

        private void Button5Seconds_Click(object sender, RoutedEventArgs e)
        {
            LogBegin(nameof(Button5Seconds));
        }

        private void LogBegin(string buttonName)
        {
            var timeStamp = GetTimeStamp();
            var eventName = $"\"{buttonName}\" is clicked";
            LogList.Items.Add(timeStamp + " " + eventName);
        }

        private static string GetTimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
