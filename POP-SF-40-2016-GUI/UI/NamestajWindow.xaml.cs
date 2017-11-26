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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public Namestaj IzabranNamestaj { get; set; }

        public NamestajWindow()
        {
            InitializeComponent();

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {               
            };

            var namestajProzor = new EditNamestajWindow(noviNamestaj, EditNamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();          
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj kopija = (Namestaj)IzabranNamestaj.Clone();
            var namestajProzor = new EditNamestajWindow(IzabranNamestaj, EditNamestajWindow.Operacija.IZMENA);
            if (namestajProzor.ShowDialog() != true)
            {
                 int index = Projekat.Instance.Namestaj.IndexOf(IzabranNamestaj);
                 Projekat.Instance.Namestaj[index] =kopija;
            }         
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            if(MessageBox.Show($"Da li zelite da izbrisete: {IzabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                foreach (var nam in listaNamestaja)
                {
                    if(nam.Id == IzabranNamestaj.Id)
                    {
                        nam.Obrisan = true;
                        break;
                    }
                }
                GenericSerializer.Serialize("namestaj.xml", listaNamestaja);              
            }
        }

        private void ZatvoriNamestaj(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
