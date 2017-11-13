using POP_40_2016.Model;
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
        public NamestajWindow()
        {
            InitializeComponent();
            OSveziPrikaz();
        }
        private void OSveziPrikaz()
        {
            lbNamestaj.Items.Clear();
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Obrisan == false)
                {

                    lbNamestaj.Items.Add(namestaj);
                }
            }
            lbNamestaj.SelectedIndex = 0;
        }


        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = "",
                Sifra = "",
                JedinicnaCena = 0,
                KolicinaUMagacinu = 0,
                TipNamestajaId = 0
            };

            var namestajProzor = new EditNamestajWindow(noviNamestaj, EditNamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            OSveziPrikaz();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var namestajProzor = new EditNamestajWindow(izabraniNamestaj, EditNamestajWindow.Operacija.IZMENA);
            namestajProzor.ShowDialog();
            OSveziPrikaz();
            
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;

            if(MessageBox.Show($"Da li zelite da izbrisete: {izabraniNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                foreach (var nam in listaNamestaja)
                {
                    if(nam.Id == izabraniNamestaj.Id)
                    {
                        nam.Obrisan = true;
                    }
                }
                Projekat.Instance.Namestaj = listaNamestaja;
                OSveziPrikaz();
            }

        }

        private void ZatvoriNamestaj(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
