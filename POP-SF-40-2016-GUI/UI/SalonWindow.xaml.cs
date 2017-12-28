using POP_40_2016.Model;
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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        ICollectionView view;

        public SalonWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Salon);

            dgPrikaziSalon.IsSynchronizedWithCurrentItem = true;
            dgPrikaziSalon.DataContext = this;
            dgPrikaziSalon.ItemsSource = view;

            dgPrikaziSalon.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgPrikaziSalon_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
        }
    }
}
