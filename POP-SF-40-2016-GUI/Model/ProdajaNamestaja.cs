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
        private double ukupanIznosPDV;
        private bool obrisan;
        private ObservableCollection<DodatnaUsluga> dodUsluge;
        private ObservableCollection<Namestaj> namProdaja;
   
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
        public double UkupanIznosPDV
        {
            get { return ukupanIznosPDV; }
            set
            {
                ukupanIznosPDV = value;
                OnPropertyChanged("UkupanIznosPDV");
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
                UkupanIznosPDV = ukupanIznosPDV,
                Obrisan = obrisan,
                NamestajZaProdajuId = namestajZaProdajuId,
                DodatnaUslugaId = uslugaId,
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
                    p.Kupac = row["Kupac"].ToString();
                    p.UkupanIznos = double.Parse(row["UkupanIznos"].ToString());
                    p.UkupanIznosPDV = double.Parse(row["UkupanIznosPDV"].ToString());
                    p.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    DataSet ds2 = new DataSet();
                    SqlCommand cmd2 = con.CreateCommand();
                    ObservableCollection<Namestaj> namestajProdaja = new ObservableCollection<Namestaj>();
                    cmd2.CommandText = "SELECT NamestajZaProdajuId FROM ProdajaProzorNamestaj WHERE ProdajaNamestajaId=@ppid AND Obrisan=@obrisan";
                    cmd2.Parameters.AddWithValue("@ppid", p.Id);
                    cmd2.Parameters.AddWithValue("@obrisan", '0');
                    da.SelectCommand = cmd2;
                    da.Fill(ds2, "ProdajaProzorNamestaj");
                    foreach (DataRow row2 in ds2.Tables["ProdajaProzorNamestaj"].Rows)
                    {
                        int id = int.Parse(row2["NamestajZaProdajuId"].ToString());
                        namestajProdaja.Add(Namestaj.GetById(id));
                    }
                    p.NamestajNaProdaja = namestajProdaja;

                    DataSet ds3 = new DataSet();
                    SqlCommand cmd3 = con.CreateCommand();
                    ObservableCollection<DodatnaUsluga> uslugaProdaja = new ObservableCollection<DodatnaUsluga>();
                    cmd3.CommandText = "SELECT DodatnaUslugaId FROM ProdajaProzorUsluga WHERE ProdajaNamestajaId=@plid AND Obrisan=@obr";
                    cmd3.Parameters.AddWithValue("@plid", p.Id);
                    cmd3.Parameters.AddWithValue("@obr", '0');
                    da.SelectCommand = cmd3;
                    da.Fill(ds3, "ProdajaProzorUsluga");
                    foreach (DataRow row3 in ds3.Tables["ProdajaProzorUsluga"].Rows)
                    {
                        int id = int.Parse(row3["DodatnaUslugaId"].ToString());
                        uslugaProdaja.Add(DodatnaUsluga.GetById(id));
                    }
                    p.DodatneUsluge = uslugaProdaja;

                    listaProdaje.Add(p);
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

                cmd.CommandText = "INSERT INTO ProdajaNamestaja (DatumProdaje, BrojRacuna, Kupac, UkupanIznos, UkupanIznosPDV, Obrisan) VALUES(@DatumProdaje, @BrojRacuna, @Kupac, @UkupanIznos, @UkupanIznosPDV, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", n.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", n.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", n.UkupanIznos);
                cmd.Parameters.AddWithValue("UkupanIznosPDV", n.UkupanIznosPDV);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());

                for (int i = 0; i < n.NamestajNaProdaja.Count; i++)
                {
                    SqlCommand cmdd = con.CreateCommand();
                    cmdd.CommandText = "INSERT INTO ProdajaProzorNamestaj (NamestajZaProdajuId, ProdajaNamestajaId, Obrisan) VALUES(@NamestajZaProdajuId, @ProdajaNamestajaId, @Obrisan);";
                    cmdd.Parameters.AddWithValue("NamestajZaProdajuId", n.NamestajNaProdaja[i].Id);
                    cmdd.Parameters.AddWithValue("ProdajaNamestajaId", n.Id);
                    cmdd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                    cmdd.ExecuteNonQuery();
                }

                for (int i = 0; i < n.DodatneUsluge.Count; i++)
                {
                    SqlCommand cmddd = con.CreateCommand();
                    cmddd.CommandText = "INSERT INTO ProdajaProzorUsluga (DodatnaUslugaId, ProdajaNamestajaId, Obrisan) VALUES(@DodatnaUslugaId, @ProdajaNamestajaId, @Obrisan);";
                    cmddd.Parameters.AddWithValue("DodatnaUslugaId", n.DodatneUsluge[i].Id);
                    cmddd.Parameters.AddWithValue("ProdajaNamestajaId", n.Id);
                    cmddd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                    cmddd.ExecuteNonQuery();
                }
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

                cmd.CommandText = "UPDATE ProdajaNamestaja SET DatumProdaje=@DatumProdaje, BrojRacuna=@BrojRacuna, Kupac=@Kupac, UkupanIznos=@UkupanIznos, UkupanIznosPDV=@UkupanIznosPDV, Obrisan=@Obrisan  WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", n.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", n.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", n.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", n.UkupanIznos);
                cmd.Parameters.AddWithValue("UkupanIznosPDV", n.UkupanIznosPDV);
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var namPro in Projekat.Instance.ProdajaNamestaja)
            {
                if (namPro.Id == n.Id)
                {
                    namPro.DatumProdaje = n.DatumProdaje;
                    namPro.BrojRacuna = n.BrojRacuna;
                    namPro.Kupac = n.Kupac;
                    namPro.UkupanIznos = n.UkupanIznos;
                    namPro.UkupanIznosPDV = n.UkupanIznosPDV;
                    namPro.Obrisan = n.Obrisan;
                }
            }
        }

        public static void Delete(ProdajaNamestaja p)
        {
            p.Obrisan = true;
            Update(p);
        }

        public static bool AddProdajaProzorNamestaj(ProdajaNamestaja a, ObservableCollection<Namestaj> dodatiNamestaji)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                for (int i = 0; i < dodatiNamestaji.Count; i++)
                {
                    cmd.CommandText = "INSERT INTO ProdajaProzorNamestaj (NamestajZaProdajuId, ProdajaNamestajaId, Obrisan) VALUES(@ZaProdajuId, @ProdajaNamId, @Obrisan)";
                    cmd.Parameters.AddWithValue("@ZaProdajuId", dodatiNamestaji[i].Id);
                    cmd.Parameters.AddWithValue("@ProdajaNamId", a.Id);
                    cmd.Parameters.AddWithValue("@Obrisan", '0');
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static bool DeleteProdajaProzorNamestaj(ProdajaNamestaja a, ObservableCollection<Namestaj> obrisaniNam)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                for (int i = 0; i < obrisaniNam.Count; i++)
                {
                    cmd.CommandText = "UPDATE ProdajaProzorNamestaj SET Obrisan=@obrisan WHERE NamestajZaProdajuId=@soid AND ProdajaNamestajaId=@pid";
                    cmd.Parameters.AddWithValue("@soid", obrisaniNam[i].Id);
                    cmd.Parameters.AddWithValue("@pid", a.Id);
                    cmd.Parameters.AddWithValue("@obrisan", '1');
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static bool AddProdajaProzorUsluga(ProdajaNamestaja a, ObservableCollection<DodatnaUsluga> dodateUsluge)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                for (int i = 0; i < dodateUsluge.Count; i++)
                {
                    cmd.CommandText = "INSERT INTO ProdajaProzorUsluga (DodatnaUslugaId, ProdajaNamestajaId, Obrisan) VALUES(@DodatnaId, @ProdajaId, @Obrisann)";
                    cmd.Parameters.AddWithValue("@DodatnaId", dodateUsluge[i].Id);
                    cmd.Parameters.AddWithValue("@ProdajaId", a.Id);
                    cmd.Parameters.AddWithValue("@Obrisann", '0');
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public static bool DeleteProdajaProzorUsluga(ProdajaNamestaja a, ObservableCollection<DodatnaUsluga> obrisaneUs)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                for (int i = 0; i < obrisaneUs.Count; i++)
                {
                    cmd.CommandText = "UPDATE ProdajaProzorUsluga SET Obrisan=@obrisan WHERE DodatnaUslugaId=@lid AND ProdajaNamestajaId=@cid";
                    cmd.Parameters.AddWithValue("@lid", obrisaneUs[i].Id);
                    cmd.Parameters.AddWithValue("@cid", a.Id);
                    cmd.Parameters.AddWithValue("@obrisan", '1');
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
        #endregion
    }
}
