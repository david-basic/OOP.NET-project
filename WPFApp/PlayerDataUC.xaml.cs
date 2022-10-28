using System;
using System.Collections.Generic;
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
        public int Goals { get; set; }
        public int YellowCards { get; set; }

        public PlayerDataUC()
        {
            InitializeComponent();
        }

        public PlayerDataUC(string fullName, bool captain, long shirtNumber, int goals, int yellowCards)
        {
            FullName = fullName;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Goals = goals;
            YellowCards = yellowCards;
        }
    }
}
