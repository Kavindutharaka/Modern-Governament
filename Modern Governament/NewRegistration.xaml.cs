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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for NewRegistration.xaml
    /// </summary>
    public partial class NewRegistration : UserControl
    {
        public NewRegistration()
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
            SqlCommand cmd1 = new SqlCommand("Select reg_num from BirthCertificate order by reg_num Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("BC000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("BC000001");
            }
            else
            {
                proid = ("BC000001");
            }
                con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private RadioButton GetRbn_male()
        {
            return rbn_male;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e, RadioButton rbn_male)
        {
    
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
        }

        private void rbn_male_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void rbn_female_Checked(object sender, RoutedEventArgs e)
        {
            sex = "female";
        }

        private void btn_add_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime reg_date;
            reg_date = DateTime.Now;
            con.Open();
            cmd = new SqlCommand("Insert into BirthCertificate values('"+txt_reg_num.Text+"','"+txt_full_name.Text+"','"+sex+"','"+txt_place_birth.Text+"','"+dob_picker.SelectedDate+"','"+txt_fname.Text+"','"+fdob_picker.SelectedDate +"','"+txt_mname.Text+"','"+mdob_picker.SelectedDate + "',@b)", con);
            cmd.Parameters.AddWithValue("b", reg_date);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
