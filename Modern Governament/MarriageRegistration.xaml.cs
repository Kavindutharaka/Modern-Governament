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
    /// Interaction logic for MarriageRegistration.xaml
    /// </summary>
    public partial class MarriageRegistration : Window
    {
        public MarriageRegistration()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            cc.Content= new MarriageRegister();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            cc.Content= new MarriageUpdate();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            cc.Content= new MarriageDelete();
        }
    }
}
