using System;
using System.Windows;


namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для Literature.xaml
    /// </summary>
    public partial class Literature : Window
    {
        public Literature(string fileName)
        {
            InitializeComponent();


            System.IO.FileInfo fileInf = new System.IO.FileInfo(fileName);
            if (fileInf.Exists)
            {
                var uri = new Uri(fileName);
                web.Navigate(uri);
            }
            else
            {
                var uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "literature/" + fileName);
                web.Navigate(uri);
            }
         

           
        }

    }
}
