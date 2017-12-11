using POP_40_2016.Model;
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
    /// Interaction logic for PrikaziNamestajUsluge.xaml
    /// </summary>
    public partial class PrikaziNamestajUsluge : Window
    {
  
        ProdajaNamestaja prodaja;

        public PrikaziNamestajUsluge(ProdajaNamestaja prodaja)
        {
            InitializeComponent();

            this.prodaja = prodaja;

            dgNamestaj.ItemsSource = prodaja.NamestajNaProdaja;
            dgDodatneUsluge.ItemsSource = prodaja.DodatneUsluge;

            dgDodatneUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "KolicinaUMagacinu" 
                || (string)e.Column.Header == "Sifra" || (string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
        }

        private void dgDodatneUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
