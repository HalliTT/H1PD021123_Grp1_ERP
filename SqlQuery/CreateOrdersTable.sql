use H1PD021123_Gruppe1;

create table Orders
(
	OrderId	text not null,
	CreationTimestamp text not null,
	DoneTimestamp text not null,
	CustomerId text not null,
	State text not null,
	OrderList text not null,
	TotalOrderPrice int not null,
)