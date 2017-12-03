using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditProdajaWindow.xaml
    /// </summary>
    public partial class EditProdajaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private ProdajaNamestaja prodaja;
        private Operacija operacija;

        public EditProdajaWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodaja = prodaja;
            this.operacija = operacija;

            dpDatumProdaje.DataContext = prodaja;
            tbBrRacuna.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbKolicinaNamestaja.DataContext = prodaja;
            dgDodUsluge.ItemsSource = prodaja.DodatneUsluge;
            dgNamestajj.ItemsSource = prodaja.NamestajNaProdaja;
        }

        private void ZatvoriProzorProdajaEdit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajEditProdaja(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            this.DialogResult = true;
            double cenaNamestaja = 0;
            double cenaUsluga = 0;
            for(int i = 0; i < prodaja.NamestajNaProdaja.Count; i++)
            {
                cenaNamestaja += prodaja.NamestajNaProdaja[i].JedinicnaCena;

            }
            for (int i = 0; i < prodaja.DodatneUsluge.Count; i++)
            {
                cenaUsluga += prodaja.DodatneUsluge[i].Cena;

            }
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    prodaja.Id = listaProdaje.Count + 1;
                    prodaja.UkupanIznos = (cenaNamestaja * prodaja.KolicinaNamestaja) + cenaUsluga ;
                    listaProdaje.Add(prodaja);
                    break;                 
            }
            GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaje);
            Close();
        }

        private void IzaberiUslugu(object sender, RoutedEventArgs e)
        {
            DodatneUslugeWindow ff = new DodatneUslugeWindow(DodatneUslugeWindow.Operacija.PREUZIMANJE);
            if (ff.ShowDialog() == true)
            {
                prodaja.DodatneUsluge.Add(ff.SelektovanaUsluga);
                prodaja.DodatnaUslugaId.Add(ff.SelektovanaUsluga.Id);
            }
        }

        private void dgDodUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header=="Obrisan" || (string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }

        }

        private void IzaberiNamestaj(object sender, RoutedEventArgs e)
        {
            NamestajWindow nn = new NamestajWindow(NamestajWindow.Operacija.PREUZIMANJE);
            if(nn.ShowDialog() == true)
            {
                prodaja.NamestajNaProdaja.Add(nn.SelektovaniNamestaj);
                prodaja.NamestajZaProdajuId.Add(nn.SelektovaniNamestaj.Id);
            }
        }

        private void dgNamestajj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra" || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "KolicinaUMagacinu")
            {
                e.Cancel = true;
            }
        }

        private void UkloniNamestaj(object sender, RoutedEventArgs e)
        {
            prodaja.NamestajNaProdaja.Remove(dgNamestajj.SelectedItem as Namestaj);
        }

        private void UkloniUslugu(object sender, RoutedEventArgs e)
        {
            prodaja.DodatneUsluge.Remove(dgDodUsluge.SelectedItem as DodatnaUsluga);
        }
    }
}
