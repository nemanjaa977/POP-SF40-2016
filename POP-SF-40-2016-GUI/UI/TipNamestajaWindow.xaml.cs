﻿using POP_40_2016.Model;
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
    /// Interaction logic for TipNamestaja.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        ICollectionView view;

        public TipNamestaja IzabranTipNamestaja { get; set; } 

        public TipNamestajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(TipNamestaja.GetAllTipNamestaja());

            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = view;

            IzabranTipNamestaja = dgTipNamestaja.SelectedItem as TipNamestaja;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja();
            var tipProzor = new EditTipWindow(noviTip, EditTipWindow.Operacija.DODAVANJE);
            tipProzor.ShowDialog();
            Osvezi();
        } 

        private void IzbrisiTipNamestaja(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranTipNamestaja.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TipNamestaja.Delete(IzabranTipNamestaja);
            }
            Osvezi();
        }

        private void ZatvoriTipNamestaja(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabranTipNamestaja.Clone();
            var tipProzor = new EditTipWindow(kopija, EditTipWindow.Operacija.IZMENA);
            if (tipProzor.ShowDialog() == true)
            {
                int index = Projekat.Instance.TipNamestaja.IndexOf(IzabranTipNamestaja);
                TipNamestaja.Update(kopija);
            }
            Osvezi();
        }

        private void dgTipNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id") 
            {
                e.Cancel = true;
            }
        }

        public void Osvezi()
        {
            view = CollectionViewSource.GetDefaultView(TipNamestaja.GetAllTipNamestaja());
            dgTipNamestaja.ItemsSource = view;
        }
    }
}
