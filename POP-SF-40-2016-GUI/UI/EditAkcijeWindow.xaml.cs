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

            cbNamestajPopust.ItemsSource = Projekat.Instance.Namestaj;

            tbDatumP.DataContext = akcija;
            tbDatumZ.DataContext = akcija;
            tbPopust.DataContext = akcija;
            cbNamestajPopust.DataContext = akcija;
        }


        private void ZatvoriProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzorEditAkcije(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                        akcija.Id = listaAkcija.Count + 1;
                        listaAkcija.Add(akcija);
                        break;
            }
            GenericSerializer.Serialize("akcija.xml", listaAkcija);
            Close();
        }
    }
    
}
