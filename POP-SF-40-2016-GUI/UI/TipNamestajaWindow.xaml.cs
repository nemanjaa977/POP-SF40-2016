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
    /// Interaction logic for TipNamestaja.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public TipNamestajaWindow()
        {
            InitializeComponent();
            OSveziPrikaz();
        }

        private void OSveziPrikaz()
        {
            lbTipNamestaja.Items.Clear();
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Obrisan == false)
                {
                    lbTipNamestaja.Items.Add(tip);
                }
            }
            lbTipNamestaja.SelectedIndex = 0;
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""            
            };

            var tipProzor = new EditTipWindow(noviTip, EditTipWindow.Operacija.DODAVANJE);
            tipProzor.ShowDialog();
            OSveziPrikaz();
        } 

        private void IzbrisiTipNamestaja(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var listaTipova = Projekat.Instance.TipNamestaja;
            if (MessageBox.Show($"Da li zelite da izbrisete: {izabraniTip.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var t in listaTipova)
                {
                    if(t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                    }
                }
                Projekat.Instance.TipNamestaja = listaTipova;
                OSveziPrikaz();
            }
        }

        private void ZatvoriTipNamestaja(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            var izabraniTip = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var tipProzor = new EditTipWindow(izabraniTip, EditTipWindow.Operacija.IZMENA);
            tipProzor.ShowDialog();
            OSveziPrikaz();
        }
    }
}
