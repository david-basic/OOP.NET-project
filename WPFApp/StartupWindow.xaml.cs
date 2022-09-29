using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private const string HR = "hr", EN = "en";

        public StartupWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCulture(EN);
            FillDdlsWithData();
            SetIndexesToZero();
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
            ddlResolution.Items.Add(Properties.Resources.res1080p);
            ddlResolution.Items.Add(Properties.Resources.res720p);
            ddlResolution.Items.Add(Properties.Resources.res480p);
        }

        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            //ResetUI();
        }
        private void ResetUI()
        {
            
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
