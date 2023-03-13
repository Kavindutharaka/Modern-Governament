﻿using System;
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
using System.Xml.Schema;

namespace Modern_Governament
{
    /// <summary>
    /// Interaction logic for secpay.xaml
    /// </summary>
    public partial class secpay : UserControl
    {
        public secpay()
        {
            InitializeComponent();
        }
        public string bill_no, bill_type;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmb_type.SelectedIndex==0)
            {
                bill_type = "WaterBill";
            }
            else if(cmb_type.SelectedIndex==1) 
            {
                bill_type = "ElectricityBill";
            }
            else
            {
                bill_type = "Telcombill";
            }
        }

        public void get()
        {
            txt_reg_num.Text = bill_no;
        }
    }
}
