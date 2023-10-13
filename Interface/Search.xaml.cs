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

namespace MachinesAndRobotsVKR.Interface
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        DB connect = new DB();
        public Search()
        {
            InitializeComponent();

            List<string> listInstitution = new List<string>();
            listInstitution = connect.InstitutionList();
            for (int i = 0; i < listInstitution.Count; i++)
            {
                ComboInstSearch.Items.Add(listInstitution[i]);
            }
            if(ComboInstSearch.Items.Count > 0)
            ComboInstSearch.SelectedIndex = 0;

            List<string> listCharacts = new List<string>();
            listCharacts = connect.CharactsDB();
            for (int i = 0; i < listCharacts.Count; i++)
            {
                CharactCombo.Items.Add(listCharacts[i]);
            }
            CharactCombo.SelectedIndex = 0;
            ComboInstSearch.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            if (Convert.ToString(ComboProdSearch.SelectedValue) == "(Пусто)")
            {
                MessageBox.Show("Необходимо выбрать значение характеристики!", "Ошибка!");
            }
            else
            {
                list = connect.Search(Convert.ToString(CharactCombo.SelectedValue), Convert.ToString(ComboProdSearch.SelectedValue), Convert.ToString(ComboSubdSearch.SelectedValue));

                int num = 0;
                if (list.Count > 0)
                {
                    SearchList.Items.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        num++;
                        SearchList.Items.Add(list[i]);
                    }
                    NumEq.Content = "Всего найдено: " + num;
                }
                else
                {
                    SearchList.Items.Clear();
                    NumEq.Content = "Всего найдено: " + num;
                    MessageBox.Show("Ничего не найдено!", "Внимание!");
                }

            }
        }

        private void CharactCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboProdSearch.Items.Clear();
            ComboProdSearch.Items.Add("(Пусто)");
            List<string> listProgrammingMethod = new List<string>();
            listProgrammingMethod = connect.ProgrammingMethodList(Convert.ToString(CharactCombo.SelectedValue));
            for (int i = 0; i < listProgrammingMethod.Count; i++)
            {
                ComboProdSearch.Items.Add(listProgrammingMethod[i]);
            }
            ComboProdSearch.SelectedIndex = 0;
        }

        private void Detals_Click(object sender, RoutedEventArgs e) // на вкладке поиска
        {
            try
            {
                Detailed window = new Detailed(Convert.ToString(SearchList.SelectedValue));
                window.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сначала выполните поиск!\nВыберите оборудование из списка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboInstSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSubdSearch.Items.Clear();
            List<string> listSubd = new List<string>();
            listSubd = connect.SubdivisionList(Convert.ToString(ComboInstSearch.SelectedValue));
            for (int i = 0; i < listSubd.Count; i++)
            {
                ComboSubdSearch.Items.Add(listSubd[i]);
            }
            if(ComboSubdSearch.Items.Count >0)
                ComboSubdSearch.SelectedIndex = 0;
        }
    }
}
