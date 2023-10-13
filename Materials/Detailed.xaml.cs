using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Data;
using System.Windows.Controls;

namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Логика взаимодействия для Detailed.xaml
    /// </summary>
    public partial class Detailed : Window
    {
        public string equipment = "";
        DB connect = new DB();
        DataTable tableCharacterictic = new DataTable();
        DataTable tableLitra = new DataTable();
        DataTable tableVideo = new DataTable();
        DataTable tableModel = new DataTable();
        DataTable listImage;
        private int NumberImageSelected = 0;
        private int MaxNumberImage = 0;
     
        ~Detailed()
        {
            connect.Close();
        }
        public Detailed(string Equipment)
        {

            InitializeComponent();
            this.equipment = Equipment;
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            EquipmentLabelName.Content = Equipment;
            tableCharacterictic.Clear();

            tableCharacterictic = connect.ReturnCharacSearch(Equipment);

            GridCharacter.ItemsSource = tableCharacterictic.DefaultView;


            foreach (var column in this.GridCharacter.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

            listImage = new DataTable();
            listImage = connect.MaterialsEquipment(Equipment, "Изображение");
            if (listImage.Rows.Count > 0)
            {
                NumberImageSelected = 0;
                DataRow row = listImage.Rows[NumberImageSelected];
                MaxNumberImage = listImage.Rows.Count;
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("images/" + row[0], UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                img.Source = src;
                img.Stretch = Stretch.Uniform;

            }


            tableLitra = connect.MaterialsEquipment(equipment, "Литература");
            tableVideo = connect.MaterialsEquipment(equipment, "Видеоматериал");
            tableModel = connect.MaterialsEquipment(equipment, "3D модель");

            for (int i = 0; i < tableLitra.Rows.Count; i++)
            {
                DataRow row = tableLitra.Rows[i];
                ComboLitra.Items.Add(row[1]);
            }
            for (int i = 0; i < tableVideo.Rows.Count; i++)
            {
                DataRow row = tableVideo.Rows[i];
                ComboVideo.Items.Add(row[1]);
            }
            for (int i = 0; i < tableModel.Rows.Count; i++)
            {
                DataRow row = tableModel.Rows[i];
                ComboModel.Items.Add(row[1]);
            }
            if (ComboLitra.Items.Count > 0)
                ComboLitra.SelectedIndex = 0;
            if (ComboVideo.Items.Count > 0)
                ComboVideo.SelectedIndex = 0;
            if (ComboModel.Items.Count > 0)
                ComboModel.SelectedIndex = 0;

        }

        private void GridCharacter_Loaded(object sender, RoutedEventArgs e)
        {
           
            
          
        }
        private void NextButt_Click(object sender, RoutedEventArgs e)
        {
            if (listImage.Rows.Count > 0 && NumberImageSelected < MaxNumberImage - 1)
            {
                NumberImageSelected++;
                DataRow row = listImage.Rows[NumberImageSelected];
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("images/" + row[0], UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                img.Source = src;
                img.Stretch = Stretch.Uniform;
            }
        }

        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            if (listImage.Rows.Count > 0 && NumberImageSelected > 0)
            {
                NumberImageSelected--;
                DataRow row = listImage.Rows[NumberImageSelected];
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("images/" + row[0], UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                img.Source = src;
                img.Stretch = Stretch.Uniform;
            }
        }
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
  
            this.Close();
        }
        class MyClass
        {
            public string First { get; set; }

            public string Second { get; set; }
        }
        private void VideoButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboVideo.Items.Count > 0)
                {
                    DataRow row = tableVideo.Rows[ComboVideo.SelectedIndex];
                    Video VV = new Video(Convert.ToString(row[0]));
                    VV.ShowDialog();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные отсутствуют", "Ошибка!");

            }
        }

        private void LiteratureButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboLitra.Items.Count > 0)
                {
                    DataRow row = tableLitra.Rows[ComboLitra.SelectedIndex];
                    Literature Lit = new Literature(Convert.ToString(row[0]));
                    Lit.ShowDialog();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные отсутствуют", "Ошибка!");

            }

        }

        private void ModelButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboModel.Items.Count > 0)
                {
                    DataRow row = tableModel.Rows[ComboModel.SelectedIndex];
                    Model3d MD = new Model3d(Convert.ToString(row[0]));
                    MD.ShowDialog();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные отсутствуют", "Ошибка!");

            }


        }
    }
}
