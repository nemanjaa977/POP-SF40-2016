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
            dgAkcija.ItemsSource = view;

            IzabranaAkcija = dgAkcija.SelectedItem as Akcija;

            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool prikazFilter(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            Akcija novaAkcija = new Akcija();
            var akcijeProzor = new EditAkcijeWindow(novaAkcija, EditAkcijeWindow.Operacija.DODAVANJE);
            akcijeProzor.ShowDialog();
            view.Refresh();           
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            var kopija = (Akcija)IzabranaAkcija.Clone();
            var akcijaProzor = new EditAkcijeWindow(kopija, EditAkcijeWindow.Operacija.IZMENA);
            if (akcijaProzor.ShowDialog() == true)
            {
                int index = Projekat.Instance.Akcija.IndexOf(IzabranaAkcija);
                Akcija.Update(kopija);
            }
        }

        private void IzbrisiAkciju(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Akcija.Delete(IzabranaAkcija);   
            }
            view.Refresh();
        }

        private void ZatvoriAkciju(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "NamestajNaPopustuId" || (string)e.Column.Header == "NamestajNaPopustu")
            {
                e.Cancel = true;
            }
        }

        private void PrikaziNamestajNaAkciji(object sender, RoutedEventArgs e)
        {
            var ak = dgAkcija.SelectedItem as Akcija;
            var a = new PrikaziPopustNamestaj(ak);
            a.ShowDialog();
        }
    }
}
