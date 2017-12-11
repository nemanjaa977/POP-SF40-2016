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
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private List<int> namestajPopustId;
        private double popust;
        private ObservableCollection<Namestaj> namPopust;
        //private Namestaj nam;

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
            namPopust = new ObservableCollection<Namestaj>();
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
                NamestajNaPopustu = namPopust
            };
        }

        [XmlIgnore]
        public ObservableCollection<Namestaj> NamestajNaPopustu
        {
            get
            {
                if (namPopust.Count == 0)
                {
                    namPopust = PronadjiNamestaj(namestajPopustId);
                }
                return namPopust;
            }
            set
            {
                namPopust = value;
                namestajPopustId = PronadjiIdNamestajPopust(namPopust);
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
    }

}
