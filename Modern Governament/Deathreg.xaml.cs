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
    /// Interaction logic for Deathreg.xaml
    /// </summary>
    public partial class Deathreg : UserControl
    {
        public Deathreg()
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
            SqlCommand cmd1 = new SqlCommand("Select reg_num from DeathCertificate order by reg_num Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("DC000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("DC000001");
            }
            else
            {
                proid = ("DC000001");
            }
            con.Close();
            txt_reg_num.Text = proid.ToString();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
            DateTime reg_date;
            reg_date = DateTime.Now;
            txt_datereg.Text = reg_date.Date.ToString("yyyy-MM-dd");
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbn_male_Checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void rbn_female_Checked(object sender, RoutedEventArgs e)
        {
            sex = "female";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("Insert into DeathCertificate values('" + txt_reg_num.Text + "','" + deathdate_picker.SelectedDate + "','" + txt_placedead.Text + "','" + txt_fname.Text + "','" + txt_age.Text + "','" + sex + "','" + txt_faname.Text + "','" + txt_moname.Text + "','" + txt_cousedeath.Text + "','" + txt_datereg.Text + "')", con);
                if(deathdate_picker.SelectedDate==null )
                {
                    lbl_dd.Text = "*Death date Cannot be null";
                }
                else if(txt_placedead.Text.Length==0)
                {
                    lbl_dd.Visibility = Visibility.Collapsed;
                    lbl_pod.Text = "*Place of death cannot be blank";
                }
                else if(txt_placedead.Text.Any(char.IsDigit))
                {
                    lbl_pod.Text = "*Place of Death cannot have Number";
                }
                else if (txt_fname.Text.Length == 0)
                {
                    lbl_pod.Visibility = Visibility.Collapsed;
                    lbl_fullname.Text = "*full name be blank";
                }
                else if (txt_fname.Text.Any(char.IsDigit))
                {
                    lbl_fullname.Text = "*full name cannot have Number";
                }
                else if (txt_age.Text.Length == 0)
                {
                    lbl_fullname.Visibility = Visibility.Collapsed;
                    lbl_age.Text = "*age be blank";
                }
                else if (int.Parse(txt_age.Text)>0)
                {
                    lbl_age.Visibility = Visibility.Collapsed;
                    lbl_age.Text = "*age Invalid";
                }
                else if(rbn_male.IsChecked==null && rbn_female.IsChecked==null )
                {
                    lbl_sex.Text = "*Please select Gender";
                }
                else if(txt_faname.Text.Length==0)
                {
                    lbl_sex.Visibility = Visibility.Collapsed;
                    lbl_faname.Text = "Father Name Cannot be Blank";
                }
                else if(txt_faname.Text.Any(char.IsDigit))
                {
                    lbl_faname.Text = "Father Name Cannot have Number";
                }
                else if (txt_moname.Text.Length == 0)
                {
                    lbl_faname.Visibility = Visibility.Collapsed;
                    lbl_moname.Text = "Mother Name Cannot be Blank";
                }
                else if (txt_moname.Text.Any(char.IsDigit))
                {
                    lbl_moname.Text = "Mother Name Cannot have Number";
                }
                else if (txt_cousedeath.Text.Length == 0)
                {
                    lbl_moname.Visibility = Visibility.Collapsed;
                    lbl_reason.Text = "Death reason Cannot be Blank";
                }
                else if (txt_cousedeath.Text.Any(char.IsDigit))
                {
                    lbl_reason.Text = "Death reason Cannot have Number";
                }
                else
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Data Save Succesful", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                        Printdeath pd1=new Printdeath();
                        pd1.lbl_reg.Text=txt_reg_num.Text;
                        pd1.lbl_dod.Text=deathdate_picker.Text;
                        pd1.lbl_fname.Text=txt_fname.Text;
                        pd1.lbl_age.Text=txt_age.Text;
                        pd1.lbl_sex.Text = sex;
                        pd1.lbl_fathname.Text=txt_faname.Text;
                        pd1.lbl_moname.Text=txt_moname.Text;
                        pd1.lbl_reason.Text = txt_cousedeath.Text;
                        PrintDialog printDlg = new PrintDialog();
                        if (printDlg.ShowDialog() == true)
                        {
                            printDlg.PrintVisual(pd1, "User Control Printing.");
                        }
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
            con.Close() ;
        }

        private void btn_close_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
