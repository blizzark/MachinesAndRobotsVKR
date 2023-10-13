using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using MachinesAndRobotsVKR.Interface;

namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {

        DB connect = new DB();

        ~Authorization()
        {
            connect.Close();
        }
        public Authorization()
        {
            
            InitializeComponent();

            try
            {
               

                List<string> list = new List<string>();
                list = connect.ComboList();

                for (int i = 0; i < list.Count; i++)
                {
                    Combo.Items.Add(list[i]);
                }
                Combo.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }


        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void EnterButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = md5.GetHash(PassBox.Password);
                string role = connect.Auth(Combo.Text, password);
                connect.Close();
              
                if (role == "admin")
                {
                    AdminPanel window = new AdminPanel();
                    this.Hide();
                    window.ShowDialog();
                    this.Close();
                }
                else if (role.Length > 0)
                {
                    NewUserView window = new NewUserView();
                    this.Hide();
                    window.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Время сессии закончилось. Попробуйте ещё раз.", "Ошибка!");
            }

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            connect.Close();
            this.Close();
            
        }
    }
}
