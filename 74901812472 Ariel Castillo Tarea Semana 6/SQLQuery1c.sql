--Creacion de la base de datos
Create database db_farmacia;
--Login base de datos
use db_farmacia;
--Crear tablas
Create Table tbl_clientes
(
CodigoCliente int primary key identity(1,1) not null,
Nombre Varchar(100),
Nit Varchar(20),
Telefono int,
Direccion Varchar(100),
Estado Varchar(15),
FechaAuditoria DateTime,
UsuarioAuditoria varchar(45)
);

--Consultar datos de la tabla

use db_farmacia;
--Crear tabla
Create Table tbl_proveedores
(CodigoProveedores int primary key identity(1,1) not null,
Nombre Varchar(100),
Nit Varchar(20),
Telefono int,
Email Varchar(100),
Estado Varchar(15),
FechaAuditoria DATETIME,
UsuarioAuditoria Varchar(45)
);