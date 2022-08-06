    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class SettingsForm : Form
    {

        private const string HR = "hr", EN = "en";

        string filePathLanguage = $"{Application.StartupPath}/MyAppFiles/LanguageSettings.txt";
        string filePathChampionship = $"{Application.StartupPath}/MyAppFiles/ChampionshipSettings.txt";
        string filePathStartup = $"{Application.StartupPath}/MyAppFiles/StartupSettings.txt";

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            SetCulture(EN);
            FillDdlsWithData();
            SetIndexesToZero();
        }

        private void SetIndexesToZero()
        {
            ddlChampionshipChoice.SelectedIndex = 0;
            ddlLanguageChoice.SelectedIndex = 0;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Restart();
        }

        private void Language_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetAndSaveLanguage();
        }


        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            ResetUI();
        }

        private void ResetUI()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        private void FillDdlsWithData()
        {
            ddlChampionshipChoice.Items.Add(Properties.Resources.men);
            ddlChampionshipChoice.Items.Add(Properties.Resources.women);

            ddlLanguageChoice.Items.Add(Properties.Resources.en);
            ddlLanguageChoice.Items.Add(Properties.Resources.cro);
        }

        private void SetAndSaveLanguage()
        {
            int currentSelectedIndex = ddlChampionshipChoice.SelectedIndex;
            if (ddlLanguageChoice.SelectedItem.ToString() == Properties.Resources.en)
            {
                SetCulture(EN);
                FillDdlsWithData();
                ddlLanguageChoice.SelectedIndex = 0;
            }
            else if (ddlLanguageChoice.SelectedItem.ToString() == Properties.Resources.cro)
            {
                SetCulture(HR);
                FillDdlsWithData();
                ddlLanguageChoice.SelectedIndex = 1;
            }
            ddlChampionshipChoice.SelectedIndex = currentSelectedIndex;

            var language = new List<string>();

            language.Add($"{Thread.CurrentThread.CurrentUICulture.Name}");

            try
            {
                if (File.Exists(filePathLanguage))
                {
                    File.Delete(filePathLanguage);
                }
                SaveToFile(filePathLanguage, language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveSettings()
        {
            var lines = new List<string>();
            var langLines = new List<string>();
            var champLines = new List<string>();

            char champLetter = ddlChampionshipChoice.SelectedItem.ToString().Trim().ToLower().ElementAt(0);

            if (champLetter == 'ž')
            {
                champLetter = 'w';
            }

            lines.Add($"{champLetter}|{Thread.CurrentThread.CurrentUICulture.Name}");
            langLines.Add($"{Thread.CurrentThread.CurrentUICulture.Name}");


            champLines.Add($"{champLetter}");

            try
            {
                SaveToFile(filePathChampionship, champLines);

                SaveToFile(filePathLanguage, langLines);

                SaveToFile(filePathStartup, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
