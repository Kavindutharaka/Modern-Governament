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
    /// Interaction logic for renewlicen.xaml
    /// </summary>
    public partial class renewlicen : UserControl
    {
        public renewlicen()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        string selected;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {

                txt_medicalreport.Text = openFileDlg.FileName;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                 imgpre i1=new imgpre();
                i1.img1 = txt_medicalreport.Text;
                i1.Show();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            DateTime reg_date, exp_date;
            reg_date = DateTime.Now;
            exp_date = DateTime.Now.AddYears(5);
            con.Open();
            cmd= new SqlCommand("Insert into driverlicenUpdate values('"+txt_reg_num.Text+"','"+selected+"','" + txt_medicalreport.Text + "','" +reg_date.Date+"','"+exp_date+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void cmb_medicalreport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_medicalreport.SelectedIndex == 0)
            {
                selected = "Pass";
            }
            else if (cmb_medicalreport.SelectedIndex == 1)
            {
                selected = "Fail";
            }
        }
    }
}
