using POP_40_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();
        static void Main(string[] args)
        {

            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Formna FTN",
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-00073666-83",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 234324,
                PIB = 323443,
                Telefon = "021/342-343",
                AdresaInternetSajta = "http://www.ftn.uns.ac.rs"
            };

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa"
            };

            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Ormani"
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Super sofa",
                Sifra = "s11",
                TipNamestaja = tn1,
                KolicinaUMagacinu = 2,
                JedinicnaCena =15000
            };

            TipoviNamestaja.Add(tn1);
            TipoviNamestaja.Add(tn2);
            Namestaj.Add(n1);

            Console.WriteLine($"==== Dobrodosli u salon {s1.Naziv}");
            IspisGlavnogMenija();
        }
        private static void IspisGlavnogMenija()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== GLAVNI MENI ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz\n");
            } while (izbor < 0 || izbor > 2);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 1:
                    IspisMenijaRadSaNamestajem();
                    break;
                case 2:
                    IspisMenijaRadSaTipomNamestaja();
                    break;

            }
        }
        private static void IspisMenijaRadSaNamestajem()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni Namestaj ===");
                Console.WriteLine("1. Izlistaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci namestaj");
                Console.WriteLine("0. Izlaz\n");


            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodajNamestaj();
                    break;
                case 3:
                    Console.WriteLine("Unesi Id namestaja za izmenu");
                    int IdZaIzmenu = int.Parse(Console.ReadLine());
                    IzmeniNamestaj(IdZaIzmenu);
                    break;
                case 4:
                    Console.WriteLine("Unesi Id namestaja za brisanje");
                    int IdZaBrisanje = int.Parse(Console.ReadLine());
                    BrisanjeNamestaja(IdZaBrisanje);
                    break;
                default:
                    break;
            }
        }

        private static void BrisanjeNamestaja(int idZaBrisanje)
        {
            
            foreach(Namestaj n in Namestaj)
            {
                if (n.Id == idZaBrisanje)
                {
                    n.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                }
                
               
            }
            
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmeniNamestaj(int idZaIzmenu)
        {
            Console.WriteLine("=== Izmena namestaja ===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaIzmenu)
                {
                    IspisMenijaIzmenaNamestaja(idZaIzmenu);
                }
                else
                {
                    Console.WriteLine("Namestaj s tim ID-jem ne postoji");
                }
            }
        }

        private static void DodajNamestaj()
        {
            Console.WriteLine("=== Dodavanje novog namestaja ===");

            var noviNamestaj = new Namestaj();

            Console.WriteLine("Unesite naziv namestaja:");
            noviNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu namestaja:");
            noviNamestaj.JedinicnaCena = Double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite sifru namestaja:");
            noviNamestaj.Sifra = Console.ReadLine();

            Console.WriteLine("Koliko komada namestaja se nalazi u magacinu:");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            int idNamestaja = Namestaj.Count+1;
            noviNamestaj.Id = idNamestaja;
            

            int Id = 0;
            TipNamestaja trazeniTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite tip namestaja:");
                Id = int.Parse( Console.ReadLine()); 

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Id == Id)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            noviNamestaj.TipNamestaja = trazeniTipNamestaja;

            Namestaj.Add(noviNamestaj);

            IspisMenijaRadSaNamestajem();

        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("--- Izlistavanje namestaja ---");

            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (!Namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. { Namestaj[i].Naziv}, cena: {Namestaj[i].JedinicnaCena}\n");
                }
            }

            IspisMenijaRadSaNamestajem();
        }

        private static void IspisMenijaIzmenaNamestaja(int idZaPromenu)
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("1. Izmeni Naziv");
                Console.WriteLine("2. Izmeni Sifru");
                Console.WriteLine("3. Izmeni Tip");
                Console.WriteLine("4. Izmeni Cenu");
                Console.WriteLine("5. Izmeni Kolicinu u magacinu");
                Console.WriteLine("0. Izlaz\n");

                izbor = int.Parse(Console.ReadLine());

                switch (izbor)
                {
                    case 0:
                        IspisMenijaRadSaNamestajem();
                        break;
                    case 1:
                        IzmenaNazivaNamestaja(idZaPromenu);
                        break;
                    case 2:
                        IzmenaSifreNamestaja(idZaPromenu);
                        break;
                    case 3:
                        IzmenaTipaNamestaja(idZaPromenu);
                        break;
                    case 4:
                        IzmenaCeneNamestaja(idZaPromenu);
                        break;
                    case 5:
                        IzmenaKolicineUMagacinu(idZaPromenu);
                        break;


                }

            } while (izbor < 0 || izbor > 5);
        }

        private static void IzmenaKolicineUMagacinu(int idZaPromenu)
        {
            Console.WriteLine("Unesite novu kolicinu namestaja:");
            var novaKolicina = int.Parse(Console.ReadLine());
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaPromenu)
                {
                    Namestaj[i].KolicinaUMagacinu = novaKolicina;
                    break;
                }

            }
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaCeneNamestaja(int idZaPromenu)
        {
            Console.WriteLine("Unesite novu cenu namestaja:");
            double novaCena = double.Parse(Console.ReadLine());
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaPromenu)
                {
                    Namestaj[i].JedinicnaCena = novaCena;
                    break;
                }

            }
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaTipaNamestaja(int idZaPromenu)
        {

            int Id = 0;

            TipNamestaja noviTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite novi tip namestaja:");
                Id = int.Parse(Console.ReadLine()); 

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Id == Id)
                    {
                        noviTipNamestaja = tipNamestaja;
                    }
                }
            } while (noviTipNamestaja == null);

            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaPromenu)
                {
                    Namestaj[i].TipNamestaja = noviTipNamestaja;
                }

            }

            IspisMenijaIzmenaNamestaja(idZaPromenu);

        }

        private static void IzmenaSifreNamestaja(int idZaPromenu)
        {
            Console.WriteLine("Unesite novu sifru namestaja:");
            var novaSifra = Console.ReadLine();
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaPromenu)
                {
                    Namestaj[i].Sifra = novaSifra;
                    break;
                }

            }
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaNazivaNamestaja(int idZaPromenu)
        {
            Console.WriteLine("Unesite novi naziv namestaja:");
            var noviNaziv = Console.ReadLine();
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (Namestaj[i].Id == idZaPromenu)
                {
                    Namestaj[i].Naziv = noviNaziv;
                    break;
                }

            }
            IspisMenijaRadSaNamestajem();

        }

        private static void IspisMenijaRadSaTipomNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni Tip Namestaja ===");
                Console.WriteLine("1. Izlistaj tipove namestaja");
                Console.WriteLine("2. Dodaj novi tip namestaja");
                Console.WriteLine("3. Izmeni postojeci tip namestaj");
                Console.WriteLine("4. Obrisi postojeci tip namestaja");
                Console.WriteLine("0. Izlaz\n");


            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                default:
                    break;
            }
        }


    }
    
}
