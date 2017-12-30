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
        Prozor prozor;

        public enum Prozor { PrezumiAkcija, PreuzmiProdaja}

        public NamestajWindow(Operacija operacija = Operacija.ADMINISTRACIJA, Prozor prozor=Prozor.PreuzmiProdaja)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.prozor = prozor;
            if (operacija == Operacija.PREUZIMANJE)
            {
                if (prozor == Prozor.PrezumiAkcija)
                {
                    btnDodaj.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzbrisi.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzmeni.Visibility = System.Windows.Visibility.Collapsed;
                    tbKolicina.Visibility = System.Windows.Visibility.Collapsed;
                    labKolicina.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    tbKolicina.Visibility = System.Windows.Visibility.Visible;
                    labKolicina.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                btnPreuzmi.Visibility = System.Windows.Visibility.Hidden;
                labKolicina.Visibility = System.Windows.Visibility.Hidden;
                tbKolicina.Visibility = System.Windows.Visibility.Hidden;
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
            var noviNamestaj = new Namestaj();
            var namestajProzor = new EditNamestajWindow(noviNamestaj, EditNamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            view.Refresh();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj kopija = (Namestaj)IzabranNamestaj.Clone();
            var namestajProzor = new EditNamestajWindow(kopija, EditNamestajWindow.Operacija.IZMENA);
            if (namestajProzor.ShowDialog() == true)
            {
                 int index = Projekat.Instance.Namestaj.IndexOf(IzabranNamestaj);
                 Namestaj.Update(kopija);              
            }
            view.Refresh();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {       
            if(MessageBox.Show($"Da li zelite da izbrisete: {IzabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                Namestaj.Delete(IzabranNamestaj);                        
            }
            view.Refresh();
        }

        private void ZatvoriNamestaj(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "ProdataKolicina") // za uklanjanje kolone Id
            {
                e.Cancel = true;
            }
        }

        private void PreuzmiNamestaj(object sender, RoutedEventArgs e)
        {
            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;
            if (prozor == Prozor.PreuzmiProdaja)
            {
                var kolicina = int.Parse(tbKolicina.Text);
                IzabranNamestaj.ProdataKolicina = kolicina;
                IzabranNamestaj.KolicinaUMagacinu = IzabranNamestaj.KolicinaUMagacinu - kolicina;
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Id == IzabranNamestaj.Id)
                        n.KolicinaUMagacinu = IzabranNamestaj.KolicinaUMagacinu;
                }
            }
            this.DialogResult = true;
            this.Close();
        }

        private void dgNamestaj_LostFocus(object sender, RoutedEventArgs e)
        {
            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;
        }
    }
}
