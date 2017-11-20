using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int NamestajNaPopustuId { get; set; }
        public double Popust { get; set; }

        private int id;
        private bool obrisan;
        private int namestajPopust;
        private double popust;

        


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

    }

}
