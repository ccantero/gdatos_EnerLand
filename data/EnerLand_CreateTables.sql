USE GD2C2014
GO

CREATE SCHEMA ENER_LAND AUTHORIZATION gd;
GO	

/* CREATE TABLES */

CREATE TABLE ENER_LAND.Rol (
  idRol INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(25) NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idRol)
);

CREATE TABLE ENER_LAND.Funcionalidad (
  idFuncionalidad INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(25) NULL,
  PRIMARY KEY(idFuncionalidad)
);

CREATE TABLE ENER_LAND.Rol_Funcionalidad (
  idRol INTEGER NOT NULL,
  idFuncionalidad INTEGER NOT NULL,
  FOREIGN KEY(idRol)
    REFERENCES ENER_LAND.Rol(idRol)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idFuncionalidad)
    REFERENCES ENER_LAND.Funcionalidad(idFuncionalidad)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Usuario (
  username VARCHAR(20) NOT NULL,
  Contraseña VARCHAR(100) NOT NULL,
  Nombre VARCHAR(50) NULL,
  Apellido VARCHAR(50) NULL,
  Mail VARCHAR(50) NULL,
  Telefono INTEGER NULL,
  Tipo VARCHAR(50) NULL,
  Documento INTEGER NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(username)
);

CREATE TABLE ENER_LAND.Rol_Usuario (
  idRol INTEGER NOT NULL ,
  username VARCHAR(20) NOT NULL,
  FOREIGN KEY(username)
    REFERENCES ENER_LAND.Usuario(username)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idRol)
    REFERENCES ENER_LAND.Rol(idRol)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);


CREATE TABLE ENER_LAND.Regimen (
  idRegimen INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(25) NULL,
  Precio FLOAT NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idRegimen)
);

CREATE TABLE ENER_LAND.Consumibles (
  idConsumibles INTEGER NOT NULL,
  Descripcion VARCHAR(25) NULL,
  Precio FLOAT NULL,
  PRIMARY KEY(idConsumibles)
);

CREATE TABLE ENER_LAND.Estado_Reserva (
  idEstado_Reserva INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(50) NULL,
  PRIMARY KEY(idEstado_Reserva)
);

CREATE TABLE ENER_LAND.Tipo_Habitacion (
  idTipo_Habitacion INTEGER NOT NULL,
  Descripcion VARCHAR(20) NULL,
  Porcentaje NUMERIC(18,2) NULL,
  PRIMARY KEY(idTipo_Habitacion)
);

CREATE TABLE ENER_LAND.Hotel (
  idHotel INTEGER NOT NULL IDENTITY(1,1),
  Administrador VARCHAR(20) NOT NULL,
  Nombre VARCHAR NULL,
  Mail VARCHAR NULL,
  Telefono INTEGER NULL,
  Cantidad_Estrellas INTEGER NOT NULL,
  Calle VARCHAR NULL,
  Numero INTEGER NULL,
  Localidad VARCHAR(25),
  Pais VARCHAR(25),
  Fecha_Creacion DATE NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idHotel),
  FOREIGN KEY(Administrador)
    REFERENCES ENER_LAND.Usuario(username)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
);

CREATE TABLE ENER_LAND.Huesped (
  idHuesped INTEGER NOT NULL IDENTITY(1,1),
  Tipo_Documento VARCHAR(25) NOT NULL,
  Nro_Documento INTEGER NOT NULL,
  Nombre VARCHAR(50) NOT NULL,
  Apellido VARCHAR(50) NOT NULL,
  Mail VARCHAR(50) NOT NULL,
  Telefono INTEGER NULL,
  Calle VARCHAR(50) NULL,
  Numero INTEGER NULL,
  Piso INTEGER NULL,
  Departamento CHAR NULL,
  Fecha_Nacimiento DATE NULL,
  Nacionalidad VARCHAR(50) NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idHuesped)
);


