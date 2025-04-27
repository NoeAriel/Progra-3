

-- Creacion de la base de datos

	Create database db_farmacia;

-- Logueo de la base de datos

	use db_farmacia;

-- Creacion de tabla tbl_clientes
	
	create table tbl_clientes
	(
		CodigoCliente int primary key identity(1,1) not null,
		Nombre Varchar(100),
		Nit Varchar(20),
		Telefono int,
		Direccion Varchar(100),
		Estado Varchar(15),
		FechaAuditoria Datetime,
		UsuarioAuditoria varchar(45)	
	);

-- Consultar datos de la tabla

	Select * from tbl_clientes;


