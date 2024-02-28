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
using EasySaveV3._0.Models;
using Microsoft.Win32;
using EasySaveV3._0.ViewModels;

namespace EasySaveV3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour EditSaveView.xaml
    /// </summary>
    public partial class EditSaveView : Window
    {
        //public EditSaveView()
        //{
        //    InitializeComponent();
        //}
        public EditSaveView(Save saveToUpdate)
        {
            InitializeComponent();
            /*
            this.txtBackupName.Text = saveToUpdate.Name;
            this.txtSourceFile.Text = saveToUpdate.FilesSource;
            this.txtDestinationFile.Text = saveToUpdate.FilesTarget;
            */
        }
        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Sélectionner ce dossier"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

                if (sender == browseButtonSource)
                {
                    (DataContext as SaveViewModel).NewSourcePath = folderPath;
                    selectedPathSource.Content = folderPath;
                }
                else if (sender == browseButtonTarget)
                {
                    (DataContext as SaveViewModel).NewTargetPath = folderPath;
                    selectedPathTarget.Content = folderPath;
                }
            }
        }
    }
}