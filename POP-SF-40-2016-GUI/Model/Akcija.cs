using System;
using System.Collections.Generic;
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
        private int namestajPopustId;
        private double popust;
        private Namestaj nam;

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
        public int NamestajNaPopustuId
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

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (nam == null)
                {
                    nam = Namestaj.PronadjiNamestajNaPopustu(NamestajNaPopustuId);
                }
                return nam;
            }
            set
            {
                nam = value;
                NamestajNaPopustuId = nam.Id;
                OnPropertyChanged("Namestaj");
            }
        }

        public override string ToString()
        {
            return $"{DatumPocetka}, {DatumZavrsetka}, {Namestaj.PronadjiNamestajNaPopustu(NamestajNaPopustuId).Naziv}, {Popust}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
                Popust = popust
            };
        }
    }

}
