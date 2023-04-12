use H1PD021123_Gruppe1;

create table Persons
(
	Id INT PRIMARY KEY IDENTITY (1,1),
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	PhoneNumber TEXT NOT NULL,
	Mail TEXT NOT NULL,
	Address TEXT NOT NULL,
	Role TEXT NOT NULL,
	CreationTimeStamp DATETIME NOT NULL DEFAULT GetDate(),
)