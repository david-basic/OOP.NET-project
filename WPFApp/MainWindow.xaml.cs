﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string HR = "hr", EN = "en";
        private bool teamsWereChosen;
        private int counterFavTeam = 0;

        private Repository repo = new Repository();

        private List<Team> teams = new List<Team>();
        private List<Matches> matches = new List<Matches>();

        string filePathLanguage = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/LanguageSettings.txt";
        string filePathCurrentChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipCurrentSettings.txt";
        string filePathPreviousChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipPreviousSettings.txt";
        string filePathChosenResolution = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenResolution.txt";
        string filePathChosenTeams = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenTeams.txt";
        string filePathChosenTeamsFifaCodes = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenTeamsFifaCodes.txt";
        string filePathNotChosenTeams = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/NotChosenTeams.txt";

        string[] fifaCodes = null;

        public MainWindow()
        {
            string[] lang = File.ReadAllLines(filePathLanguage);
            SetCulture(lang[0]);

            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] resolution = File.ReadAllLines(filePathChosenResolution);
            SetChosenResolution(resolution[0]);

            string[] currentChampionship = File.ReadAllLines(filePathCurrentChampionship);
            string[] previousChampionship = File.ReadAllLines(filePathPreviousChampionship);


            if (currentChampionship[0] == previousChampionship[0])
            {
                teamsWereChosen = File.Exists(filePathChosenTeams);
                if (File.Exists(filePathChosenTeamsFifaCodes))
                {
                    fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
                }

                if (!teamsWereChosen)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    await FillTeamsList(currentChampionship);
                    Mouse.OverrideCursor = null;
                }
                else
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    GetChosenAndNotChosenTeams();
                    Mouse.OverrideCursor = null;
                }
            }
            else
            {
                ddlTeams.Items.Clear();
                tbChosenFavTeam.Clear();

                File.Delete(filePathChosenTeams);
                File.Delete(filePathChosenTeamsFifaCodes);

                previousChampionship = currentChampionship;

                SaveToFile(filePathPreviousChampionship, previousChampionship.ToList());

                Mouse.OverrideCursor = Cursors.Wait;
                await FillTeamsList(currentChampionship);
                Mouse.OverrideCursor = null;
            }

            FillDdlsWithData();
            SettingUpIndexesOnSettingsTab(currentChampionship);
        }


        private async void btnChooseFavTeam_Click(object sender, RoutedEventArgs e)
        {
            ChooseATeam();
            ddlTeams.SelectedIndex = 0;

            if (teamsWereChosen)
            {
                string[] championship = File.ReadAllLines(filePathCurrentChampionship);
                fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
                matches = await GetAllMatches(fifaCodes, championship);

                FillOpponentTeamsDdl(matches, fifaCodes);
            }
        }

        private void btnSeeFavTeamStats_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {



            MessageBox.Show($"{Properties.Resources.settingsChangeMessage}", $"{Properties.Resources.settingsChangeTitle}", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ddlLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Team load logic
        private async Task FillTeamsList(string[] championship)
        {
            teams = await repo.PrepareTeams(championship[0]);
            teams.ForEach(t => ddlTeams.Items.Add(t));
            ddlTeams.SelectedIndex = 0;
        }
        private void GetChosenAndNotChosenTeams()
        {
            string[] ChosenTeams = File.ReadAllLines(filePathChosenTeams);
            foreach (string item in ChosenTeams)
            {
                if (item != "")
                {
                    counterFavTeam++;
                    tbChosenFavTeam.AppendText($"{item}{Environment.NewLine}");
                }
            }

            string[] NotSelectedTeams = File.ReadAllLines(filePathNotChosenTeams);

            foreach (var item in NotSelectedTeams)
            {
                ddlTeams.Items.Add(item);
            }
            ddlTeams.SelectedIndex = 0;
        }
        private async void ChooseATeam()
        {

            if (teamsWereChosen)
            {
                //var tempTeam = ddlTeams.SelectedItem;
                var tempTeam = ddlTeams.SelectedItem.ToString();

                tbChosenFavTeam.Clear();
                tbChosenFavTeam.AppendText($"{ddlTeams.SelectedItem}");
                tbChosenFavTeam.AppendText(Environment.NewLine);

                string[] championship = File.ReadAllLines(filePathCurrentChampionship);

                ddlTeams.Items.Clear();

                await FillTeamsList(championship);

                ddlTeams.Items.Remove(tempTeam); // this might or might not work, jer neznam dal ce tempTeam biti prepoznat u ddl-u kao taj objekt ili ne
            }
            else
            {
                tbChosenFavTeam.AppendText($"{ddlTeams.SelectedItem}");
                tbChosenFavTeam.AppendText(Environment.NewLine);
                ddlTeams.Items.Remove(ddlTeams.SelectedItem);

                teamsWereChosen = true;
            }

            var itemsCollection = new List<string>();
            foreach (object item in ddlTeams.Items)
            {
                itemsCollection.Add(item.ToString());
            }

            SaveToFile(filePathNotChosenTeams, itemsCollection);
        }
        private void FillOpponentTeamsDdl(List<Matches> matches, string[] fifaCodes)
        {

            foreach (var match in matches)
            {
                if (match.AwayTeam.Code != fifaCodes[0])
                {

                }
                ddlOpponentTeams.Items.Add(match.AwayTeam.Code);
            }
        }
        private async Task<List<Matches>> GetAllMatches(string[] fifaCodes, string[] championship)
        {
            var tmpMatches = await repo.PrepareMatches(fifaCodes, championship[0]);
            return tmpMatches;
        }
        #endregion

        #region General methods and closing logic
        private void SetChosenResolution(string res)
        {
            char c = res.Trim().ToLower().ElementAt(0);
            switch (c)
            {
                case 'w':
                    this.WindowState = WindowState.Maximized;
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    break;
                case 'm':
                    this.Height = 720;
                    this.Width = 1280;
                    this.WindowState = WindowState.Normal;
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    break;
                case 's':
                    this.Height = 680;
                    this.Width = 920;
                    this.WindowState = WindowState.Normal;
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    break;
                case 'f':
                    this.WindowState = WindowState.Maximized;
                    this.WindowStyle = WindowStyle.None;
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    break;
            }
        }
        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        private void FillDdlsWithData()
        {
            ddlChampionship.Items.Add(Properties.Resources.men);
            ddlChampionship.Items.Add(Properties.Resources.women);

            ddlLanguage.Items.Add(Properties.Resources.en);
            ddlLanguage.Items.Add(Properties.Resources.cro);

            ddlResolution.Items.Add(Properties.Resources.fullscreen);
            ddlResolution.Items.Add(Properties.Resources.windowed);
            ddlResolution.Items.Add(Properties.Resources.medium);
            ddlResolution.Items.Add(Properties.Resources.small);
        }
        private void SettingUpIndexesOnSettingsTab(string[] currentChampionship)
        {
            if (currentChampionship[0] == "m")
            {
                ddlChampionship.SelectedIndex = 0;
            }
            else
            {
                ddlChampionship.SelectedIndex = 1;
            }

            if (Thread.CurrentThread.CurrentUICulture.Name == "en")
            {
                ddlLanguage.SelectedIndex = 0;
            }
            else
            {
                ddlLanguage.SelectedIndex = 1;
            }
        }
        private void SaveToFile(string path, List<string> content)
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(file.FullName, content);
        }

        private void Window_Closed(object sender, EventArgs e) => Application.Current.Shutdown();
        #endregion
    }
}
