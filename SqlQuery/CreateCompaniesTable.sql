use H1PD021123_Gruppe1;

create table Companies
(
	Id	INT PRIMARY KEY IDENTITY (1,1),
	Name text NOT NULL,
	Road text NOT NULL,
	HouseNumber text NOT NULL,
	ZipCode text NOT NULL,
	City text NOT NULL,
	Country text NOT NULL,
	Currency text NOT NULL,
	Cvr text NOT NULL,
	Email text NOT NULL,
)


