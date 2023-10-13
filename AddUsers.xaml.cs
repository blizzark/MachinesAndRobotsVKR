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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        DB connect = new DB();
        public string _title = "";
        public int _newID = 0;
        public int _id = 0;
        public string name = "";
        public string password = "";
        public string roleUser = "";
        ~AddUsers()
        {
            connect.Close();
        }
        public AddUsers()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            role.Items.Add("admin");
            role.Items.Add("user");
            role.SelectedIndex = 0;
            Add.Visibility = Visibility.Visible;
            EditButt.Visibility = Visibility.Hidden;
            pass.Width = 467;
            EditPassButt.Visibility = Visibility.Hidden;
            pass.IsReadOnly = false;
        }

        public AddUsers(int id, string name, string password, string roleUser)
        {
            InitializeComponent();
            pass.IsReadOnly = true;
            TitleLabel.Content = "Изменить пользователя";
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            _id = id;
            role.Items.Add("admin");
            role.Items.Add("user");
            log.Text = name;
            pass.Text = password;
            if(roleUser == "admin")
            {
                role.SelectedIndex = 0;
            }
            else{
                role.SelectedIndex = 1;
            }
            _id = id;
            this.name = name;
            this.password = password;
            this.roleUser = roleUser;
            Add.Visibility = Visibility.Hidden;
            EditButt.Visibility = Visibility.Visible;
            pass.Width = 330;
            EditPassButt.Visibility = Visibility.Visible;
         
        }


        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            connect.Close();
            this.Close();
        }

        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(log.Text != "" && pass.Text != "" && role.Text != "")
            {

                string password = md5.GetHash(pass.Text);

                connect.AddPerson(log.Text, password, role.Text);
                MessageBox.Show("Пользователь добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
         
            if (log.Text != "" && pass.Text != "" && role.Text != "")
            {
                connect.UpdateUserRow(_id, log.Text, pass.Text, role.Text);
                MessageBox.Show("Пользователь изменён!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditPass_Click(object sender, RoutedEventArgs e)
        {
            md5.password = pass.Text;
            AddUniver win = new AddUniver(_id, name, password,  roleUser);
            this.Hide();
            win.ShowDialog();
            this.Show();
            pass.Text = md5.password;

        }
    }
}