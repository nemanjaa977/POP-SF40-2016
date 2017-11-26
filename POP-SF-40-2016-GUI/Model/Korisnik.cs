using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
}
