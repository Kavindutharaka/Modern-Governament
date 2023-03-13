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

            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into BirthCertificate values('" + txt_reg_num.Text + "','" + txt_full_name.Text + "','" + sex + "','" + txt_place_birth.Text + "','" + dob_picker.SelectedDate + "','" + txt_fname.Text + "','" + fdob_picker.SelectedDate + "','" + txt_mname.Text + "','" + mdob_picker.SelectedDate + "',@b)", con);
                cmd.Parameters.AddWithValue("b", reg_date);
               // cmd.ExecuteNonQuery();
               
                if(string.IsNullOrEmpty(txt_full_name.Text))
                {
                    lbl_fullname.Text = "*Full Name Cannot be blank";
                    txt_full_name.Focus();
                }
                else if(txt_full_name.Text.Any(char.IsDigit))
                {
                    lbl_fullname.Text = "*Full Name Cannot have Number";
                    txt_full_name.Focus();
                }
                else if(rbn_male.IsChecked==false && rbn_female.IsChecked==false)
                {
                    lbl_fullname.Visibility = Visibility.Hidden;
                    lbl_sex.Text = "Please select Gender";
                }
                else if(string.IsNullOrEmpty(txt_place_birth.Text))
                {
                    lbl_sex.Visibility= Visibility.Hidden;
                    lbl_pob.Text = "BirthPlace Cannot be blank";
                    txt_place_birth.Focus();
                }
                else if(txt_place_birth.Text.Any(char.IsDigit))
                {
                    lbl_pob.Text = "*BirthPlace Cannot have Number";
                    txt_place_birth.Focus();
                }
                else if(dob_picker.SelectedDate==null)
                {
                    lbl_pob.Visibility= Visibility.Hidden;
                    lbl_dob.Text = "Birthday Cannot be blank";
                }
                else if(txt_fname.Text.Length==0 && txt_mname.Text.Length==0)
                {
                    lbl_dob.Visibility= Visibility.Hidden;
                    lbl_fafname.Text = "Please fill parent details";
                    lbl_momname.Text= "Please fill parent details";
                }
                else if(txt_fname.Text.Length != 0 && fdob_picker.SelectedDate == null)
                {
                    lbl_fafname.Visibility= Visibility.Hidden;
                    lbl_momname.Visibility = Visibility.Hidden;
                    lbl_fadob.Text = "Father DOB cannot be blank";
                }
                else if (txt_mname.Text.Length != 0 && mdob_picker.SelectedDate == null)
                {
                    lbl_momname.Visibility= Visibility.Hidden;
                    lbl_fafname.Visibility = Visibility.Hidden;
                    lbl_modob.Text = "Mother DOB cannot be blank";
                }  
                else
                {
                    int i= cmd.ExecuteNonQuery();
                    if (i == 1) 
                    {
                        MessageBox.Show("Data Save Succesful","Info",MessageBoxButton.OK,MessageBoxImage.Information);

                        PrintReg pr1 = new PrintReg();
                        pr1.lbl_reg.Text = txt_reg_num.Text;
                        pr1.lbl_fname.Text = txt_full_name.Text;
                        pr1.lbl_sex.Text = sex;
                        pr1.lbl_pob.Text = txt_place_birth.Text;
                        pr1.lbl_dob.Text = dob_picker.Text;
                        pr1.lbl_ffname.Text = txt_fname.Text;
                        pr1.lbl_fdob.Text = fdob_picker.Text;
                        pr1.lbl_mfname.Text = txt_mname.Text;
                        pr1.lbl_mdob.Text = mdob_picker.Text;
                        pr1.lbl_regdate.Text = reg_date.ToString();

                        PrintDialog printDlg = new PrintDialog();
                        if (printDlg.ShowDialog() == true)
                        {
                            printDlg.PrintVisual(pr1, "User Control Printing.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Data Cannot save","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
                con.Close();
            }

            catch(SqlException)
            { MessageBox.Show("Error", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            catch (Exception) { MessageBox.Show("Error", " Error", MessageBoxButton.OK, MessageBoxImage.Error); }

        
        }
    }
}
