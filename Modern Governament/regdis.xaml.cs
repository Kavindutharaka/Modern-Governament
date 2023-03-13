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
    /// Interaction logic for regdis.xaml
    /// </summary>
    public partial class regdis : Window
    {
        public regdis()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_birth_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            BirDis bD= new BirDis();
            bD.Show();
        }

        private void btn_death_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Deathdis dd1=new Deathdis();
            dd1.Show();
        }

        private void btn_marriage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Mdis md1= new Mdis();
            md1.Show();
        }

        private void btn_licence_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Ddis ddis1=new Ddis();
            ddis1.Show();
        }

        private void btn_back_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            Home h1=new Home();
            h1.Show();
        }
    }
}
