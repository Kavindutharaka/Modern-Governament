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
    /// Interaction logic for DeathRegistarton.xaml
    /// </summary>
    public partial class DeathRegistarton : Window
    {
        public DeathRegistarton()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cc.Content = new Deathreg();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_new_registration_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new Deathreg();
        }
    }
}
