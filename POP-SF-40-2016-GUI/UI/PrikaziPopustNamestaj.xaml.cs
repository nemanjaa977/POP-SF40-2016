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
    /// Interaction logic for PrikaziPopustNamestaj.xaml
    /// </summary>
    public partial class PrikaziPopustNamestaj : Window
    {
        Akcija akcija;

        public PrikaziPopustNamestaj(Akcija akcija)
        {
            InitializeComponent();
            this.akcija = akcija;

            dgPrikaziPopust.ItemsSource = akcija.NamestajNaPopustu;

            dgPrikaziPopust.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgPrikaziPopust_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "KolicinaUMagacinu"
                || (string)e.Column.Header == "Sifra" || (string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
        }
    }
}
