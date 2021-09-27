using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Jail_Plugin {
    /// <summary>
    /// Interaction logic for TitanUI.xaml
    /// </summary>
    public partial class TitanUI : UserControl {
        private readonly ACT_Plugin.JailPriority plugin;
        private readonly TextBox[] PartyList;
        private readonly TextBox[] PrioList;
        private bool locked = true;

        public TitanUI(ACT_Plugin.JailPriority plugin) {
            this.plugin = plugin;
            InitializeComponent();
            PartyList = partyGrid.Children.OfType<TextBox>().OrderBy(c => c.Name).ToArray();
            PrioList = prioGrid.Children.OfType<TextBox>().OrderBy(c => c.Name).ToArray();
        }

        public void Log(string s) {
            Dispatcher.BeginInvoke(new ThreadStart(() => {
                logBox.AppendText("\r\n" + s);
                logBox.ScrollToEnd();
            }));
        }

        public void Update(string[] players, string[] order) {
            locked = true;
            for (int i = 0; i < players.Length; i++) {
                PartyList[i].Text = players[i];
                PrioList[i].Text = order[i];
            }
            locked = false;
        }

        private void UpdatePlayers(object sender, TextChangedEventArgs e) {
            if (!locked)
                plugin.UpdatePlayers(PartyList);
        }

        private void UpdatePrio(object sender, TextChangedEventArgs e) {
            if (!locked)
                plugin.UpdatePrio(PrioList);
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e) {
            if (plugin.CheckLists())
                Log("-[SUCCESS! Priority and party lists match]-");
            else
                Log("-[FAILURE! Priority and party lists do not match, check your input!]-");
        }

        private void AutoButton_Click(object sender, RoutedEventArgs e) {
            if (plugin.AutoFill())
                Log("-[SUCCESS! Filled Party List and sorted Priority List by Jobs]-");
            else
                Log("-[FAILURE! Make sure you are in a (not cross world) party with 8 players]-");
        }
    }
}
