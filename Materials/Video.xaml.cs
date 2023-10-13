using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для Video.xaml
    /// </summary>
    public partial class Video : Window
    {
        public Video(string path)
        {
            InitializeComponent();
           
            System.IO.FileInfo fileInf = new System.IO.FileInfo(path);
            if (fileInf.Exists)
            {
                media1.Source = new Uri(path);
            }
            else
            {
                media1.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/video/" + path);
            }
            

            
         
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
