using DataLayer.Constants;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class Repository
    {
        public List<Team> teams = new List<Team>();
        public List<StartingEleven> players = new List<StartingEleven>();
        public List<Matches> matches = new List<Matches>();

        // Team API
        #region
        public async Task<List<Team>> PrepareTeams(string champ)
        {
            string path;
            string endpoint;

            Cursor.Current = Cursors.WaitCursor;

            if (champ == "m")
            {
                path = $"{Application.StartupPath}/men_teams.json";
                endpoint = ApiConstants.M_TEAMS;
            }
            else
            {
                path = $"{Application.StartupPath}/women_teams.json";
                endpoint = ApiConstants.W_TEAMS;
            }

            RestResponse<List<Team>> restResponse = await GetTeams(endpoint);

            if (restResponse.Content == null)
            {
                Cursor.Current = Cursors.Arrow;
                try
                {
                    string restResponseFromFile = GetDataFromFile(path);
                    teams = DeserializeFileData<List<Team>>(restResponseFromFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
                teams = DeserializeData(restResponse);
            }

            return teams;
        }
        private Task<RestResponse<List<Team>>> GetTeams(string endpoint)
        {
            RestClient client = new RestClient(endpoint);
            return client.ExecuteAsync<List<Team>>(new RestRequest());
        }
        #endregion

        //Player API
        #region
        public async Task<List<StartingEleven>> PreparePlayers(string[] fifaCodes, string champ)
        {
            List<Matches> tempMatches = new List<Matches>();

            string path;

            if (champ == "m")
            {
                path = $"{Application.StartupPath}/men_matches.json";
            }
            else
            {
                path = $"{Application.StartupPath}/women_matches.json";
            }

            foreach (var code in fifaCodes)
            {
                RestResponse<List<Matches>> restResponse = await GetPlayers(code, champ);

                if (restResponse.Content == null)
                {
                    string restResponseFromFile = GetDataFromFile(path);
                    tempMatches = DeserializeFileData<List<Matches>>(restResponseFromFile);

                    Matches[] m = tempMatches.ToArray();

                    for (int i = 0; i < m.Length; i++)
                    {
                        if (m[i].HomeTeam.Code == code)
                        {
                            players = m[i].HomeTeamStatistics.StartingEleven;
                            var tmpPlayers = m[i].HomeTeamStatistics.Substitutes;
                            tmpPlayers.ForEach(p => players.Add(p));
                            break;
                        }
                        else if (m[i].AwayTeam.Code == code)
                        {
                            players = m[i].AwayTeamStatistics.StartingEleven;
                            var tmpPlayers = m[i].AwayTeamStatistics.Substitutes;
                            tmpPlayers.ForEach(p => players.Add(p));
                            break;
                        }
                    }
                }
                else
                {
                    tempMatches = DeserializeData(restResponse);

                    Matches[] m = tempMatches.ToArray();

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
                }

            }

            return players; // sa ovom listom ce se instancirati UCovi u mainu
        }
        private Task<RestResponse<List<Matches>>> GetPlayers(string code, string champ)
        {
            if (champ == "m")
            {
                RestClient client = new RestClient($"{ApiConstants.CUSTOM_TEAM_MATCHES_MEN_DATA}{code}");
                return client.ExecuteAsync<List<Matches>>(new RestRequest());   
            }
            else
            {
                RestClient client = new RestClient($"{ApiConstants.CUSTOM_TEAM_MATCHES_WOMEN_DATA}{code}");
                return client.ExecuteAsync<List<Matches>>(new RestRequest());   
            }
        }
        
        #endregion

        // Deserializing data
        #region
        private T DeserializeData<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }
        private T DeserializeFileData<T>(string restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse);
        }
        #endregion

        // general methods
        #region
        private string GetDataFromFile(string path)
        {
            return File.ReadAllText(path);
        }
        #endregion

    }
}
