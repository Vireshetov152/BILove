using BILoveModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BILove
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (string.IsNullOrEmpty(BILove.Properties.Settings.Default.UserName))
            {
                var login = new AuthorizationWindow();
                login.Show();
            }
            else if (BILove.Properties.Settings.Default.InterestsAreChosen != true)
            {
                InternetManager.Instance.InfoDict["userName"] = BILove.Properties.Settings.Default.UserName;
                InternetManager.Instance.InfoDict["userPhoto"] = BILove.Properties.Settings.Default.UserPhotoUrl;
                var mainView = new MainWindow();
                mainView.Show();
            }
            else
            {
                InternetManager.Instance.InfoDict["userName"] = BILove.Properties.Settings.Default.UserName;
                InternetManager.Instance.InfoDict["userPhoto"] = BILove.Properties.Settings.Default.UserPhotoUrl;
                var resultsWindow = new ResultsWindow();
                resultsWindow.Show();
                BILove.Properties.Settings.Default.Reset();
            }
        }
    }
}
