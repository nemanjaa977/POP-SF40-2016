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
    /// Interaction logic for EditNamestajWindow.xaml
    /// </summary>
    public partial class EditNamestajWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Namestaj namestaj;
        private Operacija operacija;

        public EditNamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            tbNaziv.DataContext = namestaj;
            tbNazivv.DataContext = namestaj;
            tbNazivi.DataContext = namestaj;
            tbNazivii.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
        }      

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzor(object sender, RoutedEventArgs e)
        {
            var listaa = Projekat.Instance.Namestaj;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    namestaj.Id = listaa.Count + 1;
                    Namestaj.Create(namestaj);
                    break;                  
            }
            Close();
        }
    }
}
