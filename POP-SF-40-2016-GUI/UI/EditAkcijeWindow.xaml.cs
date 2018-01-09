using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditAkcijeWindow.xaml
    /// </summary>
    public partial class EditAkcijeWindow : Window
    {
        ICollectionView view;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Akcija akcija;
        private Operacija operacija;
        private ObservableCollection<Namestaj> dodatiNamestaji = new ObservableCollection<Namestaj>();
        private ObservableCollection<Namestaj> obrisani = new ObservableCollection<Namestaj>();

        public EditAkcijeWindow(Akcija akcija, Operacija operacija)
        {

            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbDatumP.DataContext = akcija;
            tbDatumZ.DataContext = akcija;
            tbPopust.DataContext = akcija;

            dgNamestajPopust.ItemsSource = akcija.NamestajNaPopustu;
            dgNamestajPopust.IsSynchronizedWithCurrentItem = true;

        }

        private void ZatvoriProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            this.DialogResult = true;

            double cenaNamestaja = 0;
            for (int i = 0; i < akcija.NamestajNaPopustu.Count; i++)
            {
                cenaNamestaja += akcija.NamestajNaPopustu[i].JedinicnaCena;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    akcija.Id = listaAkcija.Count + 1;
                    for (int i = 0; i < akcija.NamestajNaPopustu.Count; i++)
                    {
                        akcija.NamestajNaPopustu[i].CenaPopust = cenaNamestaja - ((cenaNamestaja * akcija.Popust) / 100);
                        foreach (var namestaj in Projekat.Instance.Namestaj)
                        {
                            if (namestaj.Id == akcija.NamestajNaPopustu[i].Id)
                            {
                                namestaj.CenaPopust = namestaj.JedinicnaCena - ((namestaj.JedinicnaCena * akcija.Popust) / 100);
                            }
                        }
                    }
                    Akcija.Create(akcija);
                    break;
                case Operacija.IZMENA:
                    for (int i = 0; i < akcija.NamestajNaPopustu.Count; i++)
                    {
                        akcija.NamestajNaPopustu[i].CenaPopust = cenaNamestaja - ((cenaNamestaja * akcija.Popust) / 100);
                        foreach (var namestaj in Projekat.Instance.Namestaj)
                        {
                            if (namestaj.Id == akcija.NamestajNaPopustu[i].Id)
                            {
                                namestaj.CenaPopust = namestaj.JedinicnaCena - ((namestaj.JedinicnaCena * akcija.Popust) / 100);
                            }
                        }
                    }
                    Akcija.Update(akcija);
                    Akcija.AddNaAkciji(akcija, dodatiNamestaji);
                    Akcija.DeleteNaAkcija(akcija, obrisani);
                    break;
            }
            Close();
        }
    
        private void UkloniNamestajPopust(object sender, RoutedEventArgs e)
        {
            var odabran = dgNamestajPopust.SelectedItem as Namestaj;
            akcija.NamestajNaPopustu.Remove(odabran);
            obrisani.Add(odabran);
            foreach (var nam in dodatiNamestaji)
            {
                if (nam.Id == odabran.Id) { }
                    dodatiNamestaji.Remove(nam);
            }
        }

        private void dgNamestajPopust_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra" || (string)e.Column.Header == "TipNamestajaId" 
                || (string)e.Column.Header == "KolicinaUMagacinu" || (string)e.Column.Header == "TipNamestaja" || (string)e.Column.Header == "CenaPopust" || (string)e.Column.Header == "ProdataKolicina")
            {
                e.Cancel = true;
            }
        }

        private void IzaberiNamestajNaPopustu(object sender, RoutedEventArgs e)
        {
            NamestajWindow s = new NamestajWindow(NamestajWindow.Operacija.PREUZIMANJE,NamestajWindow.Prozor.PrezumiAkcija);
            if (s.ShowDialog() == true)
            {
              
                akcija.NamestajNaPopustu.Add(s.IzabranNamestaj);
                akcija.NamestajNaPopustuId.Add(s.IzabranNamestaj.Id);
                dodatiNamestaji.Add(s.IzabranNamestaj);
            }
        }
    }

       
         
    
}
