using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        ICollectionView view;

        public Korisnik IzabranKorisnik { get; set; }

        public KorisnikWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnik);

            view.Filter = prikazFilter;

            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.DataContext = this;
            dgKorisnik.ItemsSource = view;

            IzabranKorisnik = dgKorisnik.SelectedItem as Korisnik;

            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            List<string> listaKor = new List<string>()
            {
                "Ime", "Prezime", "KorisnickoIme", "Lozinka", "TipKorisnika"
            };
            cbSortKorisnik.ItemsSource = listaKor;
        }

        private bool prikazFilter(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }

        private void DodajKorisnika(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik();
            var korisnikProzor = new EditKorisnikWindow(noviKorisnik, EditKorisnikWindow.Operacija.DODAVANJE);
            korisnikProzor.ShowDialog();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            Korisnik kopija = (Korisnik)IzabranKorisnik.Clone();
            var korProzor = new EditKorisnikWindow(kopija, EditKorisnikWindow.Operacija.IZMENA);
            if (korProzor.ShowDialog() == true)
            {
                int index = Projekat.Instance.Korisnik.IndexOf(IzabranKorisnik);
                Korisnik.Update(kopija);
            }
        }

        private void IzbrisiKorisnika(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranKorisnik.KorisnickoIme}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik.Delete(IzabranKorisnik);
            }
            view.Refresh();
        }

        private void ZatvoriKorisnika(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
        }

        private void cbSortKorisnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var izabrano = cbSortKorisnik.SelectedItem as string;
            switch (izabrano)
            {
                case "Ime":
                    var listaK = Projekat.Instance.Korisnik.OrderBy(k => k.Ime);
                    dgKorisnik.ItemsSource = listaK;
                    break;
                case "Prezime":
                    var listaKo = Projekat.Instance.Korisnik.OrderBy(k => k.Prezime);
                    dgKorisnik.ItemsSource = listaKo;
                    break;
                case "KorisnickoIme":
                    var listaKk = Projekat.Instance.Korisnik.OrderBy(k => k.KorisnickoIme);
                    dgKorisnik.ItemsSource = listaKk;
                    break;
                case "Lozinka":
                    var listaKs = Projekat.Instance.Korisnik.OrderBy(k => k.Lozinka);
                    dgKorisnik.ItemsSource = listaKs;
                    break;
                case "TipKorisnika":
                    var listaKkk = Projekat.Instance.Korisnik.OrderBy(k => k.TipKorisnika);
                    dgKorisnik.ItemsSource = listaKkk;
                    break;
                default:
                    break;
            }
        }
    }
}
