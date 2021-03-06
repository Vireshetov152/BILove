﻿using BILoveModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BILove
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> results;
        public MainWindow()
        {
            InitializeComponent();
            results = new List<string>();
        }

        public void AddCategory(string categoryName, string photoName, Image image)
        {
            if (!results.Contains(categoryName))
            {
                results.Add(categoryName);
                image.Source = new BitmapImage(new Uri(@"/Pictures/"+photoName+"_color.png", UriKind.Relative));
            }
            else
            {
                results.Remove(categoryName);
                image.Source = new BitmapImage(new Uri(@"/Pictures/"+photoName+".png", UriKind.Relative));
            }
        }
        private void chooseSports(object sender, RoutedEventArgs e)
        {
            AddCategory("Sports", "sports", sportsImage);
        }

        private void chooseTravelling(object sender, RoutedEventArgs e)
        {
            AddCategory("Travelling", "travelling", travellingImage);
        }

        private void chooseGames(object sender, RoutedEventArgs e)
        {
            AddCategory("Games", "games", gamesImage);
        }

        private void chooseDancing(object sender, RoutedEventArgs e)
        {
            AddCategory("Dancing", "dancing", dancingImage);
        }

        private void chooseScience(object sender, RoutedEventArgs e)
        {
            AddCategory("Science", "science", scienceImage);
        }

        private void choosePhoto(object sender, RoutedEventArgs e)
        {
            AddCategory("Photo", "photography", photoImage);
        }

        private void chooseMusic(object sender, RoutedEventArgs e)
        {
            AddCategory("Music", "music", musicImage);
        }

        private void chooseIT(object sender, RoutedEventArgs e)
        {
            AddCategory("IT", "technology", ITImage);
        }

        private void chooseShopping(object sender, RoutedEventArgs e)
        {
            AddCategory("Shopping", "shopping", shoppingImage);
        }

        private void chooseGambling(object sender, RoutedEventArgs e)
        {
            AddCategory("Gambling", "gambling", gamblingImage);
        }

        private void chooseArt(object sender, RoutedEventArgs e)
        {
            AddCategory("Art", "art", artImage);
        }

        private void chooseFood(object sender, RoutedEventArgs e)
        {
            AddCategory("Food", "food", foodImage);
        }

        private void sendResults(object sender, RoutedEventArgs e)
        {
            if (results.Count() >= 3)
            {
                InternetManager.Instance.GetInterests(results);
                var req = LogicClassesFactory.Default.GetRequests();
                req.AddUser();
                Properties.Settings.Default.InterestsAreChosen = true;
                Properties.Settings.Default.Save();
                var cf = LogicClassesFactory.Default.GetCoupleFinder();
                var resultsWindow = WindowsFactory.Default.GetResultsWindow();
                resultsWindow.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Choose at least 3 interests");
            }  
        }
    }
}
