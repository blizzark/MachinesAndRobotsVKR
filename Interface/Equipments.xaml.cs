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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace MachinesAndRobotsVKR.Interface
{
    /// <summary>
    /// Логика взаимодействия для Equipments.xaml
    /// </summary>
    /// 
  

    public partial class Equipments : UserControl
    {
        DB connect = new DB();
        DataTable  listImage;
        private int NumberImageSelected = 0;
        private int MaxNumberImage = 0;
        public Equipments()
        {
            InitializeComponent();

            List<string> listInstitution = new List<string>();
            listInstitution = connect.InstitutionList();
            for (int i = 0; i < listInstitution.Count; i++)
            {
                ComboInst.Items.Add(listInstitution[i]);
            }
            if (ComboInst.Items.Count > 0)
                ComboInst.SelectedIndex = 0;

            List<string> listCharacts = new List<string>();
            listCharacts = connect.CharactsDB();
        }

        private void ComboInst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSubd.Items.Clear();
            List<string> listSubd = new List<string>();
            listSubd = connect.SubdivisionList(Convert.ToString(ComboInst.SelectedValue));
            for (int i = 0; i < listSubd.Count; i++)
            {
                ComboSubd.Items.Add(listSubd[i]);
            }
            if (ComboSubd.Items.Count > 0)
                ComboSubd.SelectedIndex = 0;
            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaxNumberImage = 0;
            if (listBox.SelectedIndex >= 0)
            {
                descBox.Text = connect.Description(Convert.ToString(listBox.SelectedValue));
                try
                {
                    listImage = new DataTable(); ;
                    listImage = connect.MaterialsEquipment(Convert.ToString(listBox.SelectedValue), "Изображение");
                    if (listImage.Rows.Count > 0) {
                        NumberImageSelected = 0;
                        DataRow row = listImage.Rows[0];
                        MaxNumberImage = listImage.Rows.Count;
                        BitmapImage src = new BitmapImage();
                        src.BeginInit();
                        src.UriSource = new Uri("images/" + row[0], UriKind.Relative);
                        src.CacheOption = BitmapCacheOption.OnLoad;
                        src.EndInit();
                        img.Source = src;
                        img.Stretch = Stretch.Uniform;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Картинка оборудования не найдена!", "Внимание!");
                }
            }
        }

        private void ComboSubd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Items.Clear();

            List<string> listEquipment = new List<string>();
            listEquipment = connect.EquipmentList(Convert.ToString(ComboSubd.SelectedValue));
            if (listEquipment.Count > 0)
                for (int i = 0; i < listEquipment.Count; i++)
                    listBox.Items.Add(listEquipment[i]);

        }

        private void NextButt_Click(object sender, RoutedEventArgs e)
        {
            if (listImage.Rows.Count > 0 && NumberImageSelected < MaxNumberImage-1)
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

        private void DetailsButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Detailed window = new Detailed(Convert.ToString(listBox.SelectedValue));
                window.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сначала выполните поиск!\nВыберите оборудование из списка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
