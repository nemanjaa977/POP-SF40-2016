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
using System.Xml.Serialization;

namespace POP_40_2016.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private List<int> namestajPopustId;
        private double popust;
        public ObservableCollection<Namestaj> namestajNaPopustu;

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
        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }
        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }
        public List<int> NamestajNaPopustuId
        {
            get { return namestajPopustId; }
            set
            {
                namestajPopustId = value;
                OnPropertyChanged("NamestajNaPopustuId");
            }
        }
        public double Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        public override string ToString()
        {
            return $"{DatumPocetka}, {DatumZavrsetka}";//, {Namestaj.PronadjiNamestajNaPopustu(NamestajNaPopustuId).Naziv}, {Popust}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Akcija()
        {
            datumPocetka = DateTime.Today;
            datumZavrsetka = DateTime.Today;
            namestajNaPopustu = new ObservableCollection<Namestaj>();
            namestajPopustId = new List<int>();
        }
        public object Clone()
        {
            return new Akcija()
            {
                Id = id,
                Obrisan = obrisan,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = datumZavrsetka,
                NamestajNaPopustuId = namestajPopustId,
                Popust = popust,
                NamestajNaPopustu = namestajNaPopustu
            };
        }

        [XmlIgnore]
        public ObservableCollection<Namestaj> NamestajNaPopustu
        {
            get
            {
                if (namestajNaPopustu.Count == 0)
                {
                    namestajNaPopustu = PronadjiNamestaj(namestajPopustId);
                }
                return namestajNaPopustu;
            }
            set
            {
                namestajNaPopustu = value;
                namestajPopustId = PronadjiIdNamestajPopust(namestajNaPopustu);
                OnPropertyChanged("NamestajNaPopustu");
            }
        }

        public static List<int> PronadjiIdNamestajPopust(ObservableCollection<Namestaj> nam)
        {
            var lista = new List<int>();
            if (nam != null)
            {
                for (int i = 0; i < nam.Count; i++)
                {
                    var id = nam[i].Id;
                    lista.Add(id);
                }
                return lista;
            }
            return null;
        }

        public static ObservableCollection<Namestaj> PronadjiNamestaj(List<int> namId)
        {
            if (namId != null)
            {
                var lista = new ObservableCollection<Namestaj>();
                for (int i = 0; i < namId.Count; i++)
                {
                    var n = Namestaj.PronadjiNamestajNaPopustu(namId[i]);
                    lista.Add(n);
                }
                return lista;
            }
            return null;
        }

        #region CRUD
        public static ObservableCollection<Akcija> GetAllAkcija()
        {
            try
            {
                var listaAkcija = new ObservableCollection<Akcija>();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM Akcije WHERE Obrisan=0;";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Akcije"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["Akcije"].Rows)
                    {
                        var a = new Akcija();
                        a.Id = int.Parse(row["Id"].ToString());
                        a.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                        a.DatumZavrsetka = DateTime.Parse(row["DatumKraja"].ToString());
                        a.Popust = double.Parse(row["Popust"].ToString());
                        a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = con.CreateCommand();
                        ObservableCollection<Namestaj> namestajAkcija = new ObservableCollection<Namestaj>();
                        cmd2.CommandText = "SELECT NamestajNaPopustuId FROM NAAKCIJI WHERE AkcijaId=@uuid AND Obrisan=@o";
                        cmd2.Parameters.AddWithValue("@uuid", a.Id);
                        cmd2.Parameters.AddWithValue("@o", '0');
                        da.SelectCommand = cmd2;
                        da.Fill(ds2, "NAAKCIJI");
                        foreach (DataRow row2 in ds2.Tables["NAAKCIJI"].Rows)
                        {
                            int id = int.Parse(row2["NamestajNaPopustuId"].ToString());
                            namestajAkcija.Add(Namestaj.GetById(id));
                        }
                        a.NamestajNaPopustu = namestajAkcija;

                        listaAkcija.Add(a);
                    }
                }
                return listaAkcija;
            }
            catch (Exception)
            {
                MessageBox.Show("Greska prilikom ucitavanja akcija!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null; 
                
            }
        }

        public static Akcija Create(Akcija a)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO Akcije (DatumPocetka, DatumKraja, Popust, Obrisan) VALUES(@DatumPocetka, @DatumKraja, @Popust, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                    cmd.Parameters.AddWithValue("DatumKraja", a.DatumZavrsetka);
                    cmd.Parameters.AddWithValue("Popust", a.Popust);
                    cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                    a.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    for (int i = 0; i < a.NamestajNaPopustu.Count; i++)
                    {
                        SqlCommand cmdd = con.CreateCommand();
                        cmdd.CommandText = "INSERT INTO NAAKCIJI (NamestajNaPopustuId, AkcijaId, Obrisan) VALUES(@NamestajNaPopustuId, @AkcijaId, @Obrisan);";
                        cmdd.Parameters.AddWithValue("NamestajNaPopustuId", a.NamestajNaPopustu[i].Id);
                        cmdd.Parameters.AddWithValue("AkcijaId", a.Id);
                        cmdd.Parameters.AddWithValue("Obrisan", a.Obrisan);
                        cmdd.ExecuteNonQuery();
                    }
                }
                Projekat.Instance.Akcija.Add(a);
                return a;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom kreiranja akcije!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public static void Update(Akcija a)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE Akcije SET DatumPocetka=@DatumPocetka, DatumKraja=@DatumKraja, Popust=@Popust, Obrisan=@Obrisan WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", a.Id);
                    cmd.Parameters.AddWithValue("DatumPocetka", a.DatumPocetka);
                    cmd.Parameters.AddWithValue("DatumKraja", a.DatumZavrsetka);
                    cmd.Parameters.AddWithValue("Popust", a.Popust);
                    cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                    cmd.ExecuteNonQuery();
                }

                foreach (var ak in Projekat.Instance.Akcija)
                {
                    if (ak.Id == a.Id)
                    {
                        ak.DatumPocetka = a.DatumPocetka;
                        ak.DatumZavrsetka = a.DatumZavrsetka;
                        ak.Popust = a.Popust;
                        ak.Obrisan = a.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom izmene akcije!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void Delete(Akcija a)
        {
            a.Obrisan = true;
            foreach (var item in a.NamestajNaPopustu)
            {
                item.CenaPopust = 0;
                Namestaj.Update(item);
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if(n.Id == item.Id)
                    {
                        n.CenaPopust = 0;
                    }
                }
            }
            Update(a);
        }

        public static bool AddNaAkciji(Akcija a, ObservableCollection<Namestaj>dodatiNamestaji)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    for (int i = 0; i < dodatiNamestaji.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO NAAKCIJI (NamestajNaPopustuId, AkcijaId, Obrisan) VALUES(@nnn, @AkcijaId, @Obrisan)";
                        cmd.Parameters.AddWithValue("@nnn", dodatiNamestaji[i].Id);
                        cmd.Parameters.AddWithValue("@AkcijaId", a.Id);
                        cmd.Parameters.AddWithValue("@Obrisan", '0');
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom kreiranja akcije, namestaja na akciju!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

        public static bool DeleteNaAkcija(Akcija a, ObservableCollection<Namestaj> obrisani)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    for (int i = 0; i < obrisani.Count; i++)
                    {
                        cmd.CommandText = "DELETE NAAKCIJI WHERE NamestajNaPopustuId=@spiid AND AkcijaId=@aid";
                        cmd.Parameters.AddWithValue("@spiid", obrisani[i].Id);
                        cmd.Parameters.AddWithValue("@aid", a.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem prilikom brisanja akcije, namestaja sa akcije!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
        #endregion
    }

}
