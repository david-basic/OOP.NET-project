using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Constants
{
    public static class ApiConstants
    {
        public const string W_TEAMS = "http://worldcup.sfg.io/teams/";
        public const string M_TEAMS = "http://world-cup-json-2018.herokuapp.com/teams/";

        public const string CUSTOM_TEAM_MATCHES_MEN_DATA = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        public const string CUSTOM_TEAM_MATCHES_WOMEN_DATA = "http://worldcup.sfg.io/matches/country?fifa_code=";
        //add country?fifa_code={FIFA_CODE} to the url to fetch data from the fifaCode country or it won't work
        //http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=

    }
}
