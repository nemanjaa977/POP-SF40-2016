using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {

                id = value;
                OnPropertyChanged("ID");
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
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public static TipNamestaja PronadjiTip(int id)
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public override string ToString()
        {
            return $"{Naziv}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }
    }
   
}
