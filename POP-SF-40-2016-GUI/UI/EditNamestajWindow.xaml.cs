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
            InicijalizujVrednosti(namestaj, operacija);
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
            this.tbNazivv.Text = namestaj.Sifra;
            this.tbNazivi.Text = namestaj.JedinicnaCena.ToString("0.###");
            this.tbNazivii.Text = namestaj.KolicinaUMagacinu.ToString();
            this.tbNaziviii.Text = namestaj.TipNamestajaId.ToString();

        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzor(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamesstaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        Sifra = this.tbNazivv.Text,
                        JedinicnaCena = Double.Parse(this.tbNazivi.Text),
                        KolicinaUMagacinu = int.Parse(this.tbNazivii.Text),
                        TipNamestajaId = int.Parse(this.tbNaziviii.Text)


                    };
                    listaNamestaja.Add(noviNamesstaj);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.Sifra = this.tbNazivv.Text;
                            n.JedinicnaCena = Double.Parse(this.tbNazivi.Text);
                            n.KolicinaUMagacinu = int.Parse(this.tbNazivii.Text);
                            n.TipNamestajaId = int.Parse(this.tbNaziviii.Text);
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Namestaj = listaNamestaja;
            Close();
        }
    }
}
