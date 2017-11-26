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
using System.Windows.Shapes;

namespace POP_SF_40_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for GlavniMeniWindow.xaml
    /// </summary>
    public partial class GlavniMeniWindow : Window
    {
        public GlavniMeniWindow()
        {
            InitializeComponent();
        }

        private void PrikaziNamestaj(object sender, RoutedEventArgs e)
        {
            var namWindow = new NamestajWindow();
            namWindow.ShowDialog();
        }

        private void PrikaziTipNamestaja(object sender, RoutedEventArgs e)
        {
            var tipWindow = new TipNamestajaWindow();
            tipWindow.ShowDialog();
        }

        private void PrikaziAkcije_Click(object sender, RoutedEventArgs e)
        {
            var a = new AkcijeWindow();
            a.ShowDialog();
        }

        private void PrikaziDodatneUsluge_Click(object sender, RoutedEventArgs e)
        {
            var d = new DodatneUslugeWindow();
            d.ShowDialog();
        }

        private void PrikaziKorisnike_Click(object sender, RoutedEventArgs e)
        {
            var k = new KorisnikWindow();
            k.ShowDialog();
        }

        private void PrikaziProdajuNamestaja_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
