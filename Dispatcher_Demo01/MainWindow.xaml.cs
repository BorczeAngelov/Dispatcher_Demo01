﻿using System;
using System.Threading;
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
            Thread.Sleep(1000);
            LogEnd(nameof(Button1Seconds));
        }

        private void Button3Seconds_Click(object sender, RoutedEventArgs e)
        {
            LogBegin(nameof(Button3Seconds));
            Thread.Sleep(3000);
            LogEnd(nameof(Button3Seconds));
        }

        private void Button5Seconds_Click(object sender, RoutedEventArgs e)
        {
            LogBegin(nameof(Button5Seconds));
            Thread.Sleep(5000);
            LogEnd(nameof(Button5Seconds));
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
