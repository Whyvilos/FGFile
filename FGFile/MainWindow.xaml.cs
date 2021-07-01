using Microsoft.Win32;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FGFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string fPath = "";
        private string saveFilePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                fPath = dialog.FileName;
                fPathBox.Text = fPath;
            }
            else
            {
                fPath = "";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                saveFilePath = saveFileDialog.FileName;
                saveFilePathText.Text = saveFilePath;
            }
            else
            {
                saveFilePath = "";
            }

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (fPath != "" && saveFilePath != "")
            {
                ClassfileHelper cfh = new ClassfileHelper();
                List<string> Text = new List<string>();
                if (cfh.ReadFFile(ref Text, fPath))
                    if(cfh.WriteGFile(Text, saveFilePath))
                        MessageBox.Show("Файл успешно записан");

            }
            else
            {
                MessageBox.Show("Выберите исходный файл и путь результата");
            }
        }
    }
}

