using FontAwesome.Sharp;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        public Update()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        string sex;
        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            DateTime reg_date;
            reg_date = DateTime.Now;
            DateTime dob, mdob, fdob;
            if(dob_picker.Text.Length==0 && fdob_picker.Text.Length==0 && mdob_picker.Text.Length==0)
            {
                con.Open();
                cmd = new SqlCommand("update BirthCertificate set full_name='" + txt_full_name + "',sex=@a,place_birth='" + txt_place_birth + "',f_name='" + txt_fname + "',m_name='" + txt_mname + "'", con);
                cmd.Parameters.AddWithValue("a", sex);
              
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else 
            {
                dob = Convert.ToDateTime(dob_picker.Text);
                fdob = Convert.ToDateTime(mdob_picker.Text);
                mdob = Convert.ToDateTime(fdob_picker.Text);
                con.Open();
                cmd = new SqlCommand("update BirthCertificate set full_name='" + txt_full_name + "',sex=@a,place_birth='" + txt_place_birth + "',dob=@c,f_name='" + txt_fname + "',f_dob=@d,m_name='" + txt_mname + "',m_dob=@e,date_reg=@b", con);
                cmd.Parameters.AddWithValue("a", sex);
                cmd.Parameters.AddWithValue("b", reg_date);
                cmd.Parameters.AddWithValue("c", dob);
                cmd.Parameters.AddWithValue("d", fdob);
                cmd.Parameters.AddWithValue("e", mdob);
                cmd.ExecuteNonQuery();
                con.Close();
            }
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }

        private void rbn_male_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void rbn_female_Checked(object sender, RoutedEventArgs e)
        {
            sex = "female";
        }
    }
}
