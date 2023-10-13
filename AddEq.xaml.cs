using MachinesAndRobotsVKR.Interface;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddEq.xaml
    /// </summary>
    public partial class AddEq : Window
    {

        DB connect = new DB();
        public string _title = "";
        public int _newID = 0;
        public int _id = 0;
        string nameEq = "";
        ~AddEq()
        {
            connect.Close();
        }
        public AddEq()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            Add.Visibility = Visibility.Visible;
            SaveButt.Visibility = Visibility.Hidden;

            ComboInst.ItemsSource = connect.SubdList();
            ComboInst.SelectedIndex = 0;

        }
        DataTable table = new DataTable();
        public AddEq(int id)
        {
            InitializeComponent();
            TitleLabel.Content = "Изменить оборудование";
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Visible;
            _id = id;

            DataTable Equip = new DataTable();
            Equip = connect.EquipmentDB(id);
            DataRow row = Equip.Rows[0];
            nameEq = (string)row["name"];
            NameBox.Text = (string)row["name"];
            ComboInst.ItemsSource = connect.SubdList();
            ComboInst.SelectedIndex = (int)row["idsubdivision"]-1;
            descrBox.Text = (string)row["description"];
            table = connect.ReturnMaterialsTabelsForEq(id);
            dataGridMaterial.ItemsSource = table.DefaultView;
            //dataGridMaterial.Columns[1].IsReadOnly = true;
            //dataGridMaterial.Columns[1].Visibility = Visibility.Collapsed;


            foreach (var column in this.dataGridMaterial.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            dataGridCharect.ItemsSource = connect.ReturnCharacSearch((string)row["name"]).DefaultView;

            foreach (var column in this.dataGridCharect.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
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
            //if (NameBox.Text != "" && descrBox.Text != "" && PathBox.Text != "")
            //{
            //    try
            //    {
            //        connect.AddEqsss(NameBox.Text, descrBox.Text, Convert.ToString(ComboInst.SelectedValue), PathBox.Text, Convert.ToString(lit.SelectedValue), Convert.ToString(vid.SelectedValue), Convert.ToString(mod.SelectedValue));
            //        MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            //        this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}



        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {



        }

        private void AddMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            AddMaterials win = new AddMaterials();
            win.ShowDialog();
            table.Clear();
            table = connect.ReturnMaterialsTabelsForEq(_id);
            dataGridMaterial.ItemsSource = table.DefaultView;
            dataGridMaterial.Columns[0].IsReadOnly = true;
        }

        private void EditMaterialButt_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRow = (DataRowView)dataGridMaterial.SelectedItem;

            int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
            string name = dataRow.Row.ItemArray[1].ToString();
            string path = dataRow.Row.ItemArray[2].ToString();
            string type = dataRow.Row.ItemArray[3].ToString();


            AddMaterials win = new AddMaterials(id, name, path, type, nameEq);
            win.ShowDialog();
            table.Clear();
            table = connect.ReturnMaterialsTabelsForEq(_id);
            dataGridMaterial.ItemsSource = table.DefaultView;
            dataGridMaterial.Columns[0].IsReadOnly = true;
        }
    }
}
