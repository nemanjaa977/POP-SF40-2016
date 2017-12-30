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
        public ObservableCollection<Namestaj> dodatiNamestaji = new ObservableCollection<Namestaj>();
        public ObservableCollection<DodatnaUsluga> dodateUsluge = new ObservableCollection<DodatnaUsluga>();
        public ObservableCollection<Namestaj> obrisaniNam = new ObservableCollection<Namestaj>();
        public ObservableCollection<DodatnaUsluga> obrisaneUs = new ObservableCollection<DodatnaUsluga>();

        public EditProdajaWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodaja = prodaja;
            this.operacija = operacija;

            dpDatumProdaje.DataContext = prodaja;
            tbKupac.DataContext = prodaja;

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
            int kolicinaNam = 0;

            for (int i = 0; i < prodaja.NamestajNaProdaja.Count; i++)
            {
                if(prodaja.NamestajNaProdaja[i].CenaPopust > 0)
                    cenaNamestaja += prodaja.NamestajNaProdaja[i].CenaPopust;
                else
                    cenaNamestaja += prodaja.NamestajNaProdaja[i].JedinicnaCena;
            }

            for (int i = 0; i < prodaja.DodatneUsluge.Count; i++)
            {
                cenaUsluga += prodaja.DodatneUsluge[i].Cena;
            }

            for (int i = 0; i < prodaja.NamestajNaProdaja.Count; i++)
            {
                kolicinaNam += prodaja.NamestajNaProdaja[i].KolicinaUMagacinu;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    prodaja.Id = listaProdaje.Count + 1;
                    prodaja.BrojRacuna = listaProdaje.Count + 1;
                    if(prodaja.NamestajNaProdaja.Count>0)
                        for (int i = 0; i < prodaja.NamestajNaProdaja.Count; i++)
                        {
                             prodaja.UkupanIznos = (cenaNamestaja * prodaja.NamestajNaProdaja[i].ProdataKolicina) + cenaUsluga;
                        }
                    prodaja.UkupanIznosPDV = prodaja.UkupanIznos + ((prodaja.UkupanIznos * 20) / 100);
                    ProdajaNamestaja.Create(prodaja);
                    break;
                case Operacija.IZMENA:
                    for (int i = 0; i < prodaja.NamestajNaProdaja.Count; i++)
                    {
                        prodaja.UkupanIznos = (cenaNamestaja * prodaja.NamestajNaProdaja[i].ProdataKolicina) + cenaUsluga;
                    }
                    prodaja.UkupanIznosPDV = prodaja.UkupanIznos + ((prodaja.UkupanIznos * 20) / 100);
                    ProdajaNamestaja.Update(prodaja);
                    if(dodatiNamestaji.Count>0)
                        ProdajaNamestaja.AddProdajaProzorNamestaj(prodaja, dodatiNamestaji);
                    if(dodateUsluge.Count>0)
                        ProdajaNamestaja.AddProdajaProzorUsluga(prodaja, dodateUsluge);
                    ProdajaNamestaja.DeleteProdajaProzorNamestaj(prodaja, obrisaniNam);
                    ProdajaNamestaja.DeleteProdajaProzorUsluga(prodaja, obrisaneUs);
                    break;
            }
            Close();
        }

        private void IzaberiUslugu(object sender, RoutedEventArgs e)
        {
            DodatneUslugeWindow ff = new DodatneUslugeWindow(DodatneUslugeWindow.Operacija.PREUZIMANJE);
            if (ff.ShowDialog() == true)
            {
                prodaja.DodatneUsluge.Add(ff.IzabranaUsluga);
                prodaja.DodatnaUslugaId.Add(ff.IzabranaUsluga.Id);
                dodateUsluge.Add(ff.IzabranaUsluga);
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
            NamestajWindow nn = new NamestajWindow(NamestajWindow.Operacija.PREUZIMANJE, NamestajWindow.Prozor.PreuzmiProdaja);
            if(nn.ShowDialog() == true)
            {
                prodaja.NamestajNaProdaja.Add(nn.IzabranNamestaj);
                prodaja.NamestajZaProdajuId.Add(nn.IzabranNamestaj.Id);
                dodatiNamestaji.Add(nn.IzabranNamestaj);
                
            }
        }

        private void dgNamestajj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra" 
                || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "TipNamestaja" || (string)e.Column.Header == "ProdataKolicina")
            {
                e.Cancel = true;
            }
        }

        private void UkloniNamestaj(object sender, RoutedEventArgs e)
        {
            var select = dgNamestajj.SelectedItem as Namestaj;
            prodaja.NamestajNaProdaja.Remove(select);
            obrisaniNam.Add(select);
            foreach(var namestaj in dodatiNamestaji)
            {
                if (namestaj.Id == select.Id)
                    dodatiNamestaji.Remove(namestaj);
            }
                      
            select.KolicinaUMagacinu = select.KolicinaUMagacinu + select.ProdataKolicina;
            foreach (var n in Projekat.Instance.Namestaj)
            {
                if (n.Id == select.Id)
                    n.KolicinaUMagacinu = select.KolicinaUMagacinu;
            }
        }

        private void UkloniUslugu(object sender, RoutedEventArgs e)

        { 
            var selected = dgDodUsluge.SelectedItem as DodatnaUsluga;
            prodaja.DodatneUsluge.Remove(selected);
            obrisaneUs.Add(selected);
            foreach (var usluga in dodateUsluge)
            {
                if (usluga.Id == selected.Id)
                     dodateUsluge.Remove(usluga);
            }
        }
    }
}
