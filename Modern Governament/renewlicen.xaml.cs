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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
