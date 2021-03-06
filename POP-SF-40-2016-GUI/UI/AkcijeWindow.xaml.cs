﻿using POP_40_2016.Model;
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

            List<string> listaAkcijaaa = new List<string>()
            {
                "DatumPocetka", "DatumZavrsetka", "Popust"
            };
            cbSortAkcije.ItemsSource = listaAkcijaaa;
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
            akcijaProzor.ShowDialog();
            view.Refresh();
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

        private void cbSortAkcije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var izabrano = cbSortAkcije.SelectedItem as string;
            switch (izabrano)
            {
                case "DatumPocetka":
                    var listaAs = Projekat.Instance.Akcija.OrderBy(a => a.DatumPocetka);
                    dgAkcija.ItemsSource = listaAs;
                    break;
                case "DatumZavrsetka":
                    var listaAc = Projekat.Instance.Akcija.OrderBy(a => a.DatumZavrsetka);
                    dgAkcija.ItemsSource = listaAc;
                    break;
                case "Popust":
                    var listaAy = Projekat.Instance.Akcija.OrderBy(a => a.Popust);
                    dgAkcija.ItemsSource = listaAy;
                    break;
                default:
                    break;
            }
        }

        private void PretragaAkcija(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    ObservableCollection<Akcija> listaAkcija = new ObservableCollection<Akcija>();
                    string sql = "SELECT * FROM Akcije WHERE Obrisan=0 AND (DatumPocetka LIKE @datet OR DatumKraja LIKE @datet OR Popust LIKE @datet) ";
                    SqlCommand com = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    com.Parameters.AddWithValue("@datet",'%' + tbPretragaAkcija.Text + '%');
                    da.SelectCommand = com;
                    da.Fill(ds, "Akcije");

                    foreach (DataRow row in ds.Tables["Akcije"].Rows)
                    {
                        var a = new Akcija();
                        a.Id = int.Parse(row["Id"].ToString());
                        a.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                        a.DatumZavrsetka = DateTime.Parse(row["DatumKraja"].ToString());
                        a.Popust = double.Parse(row["Popust"].ToString());
                        a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        listaAkcija.Add(a);
                    }

                    view = CollectionViewSource.GetDefaultView(listaAkcija);
                    dgAkcija.ItemsSource = view;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OsveziAkciju(object sender, RoutedEventArgs e)
        {
            dgAkcija.ItemsSource = Projekat.Instance.Akcija;
        }
    }
}
