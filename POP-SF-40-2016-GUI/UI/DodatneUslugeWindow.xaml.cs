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
    /// Interaction logic for DodatneUslugeWindow.xaml
    /// </summary>
    public partial class DodatneUslugeWindow : Window
    {
        ICollectionView view;

        public DodatnaUsluga IzabranaUsluga { get; set; }

        public enum Operacija { ADMINISTRACIJA, PREUZIMANJE}
        Operacija operacija;

        public DodatneUslugeWindow(Operacija operacija = Operacija.ADMINISTRACIJA)
        {
            InitializeComponent();
            this.operacija = operacija;

            if (operacija == Operacija.PREUZIMANJE)
            {
                btnDodaj.Visibility = System.Windows.Visibility.Collapsed;
                btnIzbrisi.Visibility = System.Windows.Visibility.Collapsed;
                btnIzmeni.Visibility = System.Windows.Visibility.Collapsed;
                labSort.Visibility = System.Windows.Visibility.Collapsed;
                cbSortDodUsluge.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                btnPreuzmi.Visibility = System.Windows.Visibility.Hidden;
            }

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);

            view.Filter = prikazFilter;

            dgUsluga.IsSynchronizedWithCurrentItem = true;
            dgUsluga.DataContext = this;
            dgUsluga.ItemsSource = view;

            IzabranaUsluga = dgUsluga.SelectedItem as DodatnaUsluga;

            dgUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            List<string> listaDodatnihUsluga = new List<string>()
            {
                "Naziv", "Cena"
            };
            cbSortDodUsluge.ItemsSource = listaDodatnihUsluga;
        }

        private bool prikazFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga();          
            var uslugaProzor = new EditDodatneUsluge(novaUsluga, EditDodatneUsluge.Operacija.DODAVANJE);
            uslugaProzor.ShowDialog();
        }

        private void IzmeniUslugu(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga kopija = (DodatnaUsluga)IzabranaUsluga.Clone();
            var uslugaProzor = new EditDodatneUsluge(kopija, EditDodatneUsluge.Operacija.IZMENA);
            if (uslugaProzor.ShowDialog() == true)
            {
                int index = Projekat.Instance.DodatnaUsluga.IndexOf(IzabranaUsluga);
                DodatnaUsluga.Update(kopija);
            }
        }

        private void IzbrisiUslugu(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranaUsluga.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DodatnaUsluga.Delete(IzabranaUsluga);
            }
            view.Refresh();
        }

        private void ZatvoriUslugu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
        }

        private void PreuzmiUslugu(object sender, RoutedEventArgs e)
        {
            IzabranaUsluga = dgUsluga.SelectedItem as DodatnaUsluga;
            this.DialogResult = true;
            this.Close();
        }

        private void cbSortDodUsluge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var izabrano = cbSortDodUsluge.SelectedItem as string;
            switch (izabrano)
            {
                case "Naziv":
                    var listaD = Projekat.Instance.DodatnaUsluga.OrderBy(d => d.Naziv);
                    dgUsluga.ItemsSource = listaD;
                    break;
                case "Cena":
                    var listaDd = Projekat.Instance.DodatnaUsluga.OrderBy(d => d.Cena);
                    dgUsluga.ItemsSource = listaDd;
                    break;
                default:
                    break;
            }
        }
    }
}
