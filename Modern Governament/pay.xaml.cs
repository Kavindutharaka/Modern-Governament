using System;
using System.Collections.Generic;
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
        public double billTotal;
        string paymenttype;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_total.Text=billTotal.ToString();
            lbl_card.Visibility=Visibility.Hidden;
            lbl_cvc.Visibility=Visibility.Hidden;
            lbl_exp.Visibility=Visibility.Hidden;
            txt_cardnum.Visibility=Visibility.Hidden;
            txt_exp.Visibility=Visibility.Hidden;
            txt_cvc.Visibility=Visibility.Hidden;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
