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
            InicijalizujVrednosti(akcija, operacija);
        }

        private void InicijalizujVrednosti(Akcija akcija, Operacija operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            this.tbDatumP.Text = akcija.DatumPocetka.ToString();
            this.tbDatumZ.Text = akcija.DatumZavrsetka.ToString();
            this.tbPopust.Text = akcija.Popust.ToString();

            /*foreach (var nam in Projekat.Instance.Namestaj)
            {
                cbNamestajPopust.Items.Add(nam);
            }

            foreach (Namestaj names in cbNamestajPopust.Items)
            {
                if (names.Id == akcija.NamestajNaPopustuId)
                {
                    cbNamestajPopust.SelectedItem = names;
                    break;
                }
            }*/
        }

        private void ZatvoriProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            //var izabranaAkcija = (Akcija)cbNamestajPopust.SelectedItem;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaAkcija = new Akcija()
                    {
                        Id = listaAkcija.Count + 1,
                        DatumPocetka = DateTime.Parse(this.tbDatumP.Text),
                        DatumZavrsetka = DateTime.Parse(this.tbDatumZ.Text),
                        //NamestajNaPopustuId = izabranaAkcija.Id,
                        Popust = Double.Parse(this.tbPopust.Text)


                    };
                    listaAkcija.Add(novaAkcija);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in listaAkcija)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.DatumPocetka = DateTime.Parse(this.tbDatumP.Text);
                            n.DatumZavrsetka = DateTime.Parse(this.tbDatumZ.Text);
                           // n.NamestajNaPopustuId = izabranaAkcija.Id;
                            n.Popust = Double.Parse(this.tbPopust.Text);
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Akcija = listaAkcija;
            Close();
        }
    }
    
}
