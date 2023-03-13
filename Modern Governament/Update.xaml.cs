
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
            try
            {
                DateTime reg_date;
                reg_date = DateTime.Now;


                con.Open();
                cmd = new SqlCommand("update BirthCertificate set full_name='" + txt_full_name.Text + "',sex='" + sex + "',place_birth='" + txt_place_birth.Text + "',dob='" + dob_picker.SelectedDate + "',f_name='" + txt_fname.Text + "',f_dob='" + fdob_picker.SelectedDate + "',m_name='" + txt_mname.Text + "',m_dob='" + mdob_picker.SelectedDate + "' where reg_num='" + txt_reg_num.Text + "'", con);

                if(txt_full_name.Text.Length!=0 && txt_full_name.Text.Any(char.IsDigit))
                {
                    lbl_fullname.Text = "*Full Name Cannot have Number";
                    txt_full_name.Focus();
                }
                else if(txt_place_birth.Text.Length!=0 && txt_place_birth.Text.Any(char.IsDigit))
                {
                    lbl_fullname.Visibility = Visibility.Hidden;
                    lbl_POB.Text= "*BirthPlace cannot be Number";
                    txt_place_birth.Focus();
                }
                else if (txt_fname.Text.Length != 0 && txt_fname.Text.Any(char.IsDigit))
                {
                    lbl_POB.Visibility= Visibility.Hidden;
                    lbl_faname.Text = "*Father Name cannot be Number";
                    txt_fname.Focus();
                }
                else if (txt_mname.Text.Length != 0 && txt_mname.Text.Any(char.IsDigit))
                {
                    lbl_faname.Visibility = Visibility.Hidden;
                    lbl_moname.Text = "*Father Name cannot be Number";
                    txt_mname.Focus();
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
