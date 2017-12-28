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
	CenaPopust NUMERIC(9, 2),
	Kolicina INT,
	ProdataKolicina INT,
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
	DatumPocetka DATE,
	DatumKraja DATE,
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
GO
CREATE TABLE ProdajaNamestaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumProdaje DATE,
	BrojRacuna INT,
	Kupac VARCHAR(40),
	UkupanIznos DECIMAL,
	UkupanIznosPDV DECIMAL,
	Obrisan BIT
);
GO
CREATE TABLE ProdajaProzorNamestaj(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	NamestajZaProdajuId INT	FOREIGN KEY REFERENCES Namestaj(Id),
	ProdajaNamestajaId INT FOREIGN KEY REFERENCES ProdajaNamestaja(Id),
	Obrisan BIT
);
GO
CREATE TABLE ProdajaProzorUsluga(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DodatnaUslugaId INT FOREIGN KEY REFERENCES DodatneUsluge(Id),
	ProdajaNamestajaId INT FOREIGN KEY REFERENCES ProdajaNamestaja(Id),
	Obrisan BIT
);
GO
CREATE TABLE Salon(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(90),
	Adresa VARCHAR(80),
	Telefon VARCHAR(80),
	Email VARCHAR(80),
	AdresaInternetSajta VARCHAR(100),
	Pib INT,
	MaticniBroj INT,
	BrojZiroRacuna VARCHAR(100),
	Obrisan BIT
);
