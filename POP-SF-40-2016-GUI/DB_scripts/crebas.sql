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