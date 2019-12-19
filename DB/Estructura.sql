CREATE DATABASE Loterias_Afortunadas
use Loterias_Afortunadas


CREATE TABLE Loteria
(
	id int identity(1,1)primary key,
	Nombre_Loteria varchar(15) not null,
	horario nchar(10) not null
)

CREATE TABLE Jugadas
(
	id int identity(1,1) primary key,
	Fecha_Jugada date,
	Loteria nchar(15),
	Cliente nchar(13),
	monto decimal,
	Loteria nchar(15),
	Cliente nchar(13),
	monto decimal
)
CREATE TABLE Clientes
(
	idC int identity(1,1)primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Cedula nvarchar(13)not null,
	Direccion ntext not null,

)





