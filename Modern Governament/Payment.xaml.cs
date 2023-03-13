using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
       public double  amount;
       // string bill_type;

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Payment p2=new Payment();
            p2.Show();
        }

        private void btn_add_pay_Click(object sender, RoutedEventArgs e)
        {
            c1.Content = new secpay();
            btn_add_pay_Copy.Visibility = Visibility.Visible;
            lbl_billamount.Visibility = Visibility.Visible;
            txt_amount1.Visibility = Visibility.Visible;
          
        }

        private void btn_add_pay_Copy_Click(object sender, RoutedEventArgs e)
        {
            c2.Content = new Secpa();
            lbl_billamount2.Visibility = Visibility.Visible;
            txt_amount2.Visibility = Visibility.Visible;
      
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // if (cmb_type.SelectedIndex == 0)
         //   bill_type = "WaterBill";
          //  else if (cmb_type.SelectedIndex == 1)
         //   {
          //      bill_type = "ElectricityBill";
         ///   }
         //   else
           // {
             //   bill_type = "Telcombill";
           // }
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {
            amount = Int32.Parse(txt_amount.Text);
            secpay s1= new secpay();
            pay p1= new pay();
            if(txt_amount1.Text.Length==0 && txt_amount2.Text.Length==0)
            {
                p1.billTotal = Int32.Parse(txt_amount.Text);
            }
            else if(txt_amount2.Text.Length==0)
            {
                p1.billTotal = Int32.Parse(txt_amount.Text) + Int32.Parse(txt_amount1.Text);
            }
            else
            {
                p1.billTotal = Int32.Parse(txt_amount.Text) + Int32.Parse(txt_amount1.Text) + Int32.Parse(txt_amount2.Text);
            }
          

            p1.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn_add_pay_Copy.Visibility = Visibility.Hidden;
            lbl_billamount.Visibility = Visibility.Hidden;
            txt_amount1.Visibility = Visibility.Hidden;
            lbl_billamount2.Visibility = Visibility.Hidden;
            txt_amount2.Visibility = Visibility.Hidden;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Home h1=new Home();
            h1.Show();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
