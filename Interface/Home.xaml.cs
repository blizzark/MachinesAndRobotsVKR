using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MachinesAndRobotsVKR.Interface
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            var uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "home.htm");
            WebBrowser.Navigate(uri);
            WebBrowser.ScriptErrorsSuppressed = true;
        }
    }
}
