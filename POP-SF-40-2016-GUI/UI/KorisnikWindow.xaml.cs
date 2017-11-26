using POP_40_2016.Model;
using POP_40_2016.utill;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public Korisnik IzabranKorisnik { get; set; }

        public KorisnikWindow()
        {
            InitializeComponent();

            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.DataContext = this;
            dgKorisnik.ItemsSource = Projekat.Instance.Korisnik;

            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DodajKorisnika(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
            };

            var korisnikProzor = new EditKorisnikWindow(noviKorisnik, EditKorisnikWindow.Operacija.DODAVANJE);
            korisnikProzor.ShowDialog();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            Korisnik kopija = (Korisnik)IzabranKorisnik.Clone();
            var korProzor = new EditKorisnikWindow(IzabranKorisnik, EditKorisnikWindow.Operacija.IZMENA);
            if (korProzor.ShowDialog() != true)
            {
                int index = Projekat.Instance.Korisnik.IndexOf(IzabranKorisnik);
                Projekat.Instance.Korisnik[index] = kopija;
            }
        }

        private void IzbrisiKorisnika(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranKorisnik.KorisnickoIme}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var t in listaKorisnika)
                {
                    if (t.Id == IzabranKorisnik.Id)
                    {
                        t.Obrisan = true;
                    }
                }
                GenericSerializer.Serialize("korisnik.xml", listaKorisnika);
            }
        }

        private void ZatvoriKorisnika(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
