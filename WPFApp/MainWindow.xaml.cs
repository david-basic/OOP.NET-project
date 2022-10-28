using DataLayer;
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
using WinFormsApp;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants
        private const string HR = "hr", EN = "en";
        #endregion

        #region Fields
        private bool teamsWereChosen;
        private bool opponentsWereChosen;
        private Repository repo = new Repository();
        private List<Team> teams = new List<Team>();
        private List<Matches> matches = new List<Matches>();
        private List<StartingEleven> favTeamPlayers = new List<StartingEleven>();
        private List<StartingEleven> opponentTeamPlayers = new List<StartingEleven>();
        private List<StartingEleven> allStartingPlayers = new List<StartingEleven>();
        private HashSet<PlayerUC> favPlayerUCs = new HashSet<PlayerUC>();
        private HashSet<PlayerUC> opponentPlayerUCs = new HashSet<PlayerUC>();
        string[] fifaCodes = null;
        #endregion

        #region Paths
        string filePathLanguage = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/LanguageSettings.txt";
        string filePathCurrentChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipCurrentSettings.txt";
        string filePathPreviousChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipPreviousSettings.txt";
        string filePathChosenResolution = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenResolution.txt";
        string filePathChosenTeams = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenTeams.txt";
        string filePathPreviousTeams = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/PreviousChosenTeams.txt";
        string filePathChosenTeamsFifaCodes = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenTeamsFifaCodes.txt";
        string filePathNotChosenTeams = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/NotChosenTeams.txt";
        string filePathNotChosenOpponents = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/NotChosenOpponents.txt";
        string filePathChosenOpponents = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenOpponents.txt";
        string filePathChosenOpponentsFifaCodes = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenOpponentsFifaCodes.txt";
        #endregion

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
                    await FillOpponentTeams();
                    Mouse.OverrideCursor = null;

                    btnSeeTeamStats.IsEnabled = true;
                    btnChooseOpponentTeam.IsEnabled = true;
                    ddlOpponentTeams.IsEnabled = true;
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
            SettingUpIndexesOnSettingsTab(currentChampionship, resolution[0]);
        }

        #region Teams methods and logic
        private async void btnChooseFavTeam_Click(object sender, RoutedEventArgs e)
        {
            ChooseATeam();

            ddlTeams.SelectedIndex = 0;

            if (teamsWereChosen)
            {
                await FillOpponentTeams();
            }
            btnChooseOpponentTeam.IsEnabled = true;
            ddlOpponentTeams.IsEnabled = true;
            btnSeeTeamStats.IsEnabled = true;
            btnSeeOpponentTeamStats.IsEnabled = false;
        }
        private void btnChooseOpponentTeam_Click(object sender, RoutedEventArgs e)
        {
            ClearPlayingArea();

            ChooseAOpponent();
            ddlOpponentTeams.SelectedIndex = 0;

            ShowMatchResult(filePathChosenTeamsFifaCodes, filePathChosenOpponentsFifaCodes, matches);
            btnSeeOpponentTeamStats.IsEnabled = true;

            AddOpponentTeamPlayerUCs(filePathChosenTeamsFifaCodes, filePathChosenOpponentsFifaCodes, matches);
        }
        private async void AddOpponentTeamPlayerUCs(string pathFavTeamCode, string pathOpponentTeamCode, List<Matches> matches)
        {
            string[] favTeamCode = File.ReadAllLines(pathFavTeamCode);
            string[] opponentCode = File.ReadAllLines(pathOpponentTeamCode);
            string[] championship = File.ReadAllLines(filePathCurrentChampionship);
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == favTeamCode[0] && match.AwayTeam.Code == opponentCode[0])
                {
                    allStartingPlayers = await GetStartingElevenPlayers(favTeamCode, opponentCode, championship);

                    break;
                }
                else if (match.AwayTeam.Code == favTeamCode[0] && match.HomeTeam.Code == opponentCode[0])
                {
                    allStartingPlayers = await GetStartingElevenPlayers(favTeamCode, opponentCode, championship);

                    break;
                }
            }

            int i = 0;
            allStartingPlayers.ForEach(p =>
            {
                if (i < 11)
                {
                    favTeamPlayers.Add(p);
                }
                else
                {
                    opponentTeamPlayers.Add(p);
                }
                i++;
            });
            
            favTeamPlayers.ForEach(player =>
            {
                PlayerUC plUC = new PlayerUC();
                plUC.FullName = player.FullName;
                plUC.ShirtNumber = player.ShirtNumber;
                plUC.Position = player.Position;

                plUC.BtnPlayerUC.Click += BtnPlayerUC_Click;

                if (player.Position == "Goalie")
                {
                    goalieAreaFavTeam.Children.Add(plUC);
                }
                else if (player.Position == "Defender")
                {
                    defenderAreaFavTeam.Children.Add(plUC);
                }
                else if (player.Position == "Midfield")
                {
                    midfielderAreaFavTeam.Children.Add(plUC);
                }
                else if (player.Position == "Forward")
                {
                    forwardAreaFavTeam.Children.Add(plUC);
                }
            });

            opponentTeamPlayers.ForEach(player =>
            {
                PlayerUC plUC = new PlayerUC();
                plUC.FullName = player.FullName;
                plUC.ShirtNumber = player.ShirtNumber;
                plUC.Position = player.Position;

                plUC.BtnPlayerUC.Click += BtnPlayerUC_Click;

                if (player.Position == "Goalie")
                {
                    goalieAreaOpponentTeam.Children.Add(plUC);
                }
                else if (player.Position == "Defender")
                {
                    defenderAreaOpponentTeam.Children.Add(plUC);
                }
                else if (player.Position == "Midfield")
                {
                    midfielderAreaOpponentTeam.Children.Add(plUC);
                }
                else if (player.Position == "Forward")
                {
                    forwardAreaOpponentTeam.Children.Add(plUC);
                }
            });
        }

        private void BtnPlayerUC_Click(object sender, RoutedEventArgs e)
        {
            // ovdje ces otvarati prozor sa extra detaljima igraca 
        }

        private async Task<List<StartingEleven>> GetStartingElevenPlayers(string[] favTeamCode, string[] opponentTeamCode, string[] championship)
        {
            var tmpPlayers = await repo.PrepareStartingElevenForAMatch(favTeamCode, opponentTeamCode, championship[0]);
            return tmpPlayers;
        }
        private void ClearPlayingArea()
        {
            favTeamPlayers.Clear();
            opponentTeamPlayers.Clear();
            goalieAreaFavTeam.Children.Clear();
            goalieAreaOpponentTeam.Children.Clear();
            midfielderAreaFavTeam.Children.Clear();
            midfielderAreaOpponentTeam.Children.Clear();
            forwardAreaFavTeam.Children.Clear();
            forwardAreaOpponentTeam.Children.Clear();
        }
        private void ShowMatchResult(string pathMainTeamCode, string pathOpponentCode, List<Matches> matches)
        {
            string[] mainTeamCode = File.ReadAllLines(pathMainTeamCode);
            string[] OpponentCode = File.ReadAllLines(pathOpponentCode);

            foreach (var match in matches)
            {
                long homeTeamGoalsAgg = match.HomeTeam.Goals + match.HomeTeam.Penalties;
                long awayTeamGoalsAgg = match.AwayTeam.Goals + match.AwayTeam.Penalties;

                if (match.HomeTeam.Code == mainTeamCode[0] && match.AwayTeam.Code == OpponentCode[0])
                {
                    lblChosenTeamResult.Content = homeTeamGoalsAgg.ToString();
                    lblOpponentTeamResult.Content = awayTeamGoalsAgg.ToString();
                }
                else if (match.HomeTeam.Code == OpponentCode[0] && match.AwayTeam.Code == mainTeamCode[0])
                {
                    lblChosenTeamResult.Content = awayTeamGoalsAgg.ToString();
                    lblOpponentTeamResult.Content = homeTeamGoalsAgg.ToString();
                }
            }
            matchResultGrid.Visibility = Visibility.Visible;
        }
        private void btnSeeFavTeamStats_Click(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow(filePathChosenTeamsFifaCodes, filePathChosenTeams, filePathCurrentChampionship);
            statsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            statsWindow.ShowDialog();
        }
        private void btnSeeOpponentTeamStats_Click(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow(filePathChosenOpponentsFifaCodes, filePathChosenOpponents, filePathCurrentChampionship);
            statsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            statsWindow.ShowDialog();
        }
        private async Task FillTeamsList(string[] championship)
        {
            teams = await repo.PrepareTeams(championship[0]);
            teams.ForEach(t => ddlTeams.Items.Add(t));
            ddlTeams.SelectedIndex = 0;
        }
        private async Task FillOpponentTeams()
        {
            string[] championship = File.ReadAllLines(filePathCurrentChampionship);
            fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
            matches = await GetAllMatches(fifaCodes, championship);

            FillOpponentTeamsDdl(matches, fifaCodes);
        }
        private void GetChosenAndNotChosenTeams()
        {
            string[] ChosenTeams = File.ReadAllLines(filePathChosenTeams);
            foreach (string item in ChosenTeams)
            {
                if (item != "")
                {
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
        private void ChooseATeam()
        {

            if (teamsWereChosen)
            {
                string tempOldTeam = tbChosenFavTeam.GetLineText(0).Trim();

                tbChosenFavTeam.Clear();
                tbChosenFavTeam.AppendText($"{ddlTeams.SelectedItem}");
                tbChosenFavTeam.AppendText(Environment.NewLine);
                ddlTeams.Items.Remove(ddlTeams.SelectedItem);

                ddlTeams.Items.Add(tempOldTeam);

                FileInfo file = new FileInfo(filePathPreviousTeams);
                file.Directory.Create();
                File.WriteAllText(filePathPreviousTeams, tempOldTeam);
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

            SaveTeams();

            string[] tempChosenTeams = File.ReadAllLines(filePathChosenTeams);
            if (!File.Exists(filePathPreviousTeams))
            {
                SaveToFile(filePathPreviousTeams, tempChosenTeams.ToList());
            }

            opponentsWereChosen = false;
        }
        private void ChooseAOpponent()
        {
            if (opponentsWereChosen)
            {
                string tempOldOpponent = tbChosenOpponentTeam.GetLineText(0).Trim();

                tbChosenOpponentTeam.Clear();
                tbChosenOpponentTeam.AppendText($"{ddlOpponentTeams.SelectedItem}");
                ddlOpponentTeams.Items.Remove(ddlOpponentTeams.SelectedItem);

                ddlOpponentTeams.Items.Add(tempOldOpponent);
            }
            else
            {
                tbChosenOpponentTeam.AppendText($"{ddlOpponentTeams.SelectedItem}");
                ddlOpponentTeams.Items.Remove(ddlOpponentTeams.SelectedItem);

                opponentsWereChosen = true;
            }

            var itemsCollection = new List<string>();
            foreach (object item in ddlOpponentTeams.Items)
            {
                itemsCollection.Add(item.ToString());
            }

            SaveToFile(filePathNotChosenOpponents, itemsCollection);

            SaveOpponents();
        }
        private void SaveTeams()
        {
            var lineCollection = new List<string>();

            string line = tbChosenFavTeam.GetLineText(0);

            lineCollection.Add(line);

            SaveToFile(filePathChosenTeams, lineCollection);

            var fifaCodeCollection = new List<string>();
            foreach (var l in lineCollection)
            {
                if (l != "")
                {
                    var fifaCode = l.ToString().Split('(', ')')[1];
                    fifaCodeCollection.Add(fifaCode);
                }
            }
            SaveToFile(filePathChosenTeamsFifaCodes, fifaCodeCollection);
        }
        private void SaveOpponents()
        {
            var lineCollection = new List<string>();

            string line = tbChosenOpponentTeam.GetLineText(0);

            lineCollection.Add(line);

            SaveToFile(filePathChosenOpponents, lineCollection);

            var fifaCodeCollection = new List<string>();
            foreach (var l in lineCollection)
            {
                if (l != "")
                {
                    var fifaCode = l.ToString().Split('(', ')')[1];
                    fifaCodeCollection.Add(fifaCode);
                }
            }
            SaveToFile(filePathChosenOpponentsFifaCodes, fifaCodeCollection);

        }
        private void FillOpponentTeamsDdl(List<Matches> matches, string[] fifaCodes)
        {
            string[] previousTeam = File.ReadAllLines(filePathPreviousTeams);
            string[] currentTeam = File.ReadAllLines(filePathChosenTeams);

            if (currentTeam[0] != previousTeam[0])
            {
                ddlOpponentTeams.Items.Clear();
                tbChosenOpponentTeam.Clear();
            }

            foreach (var match in matches)
            {
                if (match.AwayTeam.Code != fifaCodes[0])
                {
                    ddlOpponentTeams.Items.Add($"{match.AwayTeam.Country} ({match.AwayTeam.Code})");
                }
                else if (match.HomeTeam.Code != fifaCodes[0])
                {
                    ddlOpponentTeams.Items.Add($"{match.HomeTeam.Country} ({match.HomeTeam.Code})");
                }
            }

            ddlOpponentTeams.SelectedIndex = 0;
        }
        #endregion

        #region Settings tab methods and logic
        private void ddlLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ddlLanguage.SelectedItem.ToString() == Properties.Resources.en)
            {
                SetCulture(EN);
            }
            else if (ddlLanguage.SelectedItem.ToString() == Properties.Resources.cro)
            {
                SetCulture(HR);
            }
        }
        private void SettingUpIndexesOnSettingsTab(string[] currentChampionship, string resolution)
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

            char c = resolution.Trim().ToLower().ElementAt(0);
            switch (c)
            {
                case 'w':
                    ddlResolution.SelectedIndex = 1;
                    break;
                case 'm':
                    ddlResolution.SelectedIndex = 2;
                    break;
                case 's':
                    ddlResolution.SelectedIndex = 3;
                    break;
                case 'f':
                    ddlResolution.SelectedIndex = 0;
                    break;
            }

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            MessageBox.Show($"{Properties.Resources.settingsMainWindowMessage}", $"{Properties.Resources.settingsMainWindowTitle}", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region General methods and closing logic
        private async Task<List<Matches>> GetAllMatches(string[] fifaCodes, string[] championship)
        {
            var tmpMatches = await repo.PrepareMatches(fifaCodes, championship[0]);
            return tmpMatches;
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
        private void SaveToFile(string path, List<string> content)
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(file.FullName, content);
        }
        private void SaveSettings()
        {
            var langLines = new List<string>();
            var champLines = new List<string>();
            var prevChampLines = new List<string>();
            var resolutionLines = new List<string>();

            char champLetter = ddlChampionship.SelectedItem.ToString().Trim().ToLower().ElementAt(0);

            string[] prevChamp = File.ReadAllLines(filePathCurrentChampionship);

            char prevChampLetter = prevChamp[0].Trim()[0];

            //char prevChampLetter = ddlChampionship.SelectedItem.ToString().Trim().ToLower().ElementAt(0);

            if (champLetter == 'ž')
            {
                champLetter = 'w';
            }

            if (prevChampLetter == 'ž')
            {
                prevChampLetter = 'w';
            }

            langLines.Add($"{Thread.CurrentThread.CurrentUICulture.Name}");

            champLines.Add($"{champLetter}");
            prevChampLines.Add($"{prevChampLetter}");

            resolutionLines.Add($"{ddlResolution.SelectedItem.ToString().ToLower()}");

            if (resolutionLines.First().ToString().Trim().ToLower().ElementAt(0) == 'p')
            {
                resolutionLines.Clear();
                resolutionLines.Add("fullscreen");
            }

            try
            {
                SaveToFile(filePathCurrentChampionship, champLines);

                SaveToFile(filePathPreviousChampionship, prevChampLines);

                SaveToFile(filePathLanguage, langLines);

                SaveToFile(filePathChosenResolution, resolutionLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_Closed(object sender, EventArgs e) => Application.Current.Shutdown();
        #endregion
    }
}
