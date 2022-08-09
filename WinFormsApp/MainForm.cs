using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private bool thereAreLoadedPlayers;
        private bool teamsWereChosen;
        private bool playersWereChosen;
        private const int INIT_FAV_TEAMS_NUM = 1;
        private const int INIT_FAV_PLAYERS_NUM = 3;
        private const string HR = "hr", EN = "en";
        private int counterFavTeam = 0;
        private int globalCounterSelectedPlayers = 0;

        private Repository repo = new Repository();

        private List<Team> teams = new List<Team>();
        private List<StartingEleven> players = new List<StartingEleven>();
        private List<PlayerUC> selectedPlayersUC = new List<PlayerUC>();
        private List<Matches> matches = new List<Matches>();
        private HashSet<PlayerUC> allPlayers = new HashSet<PlayerUC>();
        private HashSet<PlayerUC> favPlayers = new HashSet<PlayerUC>();
        private HashSet<RankingPlayerUC> nonFavRankingPanelPlayers = new HashSet<RankingPlayerUC>();
        private HashSet<RankingPlayerUC> favRankingPanelPlayers = new HashSet<RankingPlayerUC>();
        private HashSet<RankingPlayerUC> allRankingPanelPlayers = new HashSet<RankingPlayerUC>();

        string filePathLanguage = $"{Application.StartupPath}/MyAppFiles/LanguageSettings.txt";
        string filePathCurrentChampionship = $"{Application.StartupPath}/MyAppFiles/ChampionshipCurrentSettings.txt";
        string filePathPreviousChampionship = $"{Application.StartupPath}/MyAppFiles/ChampionshipPreviousSettings.txt";
        string filePathChosenTeams = $"{Application.StartupPath}/MyAppFiles/ChosenTeams.txt";
        string filePathChosenTeamsFifaCodes = $"{Application.StartupPath}/MyAppFiles/ChosenTeamsFifaCodes.txt";
        string filePathNotChosenTeams = $"{Application.StartupPath}/MyAppFiles/NotChosenTeams.txt";
        string filePathChosenPlayers = $"{Application.StartupPath}/MyAppFiles/ChosenPlayers.txt";
        string filePathNotChosenPlayers = $"{Application.StartupPath}/MyAppFiles/NotChosenPlayers.txt";
        string filePathStartup = $"{Application.StartupPath}/MyAppFiles/StartupSettings.txt";

        string[] fifaCodes = null;

        public MainForm()
        {
            string[] lang = File.ReadAllLines(filePathLanguage);
            SetCulture(lang[0]);

            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {

            tabRanking.Enabled = false;

            string[] currentChampionship = File.ReadAllLines(filePathCurrentChampionship);
            string[] previousChampionship = File.ReadAllLines(filePathPreviousChampionship);
            if (currentChampionship[0] == previousChampionship[0])
            {
                teamsWereChosen = File.Exists(filePathChosenTeams);
                playersWereChosen = File.Exists(filePathChosenPlayers);

                if (File.Exists(filePathChosenTeamsFifaCodes))
                {
                    fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
                }

                if (!teamsWereChosen)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    await FillTeamsList(currentChampionship);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GetChosenAndNotChosenTeams();
                    players = await GetAllPlayers(fifaCodes, currentChampionship);

                    if (playersWereChosen)
                    {
                        GetChosenAndNotChosenPlayers();

                        if (favPlayers.Count >= INIT_FAV_PLAYERS_NUM)
                        {
                            pnlAllPlayers.Enabled = false;
                        }
                    }
                    else
                    {
                        FillAllPlayersPanelWithPlayerUCs();
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                ddlTeams.Items.Clear();
                txtChosenFavTeams.Clear();
                pnlFavouritePlayers.Controls.Clear();
                pnlAllPlayers.Controls.Clear();

                File.Delete(filePathChosenTeams);
                File.Delete(filePathChosenPlayers);
                File.Delete(filePathChosenTeamsFifaCodes);

                previousChampionship = currentChampionship;

                SaveToFile(filePathPreviousChampionship, previousChampionship.ToList());

                Cursor.Current = Cursors.WaitCursor;
                await FillTeamsList(currentChampionship);
                Cursor.Current = Cursors.Default;
            }

            //Settings tab ddls
            FillDdlsWithData();
            SetIndexesToZero();
        }

        //Culture
        #region
        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        private void ResetUI()
        {
            this.Controls.Clear();
            InitializeComponent();
        }
        #endregion

        //Events
        #region
        private async void BtnChoose_Click(object sender, EventArgs e)
        {
            thereAreLoadedPlayers = false;
            ChooseATeam();
            ddlTeams.SelectedIndex = 0;

            string[] championship = File.ReadAllLines(filePathCurrentChampionship);
            if (txtChosenFavTeams.Text.Length != 0 ^ thereAreLoadedPlayers)
            {
                fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
                players = await GetAllPlayers(fifaCodes, championship);
                FillAllPlayersPanelWithPlayerUCs();
            }
        }
        private void AddToFavourites_Click(object sender, EventArgs e)
        {
            if (favPlayers.Count >= INIT_FAV_PLAYERS_NUM)
            {
                MessageBox.Show($"Can not choose more than {INIT_FAV_PLAYERS_NUM} at this time.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var player in selectedPlayersUC)
            {
                bool isNotFavAlready = true;
                foreach (var fav in favPlayers)
                {
                    if (player.FullName == fav.FullName)
                    {
                        isNotFavAlready = false;
                    }
                }

                if (isNotFavAlready)
                {
                    player.BorderStyle = BorderStyle.FixedSingle;
                    player.BackColor = Color.WhiteSmoke;
                    player.Favourite = true;
                    pnlAllPlayers.Controls.Remove(player);
                    allPlayers.Remove(player);
                    pnlFavouritePlayers.Controls.Add(player);
                    favPlayers.Add(player);
                }
            }

            if (favPlayers.Count >= INIT_FAV_PLAYERS_NUM)
            {
                pnlAllPlayers.VerticalScroll.Value = 0;
                pnlAllPlayers.Enabled = false;
            }
            else
            {
                pnlAllPlayers.Enabled = true;
            }

            selectedPlayersUC.Clear();
            globalCounterSelectedPlayers = 0;

            List<string> tmp = new List<string>();
            favPlayers.ToList().ForEach(p => tmp.Add(p.FullName));
            SaveToFile(filePathChosenPlayers, tmp);

            tmp.Clear();
            allPlayers.ToList().ForEach(p => tmp.Add(p.FullName));
            SaveToFile(filePathNotChosenPlayers, tmp);

        }
        private void RemoveFromFavourites_Click(object sender, EventArgs e)
        {
            foreach (var player in selectedPlayersUC)
            {
                player.BorderStyle = BorderStyle.FixedSingle;
                player.BackColor = Color.WhiteSmoke;
                player.Favourite = false;
                pnlFavouritePlayers.Controls.Remove(player);
                favPlayers.Remove(player);
                pnlAllPlayers.Controls.Add(player);
                allPlayers.Add(player);
            }

            if (favPlayers.Count < INIT_FAV_PLAYERS_NUM)
            {
                pnlAllPlayers.Enabled = true;
            }
            selectedPlayersUC.Clear();
            globalCounterSelectedPlayers = 0;

            List<string> tmp = new List<string>();
            favPlayers.ToList().ForEach(p => tmp.Add(p.FullName));
            SaveToFile(filePathChosenPlayers, tmp);

            tmp.Clear();
            allPlayers.ToList().ForEach(p => tmp.Add(p.FullName));
            SaveToFile(filePathNotChosenPlayers, tmp);
        }
        private void PlayerUC_Click(object sender, EventArgs e)
        {
            PlayerUC clickedPlayerUC = sender as PlayerUC;

            if ((favPlayers.Count + globalCounterSelectedPlayers) >= INIT_FAV_PLAYERS_NUM)
            {

                bool isNewPlayer = true;
                foreach (var player in selectedPlayersUC)
                {
                    if (player.FullName == clickedPlayerUC.FullName)
                    {
                        isNewPlayer = false;
                        break;
                    }
                }

                if (isNewPlayer)
                {
                    foreach (var player in favPlayers)
                    {
                        if (player.FullName == clickedPlayerUC.FullName)
                        {
                            isNewPlayer = false;
                            break;
                        }
                    }
                }

                if (isNewPlayer)
                {
                    MessageBox.Show($"Can not choose more than {INIT_FAV_PLAYERS_NUM} at this time.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (var player in selectedPlayersUC)
            {
                if (player.FullName == clickedPlayerUC.FullName)
                {
                    clickedPlayerUC.BorderStyle = BorderStyle.FixedSingle;
                    clickedPlayerUC.BackColor = Color.WhiteSmoke;
                    selectedPlayersUC.Remove(clickedPlayerUC);
                    globalCounterSelectedPlayers--;
                    return;
                }
            }

            clickedPlayerUC.BorderStyle = BorderStyle.Fixed3D;
            clickedPlayerUC.BackColor = Color.DeepSkyBlue;

            selectedPlayersUC.Add(clickedPlayerUC);
            globalCounterSelectedPlayers++;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private async void BtnSaveInitialSetup_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure? You will not be able to change favourite players or their images immediately.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {
                pnlStartingSetup.Enabled = false;
                MessageBox.Show("Ranking tab has been enabled.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string[] championship = File.ReadAllLines(filePathCurrentChampionship);
                fifaCodes = File.ReadAllLines(filePathChosenTeamsFifaCodes);
                matches = await GetAllMatches(fifaCodes, championship);

                FillPlayerRankingPanel(matches);
                FillTeamRankingPanel(matches);

                tabRanking.Enabled = true;
            }
        }
        private void BtnSortByGoals_Click(object sender, EventArgs e)
        {
            pnlPlayersRanking.Controls.Clear();

            List<RankingPlayerUC> allRankingPlayerUCs = allRankingPanelPlayers.ToList();

            allRankingPlayerUCs.Sort();
            allRankingPlayerUCs.ForEach(plUC => pnlPlayersRanking.Controls.Add(plUC));

            btnSortByGoals.Enabled = false;
            btnSortByYellowCards.Enabled = true;
            btnSortByFavourite.Enabled = true;
        }
        private void BtnSortByYellowCards_Click(object sender, EventArgs e)
        {
            pnlPlayersRanking.Controls.Clear();

            List<RankingPlayerUC> allRankingPlayerUCs = allRankingPanelPlayers.ToList();

            allRankingPlayerUCs.Sort((x, y) => -x.YellowCards.CompareTo(y.YellowCards));
            allRankingPlayerUCs.ForEach(plUC => pnlPlayersRanking.Controls.Add(plUC));

            btnSortByGoals.Enabled = true;
            btnSortByYellowCards.Enabled = false;
            btnSortByFavourite.Enabled = true;
        }
        private void BtnSortByFavourite_Click(object sender, EventArgs e)
        {
            pnlPlayersRanking.Controls.Clear();

            List<RankingPlayerUC> allRankingPlayerUCs = allRankingPanelPlayers.ToList();

            allRankingPlayerUCs.Sort((x, y) => -x.Favourite.CompareTo(y.Favourite));
            allRankingPlayerUCs.ForEach(plUC => pnlPlayersRanking.Controls.Add(plUC));

            btnSortByGoals.Enabled = true;
            btnSortByYellowCards.Enabled = true;
            btnSortByFavourite.Enabled = false;
        }
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet implemented.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        //Ranking tab methods
        #region
        //Players
        private void FillPlayerRankingPanel(List<Matches> matches)
        {
            string[] ChosenPlayers = File.ReadAllLines(filePathChosenPlayers);
            foreach (string playerName in ChosenPlayers)
            {
                if (playerName != "")
                {
                    RankingPlayerUC rankPlUC = new RankingPlayerUC();

                    foreach (var pl in players)
                    {
                        if (pl.FullName == playerName)
                        {
                            rankPlUC.FullName = pl.FullName;
                            rankPlUC.Captain = pl.Captain;
                            rankPlUC.ShirtNumber = pl.ShirtNumber;
                            rankPlUC.Favourite = true;
                            rankPlUC.Goals = GetPlayerGoals(pl.FullName, matches);
                            rankPlUC.YellowCards = GetPlayerYellowCards(pl.FullName, matches);
                        }
                    }
                    favRankingPanelPlayers.Add(rankPlUC);
                    allRankingPanelPlayers.Add(rankPlUC);
                }
            }
            favRankingPanelPlayers.ToList().ForEach(item => pnlPlayersRanking.Controls.Add(item));

            string[] NotChosenPlayers = File.ReadAllLines(filePathNotChosenPlayers);
            foreach (var playerName in NotChosenPlayers)
            {
                if (playerName != "")
                {
                    RankingPlayerUC rankPlUC = new RankingPlayerUC();

                    foreach (var pl in players)
                    {
                        if (pl.FullName == playerName)
                        {
                            rankPlUC.FullName = pl.FullName;
                            rankPlUC.Captain = pl.Captain;
                            rankPlUC.ShirtNumber = pl.ShirtNumber;
                            rankPlUC.Favourite = false;
                            rankPlUC.Goals = GetPlayerGoals(pl.FullName, matches);
                            rankPlUC.YellowCards = GetPlayerYellowCards(pl.FullName, matches);
                        }
                    }
                    nonFavRankingPanelPlayers.Add(rankPlUC);
                    allRankingPanelPlayers.Add(rankPlUC);
                }
            }
            nonFavRankingPanelPlayers.ToList().Where(p => !favRankingPanelPlayers.Contains(p)).ToList().ForEach(player => pnlPlayersRanking.Controls.Add(player));

            btnSortByGoals.Enabled = true;
            btnSortByYellowCards.Enabled = true;
            btnSortByFavourite.Enabled = false;
        }
        private int GetPlayerGoals(string playerFullName, List<Matches> matches)
        {
            int goalCounter = 0;

            foreach (var match in matches)
            {
                List<TeamEvent> homeTeamEvents = match.HomeTeamEvents;
                foreach (var teamEvent in homeTeamEvents)
                {
                    if (teamEvent.Player == playerFullName && teamEvent.TypeOfEvent.Split('-')[0] == "goal")
                    {
                        if (teamEvent.TypeOfEvent != "goal-own")
                        {
                            goalCounter++;
                        }
                    }
                }

                List<TeamEvent> awayTeamEvents = match.AwayTeamEvents;
                foreach (var teamEvent in awayTeamEvents)
                {
                    if (teamEvent.Player == playerFullName && teamEvent.TypeOfEvent.Split('-')[0] == "goal")
                    {
                        if (teamEvent.TypeOfEvent != "goal-own")
                        {
                            goalCounter++;
                        }
                    }
                }
            }

            return goalCounter;
        }
        private int GetPlayerYellowCards(string playerFullName, List<Matches> matches)
        {
            int yellowCardCounter = 0;

            foreach (var match in matches)
            {
                List<TeamEvent> homeTeamEvents = match.HomeTeamEvents;
                foreach (var teamEvent in homeTeamEvents)
                {
                    if (teamEvent.Player == playerFullName && teamEvent.TypeOfEvent == "yellow-card")
                    {
                        yellowCardCounter++;
                    }
                }

                List<TeamEvent> awayTeamEvents = match.AwayTeamEvents;
                foreach (var teamEvent in awayTeamEvents)
                {
                    if (teamEvent.Player == playerFullName && teamEvent.TypeOfEvent == "yellow-card")
                    {
                        yellowCardCounter++;
                    }
                }
            }

            return yellowCardCounter;
        }
        private async Task<List<Matches>> GetAllMatches(string[] fifaCodes, string[] championship)
        {
            var tmpMatches = await repo.PrepareMatches(fifaCodes, championship[0]);
            return tmpMatches;
        }

        //Teams
        private void FillTeamRankingPanel(List<Matches> matches)
        {
            List<RankingTeamUC> rankingMatches = new List<RankingTeamUC>();

            foreach (var match in matches)
            {
                RankingTeamUC teamUC = new RankingTeamUC();

                teamUC.HomeTeamName = match.HomeTeam.Country;
                teamUC.AwayTeamName = match.AwayTeam.Country;
                teamUC.MatchLocation = match.Location;
                teamUC.MatchAttendance = match.Attendance;

                rankingMatches.Add(teamUC);
            }
            rankingMatches.Sort();

            rankingMatches.ForEach(m => pnlTeamsRanking.Controls.Add(m));
        }
        #endregion

        //Team, player choice
        #region
        //Teams
        private void ChooseATeam()
        {
            if (counterFavTeam >= INIT_FAV_TEAMS_NUM)
            {
                MessageBox.Show($"Can not choose more than {INIT_FAV_TEAMS_NUM} at this time.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                thereAreLoadedPlayers = true;
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure? You will not be able to change favourite team immediately.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {
                txtChosenFavTeams.AppendText($"{ddlTeams.SelectedItem}");
                txtChosenFavTeams.AppendText(Environment.NewLine);
                ddlTeams.Items.Remove(ddlTeams.SelectedItem);

                var itemsCollection = new List<string>();
                foreach (object item in ddlTeams.Items)
                {
                    itemsCollection.Add(item.ToString());
                }

                SaveToFile(filePathNotChosenTeams, itemsCollection);
            }
            else
            {
                return;
            }
            counterFavTeam++;

            SaveTeams();
        }
        private void SaveTeams()
        {
            var lineCollection = new List<string>();

            string[] lines = txtChosenFavTeams.Lines;

            lines.ToList().ForEach(l => lineCollection.Add(l));

            SaveToFile(filePathChosenTeams, lineCollection);

            var fifaCodeCollection = new List<string>();
            foreach (var line in lineCollection)
            {
                if (line != "")
                {
                    var fifaCode = line.ToString().Split('(', ')')[1];
                    fifaCodeCollection.Add(fifaCode);
                }
            }
            SaveToFile(filePathChosenTeamsFifaCodes, fifaCodeCollection);
        }
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
                    txtChosenFavTeams.AppendText($"{item}{Environment.NewLine}");
                }
            }

            string[] NotSelectedTeams = File.ReadAllLines(filePathNotChosenTeams);

            foreach (var item in NotSelectedTeams)
            {
                ddlTeams.Items.Add(item);
            }
            ddlTeams.SelectedIndex = 0;
        }

        //Players
        private async Task<List<StartingEleven>> GetAllPlayers(string[] fifaCodes, string[] championship)
        {
            var tmpPlayers = await repo.PreparePlayers(fifaCodes, championship[0]);
            return tmpPlayers;
        }
        private void GetChosenAndNotChosenPlayers()
        {
            string[] ChosenPlayers = File.ReadAllLines(filePathChosenPlayers);
            foreach (string playerName in ChosenPlayers)
            {
                if (playerName != "")
                {
                    PlayerUC plUC = new PlayerUC();

                    foreach (var pla in players)
                    {
                        if (pla.FullName == playerName)
                        {
                            plUC.FullName = pla.FullName;
                            plUC.Captain = pla.Captain;
                            plUC.ShirtNumber = pla.ShirtNumber;
                            plUC.Position = pla.Position;
                            plUC.Favourite = true;

                            plUC.Click += PlayerUC_Click;
                        }
                    }

                    favPlayers.Add(plUC);
                }
            }
            favPlayers.ToList().ForEach(t => pnlFavouritePlayers.Controls.Add(t));

            string[] NotChosenPlayers = File.ReadAllLines(filePathNotChosenPlayers);
            foreach (var playerName in NotChosenPlayers)
            {
                if (playerName != "")
                {
                    PlayerUC plUC = new PlayerUC();

                    foreach (var pla in players)
                    {
                        if (pla.FullName == playerName)
                        {
                            plUC.FullName = pla.FullName;
                            plUC.Captain = pla.Captain;
                            plUC.ShirtNumber = pla.ShirtNumber;
                            plUC.Position = pla.Position;
                            plUC.Favourite = false;

                            plUC.Click += PlayerUC_Click;
                        }
                    }

                    allPlayers.Add(plUC);
                }
            }
            //filter / dodavanje
            allPlayers.ToList().Where(p => !favPlayers.Contains(p)).ToList().ForEach(player => pnlAllPlayers.Controls.Add(player));
        }
        private void FillAllPlayersPanelWithPlayerUCs()
        {
            players.ForEach(p =>
            {
                PlayerUC plUC = new PlayerUC
                {
                    FullName = p.FullName,
                    Captain = p.Captain,
                    ShirtNumber = p.ShirtNumber,
                    Position = p.Position,
                    Favourite = false
                };
                plUC.Click += PlayerUC_Click;

                // plUC.MouseDown // ovdje mozes event za drag and drop napravit kasnije ako stignes

                allPlayers.Add(plUC);

                pnlAllPlayers.Controls.Add(plUC);
            });
        }
        #endregion

        //Settings tab controls and events
        #region
        private void SetIndexesToZero()
        {
            ddlChampionshipChoice.SelectedIndex = 0;
            ddlLanguageChoice.SelectedIndex = 0;
        }
        private void FillDdlsWithData()
        {
            ddlChampionshipChoice.Items.Add(Properties.Resources.men);
            ddlChampionshipChoice.Items.Add(Properties.Resources.women);

            ddlLanguageChoice.Items.Add(Properties.Resources.en);
            ddlLanguageChoice.Items.Add(Properties.Resources.cro);
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"{Properties.Resources.languageOrChampChange}", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                SaveSettings();
                SetAndSaveLanguage();
                Application.Restart();
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
                SaveToFile(filePathCurrentChampionship, champLines);

                SaveToFile(filePathLanguage, langLines);

                SaveToFile(filePathStartup, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        #endregion

        //General methods
        #region
        private void SaveToFile(string path, List<string> content)
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(file.FullName, content);
        }
        #endregion
    }
}