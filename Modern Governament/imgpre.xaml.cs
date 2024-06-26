﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for imgpre.xaml
    /// </summary>
    public partial class imgpre : Window
    {
        public imgpre()
        {
            InitializeComponent();
        }
        public string img1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                img_medical.Source = new BitmapImage(new Uri(img1));

            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Please select image only", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Please select a File", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Please select image only", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Errors", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Hide();
                
            }
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();  
        }
    }
}
