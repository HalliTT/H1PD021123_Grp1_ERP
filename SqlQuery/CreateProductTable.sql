use H1PD021123_Gruppe1;

create table Products
(
	Id INT PRIMARY KEY IDENTITY (1,1),
	Name TEXT NOT NULL,
	Description TEXT NOT NULL,
	PurchasePrice MONEY NOT NULL,
	Location TEXT NOT NULL,
	AmountInStock FLOAT NOT NULL,
	Unit TEXT NOT NULL,
	SalesPrice MONEY NOT NULL
)