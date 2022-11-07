using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for PlayerDataUCWindow.xaml
    /// </summary>
    public partial class PlayerDataUCWindow : Window
    {
        private readonly PlayerDataUC data;

        public PlayerDataUCWindow(PlayerDataUC data)
        {
            InitializeComponent();

            this.data = data;
        }

        private void PlayerDataWindow_Loaded(object sender, RoutedEventArgs e)
        {
            player.FullName = data.FullName;
            player.Position = data.Position;
            player.ShirtNumber = data.ShirtNumber;
            player.Captain = data.Captain;
            player.Goals = data.Goals;
            player.YellowCards = data.YellowCards;
        }
    }
}
