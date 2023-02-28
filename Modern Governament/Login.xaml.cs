using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Markup;


namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
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

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string user_name, password;
            user_name = txt_username.Text;
            password = txt_password.Password;
            con.Open();
            //cmd = new SqlCommand("Select * from AdminLogin where user_name='" + txt_userName + "' AND user_password='" + txt_password + "'", con);
            da = new SqlDataAdapter("Select * from Login where username='" + txt_username.Text + "' AND user_password='" + txt_password.Password + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                user_name = txt_username.Text;
                password = txt_password.Password;
                Hide();
                Home h1 = new Home();
                h1.Show();
                con.Close();
            }
            else
            {
                MessageBox.Show("Invalid login details", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                txt_username.Clear();
                txt_password.Clear();
                txt_username.Focus();
            }
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }
    }
}
