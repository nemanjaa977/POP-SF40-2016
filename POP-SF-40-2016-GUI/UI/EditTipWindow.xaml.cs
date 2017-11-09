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
    /// Interaction logic for EditTipWindow.xaml
    /// </summary>
    public partial class EditTipWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private TipNamestaja tip;
        private Operacija operacija;

        public EditTipWindow(TipNamestaja tip, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(tip, operacija);
        }

        private void InicijalizujVrednosti(TipNamestaja tip, Operacija operacija)
        {
            this.tip = tip;
            this.operacija = operacija;

            this.tbNaziv.Text = tip.Naziv;

        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzor(object sender, RoutedEventArgs e)
        {
            var listaTipovaNam = Projekat.Instance.TipNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviTip = new TipNamestaja()
                    {
                        Id = listaTipovaNam.Count + 1,
                        Naziv = this.tbNaziv.Text                        

                    };
                    listaTipovaNam.Add(noviTip);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in listaTipovaNam)
                    {
                        if (n.Id == tip.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;                          
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.TipNamestaja = listaTipovaNam;
            Close();
        }
    }
}
