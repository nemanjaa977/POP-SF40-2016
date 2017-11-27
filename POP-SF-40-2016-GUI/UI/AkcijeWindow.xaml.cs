using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        ICollectionView view;

        public Akcija IzabranaAkcija { get; set; }

        public AkcijeWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);
            view.Filter = prikazFilter;

            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.DataContext = this;
            dgAkcija.ItemsSource = Projekat.Instance.Akcija;           

            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool prikazFilter(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija();
            var akcijeProzor = new EditAkcijeWindow(novaAkcija, EditAkcijeWindow.Operacija.DODAVANJE);
            akcijeProzor.ShowDialog();
           
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            Akcija kopija = (Akcija)IzabranaAkcija.Clone();
            var akcijaProzor = new EditAkcijeWindow(IzabranaAkcija, EditAkcijeWindow.Operacija.IZMENA);
            if (akcijaProzor.ShowDialog() != true)
            {
                int index = Projekat.Instance.Akcija.IndexOf(IzabranaAkcija);
                Projekat.Instance.Akcija[index] = kopija;
            }

        }

        private void IzbrisiAkciju(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranaAkcija}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == IzabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("akcija.xml", listaAkcija);     
            }
        }

        private void ZatvoriAkciju(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
