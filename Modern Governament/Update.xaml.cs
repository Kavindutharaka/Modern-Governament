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

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        public Update()
        {
            InitializeComponent();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
