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
using System.Data;
using MachinesAndRobotsVKR.Interface;

namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        public AdminPanel()
        {
            InitializeComponent();

            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);

        }
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Mini(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Minimized;

            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Данный программый комплекс разработал:\nСтудент СПбГТИ(ТУ): Роман Сергеевич Овчинников", "Информация о разработчике");
        }
        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            Authorization window = new Authorization();
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void SearchRB_Checked(object sender, RoutedEventArgs e)
        {
            ViewControl.Children.Clear();
            Search Sr = new Search();
            ViewControl.Children.Add(Sr);
        }

        private void ModelRB_Checked(object sender, RoutedEventArgs e)
        {
            ViewControl.Children.Clear();
            ListLine LL = new ListLine();
            ViewControl.Children.Add(LL);
        }

        private void HomeRB_Checked(object sender, RoutedEventArgs e)
        {
            ViewControl.Children.Clear();
            Home HH = new Home();
            ViewControl.Children.Add(HH);
        }
        private void EditDBRB_Checked(object sender, RoutedEventArgs e)
        {
            ViewControl.Children.Clear();
            EditDB win = new EditDB();
            ViewControl.Children.Add(win);
        }

        private void EquipRB_Checked(object sender, EventArgs e)
        {
            ViewControl.Children.Clear();
            Equipments Eq = new Equipments();
            ViewControl.Children.Add(Eq);

        }
    }
}
