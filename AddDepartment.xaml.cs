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
    public partial class AddDepartment : Window
    {
        DB connect = new DB();
        public string _title = "";
        public int _id = 0;
        public string name = "";
        public string password = "";
        public string roleUser = "";


        public AddDepartment()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);

            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
            Add.Visibility = Visibility.Visible;
            SaveButt.Visibility = Visibility.Hidden;

            CBinst.ItemsSource = connect.InstitutionList();

            if (CBinst.Items.Count > 0)
                CBinst.SelectedIndex = 0;
        }

        public AddDepartment(int id, string name)
        {

            InitializeComponent();

            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            _id = id;
            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Visible;
            NameBox.Text = name;
            CBinst.ItemsSource = connect.InstitutionList();

            if (CBinst.Items.Count > 0)
                CBinst.SelectedIndex = connect.GiveIdInst(id)-1;


           
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
                connect.AddSubd(NameBox.Text, (int)CBinst.SelectedIndex + 1);
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
                    if (NameBox.Text != "")
                    {
                        connect.UpdateSubdRow(_id, NameBox.Text, (int)CBinst.SelectedIndex + 1);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            else
            {
                MessageBox.Show("Поле не может быть пустым!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
