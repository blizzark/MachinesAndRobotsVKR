
using System;
using System.Windows;
using System.Windows.Input;


namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для AddMaterials.xaml
    /// </summary>
    /// 
  
    public partial class AddMaterials : Window
    {
        DB connect = new DB();
        public string _title = "";
        public int _id = 0;
        ~AddMaterials()
        {
            connect.Close();
        }


        public AddMaterials()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            Add.Visibility = Visibility.Visible;
            SaveButt.Visibility = Visibility.Hidden;

            EquipmentCB.ItemsSource = connect.EquipmentList();
            EquipmentCB.SelectedIndex = 0;

            typeMaterialCB.Items.Add("Видеоматериал");
            typeMaterialCB.Items.Add("3D модель");
            typeMaterialCB.Items.Add("Литература");
            typeMaterialCB.Items.Add("Изображение");
            typeMaterialCB.SelectedIndex = 0;
        }

        public AddMaterials(int id, string name, string path, string material_type, string equipment)
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            _id = id;
            NameBox.Text = name;
            PathBox.Text = path;
            Add.Visibility = Visibility.Hidden;
            SaveButt.Visibility = Visibility.Visible;
            EquipmentCB.ItemsSource = connect.EquipmentList();
            typeMaterialCB.Items.Add("Видеоматериал");
            typeMaterialCB.Items.Add("3D модель");
            typeMaterialCB.Items.Add("Литература");
            typeMaterialCB.Items.Add("Изображение");

            typeMaterialCB.SelectedIndex = typeMaterialCB.Items.IndexOf(material_type);
            EquipmentCB.SelectedIndex = EquipmentCB.Items.IndexOf(equipment);


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
            if (NameBox.Text == "" || PathBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                try
                {
                    string nameMaterial = NameBox.Text;
                    string path = PathBox.Text;
                    int typeMaterial = typeMaterialCB.SelectedIndex + 1; // +1 потому что в БД счёт индесков идёт от 1, а в комбобоксе с 0
                    int Equipment = EquipmentCB.SelectedIndex + 1; // тоже самое

                    connect.AddMaterial(nameMaterial, path, typeMaterial, Equipment);

                    MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    connect.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    connect.Close();
                    this.Close();
                }


            }
        }

        private void OpenPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;

                PathBox.Text = filename;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "" || PathBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("Данные будут заменены!", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (res == MessageBoxResult.Yes)
                {
                    string name= NameBox.Text;

                    string path = PathBox.Text;
                    int typeMaterial = connect.GiveTypeMaterialID((string)typeMaterialCB.SelectedValue); // +1 потому что в БД счёт индесков идёт от 1, а в комбобоксе с 0
                    int Equipment = connect.GiveTypeEquipmentID((string)EquipmentCB.SelectedValue); // тоже самое
                    try
                    {
                    
                        connect.UpdateMaterial(_id, name, path, typeMaterial, Equipment);

                        MessageBox.Show("Сохранено!", "Успешное сохранение!", MessageBoxButton.OK, MessageBoxImage.Information);
                        connect.Close();
                        this.Close();
                    }
                    catch (Exception ex) //TODO: наверное, стоит выкидывать наверх исключение..
                    {
                        MessageBox.Show("Что-то пошло не так!\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        connect.Close();
                        this.Close();
                    }
                }

            }
        }
    }
}
