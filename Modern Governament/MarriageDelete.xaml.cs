﻿using System;
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
    /// Interaction logic for MarriageDelete.xaml
    /// </summary>
    public partial class MarriageDelete : UserControl
    {
        public MarriageDelete()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-13KGUEB;Initial Catalog=Government;Integrated Security=True");
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Delete from MarriageCertificate Where reg_num='" + txt_reg_num.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
