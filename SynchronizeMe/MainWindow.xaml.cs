using System;
using System.Windows;
using System.Windows.Controls;

namespace SynchronizeMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBrowseSource_Click(object sender, RoutedEventArgs e)
        {
            getFolder(TextBoxSource, ref sourceFolderPath);
        }

        private void ButtonBrowseBackup_Click(object sender, RoutedEventArgs e)
        {
            getFolder(TextBoxBackup, ref backupFolderPath);
        }

        private void ButtonSynchronize_Click(object sender, RoutedEventArgs e)
        {
            if (sourceFolderPath != backupFolderPath && sourceFolderPath.Length != 0 && backupFolderPath.Length !=0)
            { 
                Synchronizator.Run(sourceFolderPath, backupFolderPath);
            }
            else if (sourceFolderPath == backupFolderPath && sourceFolderPath.Length != 0 && backupFolderPath.Length != 0)
            {
                MessageBox.Show("Source path and backup path can not be the same.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (sourceFolderPath.Length == 0)
            {
                MessageBox.Show("Source path is empty string", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (backupFolderPath.Length == 0)
            {
                MessageBox.Show("Backup path is empty string", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void getFolder(TextBox textBox, ref string selectedPath)
        {
            // Create FolderBrowserDialog
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Open folder
                string folderPath = dialog.SelectedPath;
                textBox.Text = folderPath;
                selectedPath = folderPath;
            }
        }

        private string sourceFolderPath = String.Empty;
        private string backupFolderPath = String.Empty;
    }
}
