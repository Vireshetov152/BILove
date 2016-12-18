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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Authorize(object sender, RoutedEventArgs e)
        {
            var vkApi = LogicClassesFactory.Default.GetVKApiManager();
            try
            {
                vkApi.VKAuthorization(login.Text, password.Password);
                Properties.Settings.Default.UserName = InternetManager.Instance.InfoDict["userName"];
                Properties.Settings.Default.UserPhotoUrl = InternetManager.Instance.InfoDict["userPhoto"];
                Properties.Settings.Default.Save();
                var main = WindowsFactory.Default.GetMainWindow();
                this.Close();
                main.Show();
            } catch
            {
                MessageBox.Show("Enter correct login and password");
            }
        }
    }
}
