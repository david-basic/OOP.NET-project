using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string HR = "hr", EN = "en";

        string filePathLanguage = "MyAppFiles/LanguageSettings.txt";
        string filePathCurrentChampionship = "MyAppFiles/ChampionshipCurrentSettings.txt";
        string filePathPreviousChampionship = "MyAppFiles/ChampionshipPreviousSettings.txt";
        string filePathChosenResolution = "MyAppFiles/ChosenResolution.txt";

        public MainWindow()
        {
            string[] lang = File.ReadAllLines(filePathLanguage);
            SetCulture(lang[0]);

            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] resolution = File.ReadAllLines(filePathChosenResolution);
            SetChosenResolution(resolution[0]);


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
                    this.Height = 480;
                    this.Width = 720;
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

        private void Window_Closed(object sender, EventArgs e) => Application.Current.Shutdown();
    }
}
