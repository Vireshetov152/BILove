﻿using System;
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
            var identity = 2;
            if (identity == 2)
            {
                AuthorizationWindow login = new AuthorizationWindow();
                login.Show();
            }
            else
            {
                MainWindow mainView = new MainWindow();
                mainView.Show();
            }
        }
    }
}
