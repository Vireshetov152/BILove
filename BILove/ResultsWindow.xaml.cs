using BILoveModel;
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

namespace BILove
{
    /// <summary>
    /// Логика взаимодействия для ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow()
        {
            InitializeComponent();
            GetCouple();
        }
        public async void GetCouple()
        {
            var cf = new CoupleFinder();
            User couple;
            try
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.CoupleName))
                {
                    couple = await cf.FindCouple();
                    Properties.Settings.Default.CoupleName = couple.UserName;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    couple = await cf.ShowMyCouple(Properties.Settings.Default.CoupleName);
                }
                coupleNameTextBlock.Text = couple.UserName;
                var image = new Image();
                var fullFilePath = couple.UserPhotoUrl;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                coupleImage.Source = bitmap;
            }
            catch
            {
                MessageBox.Show("Try another time.");
                this.Close();
            }
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
