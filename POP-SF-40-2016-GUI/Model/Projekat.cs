using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }

        private Projekat()
        {
            TipNamestaja = Model.TipNamestaja.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            //TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            //Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
        }        
    }
}
