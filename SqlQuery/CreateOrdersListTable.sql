use H1PD021123_Gruppe1;

create table OrdersList
(
	Id	INT PRIMARY KEY IDENTITY (1,1),
	OrdersId INT NOT NULL REFERENCES Orders(Id),
	ProductId INT REFERENCES Products(Id),
	Amount INT NOT NULL
)