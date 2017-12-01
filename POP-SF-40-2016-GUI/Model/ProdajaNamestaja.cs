using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private string brojRacuna;
        private string kupac;
        private List<int> uslugaId;
        private double ukupanIznos;
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
        public string BrojRacuna
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
        }

        [XmlIgnore]
        public ObservableCollection<DodatnaUsluga> DodatneUsluge
        {
            get
            {
                if (dodUsluge == null)
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
                if (namProdaja == null)
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
                DodatnaUslugaId = uslugaId
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
    }
}
