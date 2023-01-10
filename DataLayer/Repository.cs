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
        public List<StartingEleven> favTeamPlayers = new List<StartingEleven>();
        public List<StartingEleven> opponentTeamPlayers = new List<StartingEleven>();
        public List<Matches> matches = new List<Matches>();

        #region Team API
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

            if (restResponse.Content == null || restResponse.Data == null)
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

        #region Player API
        public async Task<List<StartingEleven>> PrepareStartingElevenForAMatch(string[] favTeamCode, string[] opponentTeamCode, string champ)
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

            RestResponse<List<Matches>> restResponse = await GetPlayers(favTeamCode[0], champ);

            if (restResponse.Content == null || restResponse.Data == null)
            {
                string restResponseFromFile = GetDataFromFile(path);
                tempMatches = DeserializeFileData<List<Matches>>(restResponseFromFile);

                Matches[] m = tempMatches.ToArray();

                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i].HomeTeam.Code == favTeamCode[0] && m[i].AwayTeam.Code == opponentTeamCode[0])
                    {
                        favTeamPlayers = m[i].HomeTeamStatistics.StartingEleven;
                        opponentTeamPlayers = m[i].AwayTeamStatistics.StartingEleven;
                        break;
                    }
                    else if (m[i].HomeTeam.Code == opponentTeamCode[0] && m[i].AwayTeam.Code == favTeamCode[0])
                    {
                        favTeamPlayers = m[i].AwayTeamStatistics.StartingEleven;
                        opponentTeamPlayers = m[i].HomeTeamStatistics.StartingEleven;
                        break;
                    }
                }
            }
            else
            {
                tempMatches = DeserializeData(restResponse);

                Matches[] m = tempMatches.ToArray();

                for (int i = 0; i < m.Length; i++)
                {
                    if (m[i].HomeTeam.Code == favTeamCode[0] && m[i].AwayTeam.Code == opponentTeamCode[0])
                    {
                        favTeamPlayers = m[i].HomeTeamStatistics.StartingEleven;
                        opponentTeamPlayers = m[i].AwayTeamStatistics.StartingEleven;
                    }
                    else if (m[i].HomeTeam.Code == opponentTeamCode[0] && m[i].AwayTeam.Code == favTeamCode[0])
                    {
                        favTeamPlayers = m[i].AwayTeamStatistics.StartingEleven;
                        opponentTeamPlayers = m[i].HomeTeamStatistics.StartingEleven;
                    }
                }
            }

            List<StartingEleven> allStartingPlayers = new List<StartingEleven>();
            favTeamPlayers.ForEach(p => allStartingPlayers.Add(p));
            opponentTeamPlayers.ForEach(p => allStartingPlayers.Add(p));

            return allStartingPlayers;
        }
        public async Task<List<StartingEleven>> PreparePlayers(string[] fifaCodes, string champ, bool showOnlyStartingEleven)
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

                if (restResponse.Content == null || restResponse.Data == null)
                {
                    string restResponseFromFile = GetDataFromFile(path);
                    tempMatches = DeserializeFileData<List<Matches>>(restResponseFromFile);

                    Matches[] m = tempMatches.ToArray();

                    for (int i = 0; i < m.Length; i++)
                    {
                        if (m[i].HomeTeam.Code == code)
                        {
                            players = m[i].HomeTeamStatistics.StartingEleven;
                            if (!showOnlyStartingEleven)
                            {
                                var tmpPlayers = m[i].HomeTeamStatistics.Substitutes;
                                tmpPlayers.ForEach(p => players.Add(p));
                            }
                            break;
                        }
                        else if (m[i].AwayTeam.Code == code)
                        {
                            players = m[i].AwayTeamStatistics.StartingEleven;
                            if (!showOnlyStartingEleven)
                            {
                                var tmpPlayers = m[i].AwayTeamStatistics.Substitutes;
                                tmpPlayers.ForEach(p => players.Add(p));
                            }
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

        #region Matches API
        public async Task<List<Matches>> PrepareMatches(string[] fifaCodes, string champ)
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
                RestResponse<List<Matches>> restResponse = await GetMatches(code, champ);
                if (restResponse.Content == null || restResponse.Data == null)
                {
                    string restResponseFromFile = GetDataFromFile(path);
                    tempMatches = DeserializeFileData<List<Matches>>(restResponseFromFile);

                    matches = tempMatches;
                }
                else
                {
                    tempMatches = DeserializeData(restResponse);

                    matches = tempMatches;
                }
            }

            return matches;
        }
        private Task<RestResponse<List<Matches>>> GetMatches(string code, string champ)
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

        #region Deserializing data
        private T DeserializeData<T>(RestResponse<T> restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse.Content);
        }
        private T DeserializeFileData<T>(string restResponse)
        {
            return JsonConvert.DeserializeObject<T>(restResponse);
        }
        #endregion

        #region General methods
        private string GetDataFromFile(string path)
        {
            return File.ReadAllText(path);
        }
        #endregion

    }
}
