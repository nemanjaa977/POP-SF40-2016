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

namespace POP_40_2016.Model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public static TipNamestaja PronadjiTip(int id)
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }

        #region CRUD
        public static ObservableCollection<TipNamestaja> GetAllTipNamestaja()
        {
            try
            {
                var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0;";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamestaja"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                    {
                        var tn = new TipNamestaja();
                        tn.Id = int.Parse(row["Id"].ToString());
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamestaja.Add(tn);
                    }
                }
                return tipoviNamestaja;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom ucitavanja tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES(@Naziv, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    tn.Id = int.Parse(cmd.ExecuteScalar().ToString());     //ExecuteScalar izvrsava upit           
                }
                Projekat.Instance.TipNamestaja.Add(tn);
                return tn;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom kreiranja tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static void Update(TipNamestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@TId;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("TId", tn.Id);
                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    cmd.ExecuteNonQuery();
                }
                foreach (var tip in Projekat.Instance.TipNamestaja)
                {
                    if (tn.Id == tip.Id)
                    {
                        tip.Naziv = tn.Naziv;
                        tip.Obrisan = tn.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom izmene tipa namestaja!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);

        }
        #endregion
    }

}
