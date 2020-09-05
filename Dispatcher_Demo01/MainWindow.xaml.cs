using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            SyncButtonEventHandlerOperation(Button1Seconds, () => Thread.Sleep(millisecondsTimeout: 1000));
        }

        private void Button3Seconds_Click(object sender, RoutedEventArgs e)
        {
            SyncButtonEventHandlerOperation(Button3Seconds, () => Thread.Sleep(millisecondsTimeout: 3000));
        }

        private void Button5Seconds_Click(object sender, RoutedEventArgs e)
        {
            SyncButtonEventHandlerOperation(Button5Seconds, () => Thread.Sleep(millisecondsTimeout: 5000));
        }


        private void AsyncButton1Seconds_Click(object sender, RoutedEventArgs e)
        {
            AsyncButtonEventHandlerOperation(AsyncButton1Seconds, () => Thread.Sleep(1000));
        }

        private void AsyncButton3Seconds_Click(object sender, RoutedEventArgs e)
        {
            AsyncButtonEventHandlerOperation(AsyncButton3Seconds, () => Thread.Sleep(3000));
        }

        private void AsyncButton5Seconds_Click(object sender, RoutedEventArgs e)
        {
            AsyncButtonEventHandlerOperation(AsyncButton5Seconds, () => Thread.Sleep(5000));
        }

        private void SyncButtonEventHandlerOperation(
            Button button,
            Action buttonOperation)
        {
            var buttonName = button.Name;

            LogBegin(buttonName);
            button.Background = Brushes.Yellow;

            ExecuteButtonOperation(button, buttonOperation);

            LogEnd(buttonName);
            button.Background = Brushes.AliceBlue;
        }

        private async void AsyncButtonEventHandlerOperation(
            Button button,
            Action buttonOperation)
        {
            var buttonName = button.Name;

            LogBegin(buttonName);
            button.Background = Brushes.Yellow;

            await AsyncExecuteButtonOperation(button, buttonOperation);

            LogEnd(buttonName);
            button.Background = Brushes.AliceBlue;
        }


        private void ExecuteButtonOperation(
            Button button,
            Action buttonOperation)
        {
            button.Background = Brushes.Green;
            buttonOperation.Invoke();
        }

        private Task AsyncExecuteButtonOperation(
            Button button,
            Action buttonOperation)
        {
            return Task.Run(() =>
                {
                    button.Dispatcher.Invoke(() => button.Background = Brushes.Green);
                    buttonOperation.Invoke();
                });
        }


        private void LogBegin(string buttonName)
        {
            var timeStamp = GetTimeStamp();
            var eventName = $"\"{buttonName}\" is clicked";
            LogList.Items.Add(timeStamp + " " + eventName);
        }

        private void LogEnd(string buttonName)
        {
            var timeStamp = GetTimeStamp();
            var eventName = $"\"{buttonName}\" completed its operation";
            LogList.Items.Add(timeStamp + " " + eventName);
        }

        private static string GetTimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
