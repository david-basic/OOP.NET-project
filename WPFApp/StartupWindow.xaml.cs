using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
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
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private const string HR = "hr", EN = "en";
        private bool isResolutionMissing = false;

        string filePathLanguage = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/LanguageSettings.txt";
        string filePathCurrentChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipCurrentSettings.txt";
        string filePathPreviousChampionship = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChampionshipPreviousSettings.txt";
        string filePathChosenResolution = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ChosenResolution.txt";

        public StartupWindow()
        {
            if (File.Exists(filePathLanguage) && File.Exists(filePathCurrentChampionship))
            {
                string[] lang = File.ReadAllLines(filePathLanguage);
                SetCulture(lang[0]);

                if (File.Exists(filePathChosenResolution))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mainWindow.Show();

                    this.Hide();
                }
                else
                {
                    isResolutionMissing = true;
                }
            }
            else
            {
                SetCulture(EN);
            }

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDdlsWithData();

            if (isResolutionMissing)
            {
                string[] currentChampionship = File.ReadAllLines(filePathCurrentChampionship);

                if (currentChampionship[0] == "m")
                {
                    ddlChampionship.SelectedIndex = 0;
                }
                else
                {
                    ddlChampionship.SelectedIndex = 1;
                }

                this.ddlChampionship.IsEnabled = false;
                this.ddlLanguage.IsEnabled = false;
                ddlResolution.SelectedIndex = 0;

                if (Thread.CurrentThread.CurrentUICulture.Name == "en")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 1;
                }

                MessageBox.Show($"{Properties.Resources.chooseResolutionMessage}", $"{Properties.Resources.chooseResolutionCaption}", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.ddlChampionship.IsEnabled = true;
                this.ddlLanguage.IsEnabled = true;
                SetIndexesToZero();
            }
        }

        private void SetIndexesToZero()
        {
            ddlChampionship.SelectedIndex = 0;
            ddlLanguage.SelectedIndex = 0;
            ddlResolution.SelectedIndex = 0;
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

        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"{Properties.Resources.settingsChangeMessage}", $"{Properties.Resources.settingsChangeTitle}", MessageBoxButton.OK, MessageBoxImage.Warning);

            SaveSettings();

            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();

            this.Hide();
        }

        private void SaveSettings()
        {
            var langLines = new List<string>();
            var champLines = new List<string>();
            var resolutionLines = new List<string>();

            char champLetter = ddlChampionship.SelectedItem.ToString().Trim().ToLower().ElementAt(0);

            if (champLetter == 'ž')
            {
                champLetter = 'w';
            }

            langLines.Add($"{Thread.CurrentThread.CurrentUICulture.Name}");

            champLines.Add($"{champLetter}");

            resolutionLines.Add($"{ddlResolution.SelectedItem.ToString().ToLower()}");

            if (resolutionLines.First().ToString().Trim().ToLower().ElementAt(0) == 'p')
            {
                resolutionLines.Clear();
                resolutionLines.Add("fullscreen");
            }

            try
            {
                SaveToFile(filePathCurrentChampionship, champLines);

                SaveToFile(filePathPreviousChampionship, champLines);

                SaveToFile(filePathLanguage, langLines);

                SaveToFile(filePathChosenResolution, resolutionLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAndSaveLanguage();
        }

        private void SetAndSaveLanguage()
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

        private void SaveToFile(string path, List<string> content)
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(file.FullName, content);
        }
    }
}
