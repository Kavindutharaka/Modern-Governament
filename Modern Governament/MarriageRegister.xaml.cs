using Syncfusion.Lic.util.encoders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into MarriageCertificate values('" + txt_reg_num.Text + "','" + dom_picker.SelectedDate + "','" + txt_fp_fname.Text + "','" + txt_fp_nic.Text + "','" + fp_dob_picker.SelectedDate + "','" + txt_fp_address.Text + "','" + txt_fp_faname.Text + "','" + txt_fp_moname.Text + "','" + txt_fp_witness.Text + "','" + txt_sp_fname.Text + "','" + txt_sp_nic.Text + "','" + sp_dob_picker.SelectedDate + "','" + txt_sp_address.Text + "','" + txt_sp_faname.Text + "','" + txt_sp_moname.Text + "','" + txt_sp_witness.Text + "',@b)", con);
                cmd.Parameters.AddWithValue("b", reg_date);
                if(dom_picker.SelectedDate==null)
                {
                    lbl_error.Text = "*Date of Marriage cannot be blank";
                }
                else if(txt_fp_fname.Text.Length==0 || txt_sp_fname.Text.Length==0)
                {
                    lbl_error.Text = "Party's Name cannot be blank";
                }
                else if(txt_fp_fname.Text.Any(char.IsDigit) || txt_sp_fname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "Party's Name cannot have number";
                }
                else if (txt_fp_nic.Text.Length == 0 || txt_sp_nic.Text.Length == 0)
                {
                    lbl_error.Text = "Party's Nic cannot be blank";
                }
                else if(!Regex.IsMatch(txt_fp_nic.Text, @"^[0-9]{9}[vVxX]$") && txt_fp_nic.Text.Length!=12)
                {
                    lbl_error.Text = "1Party Nic invalid";
                }
                else if (!Regex.IsMatch(txt_sp_nic.Text, @"^[0-9]{9}[vVxX]$") && txt_sp_nic.Text.Length != 12)
                {
                    lbl_error.Text = "2Party's Nic invalid";
                }
                else if(fp_dob_picker.SelectedDate==null || sp_dob_picker.SelectedDate==null)
                {
                    lbl_error.Text = "Party's Birthday cannot be null";
                }
                else if(txt_fp_address.Text.Length==0 || txt_sp_address.Text.Length==0)
                {
                    lbl_error.Text = "Party's Address Cannot be Blank";
                }
                else if (txt_fp_address.Text.Any(char.IsDigit) || txt_sp_address.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "Party's address cannot have number";
                }
                else if(txt_fp_faname.Text.Length==0 || txt_sp_faname.Text.Length==0)
                {
                    lbl_error.Text = "Party's FatherName Cannot be Blank";
                }
                else if (txt_fp_faname.Text.Any(char.IsDigit) || txt_sp_faname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "Party's fathername cannot have number";
                }
                else if (txt_fp_moname.Text.Length == 0 || txt_sp_moname.Text.Length == 0)
                {
                    lbl_error.Text = "Party's MotherName Cannot be Blank";
                }
                else if (txt_fp_witness.Text.Length == 0 || txt_sp_witness.Text.Length == 0)
                {
                    lbl_error.Text = "Party's WitnessName Cannot be Blank";
                }
                else if (txt_fp_witness.Text.Any(char.IsDigit) || txt_sp_witness.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "Party's Witnessname cannot have number";
                }
               
                else
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Data Save Succesful", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Error", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception) 
            {
                MessageBox.Show("Error", " Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
      
            con.Close();
        }
    }
}
