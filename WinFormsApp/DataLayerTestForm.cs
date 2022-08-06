using DataLayer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp
{
    public partial class DataLayerTestForm : Form
    {
        public DataLayerTestForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //PrepareTeams();
            string[] fifaCodes = { "CRO", "ARG", "KOR" };
            PreparePlayers(fifaCodes);
        }

        private async void PreparePlayers(string[] fifaCodes)
        {
            lblInfo.Text = "Dohvacam podatke....";

            foreach (var code in fifaCodes)
            {
                ddlOsobe.Items.Add($"{code}");

                RestResponse<List<Matches>> restResponse = await GetPlayers(code);
                if (restResponse.Content == null)
                {
                    // !!!!
                    //TO DO: u main projektu napravit za file isto
                    // !!!!
                    MessageBox.Show("Tu bi sada radio sa fileom, kad skuzis kako");
                }
                else
                {
                    List<Matches> matches = DeserializeData(restResponse);

                    lblInfo.Text = string.Empty;

                    var players = new List<StartingEleven>();

                    Matches[] m = matches.ToArray();

                    for (int i = 0; i < 1; i++)
                    {
                        if (m[i].HomeTeam.Code == code)
                        {
                            players = m[i].HomeTeamStatistics.StartingEleven;
                            var tmpPlayers = m[i].HomeTeamStatistics.Substitutes;
                            tmpPlayers.ForEach(p => players.Add(p));
                        }
                        else
                        {
                            players = m[i].AwayTeamStatistics.StartingEleven;
                            var tmpPlayers = m[i].AwayTeamStatistics.Substitutes;
                            tmpPlayers.ForEach(p => players.Add(p));
                        }
                    }

                    players.ForEach(p => ddlOsobe.Items.Add(p));
                }
                ddlOsobe.SelectedIndex = 0;
            }
        }

        private Task<RestResponse<List<Matches>>> GetPlayers(string code)
        {
            RestClient client = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={code}");
            return client.ExecuteAsync<List<Matches>>(new RestRequest());
        }


        private async void PrepareTeams()
        {
            lblInfo.Text = "Dohvacam podatke....";

            RestResponse<List<Team>> restResponse = await GetTeams();
            if (restResponse.Content == null)
            {
                //   if rest rest response sa endpointa null, onda napravi rest response sa
                //file - a koji je u data layeru
                string restResponseFromFile = GetTeamsFromFile();

                lblInfo.Text = string.Empty;
                List<Team> teams = DeserializeFileData<List<Team>>(restResponseFromFile);
                teams.ForEach(t => ddlOsobe.Items.Add(t));
            }
            else
            {
                lblInfo.Text = string.Empty;
                List<Team> teams = DeserializeData(restResponse);
                teams.ForEach(t => ddlOsobe.Items.Add(t));
            }

            ddlOsobe.SelectedIndex = 0;
        }

        private T DeserializeData<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }

        private T DeserializeFileData<T>(string restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse);
        }

        private string GetTeamsFromFile()
        {
            // !!!!
            // TO DO: figure out how to make relative path towards the men/women in DataLayer project
            // umjesto full patha, ima u nekim vjezbama to ali neznam kojim, potrazi
            // !!!!

            // !!!! -> rijesio u glavnom projektu preko application.startuppath/[ime json file-a]

            return File.ReadAllText(@"C:\Users\dbasi\OneDrive - Visoko uciliste Algebra\FAKS\OOP.NET\Projekt\WorldCupData\women\teams.json");
            //return File.ReadAllText();

        }

        private Task<RestResponse<List<Team>>> GetTeams()
        {
            RestClient client = new RestClient("http://worldcup.sfg.io/teams/"); // http radi https ne radi
            return client.ExecuteAsync<List<Team>>(new RestRequest());
        }

    }
}
