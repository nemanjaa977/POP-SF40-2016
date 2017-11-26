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
    /// Interaction logic for TipNamestaja.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public TipNamestaja IzabranTipNamestaja { get; set; } 

        public TipNamestajaWindow()
        {
            InitializeComponent();

            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {           
            };

            var tipProzor = new EditTipWindow(noviTip, EditTipWindow.Operacija.DODAVANJE);
            tipProzor.ShowDialog();
        } 

        private void IzbrisiTipNamestaja(object sender, RoutedEventArgs e)
        {
            var listaTipova = Projekat.Instance.TipNamestaja;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranTipNamestaja.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var t in listaTipova)
                {
                    if(t.Id == IzabranTipNamestaja.Id)
                    {
                        t.Obrisan = true;
                    }
                }
                GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipova);
            }
        }

        private void ZatvoriTipNamestaja(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabranTipNamestaja.Clone();
            var tipProzor = new EditTipWindow(IzabranTipNamestaja, EditTipWindow.Operacija.IZMENA);
            if (tipProzor.ShowDialog() != true)
            {
                int index = Projekat.Instance.TipNamestaja.IndexOf(IzabranTipNamestaja);
                Projekat.Instance.TipNamestaja[index] = kopija;
            }
        }
    }
}
