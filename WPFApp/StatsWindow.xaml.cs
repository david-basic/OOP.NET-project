using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        private Repository repo = new Repository();

        private List<Matches> matches = new List<Matches>();

        private string fifaCodePath;
        private string chosenTeamPath;
        private string championshipPath;

        string[] fifaCodes = null;

        public StatsWindow(string filePathFifaCode, string filePathChosenTeam, string filePathChampionship)
        {
            this.chosenTeamPath = filePathChosenTeam;
            this.fifaCodePath = filePathFifaCode;
            this.championshipPath = filePathChampionship;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillInStats();
        }

        private async void FillInStats()
        {
            string[] championship = File.ReadAllLines(championshipPath);
            fifaCodes = File.ReadAllLines(fifaCodePath);
            matches = await GetAllMatches(fifaCodes, championship);

            ChangeLabels(matches, fifaCodes[0]);
        }
        private void ChangeLabels(List<Matches> matches, string fifaCode)
        {
            TeamNameLabelChange();

            MatchRelatedLabelsChange(matches, fifaCode);

            GoalsRelatedLabelsChange(matches, fifaCode);
        }
        private void TeamNameLabelChange()
        {
            string[] team = File.ReadAllLines(chosenTeamPath);
            lblTeam.Content = team[0];
        }
        private void GoalsRelatedLabelsChange(List<Matches> matches, string fifaCode)
        {
            long goalsGivenCnt = 0;
            long goalsTakenCnt = 0;
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    goalsGivenCnt += match.HomeTeam.Goals;
                    goalsTakenCnt += match.AwayTeam.Goals;
                }
                else if (match.AwayTeam.Code == fifaCode)
                {
                    goalsGivenCnt += match.AwayTeam.Goals;
                    goalsTakenCnt += match.HomeTeam.Goals;
                }
            }
            lblGoalsGivenNum.Content = goalsGivenCnt.ToString();
            lblGoalsTakenNum.Content = goalsTakenCnt.ToString();

            long goalDiff = goalsGivenCnt - goalsTakenCnt;

            if (goalDiff > 0)
            {
                lblGoalDiffNum.Content = "+" + goalDiff;
                lblGoalDiffNum.Foreground = Brushes.Green;
            }
            else if (goalDiff == 0)
            {
                lblGoalDiffNum.Content = goalDiff;
                lblGoalDiffNum.Foreground = Brushes.Black;
            }
            else
            {
                lblGoalDiffNum.Content = goalDiff;
                lblGoalDiffNum.Foreground = Brushes.Red;
            }
        }
        private void MatchRelatedLabelsChange(List<Matches> matches, string fifaCode)
        {
            int playedCnt = 0;
            foreach (var match in matches)
            {
                if (match.AwayTeam.Code == fifaCode || match.HomeTeam.Code == fifaCode)
                {
                    playedCnt++;
                }
            }

            lblPlayedNum.Content = playedCnt.ToString();

            int winCnt = 0;
            int lossCnt = 0;
            int drawCnt = 0;
            foreach (var match in matches)
            {
                if (fifaCode == match.AwayTeam.Code || fifaCode == match.HomeTeam.Code)
                {
                    if (match.WinnerCode == fifaCode)
                    {
                        winCnt++;
                    }
                    else if (match.WinnerCode == "Draw")
                    {
                        drawCnt++;
                    }
                    else
                    {
                        lossCnt++;
                    }
                }
            }

            lblWinsNum.Content = winCnt.ToString();
            lblLostNum.Content = lossCnt.ToString();
            lblDrawsNum.Content = drawCnt.ToString();
        }
        private async Task<List<Matches>> GetAllMatches(string[] fifaCodes, string[] championship)
        {
            var tmpMatches = await repo.PrepareMatches(fifaCodes, championship[0]);
            return tmpMatches;
        }
        private void btnCloseStats_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
