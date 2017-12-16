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
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string ime;
        private string prezime;
        private string korIme;
        private string lozinka;
        private TipKorisnika tip;
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
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string KorisnickoIme
        {
            get { return korIme; }
            set
            {
                korIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        public TipKorisnika TipKorisnika
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged("TipKorisnika");
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

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korIme,
                Lozinka = lozinka,
                TipKorisnika = tip,
                Obrisan = obrisan
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD
        public static ObservableCollection<Korisnik> GetAllKorisnik()
        {
            var listaKorisnika = new ObservableCollection<Korisnik>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnici WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnici"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                {
                    var tn = new Korisnik();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Ime = row["Ime"].ToString();
                    tn.Prezime = row["Prezime"].ToString();
                    tn.KorisnickoIme = row["KorisnickoIme"].ToString();
                    tn.Lozinka = row["Lozinka"].ToString();
                    tn.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaKorisnika.Add(tn);
                }
            }
            return listaKorisnika;
        }

        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES(@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisnika, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                k.Id = int.Parse(cmd.ExecuteScalar().ToString());     //ExecuteScalar izvrsava upit           
            }
            Projekat.Instance.Korisnik.Add(k);
            return k;
        }

        public static void Update(Korisnik kk)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Korisnici SET Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", kk.Id);
                cmd.Parameters.AddWithValue("Ime", kk.Ime);
                cmd.Parameters.AddWithValue("Prezime", kk.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", kk.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", kk.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", kk.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", kk.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var kor in Projekat.Instance.Korisnik)
            {
                if (kk.Id == kor.Id)
                {
                    kor.Ime = kk.Ime;
                    kor.Prezime = kk.Prezime;
                    kor.KorisnickoIme = kk.KorisnickoIme;
                    kor.Lozinka = kk.Lozinka;
                    kor.TipKorisnika = kk.TipKorisnika;
                    kor.Obrisan = kk.Obrisan;
                }
            }
        }

        public static void Delete(Korisnik ka)
        {
            ka.Obrisan = true;
            Update(ka);
        }
        #endregion
    }
}
