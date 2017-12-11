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