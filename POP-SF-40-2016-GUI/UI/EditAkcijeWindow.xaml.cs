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
    /// Interaction logic for EditAkcijeWindow.xaml
    /// </summary>
    public partial class EditAkcijeWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Akcija akcija;
        private Operacija operacija;

        public EditAkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbDatumP.DataContext = akcija;
            tbDatumZ.DataContext = akcija;
            tbPopust.DataContext = akcija;

            dgNamestajPopust.ItemsSource = akcija.NamestajNaPopustu;
        }


        private void ZatvoriProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    Akcija.Create(akcija);
                    break;
            }
            Close();
        }
    
        private void UkloniNamestajPopust(object sender, RoutedEventArgs e)
        {
            akcija.NamestajNaPopustu.Remove(dgNamestajPopust.SelectedItem as Namestaj);
        }

        private void dgNamestajPopust_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra" || (string)e.Column.Header == "TipNamestajaId" 
                || (string)e.Column.Header == "KolicinaUMagacinu" || (string)e.Column.Header == "TipNamestaja")
            {
                e.Cancel = true;
            }
        }

        private void IzaberiNamestajNaPopustu(object sender, RoutedEventArgs e)
        {
            NamestajWindow s = new NamestajWindow(NamestajWindow.Operacija.PREUZIMANJE);
            if (s.ShowDialog() == true)
            {
                akcija.NamestajNaPopustu.Add(s.IzabranNamestaj);
                akcija.NamestajNaPopustuId.Add(s.IzabranNamestaj.Id);
            }
        }
    }

       
         
    
}
