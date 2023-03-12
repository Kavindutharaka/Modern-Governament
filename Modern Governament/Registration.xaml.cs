
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection con;
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            NewRegistration nr1 = new NewRegistration();


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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
            BirthRegistration br1=new BirthRegistration();
            br1.Show();
        }

        private void btn_death_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            DeathRegistarton dr1=new DeathRegistarton();
            dr1.Show();
        }

        private void btn_marriage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MarriageRegistration mr1=new MarriageRegistration();
            mr1.Show();
        }

        private void btn_licence_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            DriveLicence dl1=new DriveLicence();
            dl1.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home h1=new Home();
            h1.Show();
        }
    }
}
