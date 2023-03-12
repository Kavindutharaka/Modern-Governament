using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Drivereg.xaml
    /// </summary>
    public partial class Drivereg : UserControl
    {
        public Drivereg()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        string sex;
        string selected;
        public void GetpublicId()
        {
            string proid;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select reg_num from driverlicen order by reg_num Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("DL000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("DL000001");
            }
            else
            {
                proid = ("DL000001");
            }
            con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
            
        }

      

        private void rbn_male_Copy_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void rbn_female_Copy_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            DateTime reg_date,exp_date;
            reg_date = DateTime.Now;
            exp_date= DateTime.Now.AddYears(5);
            con.Open();
            cmd = new SqlCommand("Insert into driverlicen values('" + txt_reg_num.Text + "','" + txt_nic.Text + "','" + txt_fname.Text + "','" + dob_picker.SelectedDate + "','" + sex+ "','" + txt_age.Text + "','" + txt_address .Text+ "','" + txt_tp.Text + "','" + txt_height.Text + "','"+selected  + "','"+reg_date.Date+"','"+exp_date+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmb_bgroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
          //selected = cmb_bgroup.SelectedItem.ToString();
           if(cmb_bgroup.SelectedIndex== 0)
            {
                selected = "A+";
            }
           else if (cmb_bgroup.SelectedIndex == 1)
            {
                selected = "A-";
            }
           else if (cmb_bgroup.SelectedIndex == 2)
            {
                selected = "B+";
            }
            else if (cmb_bgroup.SelectedIndex == 3)
            {
                selected = "B-";
            }
            else if (cmb_bgroup.SelectedIndex == 4)
            {
                selected = "O+";
            }
            else if (cmb_bgroup.SelectedIndex == 5)
            {
                selected = "O-";
            }
            else if (cmb_bgroup.SelectedIndex == 6)
            {
                selected = "AB+";
            }
            else if (cmb_bgroup.SelectedIndex == 7)
            {
                selected = "AB-";
            }
        }
    }
}
