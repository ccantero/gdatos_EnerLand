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
  idUsuario	INTEGER IDENTITY(1,1),
  username VARCHAR(20) NOT NULL,
  Contraseña VARCHAR(100) NOT NULL,
  Nombre VARCHAR(50) NULL,
  Apellido VARCHAR(50) NULL,
  Mail VARCHAR(50) NULL,
  Telefono INTEGER NULL,
  Tipo VARCHAR(50) NULL,
  Documento INTEGER NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idUsuario)
);

CREATE TABLE ENER_LAND.Rol_Usuario (
  idRol INTEGER NOT NULL ,
  idUsuario INTEGER NOT NULL,
  FOREIGN KEY(idUsuario)
    REFERENCES ENER_LAND.Usuario(idUsuario)
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

CREATE TABLE ENER_LAND.Consumible (
  idConsumible INTEGER NOT NULL,
  Descripcion VARCHAR(25) NULL,
  Precio FLOAT NULL,
  PRIMARY KEY(idConsumible)
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

CREATE TABLE ENER_LAND.Localidad (
	idLocalidad	INTEGER IDENTITY(1,1),
	Nombre VARCHAR(25),
	PRIMARY KEY(idLocalidad)
);

CREATE TABLE ENER_LAND.Pais (
	idPais	INTEGER IDENTITY(1,1),
	Nombre	VARCHAR(25),
	PRIMARY KEY(idPais)
);

CREATE TABLE ENER_LAND.Hotel (
  idHotel INTEGER NOT NULL IDENTITY(1,1),
  Administrador INTEGER NOT NULL,
  Nombre VARCHAR(25) NULL,
  Mail VARCHAR(50) NULL,
  Telefono INTEGER NULL,
  Cantidad_Estrellas INTEGER NOT NULL,
  PorcentajeRecarga NUMERIC(18,2) NOT NULL,
  Calle VARCHAR(50) NULL,
  Numero INTEGER NULL,
  idLocalidad INTEGER,  
  idPais INTEGER,
  Fecha_Creacion DATE NULL,
  Habilitado CHAR NOT NULL
  PRIMARY KEY(idHotel),
  FOREIGN KEY(Administrador)
    REFERENCES ENER_LAND.Usuario(idUsuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idLocalidad)
    REFERENCES ENER_LAND.Localidad(idLocalidad)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idPais)
    REFERENCES ENER_LAND.Pais(idPais)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
);


CREATE TABLE ENER_LAND.Habitacion (
  Numero INTEGER NOT NULL,
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

CREATE TABLE ENER_LAND.Huesped (
  idHuesped INTEGER NOT NULL IDENTITY(1,1),
  Tipo_Documento VARCHAR(25) NOT NULL,
  Nro_Documento INTEGER NOT NULL,
  Nombre VARCHAR(50) NOT NULL,
  Apellido VARCHAR(50) NOT NULL,
  Mail VARCHAR(50),
  Mail_Alternativo VARCHAR(50),
  Telefono INTEGER NULL,
  Calle VARCHAR(50) NULL,
  Numero INTEGER NULL,
  Piso INTEGER NULL,
  Departamento CHAR NULL,
  idLocalidad INTEGER NULL,
  Fecha_Nacimiento DATE NULL,
  Nacionalidad VARCHAR(50) NULL,
  Habilitado CHAR NOT NULL,
  PRIMARY KEY(idHuesped),
  FOREIGN KEY(idLocalidad)
    REFERENCES ENER_LAND.Localidad(idLocalidad) 
 );


CREATE TABLE ENER_LAND.Forma_de_Pago (
  idForma_De_Pago INTEGER NOT NULL IDENTITY(1,1),
  Descripcion VARCHAR(50) NULL,
  PRIMARY KEY(idForma_De_Pago)
);


CREATE TABLE ENER_LAND.Reserva (
  idReserva INTEGER NOT NULL,
  idEstado_Reserva INTEGER NOT NULL,
  idHuesped INTEGER NOT NULL,
  idRegimen INTEGER NOT NULL,
  FechaDesde DATE NULL,
  Cantidad_Dias INTEGER NULL,
  PRIMARY KEY(idReserva),
  FOREIGN KEY(idRegimen)
    REFERENCES ENER_LAND.Regimen(idRegimen)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idHuesped)
    REFERENCES ENER_LAND.Huesped(idHuesped)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idEstado_Reserva)
    REFERENCES ENER_LAND.Estado_Reserva(idEstado_Reserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ENER_LAND.Factura (
  idFactura INTEGER NOT NULL,
  idReserva INTEGER,
  Fecha DATE NULL,
  Total NUMERIC(18,2) NULL,
  idForma_De_Pago INTEGER NOT NULL,
  PRIMARY KEY(idFactura),
  FOREIGN KEY(idForma_De_Pago)
  REFERENCES ENER_LAND.Forma_de_Pago(idForma_De_Pago)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idReserva)
  REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
);

CREATE TABLE ENER_LAND.Item_Factura (
  idItem INTEGER NOT NULL,
  idFactura INTEGER NOT NULL,
  Cantidad INTEGER NOT NULL,
  Descripcion VARCHAR(25) NOT NULL,
  PrecioUnitario NUMERIC(18,2) NOT NULL,
  PRIMARY KEY(idItem, idFactura),
  FOREIGN KEY(idFactura)
    REFERENCES ENER_LAND.Factura(idFactura)
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
  idUsuario INTEGER NOT NULL,
  idHotel INTEGER NOT NULL,
  FOREIGN KEY(idUsuario)
    REFERENCES ENER_LAND.Usuario(idUsuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idHotel)
    REFERENCES ENER_LAND.Hotel(idHotel)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);


CREATE TABLE ENER_LAND.Consumible_Reserva (
  idConsumible INTEGER NOT NULL,
  idReserva INTEGER NOT NULL,
  FOREIGN KEY(idReserva)
    REFERENCES ENER_LAND.Reserva(idReserva)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idConsumible)
    REFERENCES ENER_LAND.Consumible(idConsumible)
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

INSERT [ENER_LAND].[Rol_Usuario] ([idRol], [idUsuario]) VALUES (1, 1);
INSERT [ENER_LAND].[Rol_Usuario] ([idRol], [idUsuario]) VALUES (3, 2);

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
						NULL,
						Cliente_Mail, 
						NULL, 
						Cliente_Dom_Calle, 
						Cliente_Nro_Calle, 
						Cliente_Piso, 
						Cliente_Depto,
						NULL, 
						Cliente_Fecha_Nac, 
						Cliente_Nacionalidad,
						1
	FROM gd_esquema.Maestra;

UPDATE ENER_LAND.Huesped
	SET Mail = Mail_Alternativo,
	Mail_Alternativo = NULL
FROM ENER_LAND.Huesped x1
WHERE EXISTS (	SELECT 1 FROM ENER_LAND.Huesped x2 
				WHERE x2.Mail_Alternativo = x1.Mail_Alternativo
				GROUP BY x2.Mail_Alternativo
				HAVING COUNT(1) = 1 )

INSERT ENER_LAND.Tipo_Habitacion 
	SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual FROM gd_esquema.Maestra
	ORDER BY 1;
	
INSERT ENER_LAND.Regimen
	SELECT DISTINCT Regimen_Descripcion, Regimen_Precio, 1
	FROM gd_esquema.Maestra 
	ORDER BY 2;
	
INSERT ENER_LAND.Consumible
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


INSERT [ENER_LAND].[Localidad]
	SELECT DISTINCT Hotel_Ciudad FROM gd_esquema.Maestra
	ORDER BY 1
	
INSERT [ENER_LAND].[Pais] ([Nombre]) VALUES ('Argentina');

BEGIN
	DECLARE @ROW_NUMBER INT
	DECLARE @Hotel_Ciudad INTEGER
	DECLARE @Hotel_Calle NVARCHAR(255)
	DECLARE @Hotel_Nro_Calle NUMERIC(18,0)
	DECLARE @Hotel_CantEstrella NUMERIC(18,0)
	DECLARE @Hotel_Recarga_Estrella NUMERIC(18,0)
	
	DECLARE Hotel_Cursor CURSOR FOR 
		SELECT DISTINCT Hotel_Calle,Hotel_Nro_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella,idLocalidad
		FROM gd_esquema.Maestra, Ener_Land.Localidad
		WHERE Hotel_Ciudad = Nombre;
	
	SET @ROW_NUMBER = 1;
	OPEN Hotel_Cursor;
	FETCH NEXT FROM Hotel_Cursor INTO @Hotel_Calle, @Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella, @Hotel_Ciudad;
	WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO [ENER_LAND].[Hotel]
			VALUES (1, 'Hotel '+CONVERT(CHAR,@ROW_NUMBER),NULL,NULL,@Hotel_CantEstrella, @Hotel_Recarga_Estrella, @Hotel_Calle, @Hotel_Nro_Calle, @Hotel_Ciudad,1, NULL, 1);
			FETCH NEXT FROM Hotel_Cursor INTO @Hotel_Calle, @Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella, @Hotel_Ciudad;
			SET @ROW_NUMBER = @ROW_NUMBER + 1;
		END;
	CLOSE Hotel_Cursor;
	DEALLOCATE Hotel_Cursor;
END;

INSERT [ENER_LAND].[Habitacion]
	SELECT DISTINCT Habitacion_Numero, x2.idHotel,x4.idTipo_Habitacion, Habitacion_Piso, Habitacion_Frente, NULL, 1
	FROM gd_esquema.Maestra x1, ENER_LAND.Hotel x2, ENER_LAND.Localidad x3,ENER_LAND.Tipo_Habitacion x4
	WHERE x1.Hotel_Calle = x2.Calle
	AND x1.Hotel_Nro_Calle = x2.Numero
	AND x2.idLocalidad = x3.idLocalidad
	AND x1.Hotel_Ciudad = x3.Nombre
	AND x1.Habitacion_Tipo_Codigo = x4.idTipo_Habitacion
	ORDER BY x2.idHotel, x1.Habitacion_Numero;
	
INSERT [ENER_LAND].[Usuario_Hoteles]
	SELECT 1,idHotel FROM ENER_LAND.Hotel;
	
INSERT [ENER_LAND].[Regimen_Hotel]
	SELECT DISTINCT x3.idHotel, x2.idRegimen
	FROM gd_esquema.Maestra x1, ENER_LAND.Regimen x2, ENER_LAND.Hotel x3, ENER_LAND.Localidad x4
	WHERE x1.Hotel_Calle = x3.Calle
	AND x1.Hotel_Nro_Calle = x3.Numero
	AND x1.Hotel_Ciudad = x4.Nombre
	AND x3.idLocalidad = x4.idLocalidad
	AND x1.Regimen_Descripcion = x2.Descripcion
	ORDER BY 1, 2;
	
INSERT ENER_LAND.Reserva
	SELECT DISTINCT Reserva_Codigo, 1, x6.idHuesped, x5.idRegimen, x1.Reserva_Fecha_Inicio, x1.Reserva_Cant_Noches
	FROM gd_esquema.Maestra x1, ENER_LAND.Hotel x2, ENER_LAND.Localidad x3, ENER_LAND.Habitacion x4, ENER_LAND.Regimen x5, ENER_LAND.Huesped x6
	WHERE x1.Hotel_Calle = x2.Calle
	AND x1.Hotel_Nro_Calle = x2.Numero
	AND x1.Hotel_Ciudad = x3.Nombre
	AND x2.idLocalidad = x3.idLocalidad
	AND x2.idHotel = x4.IdHotel
	AND x1.Habitacion_Numero = x4.Numero
	AND x1.Regimen_Descripcion = x5.Descripcion
	AND ( 
			x1.Cliente_Mail = x6.Mail
			OR x1.Cliente_Mail = x6.Mail_Alternativo 
		)
	AND x1.Cliente_Pasaporte_Nro = x6.Nro_Documento
	AND x1.Cliente_Apellido = x6.Apellido
	AND x1.Cliente_Nombre = x6.Nombre
	ORDER BY 1;

INSERT ENER_LAND.Reserva_Habitacion
	SELECT DISTINCT R.idReserva, Hab.idHotel, Hab.Numero
	FROM gd_esquema.Maestra M, ENER_LAND.Hotel Hot, ENER_LAND.Localidad L, ENER_LAND.Habitacion Hab, ENER_LAND.Reserva R
	WHERE M.Reserva_Codigo = R.idReserva
	AND M.Hotel_Calle = Hot.Calle
	AND M.Hotel_Nro_Calle = Hot.Numero
	AND M.Hotel_Ciudad = L.Nombre
	AND Hot.idLocalidad = L.idLocalidad
	AND Hot.idHotel = Hab.idHotel
	AND M.Habitacion_Numero = Hab.Numero;

	
INSERT INTO ENER_LAND.Estadias
	SELECT R.idReserva, Estadia_Fecha_Inicio, Estadia_Cant_Noches
	FROM gd_esquema.Maestra M, ENER_LAND.Reserva R
	WHERE M.Estadia_Fecha_Inicio IS NOT NULL
	AND M.Estadia_Cant_Noches IS NOT NULL
	AND M.Factura_Nro IS NULL
	AND M.Reserva_Codigo = R.idReserva;
	
INSERT INTO ENER_LAND.Consumible_Reserva
	SELECT C.idConsumible, R.idReserva
	FROM gd_esquema.Maestra M, ENER_LAND.Reserva R, ENER_LAND.Consumible C
	WHERE M.Consumible_Codigo = C.idConsumible
	AND M.Reserva_Codigo = R.idReserva;

INSERT INTO ENER_LAND.Huespedes_Alojados
	SELECT idHuesped, idReserva
	FROM ENER_LAND.Reserva;
	
INSERT INTO ENER_LAND.Factura
	SELECT DISTINCT Factura_Nro, R.idReserva, Factura_Fecha, Factura_Total, 1
	FROM gd_esquema.Maestra M, ENER_LAND.Reserva R
	WHERE Factura_Nro IS NOT NULL
	AND Reserva_Codigo = R.idReserva;

INSERT INTO ENER_LAND.Item_Factura([idItem],[idFactura],[Cantidad],[Descripcion],[PrecioUnitario])
	SELECT	ROW_NUMBER() OVER (PARTITION BY Factura_Nro ORDER BY Factura_Nro), 
			Factura_Nro, 
			CASE COUNT(Consumible_Codigo)
				WHEN 0 THEN Estadia_Cant_Noches
				ELSE COUNT(Consumible_Codigo)
			END, 
			ISNULL(Consumible_Descripcion,'Estadia'),
			Item_Factura_Monto
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, Consumible_Codigo, Item_Factura_Monto, Estadia_Cant_Noches, Consumible_Descripcion
	ORDER BY Factura_Nro;

UPDATE ENER_LAND.Factura
	SET Total = ( SELECT SUM(Cantidad * PrecioUnitario) FROM ENER_LAND.Item_Factura it WHERE it.idFactura = F.idFactura GROUP BY it.idFactura)
FROM ENER_LAND.Factura f

/* STORE PROCEDURES */
GO
CREATE PROCEDURE ENER_LAND.Agregar_Rol
(
	@NombreRol	VARCHAR(25),
	@habilitado	INT
)
AS
	IF EXISTS ( SELECT 1 FROM ENER_LAND.Rol WHERE Descripcion = @NombreRol )
		BEGIN
			RETURN -1; /* Rol Existente */
		END;
	
	INSERT INTO ENER_LAND.Rol(Descripcion, Habilitado)
	VALUES (@NombreRol, @habilitado);
	
	RETURN @@IDENTITY; 		
GO

CREATE PROCEDURE ENER_LAND.Agregar_Funcionalidad
(
	@idRol	INT,
	@idFuncionalidad	INT
)
AS
	IF NOT EXISTS ( SELECT 1 FROM ENER_LAND.Funcionalidad WHERE idFuncionalidad = @idFuncionalidad )
		BEGIN
			RETURN -1; /* Funcionalidad Inexistente */
		END
	ELSE	
		BEGIN
			IF EXISTS ( SELECT 1 FROM ENER_LAND.Rol_Funcionalidad
						WHERE idFuncionalidad = @idFuncionalidad
						AND idRol = @idRol )
				BEGIN
					RETURN -2; /* Funcionalidad Repetida */
				END
			ELSE
				BEGIN
					INSERT INTO ENER_LAND.Rol_Funcionalidad ( idRol, idFuncionalidad )
					VALUES ( @idRol, @idFuncionalidad );
					RETURN 0
				END
		END
GO

CREATE PROCEDURE ENER_LAND.Nuevo_Hotel
  @idAdmin int,
  @nombre varchar(25),
  @mail varchar(50),
  @telefono int ,@cantEstrellas int ,@calle varchar(50),@numero int,@idLocalidad int,@idPais int,@fechaCreacion date,@habilitado char(1)
AS

INSERT INTO  ENER_LAND.HOTEL (Administrador,nombre,mail, telefono,Cantidad_Estrellas,PorcentajeRecarga,calle,numero,idLocalidad,idPais,Fecha_Creacion,habilitado)
VALUES (@idAdmin,@nombre,@mail, @telefono,@cantEstrellas,10,@calle,@numero,@idLocalidad,@idPais,@fechaCreacion,@habilitado);

SELECT @@IDENTITY AS idHotel
GO