CREATE TABLE ENER_LAND.Forma_de_Pago (
  idForma_De_Pago INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(50) NULL,
  PRIMARY KEY(idForma_De_Pago)
);

CREATE TABLE ENER_LAND.Factura (
  idFactura INTEGER NOT NULL,
  idHuesped INTEGER,
  idHotel INTEGER,
  Fecha DATE NULL,
  Total FLOAT NULL,
  idForma_De_Pago INTEGER NOT NULL,
  PRIMARY KEY(idFactura),
  FOREIGN KEY(idForma_De_Pago)
  REFERENCES ENER_LAND.Forma_de_Pago(idForma_De_Pago)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idHuesped)
  REFERENCES ENER_LAND.Huesped(idHuesped)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idHotel)
  REFERENCES ENER_LAND.Hotel(idHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Item_Factura (
  idItem INTEGER NOT NULL IDENTITY(1,1),
  idFactura INTEGER NOT NULL,
  Cantidad INTEGER NULL,
  Monto FLOAT NULL,
  PRIMARY KEY(idItem, idFactura),
  FOREIGN KEY(idFactura)
    REFERENCES ENER_LAND.Factura(idFactura)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Reserva (
  idReserva INTEGER NOT NULL IDENTITY(1,1),
  idEstado_Reserva INTEGER NOT NULL,
  Huesped_idHuesped INTEGER NOT NULL,
  idRegimen INTEGER NOT NULL,
  FechaDesde DATE NULL,
  Cantidad_Dias INTEGER NULL,
  PRIMARY KEY(idReserva),
  FOREIGN KEY(idRegimen)
    REFERENCES ENER_LAND.Regimen(idRegimen)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Huesped_idHuesped)
    REFERENCES ENER_LAND.Huesped(idHuesped)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idEstado_Reserva)
    REFERENCES ENER_LAND.Estado_Reserva(idEstado_Reserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);


CREATE TABLE ENER_LAND.Estadias (
  idReserva INTEGER NOT NULL,
  Fecha_Ingreso DATE NOT NULL,
  Cantidad_Dias INTEGER NULL,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Auditoria_Reserva (
  idReserva INTEGER NOT NULL,
  Fecha DATE NOT NULL,
  Operacion VARCHAR NULL,
  Usuario VARCHAR NULL,
  Motivo_Cancelacion VARCHAR NULL,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Hotel_Inhabilitado (
  IdHotel INTEGER NOT NULL,
  FechaInicio DATE NOT NULL,
  Cantidad_Dias INTEGER NULL,
  Motivo VARCHAR NULL
  FOREIGN KEY(idHotel)
    REFERENCES ENER_LAND.Hotel(IdHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Usuario_Hoteles (
  username VARCHAR(20) NOT NULL,
  idHotel INTEGER NOT NULL,
  FOREIGN KEY(username)
    REFERENCES ENER_LAND.Usuario(username)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idHotel)
    REFERENCES ENER_LAND.Hotel(idHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Habitacion (
  Numero INTEGER NOT NULL IDENTITY(1,1),
  IdHotel INTEGER NOT NULL,
  idTipo_Habitacion INTEGER NOT NULL,
  Piso INTEGER NULL,
  Ubicacion CHAR NULL,
  Descripcion VARCHAR NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(Numero, IdHotel),
  FOREIGN KEY(idHotel)
    REFERENCES ENER_LAND.Hotel(idHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idTipo_Habitacion)
    REFERENCES ENER_LAND.Tipo_Habitacion(idTipo_Habitacion)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Consumible_Reserva (
  idConsumibles INTEGER NOT NULL,
  idReserva INTEGER NOT NULL,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idConsumibles)
    REFERENCES ENER_LAND.Consumibles(idConsumibles)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Huespedes_Alojados (
  idHuesped INTEGER NOT NULL,
  idReserva INTEGER NOT NULL,
  FOREIGN KEY(idHuesped)
    REFERENCES ENER_LAND.Huesped(idHuesped)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Regimen_Hotel (
  idHotel INTEGER NOT NULL,
  idRegimen INTEGER NOT NULL,
  FOREIGN KEY(idHotel)
    REFERENCES ENER_LAND.Hotel(idHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idRegimen)
    REFERENCES ENER_LAND.Regimen(idRegimen)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Reserva_Habitacion (
  idReserva INTEGER NOT NULL,
  IdHotel INTEGER NOT NULL,
  Habitacion_Numero INTEGER NOT NULL,
  FOREIGN KEY(Habitacion_Numero, IdHotel)
    REFERENCES ENER_LAND.Habitacion(Numero, IdHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

/* INSERT */

INSERT [ENER_LAND].[Rol] ([Descripcion], [Habilitado]) VALUES ('Administrador', 1);
INSERT [ENER_LAND].[Rol] ([Descripcion], [Habilitado]) VALUES ('Recepcionista', 1);
INSERT [ENER_LAND].[Rol] ([Descripcion], [Habilitado]) VALUES ('Guest', 1);

INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('ABM Usuario');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('ABM Huesped');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('ABM Hotel');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('ABM Habitacion');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Generar Reserva');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Cancelar Reserva');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Registrar Estadia');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Registrar Consumible');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Facturar');
INSERT [ENER_LAND].[Funcionalidad] ([Descripcion]) VALUES ('Estadisticas');	

INSERT [ENER_LAND].[Usuario] ([username], [Contraseña], [Habilitado]) VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 1);
-- w23e encriptado en SHA256 es e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7
INSERT [ENER_LAND].[Usuario] ([username], [Contraseña], [Habilitado]) VALUES ('guest', '280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02', 1);
-- welcome encriptado en SHA256 es 280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02

INSERT [ENER_LAND].[Rol_Usuario] ([idRol], [username]) VALUES (1, 'admin');
INSERT [ENER_LAND].[Rol_Usuario] ([idRol], [username]) VALUES (3, 'guest');

INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 1);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 2);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 3);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 4);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 5);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 6);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 7);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 8);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 9);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (1, 10);

INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 2);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 5);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 6);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 7);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 8);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (2, 9);

INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (3, 2);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (3, 5);
INSERT [ENER_LAND].[Rol_Funcionalidad] ([idRol], [idFuncionalidad]) VALUES (3, 6);

INSERT ENER_LAND.Huesped
	SELECT	DISTINCT	'Pasaporte',
						Cliente_Pasaporte_Nro, 
						Cliente_Nombre,
						Cliente_Apellido, 
						Cliente_Mail, 
						NULL, 
						Cliente_Dom_Calle, 
						Cliente_Nro_Calle, 
						Cliente_Piso, 
						Cliente_Depto, 
						Cliente_Fecha_Nac, 
						Cliente_Nacionalidad,
						1
	FROM gd_esquema.Maestra;


INSERT ENER_LAND.Tipo_Habitacion 
	SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual FROM gd_esquema.Maestra
	ORDER BY 1;
	
INSERT ENER_LAND.Regimen
	SELECT DISTINCT Regimen_Descripcion, Regimen_Precio, 1
	FROM gd_esquema.Maestra 
	ORDER BY 2;
	
INSERT ENER_LAND.Consumibles
	SELECT DISTINCT Consumible_Codigo, 
					Consumible_Descripcion,
					Consumible_Precio 
	FROM gd_esquema.Maestra
	WHERE Consumible_Codigo IS NOT NULL
	ORDER BY 1;
	
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva correcta');
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva modificada');
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva cancelada por Recepción');
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva cancelada por Cliente');
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva cancelada por No-Show');
INSERT [ENER_LAND].[Estado_Reserva] ([Descripcion]) VALUES ('Reserva con ingreso (efectivizada)');

INSERT [ENER_LAND].[Forma_de_Pago] ([Descripcion]) VALUES ('Efectivo');
INSERT [ENER_LAND].[Forma_de_Pago] ([Descripcion]) VALUES ('Tarjeta de Credito');