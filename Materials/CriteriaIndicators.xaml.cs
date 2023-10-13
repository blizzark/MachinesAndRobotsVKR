using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace MachinesAndRobotsVKR.Materials
{
    /// <summary>
    /// Логика взаимодействия для CriteriaIndicators.xaml
    /// </summary>
    public partial class CriteriaIndicators : Window
    {

        public CriteriaIndicators()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(ProductivityBox.Text) > 0 && Convert.ToInt32(EnergyBox.Text) > 0 && Convert.ToInt32(SquareBox.Text) > 0)
            {
                ClientFTP.setValueProductivity = Convert.ToInt32(ProductivityBox.Text);
                ClientFTP.setValueEnergy = Convert.ToInt32(EnergyBox.Text);
                ClientFTP.setValueSquare = Convert.ToInt32(SquareBox.Text);
            }
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
