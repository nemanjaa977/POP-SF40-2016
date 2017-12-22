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
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
       
        private int id;
        private List<int> namestajZaProdajuId;
        private DateTime datumProdaje;
        private int brojRacuna;
        private string kupac;
        private List<int> uslugaId;
        private double ukupanIznos;
        private bool obrisan;
        private ObservableCollection<DodatnaUsluga> dodUsluge;
        private ObservableCollection<Namestaj> namProdaja;
        private int kolicina;
   
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        public int BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }
        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }
        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
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

        public int KolicinaNamestaja
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("KolicinaNamestaja");
            }
        }

        public List<int> NamestajZaProdajuId 
        {
            get { return namestajZaProdajuId; }
            set {
                namestajZaProdajuId = value;
                OnPropertyChanged("NamestajZaProdajuId");
                }
        }

        public List<int> DodatnaUslugaId
        {
            get { return uslugaId; }
            set
            {
                uslugaId = value;
                OnPropertyChanged("DodatnaUslugaId");
            }
        }

        public const double PDV = 0.2;

        public ProdajaNamestaja()
        {
            datumProdaje = DateTime.Today;
            dodUsluge = new ObservableCollection<DodatnaUsluga>();
            namProdaja = new ObservableCollection<Namestaj>();
            uslugaId = new List<int>();
            namestajZaProdajuId = new List<int>();
        }

        [XmlIgnore]
        public ObservableCollection<DodatnaUsluga> DodatneUsluge
        {
            get
            {
                if (dodUsluge.Count == 0)
                {                                 
                    dodUsluge = PronadjiUsluge(uslugaId);                                 
                }
                return dodUsluge;
            }
            set
            {
                dodUsluge = value;                             
                uslugaId=PronadjiIdUsluga(dodUsluge);
                OnPropertyChanged("DodatneUsluge");              
            }
        }

        [XmlIgnore]
        public ObservableCollection<Namestaj> NamestajNaProdaja
        {
            get
            {
                if (namProdaja.Count == 0)
                {
                    namProdaja = PronadjiNamestaj(namestajZaProdajuId);               
                }
                return namProdaja;
            }
            set
            {
                namProdaja = value;
                namestajZaProdajuId = PronadjiIdNamestaja(namProdaja);
                OnPropertyChanged("NamestajNaProdaja");              
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                UkupanIznos = ukupanIznos,
                Obrisan = obrisan,
                NamestajZaProdajuId = namestajZaProdajuId,
                DodatnaUslugaId = uslugaId,
                KolicinaNamestaja = kolicina,
                NamestajNaProdaja = namProdaja,
                DodatneUsluge = dodUsluge
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static ObservableCollection<DodatnaUsluga> PronadjiUsluge(List<int> uslugeId)
        {
            if (uslugeId != null)
            {
                var lista = new ObservableCollection<DodatnaUsluga>();
                for (int i = 0; i < uslugeId.Count; i++)
                {
                    var usluga = DodatnaUsluga.PronadjiDodatnuUslugu(uslugeId[i]);
                    lista.Add(usluga);
                }
                return lista;
            }
            return null;
        }

        public static List<int> PronadjiIdUsluga(ObservableCollection<DodatnaUsluga> usluge)
        {
            var lista = new List<int>();
            if (usluge != null) { 
                for (int i = 0; i < usluge.Count; i++)
                {
                    var id=usluge[i].Id;
                    lista.Add(id);
                }
                return lista;
            }
            return null;
        }

        public static ObservableCollection<Namestaj> PronadjiNamestaj(List<int> namestajId)
        {
            if (namestajId != null)
            {
                var lista = new ObservableCollection<Namestaj>();
                for (int i = 0; i < namestajId.Count; i++)
                {
                    var nam = Namestaj.PronadjiNamestajZaProdaju(namestajId[i]);
                    lista.Add(nam);
                }
                return lista;
            }
            return null;
        }

        public static List<int> PronadjiIdNamestaja(ObservableCollection<Namestaj> namestaji)
        {
            var lista = new List<int>();
            if (namestaji != null)
            {
                for (int i = 0; i < namestaji.Count; i++)
                {
                    var id = namestaji[i].Id;
                    lista.Add(id);
                }
                return lista;
            }
            return null;
        }

        #region CRUD

        public static ObservableCollection<ProdajaNamestaja> GetAllProdajaNamestaja()
        {
            var listaProdaje = new ObservableCollection<ProdajaNamestaja>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM ProdajaNamestaja WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "ProdajaNamestaja");

                foreach (DataRow row in ds.Tables["ProdajaNamestaja"].Rows)
                {
                    var p = new ProdajaNamestaja();
                    p.Id = int.Parse(row["Id"].ToString());
                    p.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    p.BrojRacuna = int.Parse(row["BrojRacuna"].ToString());
                    p.KolicinaNamestaja = int.Parse(row["KolicinaNamestaja"].ToString());
                    p.Kupac = row["Kupac"].ToString();
                    p.UkupanIznos = double.Parse(row["UkupanIznos"].ToString());
                    p.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    
                    listaProdaje.Add(p);
                }

                DataSet ds2 = new DataSet();
                foreach (var prod in listaProdaje)
                {

                    ObservableCollection<Namestaj> namestajProdaja = new ObservableCollection<Namestaj>();
                    cmd.CommandText = "SELECT NamestajZaProdajuId FROM ProdajaProzorNamestaj WHERE ProdajaNamestajaId=@id";
                    cmd.Parameters.AddWithValue("@id", prod.Id);
                    da.SelectCommand = cmd;
                    da.Fill(ds2, "ProdajaProzorNamestaj");
                    foreach (DataRow row in ds2.Tables["ProdajaProzorNamestaj"].Rows)
                    {
                        int id = int.Parse(row["NamestajZaProdajuId"].ToString());
                        namestajProdaja.Add(Namestaj.GetById(id));
                    }
                    prod.NamestajNaProdaja = namestajProdaja;
                }

                DataSet ds3 = new DataSet();
                foreach (var pro in listaProdaje)
                {

                    ObservableCollection<DodatnaUsluga> namestajProdaja = new ObservableCollection<DodatnaUsluga>();
                    cmd.CommandText = "SELECT DodatnaUslugaId FROM ProdajaProzorUsluga WHERE ProdajaNamestajaId=@id";
                    cmd.Parameters.AddWithValue("@id", pro.Id);
                    da.SelectCommand = cmd;
                    da.Fill(ds3, "ProdajaProzorUsluga");
                    foreach (DataRow row in ds3.Tables["ProdajaProzorUsluga"].Rows)
                    {
                        int id = int.Parse(row["DodatnaUslugaId"].ToString());
                        namestajProdaja.Add(DodatnaUsluga.GetById(id));
                    }
                    pro.DodatneUsluge = namestajProdaja;
                }
            }
            return listaProdaje;
        }

        public static ProdajaNamestaja Create(ProdajaNamestaja n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO ProdajaNamestaja (DatumProdaje, BrojRacuna, KolicinaNamestaja, Kupac, UkupanIznos, Obrisan) VALUES(@DatumProdaje, @BrojRacuna, @KolicinaNamestaja, @Kupac, @UkupanIznos, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", n.BrojRacuna);
                cmd.Parameters.AddWithValue("KolicinaNamestaja", n.KolicinaNamestaja);
                cmd.Parameters.AddWithValue("Kupac", n.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", n.UkupanIznos);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            Projekat.Instance.ProdajaNamestaja.Add(n);
            return n;
        }

        public static void Update(ProdajaNamestaja n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE ProdajaNamestaja SET DatumProdaje=@DatumProdaje, BrojRacuna=@BrojRacuna, KolicinaNamestaja=@KolicinaNamestaja, Kupac=@Kupac, UkupanIznos=@UkupanIznos, Obrisan=@Obrisan  WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", n.BrojRacuna);
                cmd.Parameters.AddWithValue("KolicinaNamestaja", n.KolicinaNamestaja);
                cmd.Parameters.AddWithValue("Kupac", n.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", n.UkupanIznos);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var namPro in Projekat.Instance.ProdajaNamestaja)
            {
                if (namPro.Id == n.Id)
                {
                    namPro.DatumProdaje = n.DatumProdaje;
                    namPro.BrojRacuna = n.BrojRacuna;
                    namPro.KolicinaNamestaja = n.KolicinaNamestaja;
                    namPro.Kupac = n.Kupac;
                    namPro.UkupanIznos = n.UkupanIznos;
                    namPro.Obrisan = n.Obrisan;
                }
            }
        }

        public static void Delete(ProdajaNamestaja p)
        {
            p.Obrisan = true;
            Update(p);
        }

        #endregion
    }
}
