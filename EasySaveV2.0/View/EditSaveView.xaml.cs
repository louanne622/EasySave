﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasySaveV2._0
{
    /// <summary>
    /// Logique d'interaction pour AddReservationView.xaml
    /// </summary>
    public partial class EditSaveView : Window
    {
        public EditSaveView()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}