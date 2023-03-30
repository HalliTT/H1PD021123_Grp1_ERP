use H1PD021123_Gruppe1;

create table Products
(
	ProductId text not null,
	Name text not null,
	PurchasePrice money not null,
	Location text not null,
	AmountInStock float not null,
	Unit text not null,
)