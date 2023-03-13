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
using System.Windows.Shapes;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for pay.xaml
    /// </summary>
    public partial class pay : Window
    {
        public pay()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        public double billTotal;
        string paymenttype;

        public void GetpublicId()
        {
            string proid;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Bill_no from Payment order by Bill_no Desc", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString().Substring(2)) + 1;
                proid = id.ToString("BL000000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("BL000001");
            }
            else
            {
                proid = ("BL000001");
            }
            con.Close();
            txt_no.Text = proid.ToString();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {
            BillPrint b1= new BillPrint();
            b1.lbl_no.Text=txt_no.Text;
            b1.lbl_method.Text = paymenttype;
            b1.lbl_total.Text = billTotal.ToString();

            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(b1, "User Control Printing.");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Payment p1= new Payment();
            p1.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_paymethod.SelectedIndex == 0)
            {
                paymenttype = "Cash";
                lbl_card.Visibility = Visibility.Hidden;
                lbl_cvc.Visibility = Visibility.Hidden;
                lbl_exp.Visibility = Visibility.Hidden;
                txt_cardnum.Visibility = Visibility.Hidden;
                txt_exp.Visibility = Visibility.Hidden;
                txt_cvc.Visibility = Visibility.Hidden;
            }
            else if (cmb_paymethod.SelectedIndex == 1)
            {
                paymenttype = "Credit Card";
                lbl_card.Visibility = Visibility.Visible;
                lbl_cvc.Visibility = Visibility.Visible;
                lbl_exp.Visibility = Visibility.Visible;
                txt_cardnum.Visibility = Visibility.Visible;
                txt_exp.Visibility = Visibility.Visible;
                txt_cvc.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
            GetpublicId();
            txt_total.Text = billTotal.ToString();
            lbl_card.Visibility = Visibility.Hidden;
            lbl_cvc.Visibility = Visibility.Hidden;
            lbl_exp.Visibility = Visibility.Hidden;
            txt_cardnum.Visibility = Visibility.Hidden;
            txt_exp.Visibility = Visibility.Hidden;
            txt_cvc.Visibility = Visibility.Hidden;
        }
    }
}
