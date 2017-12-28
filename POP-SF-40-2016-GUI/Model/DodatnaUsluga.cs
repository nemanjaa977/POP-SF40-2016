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

namespace POP_40_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {     
        private int id;
        private bool obrisan;
        private string naziv;
        private double cena;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static DodatnaUsluga PronadjiDodatnuUslugu(int id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == id)
                {
                    return usluga;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                Obrisan = obrisan,
                Naziv = naziv,
                Cena = cena
            };
        }

        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAllUsluge()
        {
            var listaUsluga = new ObservableCollection<DodatnaUsluga>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatneUsluge WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatneUsluge"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    var dd = new DodatnaUsluga();
                    dd.Id = int.Parse(row["Id"].ToString());
                    dd.Naziv = row["Naziv"].ToString();
                    dd.Cena = double.Parse(row["Cena"].ToString());
                    dd.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaUsluga.Add(dd);
                }
            }
            return listaUsluga;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES(@Naziv, @Cena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                du.Id = int.Parse(cmd.ExecuteScalar().ToString());     //ExecuteScalar izvrsava upit           
            }
            Projekat.Instance.DodatnaUsluga.Add(du);
            return du;
        }

        public static void Update(DodatnaUsluga ddd)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE DodatneUsluge SET Naziv=@NAziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", ddd.Id);
                cmd.Parameters.AddWithValue("Naziv", ddd.Naziv);
                cmd.Parameters.AddWithValue("Cena", ddd.Cena);
                cmd.Parameters.AddWithValue("Obrisan", ddd.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (ddd.Id == usluga.Id)
                {
                    usluga.Naziv = ddd.Naziv;
                    usluga.Cena = ddd.Cena;
                    usluga.Obrisan = ddd.Obrisan;
                }
            }
        }

        public static void Delete(DodatnaUsluga ddd)
        {
            ddd.Obrisan = true;
            Update(ddd);
        }

        public static DodatnaUsluga GetById(int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatneUsluge WHERE Obrisan=0 AND Id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatneUsluge"); 

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    var dd = new DodatnaUsluga();
                    dd.Id = int.Parse(row["Id"].ToString());
                    dd.Naziv = row["Naziv"].ToString();
                    dd.Cena = double.Parse(row["Cena"].ToString());
                    dd.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    return dd;
                }
            }
            return null;
        }
        #endregion
    }
}
