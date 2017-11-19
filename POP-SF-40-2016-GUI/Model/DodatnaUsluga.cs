using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class DodatnaUsluga
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }

        public static DodatnaUsluga PronadjiDodatnuUslugu(int id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == id)
                {
                    return usluga;
                }
            }
            return null;
        }


    }
}
