use banco_amigo;


CREATE TABLE cliente (
    ID INT PRIMARY KEY,
	saldo NUMERIC (10,2)
);


insert into cliente values(
	1,
	10000
);

select * from cliente;