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

            view = CollectionViewSource.GetDefaultView(Namestaj.GetAllNamestaj());
            

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = view;

            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj();
            var namestajProzor = new EditNamestajWindow(noviNamestaj, EditNamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            Osvezi();
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
            Osvezi();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {       
            if(MessageBox.Show($"Da li zelite da izbrisete: {IzabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                Namestaj.Delete(IzabranNamestaj);                        
            }
            Osvezi();
        }

        private void ZatvoriNamestaj(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "Id") // za uklanjanje kolone Id
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

        public void Osvezi()
        {
            view = CollectionViewSource.GetDefaultView(Namestaj.GetAllNamestaj());
            dgNamestaj.ItemsSource = view;
        }
    }
}
