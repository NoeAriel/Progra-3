

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

-- script para agregar datos a tabla clientes

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Elvis','542154-2',78879654,'Cuilapa Inejab zona 0','Activo','23/03/2025','Emorales');

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria) values ( @Nombre, @Nit, @Telefono, @Direccion, @Estado, @FechaAuditoria,@ UsuarioAuditoria);


	Select * from tbl_clientes;


