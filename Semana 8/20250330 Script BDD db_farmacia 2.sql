
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

	Select * from tbl_clientes;

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Elvis','542154-2',78879654,'Cuilapa Inejab zona 0','Activo','23/03/2025','Emorales');

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Luis','655879-3',78875241,'Barberena Calle Real zona 1','Activo','30/03/2025','Emorales');

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Maria','6633165-5',78872241,'Jutiapa Colonia Rela zona 3','Activo','30/03/2025','Emorales');

	Insert into tbl_clientes( Nombre, Nit, Telefono, Direccion, Estado, FechaAuditoria, UsuarioAuditoria) values (@Nombre, @Nit, @Telefono, @Direccion, @Estado, @FechaAuditoria, @UsuarioAuditoria);


	Select * from tbl_clientes;

-- Creacion de tabla tbl_proveedores

	Create table tbl_proveedores
	(
		CodigoProveedor int primary key identity(1,1) not null,
		Nombre varchar(100),
		Nit varchar(20),
		Telefono int,
		Email varchar(100),
		Estado varchar(15),
		FechaAuditoria DateTime,
		UsuarioAuditoria varchar(45)
	);

	Select * from tbl_proveedores;

	Insert into tbl_proveedores(Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Laboratorios MediCentro S.A.', '546216-2',78876547,'medicentro@gmail.com','Activo','30/03/2025','Emorales');

	Insert into tbl_proveedores(Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Laboratorios La Salud S.A.', '654125-3',87789621,'lasalud@gmail.com','Activo','30/03/2025','Emorales');

	Insert into tbl_proveedores(Nombre, Nit, Telefono, Email, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('Laboratorios La Fe S.A.', '985412-2',78878741,'lafe@gmail.com','Activo','30/03/2025','Emorales');

	Select * from tbl_proveedores;


-- Creacion de tabla tbl_usuarios

	Create table tbl_usuarios
	(
		CodigoEmpleado int primary key identity(1,1) not null,
		Email varchar(100),
		Rol varchar(45),
		Usuario varchar(50),
		Contrasena varchar(255),
		Estado varchar(15),
		FechaAuditoria DateTime,
		UsuarioAuditoria varchar(45)
	);

	Select * from tbl_usuarios;

	insert into tbl_usuarios(Email, Rol, Usuario, Contrasena, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('eroldan@gmial.com','admin','Eroldan','Roldan123','Activo','29/03/2025','Emorales');

	insert into tbl_usuarios(Email, Rol, Usuario, Contrasena, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('mlopez@gmial.com','contador','mlopez','Farmacia3','Activo','29/03/2025','Emorales');

	insert into tbl_usuarios(Email, Rol, Usuario, Contrasena, Estado, FechaAuditoria, UsuarioAuditoria)
	values ('dflores@gmial.com','gerente','dflores','123','Activo','29/03/2025','Emorales');

	Select * from tbl_usuarios;

	Select * from tbl_clientes;

	update tbl_clientes	set 
		Nombre = 'Nombre',
		Nit = 'Nit',
		Telefono = telefono,
		Direccion = 'direccion',
		FechaAuditoria ='FechaAditoria',
		Estado = 'Estado',
		UsuarioAuditoria = 'auditoria',			   		 
	where CodigoCliente=1;
	
	--Script para actualizar datos

	Select * from tbl_clientes;

	update tbl_clientes	set Nombre = @Nombre,Nit = @Nit,Telefono = @telefono,Direccion = @direccion,FechaAuditoria =@FechaAditoria,Estado = @Estado,UsuarioAuditoria = @auditoria,			   		 
	where CodigoCliente=1;


	--Query para eliminar registros
	Select*from tbl_clientes;
	Delete tbl_clientes where CodigoCliente = 1;
	Delete tbl_clientes where CodigoCliente = @CodigoCliente;

	---Tabla medicamentos
	create table tbl_medicamentos
	(
	CodigoMedicamento int primary key identity(1,1) not null,
	Descripcion varchar(255),
	UnidadMedida varchar(20),
	precio decimal(10,2),
	stock decimal(10,2),
	FechaVencimiento datetime,
	CodigoCategoria int,
	CodigoProveedr int,
	Estado varchar(20),
	FechaAuditoria datetime,
	UsuarioAuditoria varchar(50)
	);




	












