﻿
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
using System.Windows.Shapes;

namespace k.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowV.xaml
    /// </summary>
    public partial class MainWindowV : Window
    {
        public MainWindowV()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           ClientV obj = new ClientV();
            obj.Show();
        }

     
    }
}