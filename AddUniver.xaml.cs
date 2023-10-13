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
    /// Логика взаимодействия для AddUniver.xaml
    /// </summary>
    public partial class AddUniver : Window
    {
        DB connect = new DB();
        public string _title = "";
        public int _id = 0;
        public string name = "";
        public string password = "";
        public string roleUser = "";

        public AddUniver(int id, string name, string password, string roleUser)
        {
            InitializeComponent();
            TitleLabel.Content = "Изменить пароль";
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            _id = id;
            this.name = name;
            this.password = password;
            this.roleUser = roleUser;
            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Hidden;
            SavePassButt.Visibility = Visibility.Visible;
            TextLabel.Content = "Введите новый пароль:";
        }


        public AddUniver(string names)
        {
            _title = names;
            InitializeComponent();
            TitleLabel.Content = names;
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);

            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
            Add.Visibility = Visibility.Visible;
            SaveButt.Visibility = Visibility.Hidden;
            SavePassButt.Visibility = Visibility.Hidden;
        }

        public AddUniver(string title, int id, string name)
        {
            _title = title;
            InitializeComponent();
            TitleLabel.Content = title;
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            _id = id;
            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Visible;
            SavePassButt.Visibility = Visibility.Hidden;
            NameBox.Text = name;
            

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            connect.Close();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "")
            {
                if (_title == "Добавить учебное заведение")
                {
                    try
                    {
                        connect.AddUniver(NameBox.Text);
                        MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        connect.AddCharac(NameBox.Text);
                        MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Поле не может быть пустым!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "")
            {
                if (_title == "Изменить учебное заведение")
                {
                    try
                    {
                        connect.UpdateUniverRow(_id, NameBox.Text);
                        MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        connect.UpdateListCharacRow(_id, NameBox.Text);
                        MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Поле не может быть пустым!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SavePass_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "")
            {
                md5.password = md5.GetHash(NameBox.Text);
            
                connect.UpdateUserRow(_id, name, md5.password, roleUser);
                MessageBox.Show("Пароль изменён!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
