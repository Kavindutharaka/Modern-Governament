using Syncfusion.Lic.util.encoders;
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
    /// Interaction logic for MarriageRegister.xaml
    /// </summary>
    public partial class MarriageRegister : UserControl
    {
        public MarriageRegister()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public void GetpublicId()
        {
            string proid;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select reg_num from MarriageCertificate order by reg_num Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("MC000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("MC000001");
            }
            else
            {
                proid = ("MC000001");
            }
            con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            DateTime reg_date;
            reg_date = DateTime.Now;
            con.Open();
            cmd = new SqlCommand("Insert into MarriageCertificate values('" + txt_reg_num.Text + "','" + dom_picker.SelectedDate + "','" + txt_fp_fname.Text + "','" + txt_fp_nic.Text + "','" + fp_dob_picker.SelectedDate + "','" + txt_fp_address.Text + "','" + txt_fp_faname.Text + "','" + txt_fp_moname.Text + "','" + txt_fp_witness.Text + "','"+txt_sp_fname.Text+"','"+txt_sp_nic.Text+"','"+sp_dob_picker.SelectedDate+"','"+txt_sp_address.Text+"','"+txt_sp_faname.Text+"','"+txt_sp_moname.Text +"','"+txt_sp_witness.Text+"',@b)", con);
            cmd.Parameters.AddWithValue("b", reg_date);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
