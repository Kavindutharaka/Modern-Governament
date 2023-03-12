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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for Deathreg.xaml
    /// </summary>
    public partial class Deathreg : UserControl
    {
        public Deathreg()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        string sex;
        public void GetpublicId()
        {
            string proid;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select reg_num from DeathCertificate order by reg_num Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("DC000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("DC000001");
            }
            else
            {
                proid = ("DC000001");
            }
            con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
            DateTime reg_date;
            reg_date = DateTime.Now;
            txt_datereg.Text = reg_date.Date.ToString("yyyy-MM-dd");
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbn_male_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void rbn_female_Checked(object sender, RoutedEventArgs e)
        {
            sex = "female";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            
            con.Open();
            cmd = new SqlCommand("Insert into DeathCertificate values('"+txt_reg_num.Text+"','"+deathdate_picker.SelectedDate+"','"+txt_placedead.Text+"','"+txt_fname.Text+"','"+txt_age.Text+"','"+sex+"','"+txt_faname.Text+"','"+txt_moname.Text+"','"+txt_cousedeath.Text+"','"+txt_datereg.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close() ;
        }

        private void btn_close_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
