use H1PD021123_Gruppe1;

create table Orders
(
	Id	INT PRIMARY KEY IDENTITY (1,1),
	CreationTimestamp DATETIME NOT NULL DEFAULT GetDate(),
	DoneTimestamp TEXT NOT NULL,
	CustomerId INT NOT NULL REFERENCES Persons(Id),
	State TEXT NOT NULL,
	TotalOrderPrice INT NOT NULL,
)