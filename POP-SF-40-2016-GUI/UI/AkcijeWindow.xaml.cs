using POP_40_2016.Model;
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
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        public AkcijeWindow()
        {
            InitializeComponent();
            OSveziPrikaz();
        }

        private void OSveziPrikaz()
        {
            lbAkcija.Items.Clear();
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (akcija.Obrisan == false)
                {

                    lbAkcija.Items.Add(akcija);
                }
            }
            lbAkcija.SelectedIndex = 0;
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija()
            {
                DatumPocetka = DateTime.Parse(""),
                DatumZavrsetka = DateTime.Parse(""),
                NamestajNaPopustuId = 0,
                Popust = 0
            };

            var akcijeProzor = new EditAkcijeWindow(novaAkcija, EditAkcijeWindow.Operacija.DODAVANJE);
            akcijeProzor.ShowDialog();
            OSveziPrikaz();
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (Akcija)lbAkcija.SelectedItem;
            var akcijeProzor = new EditAkcijeWindow(izabranaAkcija, EditAkcijeWindow.Operacija.IZMENA);
            akcijeProzor.ShowDialog();
            OSveziPrikaz();
        }

        private void IzbrisiAkciju(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (Akcija)lbAkcija.SelectedItem;
            var listaAkcija = Projekat.Instance.Akcija;

            if (MessageBox.Show($"Da li zelite da izbrisete: {izabranaAkcija}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                    }
                }
                Projekat.Instance.Akcija = listaAkcija;
                OSveziPrikaz();
            }
        }

        private void ZatvoriAkciju(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
