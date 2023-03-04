
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

            if(dob_picker.Text.Length==0 && fdob_picker.Text.Length==0 && mdob_picker.Text.Length==0)
            {
                con.Open();
                cmd = new SqlCommand("update BirthCertificate set full_name='" + txt_full_name.Text + "',sex='"+sex+"',place_birth='" + txt_place_birth.Text + "',dob='"+dob_picker.SelectedDate+"',f_name='" + txt_fname.Text + "',f_dob='"+fdob_picker.SelectedDate+"',m_name='" + txt_mname.Text + "',m_dob='"+mdob_picker.SelectedDate+ "' where reg_num='"+txt_reg_num.Text +"'", con);
               
              
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
