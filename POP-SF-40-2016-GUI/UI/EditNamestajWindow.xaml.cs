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
            //InicijalizujVrednosti(namestaj, operacija);
            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            tbNaziv.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;

        }

        /*private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            //this.namestaj = namestaj;
            //this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
            this.tbNazivv.Text = namestaj.Sifra;
            this.tbNazivi.Text = namestaj.JedinicnaCena.ToString("0.###");
            this.tbNazivii.Text = namestaj.KolicinaUMagacinu.ToString();

            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(tipNamestaja);    
            }

            foreach (TipNamestaja tipN in cbTipNamestaja.Items)
            {
                if(tipN.Id == namestaj.TipNamestajaId)
                {
                    cbTipNamestaja.SelectedItem = tipN;
                    break;
                }
            }

        }*/

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzor(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            //var izabranTip = (TipNamestaja)cbTipNamestaja.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    namestaj.Id = listaNamestaja.Count + 1;                                                                         
                    /*Naziv = this.tbNaziv.Text,
                    Sifra = this.tbNazivv.Text,
                    JedinicnaCena = Double.Parse(this.tbNazivi.Text),
                    KolicinaUMagacinu = int.Parse(this.tbNazivii.Text),*/
                    listaNamestaja.Add(namestaj);
                    break;                  
                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {

                            n.Naziv = namestaj.Naziv;
                            n.Sifra = namestaj.Sifra;
                            n.JedinicnaCena = Double.Parse(this.tbNazivi.Text);
                            n.KolicinaUMagacinu = int.Parse(this.tbNazivii.Text);
                            n.TipNamestaja = namestaj.TipNamestaja;                       
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
            Projekat.Instance.Namestaj = listaNamestaja;
            Close();
        }
    }
}
