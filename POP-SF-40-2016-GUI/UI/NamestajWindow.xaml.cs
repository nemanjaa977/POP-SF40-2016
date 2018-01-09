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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        ICollectionView view;

        public Namestaj IzabranNamestaj { get; set; }

        public enum Operacija { ADMINISTRACIJA, PREUZIMANJE }

        Operacija operacija;
        Prozor prozor;

        public enum Prozor { PrezumiAkcija, PreuzmiProdaja}

        public NamestajWindow(Operacija operacija = Operacija.ADMINISTRACIJA, Prozor prozor=Prozor.PreuzmiProdaja)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.prozor = prozor;
            if (operacija == Operacija.PREUZIMANJE)
            {
                if (prozor == Prozor.PrezumiAkcija)
                {
                    btnDodaj.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzbrisi.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzmeni.Visibility = System.Windows.Visibility.Collapsed;
                    tbKolicina.Visibility = System.Windows.Visibility.Collapsed;
                    labKolicina.Visibility = System.Windows.Visibility.Collapsed;
                    labSort.Visibility = System.Windows.Visibility.Hidden;
                    cbSortiranjeNAmestaj.Visibility = System.Windows.Visibility.Hidden;
                    tbPretragaNamestaj.Visibility = System.Windows.Visibility.Hidden;
                    btnPretragaNamestaj.Visibility = System.Windows.Visibility.Hidden;

                }
                else
                {
                    btnDodaj.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzbrisi.Visibility = System.Windows.Visibility.Collapsed;
                    btnIzmeni.Visibility = System.Windows.Visibility.Collapsed;
                    tbKolicina.Visibility = System.Windows.Visibility.Visible;
                    labKolicina.Visibility = System.Windows.Visibility.Visible;
                    labSort.Visibility = System.Windows.Visibility.Hidden;
                    cbSortiranjeNAmestaj.Visibility = System.Windows.Visibility.Hidden;
                    tbPretragaNamestaj.Visibility = System.Windows.Visibility.Hidden;
                    btnPretragaNamestaj.Visibility = System.Windows.Visibility.Hidden;
                }
            }
            else
            {
                btnPreuzmi.Visibility = System.Windows.Visibility.Hidden;
                labKolicina.Visibility = System.Windows.Visibility.Hidden;
                tbKolicina.Visibility = System.Windows.Visibility.Hidden;
                labSort.Visibility = System.Windows.Visibility.Visible;
                cbSortiranjeNAmestaj.Visibility = System.Windows.Visibility.Visible;
                tbPretragaNamestaj.Visibility = System.Windows.Visibility.Visible;
                btnPretragaNamestaj.Visibility = System.Windows.Visibility.Visible;
            }
    
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);

            view.Filter = prikazFilter;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = view;

            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            List<string> listaNamestajaaa = new List<string>()
            {
                "Naziv", "JedinicnaCena", "Sifra", "KolicinaUMagacinu", "TipNamestaja"
            };
            cbSortiranjeNAmestaj.ItemsSource = listaNamestajaaa;
        }

        private bool prikazFilter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj();
            var namestajProzor = new EditNamestajWindow(noviNamestaj, EditNamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
            view.Refresh();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj kopija = (Namestaj)IzabranNamestaj.Clone();
            var namestajProzor = new EditNamestajWindow(kopija, EditNamestajWindow.Operacija.IZMENA);
            if (namestajProzor.ShowDialog() == true)
            {
                 int index = Projekat.Instance.Namestaj.IndexOf(IzabranNamestaj);
                 Namestaj.Update(kopija);              
            }
            view.Refresh();
        }

        private void IzbrisiNamestaj(object sender, RoutedEventArgs e)
        {       
            if(MessageBox.Show($"Da li zelite da izbrisete: {IzabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                Namestaj.Delete(IzabranNamestaj);                        
            }
            view.Refresh();
        }

        private void ZatvoriNamestaj(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "TipNamestajaId" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "ProdataKolicina") // za uklanjanje kolone Id
            {
                e.Cancel = true;
            }
        }

        private void PreuzmiNamestaj(object sender, RoutedEventArgs e)
        {
            var izabran = dgNamestaj.SelectedItem as Namestaj;
            if (prozor == Prozor.PreuzmiProdaja)
            {
                var kolicina = int.Parse(tbKolicina.Text);
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Id == IzabranNamestaj.Id)
                    {
                        if (n.KolicinaUMagacinu < kolicina)
                        {
                            MessageBox.Show("Nema dovoljno kolicine namestaja u magacinu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (kolicina == 0)
                        {
                            MessageBox.Show("Ne mozete uneti za kolicinu 0!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else if (kolicina < 0)
                        {
                            MessageBox.Show("Ne mozete uneti negativan broj za kolicinu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else 
                        {
                            IzabranNamestaj = izabran;
                            IzabranNamestaj.ProdataKolicina = kolicina;
                            IzabranNamestaj.KolicinaUMagacinu = IzabranNamestaj.KolicinaUMagacinu - kolicina;
                            n.KolicinaUMagacinu = IzabranNamestaj.KolicinaUMagacinu;
                            Namestaj.Update(n);
                        }
                    } 
                }
            }
            else
                IzabranNamestaj = izabran;
            
            this.DialogResult = true;
            this.Close();
        }

        private void dgNamestaj_LostFocus(object sender, RoutedEventArgs e)
        {
            IzabranNamestaj = dgNamestaj.SelectedItem as Namestaj;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var izabrano = cbSortiranjeNAmestaj.SelectedItem as string;
            switch (izabrano)
            {
                case "Naziv":
                    var listaN = Projekat.Instance.Namestaj.OrderBy(n => n.Naziv);
                    dgNamestaj.ItemsSource = listaN;
                    break;
                case "JedinicnaCena":
                    var listaNa = Projekat.Instance.Namestaj.OrderBy(n => n.JedinicnaCena);
                    dgNamestaj.ItemsSource = listaNa;
                    break;
                case "Sifra":
                    var listaNaa = Projekat.Instance.Namestaj.OrderBy(n => n.Sifra);
                    dgNamestaj.ItemsSource = listaNaa;
                    break;
                case "KolicinaUMagacinu":
                    var listaNam = Projekat.Instance.Namestaj.OrderBy(n => n.KolicinaUMagacinu);
                    dgNamestaj.ItemsSource = listaNam;
                    break;
                case "TipNamestaja":
                    var listaNami = Projekat.Instance.Namestaj.OrderBy(n => n.TipNamestaja.Naziv);
                    dgNamestaj.ItemsSource = listaNami;
                    break;
                default:
                    break;
            }
        }

        private void PretragaNamestaj(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    ObservableCollection<Namestaj> listaNamestaja = new ObservableCollection<Namestaj>();
                    string sql = "SELECT * FROM Namestaj WHERE Obrisan=0 AND(Naziv LIKE @nazz OR Sifra LIKE @nazz OR Cena LIKE @nazz OR CenaPopust LIKE @nazz OR Kolicina LIKE @nazz)";
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    com.Parameters.AddWithValue("@nazz", '%'+ tbPretragaNamestaj.Text+'%');
                    da.SelectCommand = com;
                    da.Fill(ds, "Namestaj"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                    {
                        var n = new Namestaj();
                        n.Id = int.Parse(row["Id"].ToString());
                        n.Naziv = row["Naziv"].ToString();
                        n.Sifra = row["Sifra"].ToString();
                        n.JedinicnaCena = double.Parse(row["Cena"].ToString());
                        n.CenaPopust = double.Parse(row["CenaPopust"].ToString());
                        n.KolicinaUMagacinu = Convert.ToInt32(row["Kolicina"]);
                        n.ProdataKolicina = Convert.ToInt32(row["ProdataKolicina"]);
                        n.TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]);
                        n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        listaNamestaja.Add(n);
                    }

                    view = CollectionViewSource.GetDefaultView(listaNamestaja);
                    dgNamestaj.ItemsSource = view;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OsveziNamestajPretraga(object sender, RoutedEventArgs e)
        {
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;
        }
    }
}
