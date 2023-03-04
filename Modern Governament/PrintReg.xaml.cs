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
    /// Interaction logic for PrintReg.xaml
    /// </summary>
    public partial class PrintReg : UserControl
    {
        public PrintReg()
        {
            InitializeComponent();
        }
        public String reg_num, reg_name, sex, pob, dob, fname, fdob, mname, mdob, date_reg;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_reg.Text= reg_num;
            lbl_fname.Text= reg_name;
            lbl_sex.Text = sex;
            lbl_pob.Text = pob;
            lbl_dob.Text = dob;
            lbl_ffname.Text= fname;
            lbl_fdob.Text = fdob;
            lbl_mfname.Text =mname;
            lbl_mdob.Text = mdob;
            lbl_regdate.Text = date_reg;
        }
    }
}
