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
    /// Логика взаимодействия для ListLine.xaml
    /// </summary>
    public partial class ListLine : UserControl
    {
        DB connect = new DB();
        DataTable tableLine;
        public ListLine()
        {
            InitializeComponent();
            tableLine = new DataTable();
            tableLine = connect.ListLine();

            for (int i = 0; i < tableLine.Rows.Count; i++)
            {
                DataRow row = tableLine.Rows[i];
                ListProdLines.Items.Add(Convert.ToString(row["name"]));
            }
            if (ListProdLines.Items.Count > 0)
                ListProdLines.SelectedIndex = 0;
        }

        private void ListProdLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListProdLines.SelectedIndex >= 0)
            {
                DataRow row = tableLine.Rows[ListProdLines.SelectedIndex];
                ProductBox.Text = "Производительность: " + row["productivity"] + " шт/ч";
                EnergyBox.Text = "Энергопотребление: " + row["energy"] + " Вт";
                SquareBox.Text = "Общая площать: " + row["square"] + " м^2";
                dateBox.Text = Convert.ToString(row["date"]);

                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri("preview/" + row["preview"], UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                img.Source = src;
                img.Stretch = Stretch.Uniform;
            }


        }

        private void CreateButt_Click(object sender, RoutedEventArgs e)
        {
            Modeling Mod = new Modeling();
            Mod.ShowDialog();
            tableLine.Clear();
            ListProdLines.Items.Clear();
            tableLine = connect.ListLine();

            for (int i = 0; i < tableLine.Rows.Count; i++)
            {
                DataRow row = tableLine.Rows[i];
                ListProdLines.Items.Add(Convert.ToString(row["name"]));
            }
            if (ListProdLines.Items.Count > 0)
                ListProdLines.SelectedIndex = 0;
        }

        private void editButt_Click(object sender, RoutedEventArgs e)
        {
            if(ListProdLines.Items.Count > 0)
            {
                if(ListProdLines.SelectedIndex >= 0)
                {
                    DataRow row = tableLine.Rows[ListProdLines.SelectedIndex];
                    Modeling Mod = new Modeling((int)row["idproduction_line"], (string)row["name"]);
                    Mod.ShowDialog();
                }
            }
        }

        private void deleteButt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить выбранную производственную линию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {
                connect.DeleteProductLine((string)ListProdLines.SelectedValue);
                ListProdLines.Items.RemoveAt(ListProdLines.SelectedIndex);

            }
        }
    }
}
