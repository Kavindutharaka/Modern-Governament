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
    /// Interaction logic for pay.xaml
    /// </summary>
    public partial class pay : Window
    {
        public pay()
        {
            InitializeComponent();
        }
        public double billTotal;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_total.Text=billTotal.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
