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

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for DriveLicence.xaml
    /// </summary>
    public partial class DriveLicence : Window
    {
        public DriveLicence()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cc.Content = new Drivereg();
        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new Drivereg();
        }

        private void btn_reg_update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
