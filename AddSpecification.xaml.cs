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
    /// Логика взаимодействия для AddSpecification.xaml
    /// </summary>
    public partial class AddSpecification : Window
    {
        DB connect = new DB();
        public string _title = "";
        public int _newID = 0;
        public int _id = 0;
        ~AddSpecification()
        {
            connect.Close();
        }
        public AddSpecification()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            List<string> listEquipment = new List<string>();
            listEquipment = connect.EquipmentList();

            for (int i = 0; i < listEquipment.Count; i++)
            {
                Equipment.Items.Add(listEquipment[i]);

            }
            Equipment.SelectedIndex = 0;


            List<string> listChar= new List<string>();
            listChar = connect.ComboListCharac();
         
            for (int i = 0; i < listChar.Count; i++)
            {
                characList.Items.Add(listChar[i]);
            }
            characList.SelectedIndex = 0;

            Add.Visibility = Visibility.Visible;
            SaveButt.Visibility = Visibility.Hidden;

        }

        public AddSpecification(int id, string eq, string ch, string val, string unit)
        {
            InitializeComponent();
            TitleLabel.Content = "Изменить характеристики";
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            List<string> listEquipment = new List<string>();
            listEquipment = connect.EquipmentList();
            _id = id;
            for (int i = 0; i < listEquipment.Count; i++)
            {
                Equipment.Items.Add(listEquipment[i]);

            }
          


            List<string> listChar = new List<string>();
            listChar = connect.ComboListCharac();

            for (int i = 0; i < listChar.Count; i++)
            {
                characList.Items.Add(listChar[i]);
            }
        
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Visible;

            int indexEQ = Equipment.Items.IndexOf(eq);
            int indexCH = characList.Items.IndexOf(ch);
            NameBox.Text = val;
            UnitBox.Text = unit;
            Equipment.SelectedIndex = indexEQ;
            characList.SelectedIndex = indexCH;
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
            if (NameBox.Text != "")
            {
                try
                {
                    connect.AddCharacAndEq(Convert.ToString(Equipment.SelectedValue), Convert.ToString(characList.SelectedValue), NameBox.Text, UnitBox.Text);
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
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

          
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (NameBox.Text != "")
            {
                try
                {
                    connect.UpdateCharacEQRow(_id, Convert.ToString(Equipment.SelectedValue), Convert.ToString(characList.SelectedValue), NameBox.Text, UnitBox.Text);
                    MessageBox.Show("Сохранено!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
