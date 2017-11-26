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

            this.tip = tip;
            this.operacija = operacija;

            tbNaziv.DataContext = tip;
        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajProzor(object sender, RoutedEventArgs e)
        {
            var listaTipovaNam = Projekat.Instance.TipNamestaja;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    tip.Id = listaTipovaNam.Count + 1;
                    listaTipovaNam.Add(tip);
                    break;
            }
            GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipovaNam);
            Close();
        }
    }
}
