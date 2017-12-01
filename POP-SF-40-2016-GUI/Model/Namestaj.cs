using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            //throw new NotImplementedException();
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
     


    }
}
