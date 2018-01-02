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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        ICollectionView view;

        public ProdajaNamestaja IzabranaProdaja { get; set; }

        public ProdajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaNamestaja);

            view.Filter = prikazFilter;

            dgProdaja.IsSynchronizedWithCurrentItem = true;
            dgProdaja.DataContext = this;
            dgProdaja.ItemsSource = view;

            IzabranaProdaja = dgProdaja.SelectedItem as ProdajaNamestaja;

            dgProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            List<string> listaRacuna = new List<string>()
            {
                "DatumProdaje", "BrojRacuna", "Kupac", "UkupanIznos", "UkupanIznosPDV"
            };
            cbSortProdaja.ItemsSource = listaRacuna;
        }

        private bool prikazFilter(object obj)
        {
            return ((ProdajaNamestaja)obj).Obrisan == false;
        }

        private void DodajRacun(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja();
            var prodajaProzor = new EditProdajaWindow(novaProdaja, EditProdajaWindow.Operacija.DODAVANJE);
            prodajaProzor.ShowDialog();
            view.Refresh();
        }

        private void ZatvoriRacun(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "NamestajZaProdajuId" || (string)e.Column.Header == "DodatnaUslugaId"
                || (string)e.Column.Header == "NamestajNaProdaja" || (string)e.Column.Header == "DodatneUsluge" || (string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
        }

        private void IzmeniRacun(object sender, RoutedEventArgs e)
        {
            ProdajaNamestaja kopija = (ProdajaNamestaja)IzabranaProdaja.Clone();
            var pProzor = new EditProdajaWindow(kopija, EditProdajaWindow.Operacija.IZMENA);
            pProzor.ShowDialog();
            view.Refresh();      
        }

        private void PrikaziNamUs(object sender, RoutedEventArgs e)
        {
            ProdajaNamestaja pr = dgProdaja.SelectedItem as ProdajaNamestaja;
            var novi = new PrikaziNamestajUsluge(pr);
            novi.ShowDialog();
        }

        private void cbSortProdaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var izabrano = cbSortProdaja.SelectedItem as string;
            switch (izabrano)
            {
                case "DatumProdaje":
                    var listaP = Projekat.Instance.ProdajaNamestaja.OrderBy(p => p.DatumProdaje);
                    dgProdaja.ItemsSource = listaP;
                    break;
                case "BrojRacuna":
                    var listaPp = Projekat.Instance.ProdajaNamestaja.OrderBy(p => p.BrojRacuna);
                    dgProdaja.ItemsSource = listaPp;
                    break;
                case "Kupac":
                    var listaPo = Projekat.Instance.ProdajaNamestaja.OrderBy(p => p.Kupac);
                    dgProdaja.ItemsSource = listaPo;
                    break;
                case "UkupanIznos":
                    var listaPP = Projekat.Instance.ProdajaNamestaja.OrderBy(p => p.UkupanIznos);
                    dgProdaja.ItemsSource = listaPP;
                    break;
                case "UkupanIznosPDV":
                    var listaPaa = Projekat.Instance.ProdajaNamestaja.OrderBy(p => p.UkupanIznosPDV);
                    dgProdaja.ItemsSource = listaPaa;
                    break;
                default:
                    break;
            }
        }
    }
}
