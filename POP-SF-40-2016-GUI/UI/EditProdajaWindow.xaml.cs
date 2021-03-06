﻿using POP_40_2016.Model;
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
            tbKupac.DataContext = prodaja;

            dgDodUsluge.ItemsSource = prodaja.DodatneUsluge;
            dgDodUsluge.IsSynchronizedWithCurrentItem = true;
            dgNamestajj.ItemsSource = prodaja.NamestajNaProdaja;
            dgNamestajj.IsSynchronizedWithCurrentItem = true;
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
                             
                            prodaja.NamestajNaProdaja[i].KolicinaUMagacinu= prodaja.NamestajNaProdaja[i].KolicinaUMagacinu - prodaja.NamestajNaProdaja[i].ProdataKolicina;
                            prodaja.UkupanIznos = (cenaNamestaja * prodaja.NamestajNaProdaja[i].ProdataKolicina) + cenaUsluga;
                            Namestaj.Update(prodaja.NamestajNaProdaja[i]);
                        }
                    prodaja.UkupanIznosPDV = prodaja.UkupanIznos + ((prodaja.UkupanIznos * 20) / 100);
                    ProdajaNamestaja.Create(prodaja);
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

                dgDodUsluge.ItemsSource = prodaja.DodatneUsluge;
                dgDodUsluge.IsSynchronizedWithCurrentItem = true;
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
                nn.IzabranNamestaj.ProdataKolicina = NamestajWindow.UnetaKolicina;
                prodaja.NamestajZaProdajuId.Add(nn.IzabranNamestaj.Id);
                NamestajWindow.UnetaKolicina=0;
                dgNamestajj.ItemsSource = prodaja.NamestajNaProdaja;
                dgNamestajj.IsSynchronizedWithCurrentItem = true;

            }
        }

        private void dgNamestajj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra" 
                || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "TipNamestaja" || (string)e.Column.Header == "KolicinaUMagacinu")
            {
                e.Cancel = true;
            }
        }

        private void UkloniNamestaj(object sender, RoutedEventArgs e)
        {

            try
            {
                if (dgNamestajj.SelectedIndex >= 0)
                {
                    var selected = dgNamestajj.SelectedItem as Namestaj;
                    prodaja.NamestajNaProdaja.Remove(selected);
                    prodaja.NamestajZaProdajuId.Remove(selected.Id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom brisanja usluga!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void UkloniUslugu(object sender, RoutedEventArgs e)

        {
            try
            {
                if (dgDodUsluge.SelectedIndex >= 0)
                {
                    var selected = dgDodUsluge.SelectedItem as DodatnaUsluga;
                    prodaja.DodatneUsluge.Remove(selected);
                    prodaja.DodatnaUslugaId.Remove(selected.Id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom brisanja usluga!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
