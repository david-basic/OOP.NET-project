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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for PlayerDataUC.xaml
    /// </summary>
    public partial class PlayerDataUC : UserControl
    {
        private Dictionary<string, string> namePathCollection = new Dictionary<string, string>();

        string filePathImagesPaths = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/MyAppFiles/ImagesPaths.txt";

        public string FullName { get; set; }
        public bool Captain { get; set; }
        public long ShirtNumber { get; set; }
        public string Position { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }

        public PlayerDataUC()
        {
            InitializeComponent();
        }

        public PlayerDataUC(string fullName, bool captain, long shirtNumber, int goals, int yellowCards, string position)
        {
            InitializeComponent();

            FullName = fullName;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Goals = goals;
            YellowCards = yellowCards;
            Position = position;
        }

        private void PlayerDataUC_Loaded(object sender, RoutedEventArgs e)
        {
            if (Captain)
            {
                imgCaptain.Visibility = Visibility.Visible;
            }
            else
            {
                imgCaptain.Visibility = Visibility.Hidden;
            }

            lblFullName.Content = FullName;
            lblPosition.Content = Position;
            lblGoals.Content = Goals.ToString();
            lblYellowCards.Content = YellowCards.ToString();



            //if (File.Exists(filePathImagesPaths))
            //{
            //    string[] tempPathsCollection = File.ReadAllLines(filePathImagesPaths);
            //    tempPathsCollection.ToList().ForEach(p => namePathCollection.Add(p.Split('|')[1], p.Split('|')[0]));

            //    foreach (var item in namePathCollection)
            //    {
            //        if (item.Key == FullName)
            //        {
            //            imgPlayer.Source = item.Value;
            //        }
            //    }
            //}
        }
    }
}
