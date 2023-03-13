using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //int age;
            //  age=int.Parse(dob_picker.SelectedDate);
           
            try 
            {
                con.Open();
                cmd = new SqlCommand("Insert into driverlicen values('" + txt_reg_num.Text + "','" + txt_nic.Text + "','" + txt_fname.Text + "','" + dob_picker.SelectedDate + "','" + sex + "','" + txt_age.Text + "','" + txt_address.Text + "','" + txt_tp.Text + "','" + txt_height.Text + "','" + selected + "','" + reg_date.Date + "','" + exp_date.Date + "')", con);
               if (txt_nic.Text.Length == 0 || txt_nic.Text.Length == 0)
                {
                    lbl_nic.Text = "Nic cannot be blank";
                }
                else if (!Regex.IsMatch(txt_nic.Text, @"^[0-9]{9}[vVxX]$") && txt_nic.Text.Length != 12)
                {
                    lbl_nic.Text = "Nic invalid";
                }
               else if(txt_fname.Text.Length==0)
                {
                    lbl_nic.Visibility= Visibility.Hidden;
                    lbl_fullname.Text = "Full name cannot be blank";
                    txt_fname.Focus();
                }
               else if(txt_fname.Text.Any(char.IsDigit))
                {
                    lbl_fullname.Text = "Full name cannot have number";
                }
               else if(dob_picker.SelectedDate==null)
                {
                    lbl_fullname.Visibility= Visibility.Hidden;
                    lbl_dob.Text = "Please enter date";
                }
               else if(rbn_male_Copy.IsChecked==false && rbn_female_Copy.IsChecked==false)
                {
                    lbl_dob.Visibility = Visibility.Hidden;
                    lbl_sex.Text = "*Please select Gender";
                }
               else if(int.Parse(txt_age.Text)<18 )
                {
                    lbl_sex.Visibility = Visibility.Hidden;
                    lbl_age.Text = "Invalid age";
                }
               else if(txt_address.Text.Length==0)
                {
                lbl_age.Visibility = Visibility.Hidden;
                    lbl_address.Text = "Address cannot be null";
                }
                else if (txt_address.Text.Any(char.IsDigit))
                {
                 
                    lbl_address.Text = "Address cannot have number";
                }
               else if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{9,10}$"))
                {
                    lbl_address.Visibility= Visibility.Hidden;
                    lbl_tp.Text = "Telephone num Invalid";
              }
              else if(double.Parse(txt_height.Text)<0)
                {
                    lbl_tp.Visibility= Visibility.Hidden;
                    lbl_height.Text = "Invalid Height";
                }
               else if(cmb_bgroup.SelectedIndex==-1)
                {
                    lbl_height.Visibility= Visibility.Hidden;
                    lbl_bgroup.Text = "Please select blod group";
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
            catch (SqlException)
            {
                MessageBox.Show("Error", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error", " Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private void dob_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_age.Text = (DateTime.Now.Year - dob_picker.SelectedDate.Value.Year).ToString();
        }
    }
}
