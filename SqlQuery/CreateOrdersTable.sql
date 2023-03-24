use H1PD021123_Gruppe1;

create table Orders
(
	OrderNumber	int identity(1,1) not null primary key,
	CreationTimestamp text not null,
	DoneTimestamp text not null,
	CustomerNumber text not null,
	State text not null,
	OrderList text not null,
	TotalOrderPrice int not null,
)