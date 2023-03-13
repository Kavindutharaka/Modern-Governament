using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for Ddis.xaml
    /// </summary>
    public partial class Ddis : Window
    {
        public Ddis()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_type.SelectedIndex == -1)
            {
                lbl_error.Text = "Please select one";
            }
            else
            {
                lbl_error.Visibility= Visibility.Collapsed;
                try
                {
                    if (cmb_type.SelectedIndex == 0)
                    {
                        if (rbn_reg_num.IsChecked == true && txt_reg_num.Text.Length != 0)
                        {
                            con.Open();
                            da = new SqlDataAdapter("Select * from driverlicen where reg_num='" + txt_reg_num.Text + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.ItemsSource = dt.DefaultView;

                        }
                        else if (rbn_name.IsChecked == true && txt_reg_num.Text.Length != 0)
                        {
                            da = new SqlDataAdapter("Select * from driverlicen where fname='" + txt_reg_num.Text + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.ItemsSource = dt.DefaultView;
                        }
                        else if (txt_reg_num.Text.Length == 0)
                        {

                            da = new SqlDataAdapter("Select * from driverlicen", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.ItemsSource = dt.DefaultView;
                            con.Close();
                        }
                        else { }
                    }
                    else
                    {

                        if (rbn_reg_num.IsChecked == true && txt_reg_num.Text.Length != 0)
                        {
                            con.Open();
                            da = new SqlDataAdapter("Select * from driverlicenUpdate where Licen_no='" + txt_reg_num.Text + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.ItemsSource = dt.DefaultView;

                        }

                        else if (txt_reg_num.Text.Length == 0)
                        {

                            da = new SqlDataAdapter("Select * from driverlicenUpdate", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.ItemsSource = dt.DefaultView;
                            con.Close();
                        }
                        else { }
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
            }
        }

        private void rbn_reg_num_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbn_name_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmb_type.SelectedIndex == 1) 
            {
                rbn_name.Visibility = Visibility.Hidden;
            }
            else
            {
                rbn_name.Visibility = Visibility.Visible;
            }
        }
    }
}
