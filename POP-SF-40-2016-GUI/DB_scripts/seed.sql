--seed.sql

INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Polica', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Regal', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Ugaona garnitura', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Krevet', 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
	VALUES(1, 'Ultra polica', 'UL1PO', 123.5, 2 , 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
	VALUES(2, 'Crni regal', 'CR1RE', 173.5, 5 , 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
	VALUES(3, 'Nova ugaona', 'NO1UG', 456.5, 11 , 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
	VALUES(4, 'Leteci krevet', 'LE1KR', 123.5, 15 , 0);

INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Prevoz', 500, 0);
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Utovar', 200, 0);
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Istovar', 300, 0);
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Rezervacija', 800, 0);

INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
	VALUES('Marko', 'Jezdic', 'mare', '123', 'Administrator' , 0);
INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
	VALUES('Petar', 'Kojic', 'pera', '12345', 'Prodavac' , 0);

INSERT INTO Akcije(DatumPocetka, DatumKraja, Popust, Obrisan)
	VALUES('11/06/2017', '11/26/2018', 30, 0)	

INSERT INTO NAAKCIJI(NamestajNaPopustuId, AkcijaId, Obrisan)
	VALUES(1, 1, 0)

INSERT INTO ProdajaNamestaja(DatumProdaje, BrojRacuna, KolicinaNamestaja, Kupac, UkupanIznos, Obrisan)
	VALUES('10/07/2017', 1, 15, 'Avram Adzic', 14500, 0)

INSERT INTO ProdajaProzorNamestaj(NamestajZaProdajuId, ProdajaNamestajaId, Obrisan)
	VALUES(2, 1, 0)

INSERT INTO ProdajaProzorUsluga(DodatnaUslugaId, ProdajaNamestajaId, Obrisan)
	VALUES(2, 1, 0)