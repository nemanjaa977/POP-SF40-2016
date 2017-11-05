using POP_40_2016.Model;
using POP_40_2016.utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_40_2016
{
    class Program
    {
        
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
            Console.WriteLine($"==== Dobrodosli u salon ====>>>>>>>>>>>>>>>>>{s1.Naziv}\n");
            for (int i = 0; i < 3; i++)
            {
                var korisnici = Projekat.Instance.Korisnik;
                Console.WriteLine("Unesite korisnicko ime: ");
                var kIme = Console.ReadLine();
                Console.WriteLine("Unesite lozinku: ");
                var lozinka = Console.ReadLine();
                foreach (Korisnik k in korisnici)
                {
                    if (k.KorisnickoIme == kIme && k.Lozinka == lozinka)
                    {                      
                        IspisGlavnogMenija();
                        return;
                    }

                }

            }
            Environment.Exit(0);

            
            
        }
        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== GLAVNI MENI ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("3. Rad sa akcijama");
                Console.WriteLine("4. Rad sa dodatnim uslugama");
                Console.WriteLine("5. Rad sa korisnikom");           
                Console.WriteLine("0. Izlaz\n");
            } while (izbor < 0 || izbor > 5);

            izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:
                    IspisMenijaRadSaNamestajem();
                    break;
                case 2:
                    IspisMenijaRadSaTipomNamestaja();
                    break;
                case 3:
                    IspisMenijaRadSaAkcijama();
                    break;
                case 4:
                    IspisMenijaRadSaDodatnimUslugama();
                    break;
                case 5:
                    IspisMenijaRadSaKorisnikom();
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
            var namestaj = Projekat.Instance.Namestaj;
            foreach (Namestaj n in namestaj)
            {
                if (n.Id == idZaBrisanje)
                {
                    n.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                } 
            }
            Projekat.Instance.Namestaj = namestaj;
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmeniNamestaj(int idZaIzmenu)
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("=== Izmena namestaja ===");
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (namestaj[i].Id == idZaIzmenu)
                {
                    IspisMenijaIzmenaNamestaja(idZaIzmenu);
                }            
            }
            Projekat.Instance.Namestaj = namestaj;
        }

        private static void DodajNamestaj()
        {
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;
            var listaNamestaja = Projekat.Instance.Namestaj;
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

            int idNamestaja = listaNamestaja.Count + 1;
            noviNamestaj.Id = idNamestaja;
            
            int Id = 0;
            TipNamestaja trazeniTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite tip namestaja:");
                Id = int.Parse( Console.ReadLine()); 

                foreach (var tipNamestaja in tipoviNamestaja)
                {
                    if (tipNamestaja.Id == Id)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            noviNamestaj.TipNamestaja = trazeniTipNamestaja;
            listaNamestaja.Add(noviNamestaj);
            Projekat.Instance.Namestaj = listaNamestaja;
            IspisMenijaRadSaNamestajem();
        }

        private static void IzlistajNamestaj()
        {   
            Console.WriteLine("--- Izlistavanje namestaja ---");
            var namestaj = Projekat.Instance.Namestaj;
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (!namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. {namestaj[i].Naziv}, cena: {namestaj[i].JedinicnaCena}\n");
                }
            }
            Projekat.Instance.Namestaj = namestaj;
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
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("Unesite novu kolicinu namestaja:");
            var novaKolicina = int.Parse(Console.ReadLine());
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (namestaj[i].Id == idZaPromenu)
                {
                    namestaj[i].KolicinaUMagacinu = novaKolicina;
                    break;
                }
            }
            Projekat.Instance.Namestaj = namestaj;
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaCeneNamestaja(int idZaPromenu)
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("Unesite novu cenu namestaja:");
            double novaCena = double.Parse(Console.ReadLine());
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (namestaj[i].Id == idZaPromenu)
                {
                    namestaj[i].JedinicnaCena = novaCena;
                    break;
                }
            }
            Projekat.Instance.Namestaj = namestaj;
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaTipaNamestaja(int idZaPromenu)
        {
            var tipoviNamestaja = Projekat.Instance.TipNamestaja;
            var listaNamestaja = Projekat.Instance.Namestaj;

            int Id = 0;

            TipNamestaja noviTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite novi tip namestaja:");
                Id = int.Parse(Console.ReadLine()); 

                foreach (var tipNamestaja in tipoviNamestaja)
                {
                    if (tipNamestaja.Id == Id)
                    {
                        noviTipNamestaja = tipNamestaja;
                    }
                }
            } while (noviTipNamestaja == null);

            for (int i = 0; i < listaNamestaja.Count; i++)
            {
                if (listaNamestaja[i].Id == idZaPromenu)
                {
                    listaNamestaja[i].TipNamestaja = noviTipNamestaja;
                }
            }
            Projekat.Instance.Namestaj = listaNamestaja;
            Projekat.Instance.TipNamestaja = tipoviNamestaja;
            IspisMenijaIzmenaNamestaja(idZaPromenu);
        }

        private static void IzmenaSifreNamestaja(int idZaPromenu)
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("Unesite novu sifru namestaja:");
            var novaSifra = Console.ReadLine();
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (namestaj[i].Id == idZaPromenu)
                {
                    namestaj[i].Sifra = novaSifra;
                    break;
                }
            }
            Projekat.Instance.Namestaj = namestaj;
            IspisMenijaRadSaNamestajem();
        }

        private static void IzmenaNazivaNamestaja(int idZaPromenu)
        {
            var namestaj = Projekat.Instance.Namestaj;
            Console.WriteLine("Unesite novi naziv namestaja:");
            var noviNaziv = Console.ReadLine();
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (namestaj[i].Id == idZaPromenu)
                {
                    namestaj[i].Naziv = noviNaziv;
                    break;
                }
            }
            Projekat.Instance.Namestaj = namestaj;
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
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajTipNamestaja();
                    break;
                case 2:
                    DodajNoviTipNamestaja();
                    break;
                case 3:
                    Console.WriteLine("Unesi Id tipa namestaja za izmenu");
                    int IdZaIzmenu = int.Parse(Console.ReadLine());
                    IzmeniTipNamestaja(IdZaIzmenu);
                    break;
                case 4:
                    Console.WriteLine("Unesi Id tipa namestaja za brisanje");
                    int IdZaBrisanje = int.Parse(Console.ReadLine());
                    BrisanjeTipaNamestaja(IdZaBrisanje);
                    break;
                default:
                    break;
            }
        }

        private static void DodajNoviTipNamestaja()
        {
            var tipNamestaj = Projekat.Instance.TipNamestaja;
            Console.WriteLine("Unesite naziv tipa namestaja: ");
            string inaziv = Console.ReadLine();
            var tn = new TipNamestaja()
            {
                Naziv = inaziv,
                Id = tipNamestaj.Count + 1
        };
            tipNamestaj.Add(tn);
            Projekat.Instance.TipNamestaja=tipNamestaj;
            IspisMenijaRadSaTipomNamestaja();   
        }

        private static void BrisanjeTipaNamestaja(int idZaBrisanje)
        {
            var tipNamestaj = Projekat.Instance.TipNamestaja;
            foreach (TipNamestaja t in tipNamestaj)
            {
                if (t.Id == idZaBrisanje)
                {
                    t.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                }
            }
            Projekat.Instance.TipNamestaja = tipNamestaj;
            IspisMenijaRadSaTipomNamestaja();
        }

        private static void IzlistajTipNamestaja()
        {
            var tipNamestaj = Projekat.Instance.TipNamestaja;
            Console.WriteLine("--- Izlistavanje tipa namestaja ---");

            for (int i = 0; i < tipNamestaj.Count; i++)
            {
                if (!tipNamestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. { tipNamestaj[i].Id}, naziv: {tipNamestaj[i].Naziv}\n");
                }
            }
            Projekat.Instance.TipNamestaja = tipNamestaj;
            IspisMenijaRadSaTipomNamestaja();
        }


        private static void IzmeniTipNamestaja(int idZaIzmenu)
        {
            var tipNamestaj = Projekat.Instance.TipNamestaja;
            Console.WriteLine("=== Izmena tipa namestaja ===");
            for (int i = 0; i < tipNamestaj.Count; i++)
            {
                if (tipNamestaj[i].Id == idZaIzmenu)
                {
                    IzmenaNazivaTipaNamestaja(idZaIzmenu);
                }
                else
                {
                    Console.WriteLine("Tip namestaja s tim ID-jem ne postoji");
                }
            }
            Projekat.Instance.TipNamestaja = tipNamestaj;
        }

        private static void IzmenaNazivaTipaNamestaja(int idZaPromenu)
        {
            var tipNamestaj = Projekat.Instance.TipNamestaja;
            Console.WriteLine("Unesite novi naziv za tip namestaja:");
            var noviNaziv = Console.ReadLine();
            for (int i = 0; i < tipNamestaj.Count; i++)
            {
                if (tipNamestaj[i].Id == idZaPromenu)
                {
                    tipNamestaj[i].Naziv = noviNaziv;
                    break;
                }
            }
            Projekat.Instance.TipNamestaja = tipNamestaj;
            IspisMenijaRadSaTipomNamestaja();
        }

        private static void IspisMenijaRadSaAkcijama()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni Akcija ===");
                Console.WriteLine("1. Izlistaj akcije");
                Console.WriteLine("2. Dodaj novu akciju");
                Console.WriteLine("3. Izmeni postojecu akciju");
                Console.WriteLine("4. Obrisi postojecu akciju");
                Console.WriteLine("0. Izlaz\n");
            } while (izbor < 0 || izbor > 4);

            izbor = int.Parse(Console.ReadLine());

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajAkcije();
                    break;
                case 2:
                    DodajNovuAkciju();
                    break;
                case 3:
                    Console.WriteLine("Unesi Id akcije za izmenu");
                    int IdZaIzmenu = int.Parse(Console.ReadLine());
                    IzmeniAkcije(IdZaIzmenu);
                    break;
                case 4:
                    Console.WriteLine("Unesi Id akcije za brisanje");
                    int IdZaBrisanje = int.Parse(Console.ReadLine());
                    BrisanjeAkcija(IdZaBrisanje);
                    break;
                default:
                    break;
            }
        }

        private static void DodajNovuAkciju()
        {
            List<int> namestajNaAkciji = new List<int>();
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("Unesite pocetak akcije: ");
            var pocetak = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kraj akcije: ");
            var kraj = DateTime.Parse(Console.ReadLine());
            IzlistajNamestaj();
            bool unos = true;
            while(unos)
            {
                Console.WriteLine("\nIzaberite namestaj za akciju, za prekid 0:c");
                var izbor = int.Parse(Console.ReadLine());
                if(izbor != 0)
                {
                    //var namestaj = 
                   // namestajNaAkciji.Add(namestaj.Id);
                }
                else
                {
                    unos = false;
                }
            }
            Console.WriteLine("Unesite popust: ");
            double popust = double.Parse(Console.ReadLine());
            var nakcija = new Akcija()
            {
                Id = akcije.Count + 1,
                DatumPocetka = pocetak,
                DatumZavrsetka = kraj,
                //NamestajNaPopustu =namestajNaAkciji,
                Popust = popust,
            };
            akcije.Add(nakcija);
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void IzlistajAkcije()
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("--- Izlistavanje akcija ---");
            for (int i = 0; i < akcije.Count; i++)
            {
                if (!akcije[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. { akcije[i].Id}, datumPocetka: {akcije[i].DatumPocetka}\n, datumZavrsetka: {akcije[i].DatumZavrsetka}\n, namestajNaPopustu: {akcije[i].NamestajNaPopustu}\n, popust: {akcije[i].Popust}\n");
                }
            }
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void IzmeniAkcije(int idZaIzmenu)
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("=== Izmena akcija ===");
            for (int i = 0; i < akcije.Count; i++)
            {
                if (akcije[i].Id == idZaIzmenu)
                {
                    IspisMenijaIzmenaAkcija(idZaIzmenu);
                }
            }
            Projekat.Instance.Akcija = akcije;
        }

        private static void IspisMenijaIzmenaAkcija(int idZaPromenu)
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("1. Izmeni Datum pocetka");
                Console.WriteLine("2. Izmeni Datum zavrsetka");
                Console.WriteLine("3. Izmeni namestaj na popustu");
                Console.WriteLine("4. Izmeni popust");
                Console.WriteLine("0. Izlaz\n");
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                {
                    case 0:
                        IspisMenijaRadSaAkcijama();
                        break;           
                    case 1:
                        IzmenaDatumPocetka(idZaPromenu);
                        break;
                    case 2:
                        IzmenaDatumZavrsetka(idZaPromenu);
                        break;
                    case 3:
                        IzmenaNamestajaNaPopustu(idZaPromenu);
                        break;
                    case 4:
                        IzmenaPopusta(idZaPromenu);
                        break;
                }
            } while (izbor < 0 || izbor > 4);
        }

        private static void IzmenaNamestajaNaPopustu(int idZaPromenu)
        {
            
        }

        private static void IzmenaDatumPocetka(int idZaPromenu)
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("Unesite novi datum pocetka:");
            DateTime novDatum = DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < akcije.Count; i++)
            {
                if (akcije[i].Id == idZaPromenu)
                {
                    akcije[i].DatumPocetka= novDatum;
                    break;
                }
            }
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void IzmenaDatumZavrsetka(int idZaPromenu)
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("Unesite novi datum zavrsetka:");
            DateTime novDatum = DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < akcije.Count; i++)
            {
                if (akcije[i].Id == idZaPromenu)
                {
                    akcije[i].DatumZavrsetka = novDatum;
                    break;
                }
            }
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void IzmenaPopusta(int idZaPromenu)
        {
            var akcije = Projekat.Instance.Akcija;
            Console.WriteLine("Unesite novi popust:");
            double novPopust = double.Parse(Console.ReadLine());
            for (int i = 0; i < akcije.Count; i++)
            {
                if (akcije[i].Id == idZaPromenu)
                {
                    akcije[i].Popust = novPopust;
                    break;
                }
            }
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void BrisanjeAkcija(int idZaBrisanje)
        {
            var akcije = Projekat.Instance.Akcija;
            foreach (Akcija a in akcije)
            {
                if (a.Id == idZaBrisanje)
                {
                    a.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                }
            }
            Projekat.Instance.Akcija = akcije;
            IspisMenijaRadSaAkcijama();
        }

        private static void IspisMenijaRadSaDodatnimUslugama()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni dodatnih usluga ===");
                Console.WriteLine("1. Izlistaj usluge");
                Console.WriteLine("2.Dodaj novu uslugu");
                Console.WriteLine("3.Izmeni postojecu uslugu");
                Console.WriteLine("4. Obrisi postojecu uslugu ");
                Console.WriteLine("0. Izlaz\n ");
                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);
            switch (izbor)
            {
                case 1:
                    IzlistajDodatneUsluge();
                    break;
                case 2:
                    DodavanjeUsluga();
                    break;
                case 3:
                    IzmenaUsluga();
                    break;
                case 4:
                    Console.WriteLine("Unesi Id dodatne usluge za brisanje");
                    int IdZaBrisanje = int.Parse(Console.ReadLine());
                    BrisanjeUsluga(IdZaBrisanje);
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:
                    break;
            }
        }

        private static void IzlistajDodatneUsluge()
        {
            Console.WriteLine("=== Ispis Dodatnih usluga ===");
            var dodatneUsluge = Projekat.Instance.DodatnaUsluga;
            for (int i = 0; i < dodatneUsluge.Count; i++)
            {
                if (!dodatneUsluge[i].Obrisan)
                {
                    Console.WriteLine($"{dodatneUsluge[i].Id}. naziv:{dodatneUsluge[i].Naziv} \tcena:{dodatneUsluge[i].Cena} \tPdv:{dodatneUsluge[i].PDV},\tUkupanIznos: {dodatneUsluge[i].UkupanIznos}\n");
                }
            }
            Projekat.Instance.DodatnaUsluga = dodatneUsluge;
            IspisMenijaRadSaDodatnimUslugama();
        }

        private static void DodavanjeUsluga()
        {
            var dodatneUsluge = Projekat.Instance.DodatnaUsluga;
            Console.WriteLine("Unesite naziv dodatne usluge: ");
            string naziv = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ukupan iznos: ");
            double ukupanIznos = double.Parse(Console.ReadLine());
            double pdv = 15;
            var u = new DodatnaUsluga()
            {
                Id = dodatneUsluge.Count + 1,
                Naziv = naziv,
                Cena = cena,
                PDV = pdv,
                UkupanIznos = ukupanIznos,
            };
            dodatneUsluge.Add(u);
            Projekat.Instance.DodatnaUsluga = dodatneUsluge;
            IspisMenijaRadSaDodatnimUslugama();

        }

        private static void IzmenaUsluga()
            
        {
            var dodatneUsluge = Projekat.Instance.DodatnaUsluga;
            IzlistajDodatneUsluge();
            Console.WriteLine("Unesite Id usluge za izmenu: ");
            int id = int.Parse(Console.ReadLine());
            DodatnaUsluga nIzmena = new DodatnaUsluga();
            foreach (DodatnaUsluga dt in dodatneUsluge)
            {
                if (dt.Id == id)
                {
                    nIzmena = dt;
                }
            }
            Console.WriteLine("Izaberite parametar za izmenu: ");
            Console.WriteLine(" 1. Izmena naziva\n 2.Izmena cene\n 3.Izmena pdv-a\n 4.Izmena ukupnog iznosa\n");
            int izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Unesite naziv za izmenu: ");
                    nIzmena.Naziv = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Unesite cenu za izmenu: ");
                    nIzmena.Cena = double.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Unesite pdv za izmenu: ");
                    nIzmena.PDV = double.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Unesite ukupan iznos za izmenu: ");
                    nIzmena.UkupanIznos = double.Parse(Console.ReadLine());
                    break;
                
            }
            Projekat.Instance.DodatnaUsluga = dodatneUsluge;
            IspisMenijaRadSaDodatnimUslugama();
        }

        private static void BrisanjeUsluga(int idZaBrisanje)
        {
            var dodatneUsluge = Projekat.Instance.DodatnaUsluga;
            foreach (DodatnaUsluga d in dodatneUsluge)
            {
                if (d.Id == idZaBrisanje)
                {
                    d.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                }
            }
            Projekat.Instance.DodatnaUsluga = dodatneUsluge;
            IspisMenijaRadSaDodatnimUslugama();
        }

        private static void IspisMenijaRadSaKorisnikom()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni korsnika ===");
                Console.WriteLine("1. Izlistaj korisnike");
                Console.WriteLine("2.Dodaj novog korisnika");
                Console.WriteLine("3.Izmeni postojeceg korisnika");
                Console.WriteLine("4. Obrisi postojeceg korisnika ");
                Console.WriteLine("0. Izlaz\n ");
                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);
            switch (izbor)
            {
                case 1:
                    IzlistajKorisnike();
                    break;
                case 2:
                    DodavanjeKorisnika();
                    break;
                case 3:
                    IzmenaKorisnika();
                    break;
                case 4:
                    Console.WriteLine("Unesi Id korisnika za brisanje");
                    int IdZaBrisanje = int.Parse(Console.ReadLine());
                    BrisanjeKorisnika(IdZaBrisanje);
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:
                    break;
            }
        }

        private static void IzlistajKorisnike()
        {
            Console.WriteLine("=== Ispis korisnika ===");
            var korisnik = Projekat.Instance.Korisnik;
            for (int i = 0; i < korisnik.Count; i++)
            {
                if (!korisnik[i].Obrisan)
                {
                    Console.WriteLine($"{korisnik[i].Id}. ime:{korisnik[i].Ime} \tprezime:{korisnik[i].Prezime} \tkorIme:{korisnik[i].KorisnickoIme},\tlozinka: {korisnik[i].Lozinka},\ttipKor: {korisnik[i].TipKorisnika}\n");
                }
            }
            Projekat.Instance.Korisnik = korisnik;
            IspisMenijaRadSaKorisnikom();
        }

        private static void DodavanjeKorisnika()
        {
            var korisnik = Projekat.Instance.Korisnik;
            Console.WriteLine("Unesite ime korisnika: ");
            string ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime salona: ");
            string prezime = Console.ReadLine();
            Console.WriteLine("Unesite korisnicko ime: ");
            string korIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            string lozinka = Console.ReadLine();
            Console.WriteLine("Unesite tip korisnika za izmenu: ");
            string tip = Console.ReadLine();
            var tipKorisnika=TipKorisnika.Prodavac;
            if (tip.ToUpper().Equals("ADMINISTRATOR"))
            {
                 tipKorisnika = TipKorisnika.Administrator;

            }
            else
            {

                tipKorisnika = TipKorisnika.Prodavac;
            }           

            var kk = new Korisnik()
            {
                Id = korisnik.Count + 1,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika
            };
            korisnik.Add(kk);
            Projekat.Instance.Korisnik = korisnik;
            IspisMenijaRadSaKorisnikom();

        }

        private static void IzmenaKorisnika()
        {
            var korisnik = Projekat.Instance.Korisnik;
            IzlistajKorisnike();
            Console.WriteLine("Unesite Id korisnika za izmenu: ");
            int id = int.Parse(Console.ReadLine());
            Korisnik nIzmena = new Korisnik();
            foreach (Korisnik k in korisnik)
            {
                if (k.Id == id)
                {
                    nIzmena = k;
                }
            }
            Console.WriteLine("Izaberite parametar za izmenu: ");
            Console.WriteLine(" 1. Izmena imena\n 2.Izmena prezimena\n 3.Izmena korsnickog imena\n 4.Izmena lozinke\n 5.Izmena tipa korisnika\n ");
            int izbor = int.Parse(Console.ReadLine());
            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Unesite ime za izmenu: ");
                    nIzmena.Ime = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Unesite prezime za izmenu: ");
                    nIzmena.Prezime = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Unesite korisnicko ime za izmenu: ");
                    nIzmena.KorisnickoIme = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Unesite lozinku za izmenu: ");
                    nIzmena.Lozinka = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Unesite tip korisnika za izmenu: ");
                    string tip = Console.ReadLine();
                    
                    if (tip.ToUpper().Equals("ADMINISTRATOR"))
                    {
                        nIzmena.TipKorisnika = TipKorisnika.Administrator;

                    }
                    else
                    {

                        nIzmena.TipKorisnika = TipKorisnika.Prodavac;
                    }
                    break;                  
            }
            Projekat.Instance.Korisnik = korisnik;
            IspisMenijaRadSaKorisnikom();
        }

        private static void BrisanjeKorisnika(int idZaBrisanje)
        {
            var korisnik = Projekat.Instance.Korisnik;
            foreach (Korisnik k in korisnik)
            {
                if (k.Id == idZaBrisanje)
                {
                    k.Obrisan = true;
                    Console.WriteLine("=== Uspesno brisanje ===\n");
                    break;
                }
            }
            Projekat.Instance.Korisnik = korisnik;
            IspisMenijaRadSaKorisnikom();
        }
        
    }
    
}
