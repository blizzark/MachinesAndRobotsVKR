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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachinesAndRobotsVKR.Interface
{
    /// <summary>
    /// Логика взаимодействия для EditDB.xaml
    /// </summary>
    public partial class EditDB : System.Windows.Controls.UserControl
    {
        DB connect = new DB();
        DataTable table = new DataTable();

        public string RealName(string fake)
        {
            if (fake == "Оборудование")
                return "equipment";
            if (fake == "Пользователи")
                return "user";
            if (fake == "Список всех характеристик")
                return "list_of_characteristics";
            if (fake == "Учебные организации")
                return "institution";
            //if (fake == "Материалы")
            //    return "material";
            if (fake == "Учебное подразделение")
                return "subdivision";
            return "";

        }

        public EditDB()
        {
            InitializeComponent();

            EditTabelsGrid.CanUserAddRows = false;




            Tabels.Items.Add("Оборудование");
            Tabels.Items.Add("Пользователи");
            Tabels.Items.Add("Список всех характеристик");
            //Tabels.Items.Add("Материалы");
            Tabels.Items.Add("Учебные организации");
            Tabels.Items.Add("Учебное подразделение");
            //Tabels.SelectedIndex = 0;


           
        }

      

        private void Tabels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            table.Clear();
            if (Convert.ToString(Tabels.SelectedValue) == "Характеристики оборудования")
            {
                table = connect.ReturnTabelCharact();
                //     SaveTabelButton.Visibility = Visibility.Hidden;
            }
            else if (Convert.ToString(Tabels.SelectedValue) == "Оборудование")
            {
                table = connect.ReturnTabelEQ();
                //     SaveTabelButton.Visibility = Visibility.Hidden;
            }
            else
            {
                table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                //    SaveTabelButton.Visibility = Visibility.Visible;
            }

            EditTabelsGrid.ItemsSource = table.DefaultView;
            EditTabelsGrid.Columns[0].IsReadOnly = true;
            EditTabelsGrid.Columns[0].Visibility = Visibility.Collapsed;
            if (Convert.ToString(Tabels.SelectedValue) == "Характеристики оборудования")
                EditTabelsGrid.Columns[0].IsReadOnly = false;

            foreach (var column in this.EditTabelsGrid.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

        }

        private void DeleteLineGrid_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (Tabels.SelectedIndex >= 0)
                {
                    if (Convert.ToString(Tabels.SelectedValue) != "Пользователи")
                    {
                        MessageBoxResult res = System.Windows.MessageBox.Show("Вы точно хотите удалить выделенные строчки из списка?\nОтменить это действие будет невозможно!", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (res == MessageBoxResult.Yes)
                        {
                            if (Convert.ToString(Tabels.SelectedValue) == "Характеристики оборудования")
                            {
                                DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;

                                int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                                while (EditTabelsGrid.SelectedItems.Count > 0)
                                {

                                    //table.Rows.RemoveAt(EditTabelsGrid.SelectedIndex);
                                    DataRow dr = table.Rows[EditTabelsGrid.SelectedIndex];
                                    dr.Delete();
                                }
                                EditTabelsGrid.ItemsSource = table.DefaultView;
                                connect.DeleteCharac(id);

                            }
                            else if (Convert.ToString(Tabels.SelectedValue) == "Оборудование")
                            {
                                DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;
                                int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                                while (EditTabelsGrid.SelectedItems.Count > 0)
                                {

                                    //table.Rows.RemoveAt(EditTabelsGrid.SelectedIndex);
                                    DataRow dr = table.Rows[EditTabelsGrid.SelectedIndex];
                                    dr.Delete();
                                }
                                EditTabelsGrid.ItemsSource = table.DefaultView;
                                connect.DeleteEQ(id);
                            }
                            else
                            {
                                DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;
                                int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                                while (EditTabelsGrid.SelectedItems.Count > 0)
                                {

                                    //table.Rows.RemoveAt(EditTabelsGrid.SelectedIndex);
                                    DataRow dr = table.Rows[EditTabelsGrid.SelectedIndex];
                                    dr.Delete();
                                }

                                EditTabelsGrid.ItemsSource = table.DefaultView;
                                connect.DeleteNew(id, RealName(Convert.ToString(Tabels.SelectedValue)));
                            }
                        }
                    }
                    else
                    {
                        if (table.Rows.Count > 2)
                        {
                            MessageBoxResult res = System.Windows.MessageBox.Show("Вы точно хотите удалить выделенные строчки из списка?\nОтменить это действие будет невозможно!", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                            if (res == MessageBoxResult.Yes)
                            {
                                DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;
                                int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                                while (EditTabelsGrid.SelectedItems.Count > 0)
                                {
                                    //table.Rows.RemoveAt(EditTabelsGrid.SelectedIndex);
                                    DataRow dr = table.Rows[EditTabelsGrid.SelectedIndex];
                                    dr.Delete();
                                }

                                EditTabelsGrid.ItemsSource = table.DefaultView;
                                connect.DeleteNew(id, RealName(Convert.ToString(Tabels.SelectedValue)));
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Должно оставаться минимум 2 пользователя!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Выберите таблицу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                EditTabelsGrid.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Выберите строчку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void AddLine_Click(object sender, RoutedEventArgs e)
        {
            if (Tabels.SelectedIndex >= 0)
            {
                DataRow row = table.Rows[table.Rows.Count - 1];
                if (Convert.ToString(Tabels.SelectedValue) == "Оборудование")
                {
                    
                    AddEq win = new AddEq();
                    win.ShowDialog();
                    table.Clear();


                    table = connect.ReturnTabelEQ();


                    EditTabelsGrid.ItemsSource = table.DefaultView;
                    EditTabelsGrid.Columns[0].IsReadOnly = true;

                }

                else if (Convert.ToString(Tabels.SelectedValue) == "Пользователи")
                {
                    //AddMaterials win = new AddMaterials("Добавить учебно-методическую литературу", (Convert.ToInt32(row[0]) + 1));
                    //win.ShowDialog();

                    AddUsers win = new AddUsers();
                    win.ShowDialog();

                    table.Clear();
                    table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                    EditTabelsGrid.ItemsSource = table.DefaultView;
                    EditTabelsGrid.Columns[0].IsReadOnly = true;

                }
                else if (Convert.ToString(Tabels.SelectedValue) == "Список всех характеристик")
                {
                    //AddMaterials win = new AddMaterials("Добавить учебно-методическую литературу", (Convert.ToInt32(row[0]) + 1));
                    //win.ShowDialog();

                    AddUniver win = new AddUniver("Добавить характеристику");
                    win.ShowDialog();

                    table.Clear();
                    table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                    EditTabelsGrid.ItemsSource = table.DefaultView;
                    EditTabelsGrid.Columns[0].IsReadOnly = true;

                }
                else if (Convert.ToString(Tabels.SelectedValue) == "Характеристики оборудования")
                {
                    //AddMaterials win = new AddMaterials("Добавить учебно-методическую литературу", (Convert.ToInt32(row[0]) + 1));
                    //win.ShowDialog();
                    AddSpecification win = new AddSpecification();
                    win.ShowDialog();


                    table.Clear();
                    table = connect.ReturnTabelCharact();

                    EditTabelsGrid.ItemsSource = table.DefaultView;
                    EditTabelsGrid.Columns[0].IsReadOnly = true;

                }
                else if (Convert.ToString(Tabels.SelectedValue) == "Учебные организации")
                {
                    //AddMaterials win = new AddMaterials("Добавить учебно-методическую литературу", (Convert.ToInt32(row[0]) + 1));
                    //win.ShowDialog();


                    AddUniver win = new AddUniver("Добавить учебное заведение");
                    win.ShowDialog();

                    table.Clear();
                    table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                    EditTabelsGrid.ItemsSource = table.DefaultView;
                    EditTabelsGrid.Columns[0].IsReadOnly = true;

                }
                else
                {


                    table.Rows.Add(Convert.ToInt32(row[0]) + 1);

                    EditTabelsGrid.ItemsSource = table.DefaultView;
                }
                Tabels.SelectedIndex = Tabels.SelectedIndex;
                EditTabelsGrid.Columns[0].Visibility = Visibility.Collapsed;
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите таблицу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void SaveTabelButton_Click(object sender, RoutedEventArgs e)
        {


            if (Tabels.SelectedIndex >= 0)
            {
                DB connectForSave = new DB(); // пришлось ещё раз переподключаться, т.к. иначе почему-то видела старая таблица в памяти
                try
                {
                    connectForSave.SaveTabelDB(table, RealName(Convert.ToString(Tabels.SelectedValue)));
                    System.Windows.MessageBox.Show("Сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    connectForSave.Close();
                }
                catch (Exception ex)
                {
                    connectForSave.Close();
                    System.Windows.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите таблицу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEq qw = new AddEq();
            qw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddSpecification qw = new AddSpecification();
            qw.ShowDialog();
        }

        private void EditLine_Click(object sender, RoutedEventArgs e)
        {
            if (Tabels.SelectedIndex >= 0)
            {
                if (EditTabelsGrid.SelectedItems.Count > 0)
                {


                    DataRow row = table.Rows[table.Rows.Count - 1];

                    if (Convert.ToString(Tabels.SelectedValue) == "Оборудование")
                    {
                        DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;
                        //(int id, string name, string desc, string img, string univer, string lit, string vid, string mod)
                        int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        AddEq win = new AddEq(id);
                        win.ShowDialog();


                        table.Clear();
                        table = connect.ReturnTabelEQ();

                        EditTabelsGrid.ItemsSource = table.DefaultView;
                        EditTabelsGrid.Columns[0].IsReadOnly = true;

                    }

                    else if (Convert.ToString(Tabels.SelectedValue) == "Пользователи")
                    {
                        //AddMaterials win = new AddMaterials("Добавить учебно-методическую литературу", (Convert.ToInt32(row[0]) + 1));
                        //win.ShowDialog();

                        DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;

                        int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        string name = dataRow.Row.ItemArray[1].ToString();
                        string pass = dataRow.Row.ItemArray[2].ToString();
                        string role = dataRow.Row.ItemArray[3].ToString();

                        AddUsers win = new AddUsers(id, name, pass, role);
                        win.ShowDialog();

                        table.Clear();
                        table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                        EditTabelsGrid.ItemsSource = table.DefaultView;
                        EditTabelsGrid.Columns[0].IsReadOnly = true;

                    }
                    else if (Convert.ToString(Tabels.SelectedValue) == "Список всех характеристик")
                    {
                        DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;

                        int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        string name = dataRow.Row.ItemArray[1].ToString();


                        AddUniver win = new AddUniver("Изменить характеристику", id, name);
                        win.ShowDialog();

                        table.Clear();
                        table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));

                        EditTabelsGrid.ItemsSource = table.DefaultView;
                        EditTabelsGrid.Columns[0].IsReadOnly = true;

                    }
                    else if (Convert.ToString(Tabels.SelectedValue) == "Характеристики оборудования")
                    {
                        DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;

                        int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        string eq = dataRow.Row.ItemArray[1].ToString();
                        string ch = dataRow.Row.ItemArray[2].ToString();
                        string val = dataRow.Row.ItemArray[3].ToString();
                        string unit = dataRow.Row.ItemArray[4].ToString();

                        AddSpecification win = new AddSpecification(id, eq, ch, val, unit);
                        win.ShowDialog();


                        table.Clear();

                        table = connect.ReturnTabelCharact();

                        EditTabelsGrid.ItemsSource = table.DefaultView;
                        EditTabelsGrid.Columns[0].IsReadOnly = true;

                    }
                    else if (Convert.ToString(Tabels.SelectedValue) == "Учебные организации")
                    {
                        DataRowView dataRow = (DataRowView)EditTabelsGrid.SelectedItem;

                        int id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        string name = dataRow.Row.ItemArray[1].ToString();

                        AddUniver win = new AddUniver("Изменить учебное заведение", id, name);
                        win.ShowDialog();

                        table.Clear();
                        table = connect.ReturnNameTabels(RealName(Convert.ToString(Tabels.SelectedValue)));
                        EditTabelsGrid.ItemsSource = table.DefaultView;
                        EditTabelsGrid.Columns[0].IsReadOnly = true;

                    }
                    else
                    {


                        table.Rows.Add(Convert.ToInt32(row[0]) + 1);

                        EditTabelsGrid.ItemsSource = table.DefaultView;
                    }
                    Tabels.SelectedIndex = Tabels.SelectedIndex;
                    EditTabelsGrid.Columns[0].Visibility = Visibility.Collapsed;
                }
                else
                {
                    System.Windows.MessageBox.Show("Выберите строчку!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Выберите таблицу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
