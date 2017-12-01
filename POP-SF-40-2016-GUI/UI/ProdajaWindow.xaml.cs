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
        }

        private void IzbrisiRacun(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajaNamestaja;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranaProdaja}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var p in listaProdaja)
                {
                    if (p.Id == IzabranaProdaja.Id)
                    {
                        p.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaja);
            }
        }

        private void ZatvoriRacun(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" )
            {
                e.Cancel = true;
            }
        }
    }
}
