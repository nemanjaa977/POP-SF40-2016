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
using System.Xml.Serialization;

namespace POP_40_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private double jedinicnaCena;
        private int tipNamestajaId;
        private bool obrisan;
        private string sifra;
        private int kolicina;
        private TipNamestaja tippNamestaja;

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

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public Double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }

        [XmlIgnore]

        public TipNamestaja TipNamestaja 
        {
            get {
                if(tippNamestaja == null)
                {
                    tippNamestaja = TipNamestaja.PronadjiTip(TipNamestajaId);
                }
                return tippNamestaja;

                }
            set {
                tippNamestaja = value;
                TipNamestajaId = tippNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
                }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }

        public  bool Obrisan
        {
            get { return obrisan; }
            set {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public static Namestaj PronadjiNamestajNaPopustu(int id)
        {
            foreach (var naPopustu in Projekat.Instance.Namestaj)
            {
                if (naPopustu.Id == id)
                {
                    return naPopustu;
                }
            }
            return null;
        }

        public static Namestaj PronadjiNamestajZaProdaju(int id)
        {
            foreach (var zaProdaju in Projekat.Instance.Namestaj)
            {
                if (zaProdaju.Id == id)
                {
                    return zaProdaju;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                JedinicnaCena = jedinicnaCena,
                Obrisan = obrisan,
                TipNamestaja = tippNamestaja,
                TipNamestajaId = tipNamestajaId,
                KolicinaUMagacinu = kolicina,
                Sifra = sifra
            };
        }

        public override string ToString()
        {
            return $"{Naziv}"; //{Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {TipNamestaja.PronadjiTip(TipNamestajaId).Naziv}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD

        public static ObservableCollection<Namestaj> GetAllNamestaj()
        {
            var listaNamestaja = new ObservableCollection<Namestaj>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.JedinicnaCena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = Convert.ToInt32(row["Kolicina"]);
                    n.TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaNamestaja.Add(n);
                }
            }
            return listaNamestaja;
        }

        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Namestaj (Naziv, Obrisan, TipNamestajaId, Sifra, Cena, Kolicina) VALUES(@Naziv, @Obrisan, @TipNamestajaId, @Sifra, @Cena, @Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu); 

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
                
            }
            Projekat.Instance.Namestaj.Add(n);
            return n;
        }

        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Namestaj SET Naziv=@Naziv, Obrisan=@Obrisan, TipNamestajaId=@TipNamestajaId, Sifra=@Sifra, Cena=@Cena, Kolicina=@Kolicina  WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);

                cmd.ExecuteNonQuery();
            }
            foreach (var nam in Projekat.Instance.Namestaj)
            {
                if (nam.Id == n.Id)
                {
                    nam.Naziv = n.Naziv;
                    nam.Obrisan = n.Obrisan;
                    nam.TipNamestajaId = n.TipNamestajaId;
                    nam.Sifra = n.Sifra;
                    nam.JedinicnaCena = n.JedinicnaCena;
                    nam.KolicinaUMagacinu = n.KolicinaUMagacinu;
                }
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion



    }
}
