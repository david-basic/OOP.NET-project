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
    /// Interaction logic for PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        public string FullName { get; set; }
        public long ShirtNumber { get; set; }
        public string Position { get; set; }


        public PlayerUC()
        {
            InitializeComponent();
        }

        public PlayerUC(string fullName, int shirtNumber, string position)
        {
            InitializeComponent();

            FullName = fullName;
            ShirtNumber = shirtNumber;
            Position = position;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lblPlayerShirtNumber.Content = ShirtNumber.ToString();
            lblPlayerName.Content = FullName;
        }
    }
}
