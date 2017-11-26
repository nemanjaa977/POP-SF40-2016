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
    /// Interaction logic for EditDodatneUsluge.xaml
    /// </summary>
    public partial class EditDodatneUsluge : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private DodatnaUsluga dUsluga;
        private Operacija operacija;

        public EditDodatneUsluge(DodatnaUsluga dUsluga, Operacija operacija)
        {
            InitializeComponent();

            this.dUsluga = dUsluga;
            this.operacija = operacija;

            tbNaziv.DataContext = dUsluga;
            tbCena.DataContext = dUsluga;
        }

        private void ZatvoriEditProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajEditProzor(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    dUsluga.Id = listaUsluga.Count + 1;
                    listaUsluga.Add(dUsluga);
                    break;
            }
            GenericSerializer.Serialize("dodatnaUsluga.xml", listaUsluga);
            Close();
        }
    }
}
