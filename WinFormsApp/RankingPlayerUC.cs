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
    public partial class RankingPlayerUC : UserControl, IComparable<RankingPlayerUC>
    {
        Bitmap emptyStar = Properties.ResourcesImages.emptyStar;
        Bitmap fullStar = Properties.ResourcesImages.fullStar;
        Bitmap captain = Properties.ResourcesImages.captain;
        Bitmap defaultImage = Properties.ResourcesImages.defaultPlayer;

        private Dictionary<string, string> namePathCollection = new Dictionary<string, string>();

        string filePathImagesPaths = $"{Application.StartupPath}/MyAppFiles/ImagesPaths.txt";

        public string FullName { get; set; }
        public bool Captain { get; set; }
        public long ShirtNumber { get; set; }
        public bool Favourite { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }


        public RankingPlayerUC()
        {
            InitializeComponent();
        }

        public RankingPlayerUC(string fullName, bool captain, bool favourite, int goals, int yellowCards, long shirtNumber)
        {
            InitializeComponent();

            FullName = fullName;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Favourite = favourite;
            Goals = goals;
            YellowCards = yellowCards;
        }

        private void RankingPlayerUC_Load(object sender, EventArgs e)
        {
            if (Captain)
            {
                imgCaptain.Image = captain;
            }
            else
            {
                imgCaptain.Image = null;
            }

            lblName.Text = FullName;

            if (Favourite)
            {
                imgFavourite.Image = fullStar;
            }
            else
            {
                imgFavourite.Image = emptyStar;
            }

            lblGoalsNumber.Text = Goals.ToString();
            lblYellowCardsNumber.Text = YellowCards.ToString();

            if (File.Exists(filePathImagesPaths))
            {
                string[] tempPathsCollection = File.ReadAllLines(filePathImagesPaths);
                tempPathsCollection.ToList().ForEach(p => namePathCollection.Add(p.Split('|')[1], p.Split('|')[0]));

                foreach (var item in namePathCollection)
                {
                    if (item.Key == FullName)
                    {
                        imgPlayer.ImageLocation = item.Value;
                    }
                    else
                    {
                        imgPlayer.Image = defaultImage;
                    }
                }
            }
        }

        private void RankingPlayerUC_Paint(object sender, PaintEventArgs e)
        {
            if (Favourite)
            {
                imgFavourite.Image = fullStar;
            }
            else
            {
                imgFavourite.Image = emptyStar;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is RankingPlayerUC uC &&
                   FullName == uC.FullName &&
                   ShirtNumber == uC.ShirtNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = 1319128817;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + ShirtNumber.GetHashCode();
            return hashCode;
        }

        public int CompareTo(RankingPlayerUC other)
        {
            return other.Goals.CompareTo(Goals);
        }
    }
}
