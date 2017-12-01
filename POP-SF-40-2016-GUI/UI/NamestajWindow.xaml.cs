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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        ICollectionView view;

        public Namestaj IzabranNamestaj { get; set; }

        public enum Operacija { ADMINISTRACIJA, PREUZIMANJE }
        Operacija operacija;

        public NamestajWindow(Operacija operacija = Operacija.ADMINISTRACIJA)
        {
            InitializeComponent();
            this.operacija = operacija;

            if (operacija == Operacija.PREUZIMANJE)
            {
                btnDodaj.Visibility = System.Windows.Visibility.Collapsed;
                btnIzbrisi.Visibility = System.Windows.Visibility.Collapsed;
                btnIzmeni.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                btnPreuzmi.Visibility = System.Windows.Visibility.Hidden;
            }

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = prikazFilter;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = view;

            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool prikazFilter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false; 
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
                        view.Refresh();
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

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "TipNamestaja") // za uklanjanje kolone Id
            {
                e.Cancel = true;
            }
        }

        public Namestaj SelektovaniNamestaj = null;

        private void PreuzmiNamestaj(object sender, RoutedEventArgs e)
        {
            SelektovaniNamestaj = dgNamestaj.SelectedItem as Namestaj;
            this.DialogResult = true;
            this.Close();
        }
    }
}
