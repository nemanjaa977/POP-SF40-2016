using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        ICollectionView view;

        public TipNamestaja IzabranTipNamestaja { get; set; } 

        public TipNamestajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestaja);

            view.Filter = prikazFilter;

            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = view;

            IzabranTipNamestaja = dgTipNamestaja.SelectedItem as TipNamestaja;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            List<string> listaTipNamestaja = new List<string>()
            {
                "Naziv"
            };

            cbSortiranjeTipa.ItemsSource = listaTipNamestaja;
            
        }

        private bool prikazFilter(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTip = new TipNamestaja();
            var tipProzor = new EditTipWindow(noviTip, EditTipWindow.Operacija.DODAVANJE);
            tipProzor.ShowDialog();
        } 

        private void IzbrisiTipNamestaja(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranTipNamestaja.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in Projekat.Instance.Namestaj.Where(n=> n.TipNamestaja!=null))
                {
                    if (n.TipNamestaja.Id == IzabranTipNamestaja.Id)
                    {
                        n.TipNamestaja = null;
                        n.TipNamestajaId = 0;
                        Namestaj.Update(n);
                    }
                }
                TipNamestaja.Delete(IzabranTipNamestaja);
               
            }
            view.Refresh();
        }

        private void ZatvoriTipNamestaja(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabranTipNamestaja.Clone();
            var tipProzor = new EditTipWindow(kopija, EditTipWindow.Operacija.IZMENA);
            if (tipProzor.ShowDialog() == true)
            {
                TipNamestaja.Update(kopija);
            }
        }

        private void dgTipNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id") 
            {
                e.Cancel = true;
            }
        }

        private void PretragaTipNamestaja(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                     con.Open();
                     ObservableCollection<TipNamestaja> tipoviNamestaja = new ObservableCollection<TipNamestaja>();
                     string sql = "SELECT * FROM TipNamestaja WHERE Obrisan = 0 AND (Naziv LIKE @nn)";
                     SqlCommand com = new SqlCommand(sql, con);
                     SqlDataAdapter da = new SqlDataAdapter(com);
                     DataSet ds = new DataSet();
                     com.Parameters.AddWithValue("@nn",'%' + tbTipPretraga.Text + '%');
                     da.SelectCommand = com;
                     da.Fill(ds, "TipNamestaja");

                    foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                    {
                        var tn = new TipNamestaja();
                        tn.Id = int.Parse(row["Id"].ToString());
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamestaja.Add(tn);
                    }

                    view = CollectionViewSource.GetDefaultView(tipoviNamestaja);
                    dgTipNamestaja.ItemsSource = view;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbSortiranjeTipa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listaT = Projekat.Instance.TipNamestaja.OrderBy(t => t.Naziv);
            dgTipNamestaja.ItemsSource = listaT;
        }

        private void OsveziTabelu(object sender, RoutedEventArgs e)
        {
            dgTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;
        }
    }
}
