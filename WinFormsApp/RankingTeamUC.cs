using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class RankingTeamUC : UserControl, IComparable<RankingTeamUC>
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string MatchLocation { get; set; }
        public string MatchAttendance { get; set; }

        public RankingTeamUC()
        {
            InitializeComponent();
        }

        public RankingTeamUC(string homeTeamName, string awayTeamName, string matchLocation, string matchAttendance)
        {
            InitializeComponent();

            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            MatchLocation = matchLocation;
            MatchAttendance = matchAttendance;
        }

        private void RankingTeamUC_Load(object sender, EventArgs e)
        {
            lblHomeTeam.Text = HomeTeamName;
            lblAwayTeam.Text = AwayTeamName;
            lblMatchLocation.Text = MatchLocation;
            lblMatchAttendance.Text = MatchAttendance;
        }

        public int CompareTo(RankingTeamUC other)
        {
            return other.MatchAttendance.CompareTo(MatchAttendance);
        }
    }
}
