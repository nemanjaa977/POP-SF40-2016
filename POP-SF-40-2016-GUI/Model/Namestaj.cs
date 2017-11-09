using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public int TipNamestajaId { get; set; }

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

        public override string ToString()
        {
            return $"{Naziv}, {Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {TipNamestaja.PronadjiTip(TipNamestajaId).Naziv}";
        }
     


    }
}
