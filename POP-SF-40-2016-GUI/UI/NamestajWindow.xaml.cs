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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        //private Namestaj izabranNamestaj;
        public Namestaj IzabranNamestaj { get; set; }

        public NamestajWindow()
        {
            InitializeComponent();

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;

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
            
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            //var izabraniNamestaj = (Namestaj)dgNamestaj.SelectedItem;
            Namestaj kopija = (Namestaj)IzabranNamestaj.Clone();
            var namestajProzor = new EditNamestajWindow(kopija, EditNamestajWindow.Operacija.IZMENA);
            namestajProzor.ShowDialog();
            
            
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {
            //var izabraniNamestaj = (Namestaj)dgNamestaj.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;

            if(MessageBox.Show($"Da li zelite da izbrisete: {IzabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                foreach (var nam in listaNamestaja)
                {
                    if(nam.Id == IzabranNamestaj.Id)
                    {
                        nam.Obrisan = true;
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
    }
}
