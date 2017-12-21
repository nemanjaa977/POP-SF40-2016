--crebas.sql

CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(100),
	Obrisan BIT
);

GO
CREATE TABLE Namestaj(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT,
	Naziv VARCHAR(80),
	Sifra VARCHAR(20),
	Cena NUMERIC(9, 2),
	Kolicina INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
);

GO
CREATE TABLE DodatneUsluge(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(90),
	Cena NUMERIC(9, 2),
	Obrisan BIT
);
GO
CREATE TABLE Korisnici(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Ime VARCHAR(70),
	Prezime VARCHAR(70),
	KorisnickoIme VARCHAR(60),
	Lozinka VARCHAR(60),
	TipKorisnika VARCHAR(20),
	Obrisan BIT
);
GO
CREATE TABLE Akcije(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumPocetka Date,
	DatumKraja Date,
	Popust INT,
	Obrisan BIT
);
GO
CREATE TABLE NAAKCIJI(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	NamestajNaPopustuId INT FOREIGN KEY REFERENCES Namestaj(Id),
	AkcijaId INT FOREIGN KEY REFERENCES Akcije(Id),
	Obrisan BIT
);
