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
            try
            {


                con.Open();
                cmd = new SqlCommand("update MarriageCertificate set date_of_marriage='" + dom_picker.SelectedDate + "',fp_name='" + txt_fp_fname.Text + "',fp_nic='" + txt_fp_nic.Text + "',fp_dob='" + fp_dob_picker.SelectedDate + "',fp_address='" + txt_fp_address.Text + "',fp_faname='" + txt_fp_faname.Text + "',fp_moname='" + txt_fp_moname.Text + "',fp_witness='" + txt_fp_witness.Text + "',sp_name='" + txt_sp_fname.Text + "',sp_nic='" + txt_sp_nic.Text + "',sp_dob='" + sp_dob_picker.SelectedDate + "',sp_address='" + txt_sp_address.Text + "',sp_faname='" + txt_sp_faname.Text + "',sp_moname='" + txt_sp_moname.Text + "',sp_witness='" + txt_sp_witness.Text + "'where reg_num='" + txt_reg_num.Text + "'", con);
                if(txt_fp_fname.Text.Length!=0 && txt_fp_fname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "1Party FullName Cannot have Number";
                    txt_fp_fname.Focus();
                }
                else if(txt_sp_fname.Text.Length!=0 && txt_sp_fname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "2Party FullName Cannot have Number";
                    txt_sp_fname.Focus();
                }
               else if (txt_fp_nic.Text.Length != 0 && !Regex.IsMatch(txt_fp_nic.Text, @"^[0-9]{9}[vVxX]$") && txt_fp_nic.Text.Length != 12)
                {
                    lbl_error.Text = "1Party Nic invalid";
                    txt_fp_nic.Focus();
                }
                else if (txt_sp_nic.Text.Length != 0 && !Regex.IsMatch(txt_sp_nic.Text, @"^[0-9]{9}[vVxX]$") && txt_sp_nic.Text.Length != 12)
                {
                    lbl_error.Text = "2Party's Nic invalid";
                    txt_sp_nic.Focus();
                }
                else if (txt_fp_address.Text.Length != 0 && txt_fp_address.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "1Party address Cannot have Number";
                    txt_fp_address.Focus();
                }
                else if (txt_sp_address.Text.Length != 0 && txt_sp_address.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "2Party address Cannot have Number";
                    txt_sp_address.Focus();
                }
                else if (txt_fp_faname.Text.Length != 0 && txt_fp_faname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "1Party Fathers Name Cannot have Number";
                    txt_fp_faname.Focus();
                }
                else if (txt_sp_faname.Text.Length != 0 && txt_sp_faname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "2Party Fathers Name Cannot have Number";
                    txt_sp_faname.Focus();
                }
                else if (txt_fp_moname.Text.Length != 0 && txt_fp_moname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "1Party Mother Name Cannot have Number";
                    txt_fp_moname.Focus();
                }
                else if (txt_sp_moname.Text.Length != 0 && txt_sp_moname.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "2Party Mother Name Cannot have Number";
                    txt_sp_moname.Focus();
                }
                else if (txt_fp_witness.Text.Length != 0 && txt_fp_witness.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "1Party Witness Name Cannot have Number";
                    txt_fp_witness.Focus();
                }
                else if (txt_sp_witness.Text.Length != 0 && txt_sp_witness.Text.Any(char.IsDigit))
                {
                    lbl_error.Text = "2Party Witness Name Cannot have Number";
                    txt_sp_witness.Focus();
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
                con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error", " Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
                
           
        }
    }
}
