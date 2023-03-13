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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Registration r1= new Registration();
            r1.Show();
        }



        private void btn_banking_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Payment b1= new Payment();  
            b1.Show();
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            regdis rd= new regdis();
            rd.Show();
        }
    }
}
