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
    /// Interaction logic for Loan.xaml
    /// </summary>
    public partial class Loan : Window
    {
        public Loan()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public void GetpublicId()
        {
            string proid;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select loan_no from loan order by loan_no Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("LN000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("LN000001");
            }
            else
            {
                proid = ("LN000001");
            }
            con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void btn_add_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
