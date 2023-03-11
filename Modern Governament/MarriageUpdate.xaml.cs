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
    /// Interaction logic for MarriageUpdate.xaml
    /// </summary>
    public partial class MarriageUpdate : UserControl
    {
        public MarriageUpdate()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update MarriageCertificate set date_of_marriage='" + dom_picker.SelectedDate + "',fp_name='" + txt_fp_fname.Text + "',fp_nic='"+txt_fp_nic.Text+ "',fp_dob='"+fp_dob_picker.SelectedDate+ "',fp_address='"+txt_fp_address.Text+ "',fp_faname='"+txt_fp_faname.Text+ "',fp_moname='"+txt_fp_moname.Text+ "',fp_witness='"+txt_fp_witness.Text+ "',sp_name='"+txt_sp_fname.Text+ "',sp_nic='"+txt_sp_nic.Text + "',sp_dob='"+sp_dob_picker.SelectedDate+ "',sp_address='"+txt_sp_address.Text + "',sp_faname='"+txt_sp_faname.Text+ "',sp_moname='"+txt_sp_moname.Text+ "',sp_witness='"+txt_sp_witness.Text+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
