USE GD2C2013
GO
						/* CREACIÓN DE ESQUEMA*/
/****** Object:  Schema [gd_esquema]    Script Date: 04/15/2012 01:58:54 ******/
CREATE SCHEMA ORACLE_FANS AUTHORIZATION gd;
GO	
						/*FIN DE ESQUEMA*/

		
							/*Inicio de la Creación de Tablas*/

--Creación de la tabla: Roles
CREATE TABLE ORACLE_FANS.Roles
(
	[id_Rol][int] IDENTITY(1,1),
	[Nombre] [varchar](50),
	[isActive][bit],
CONSTRAINT PK_Roles PRIMARY KEY (id_Rol)
);
GO

--Creación de la tabla: Usuarios
CREATE TABLE ORACLE_FANS.Usuarios
(
	[idUsuario][int] IDENTITY(1,1),
	[id_Rol][int] NOT NULL,
	[username][varchar](10) NOT NULL,
	[password][varchar](100) NOT NULL,
	[intentosLogin][int],
	[habilitado][bit],
CONSTRAINT PK_Usuarios PRIMARY KEY (idUsuario),
CONSTRAINT FK_Usuarios FOREIGN KEY (id_Rol) REFERENCES ORACLE_FANS.Roles(id_Rol)
);
GO

--Creación de tabla: Funcionalidades
CREATE TABLE ORACLE_FANS.Funcionalidades
(
	[id_funcionalidad] [int],
	[Descripcion][varchar](100),
CONSTRAINT PK_Funcionalidades PRIMARY KEY(id_Funcionalidad) 
);
GO

--Creación de tabla: Roles_Funcionalidad
CREATE TABLE ORACLE_FANS.Roles_Funcionalidad
(
	[id_Funcionalidad] [int],
	[id_Rol][int],
CONSTRAINT FK_Roles_Funcionalidad_Id FOREIGN KEY(id_Funcionalidad) REFERENCES ORACLE_FANS.Funcionalidades(id_Funcionalidad),
CONSTRAINT FK_Roles_Funcionalidad_Rol FOREIGN KEY (id_Rol) REFERENCES ORACLE_FANS.Roles(id_Rol)
);

GO

--Creación de tabla: Planes_Medicos
CREATE TABLE ORACLE_FANS.Planes_Medicos
(
	[Cod_PlanMedico][numeric](18),
	[Descripcion][varchar](255),
	[Precio_Bono_Consulta][numeric](18),
	[Precio_Bono_Farmacia][numeric](18),
CONSTRAINT PK_Plan_Medico_Cod_PlanMedico PRIMARY KEY(Cod_PlanMedico)
);

GO

--Creación de tabla: Afiliados
CREATE TABLE ORACLE_FANS.Afiliados
(
	[Cod_Afiliado][int],
	[Cod_PlanMedico][numeric](18), 
	[Nombre][varchar](255),
	[Apellido][varchar](255),
	[Tipo_Documento][varchar](6),
	[Numero_Documento][numeric](18),
	[Direccion][varchar](255),
	[Telefono][numeric](18),
	[Mail][varchar](255),
	[Fecha_Nac][datetime],
	[Sexo][char],
	[Estado_Civil][varchar](15),
	[Cant_Familiares_A_Cargo][int],
	[Activo][bit],
	[Fecha_Baja][datetime]
	
CONSTRAINT PK_Paciente PRIMARY KEY (Cod_Afiliado),
CONSTRAINT FK_Paciente FOREIGN KEY (Cod_PlanMedico) REFERENCES ORACLE_FANS.Planes_Medicos(Cod_PlanMedico)
);
GO

--Creación de tabla: Profesionales
CREATE TABLE ORACLE_FANS.Profesionales
(
	[Matricula][int],
	[Nombre][varchar](255),
	[Apellido][varchar](255),
	[Tipo_Documento][varchar](6),
	[Numero_Documento][numeric](18),
	[Direccion][varchar](255),
	[Mail][varchar](255),
	[Telefono][numeric](18),
	[Fecha_Nac][datetime],
	[Sexo][char],
	[Activo][bit],
CONSTRAINT PK_Medico PRIMARY KEY (Matricula)
);
GO

--Creación de la tabla: Tipo_Especialidad
CREATE TABLE ORACLE_FANS.Tipo_Especialidad
(
	[Cod_Tipo_Especialidad][numeric](18),
	[Descripcion][varchar](255),
CONSTRAINT PK_Tipo_Especialidad PRIMARY KEY (Cod_Tipo_Especialidad)	
);
GO

--Creación de la tabla: Especialidades
CREATE TABLE ORACLE_FANS.Especialidades
(
	[Cod_Especialidad][numeric](18),
	[Cod_Tipo_Especialidad][numeric](18),
	[Descripcion][varchar](255),
CONSTRAINT PK_Especialidad_Cod_Especialidad PRIMARY KEY (Cod_Especialidad),
CONSTRAINT FK_Especialidad_Cod_Tipo_Especialidad FOREIGN KEY (Cod_Tipo_Especialidad) REFERENCES ORACLE_FANS.Tipo_Especialidad(Cod_Tipo_Especialidad)
);
GO

--Creacion de la tabla: Medico_Especialidad
CREATE TABLE ORACLE_FANS.Medico_Especialidad
(
	[Cod_Especialidad][numeric](18),
	[Matricula][int],
CONSTRAINT FK_Medico_Especialidad_Especialidad FOREIGN KEY (Cod_Especialidad) REFERENCES ORACLE_FANS.Especialidades(Cod_Especialidad),
CONSTRAINT FK_Medico_Especialidad_Matricula FOREIGN KEY (Matricula) REFERENCES ORACLE_FANS.Profesionales(Matricula)
);
GO

--Creación de la tabla:Bono_Farmacia
CREATE TABLE ORACLE_FANS.Bono_Farmacia
(
	[Numero][numeric](18) IDENTITY(75757,1),
	[Cod_Afiliado][int],
	[Cod_PlanMedico][numeric](18),
	[Fecha_Impresion][datetime],
	[Fecha_Vencimiento][datetime],
	[Activo][bit]
	
CONSTRAINT PK_Bono_Farmacia PRIMARY KEY (Numero)
CONSTRAINT FK_Bono_Farmacia_Cod_Afiliado FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados(Cod_Afiliado),
CONSTRAINT FK_Bono_Farmacia_PlanMedico FOREIGN KEY (Cod_PlanMedico) REFERENCES ORACLE_FANS.Planes_Medicos(Cod_PlanMedico)
);
GO

--Creación de la tabla: Bono_Consulta
CREATE TABLE ORACLE_FANS.Bono_Consulta
(
	[Numero][numeric](18),
	[Cod_PlanMedico][numeric](18),
	[Numero_Consulta][int],
	[Cod_Afiliado][int],
	[Fecha_Impresion][datetime],
	[Activo][bit]
CONSTRAINT PK_Numero PRIMARY KEY (Numero),
CONSTRAINT FK_Bono_Consulta_Cod_Afiliado FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados(Cod_Afiliado),
CONSTRAINT FK_Bono_Consulta_Cod_PlanMedico FOREIGN KEY (Cod_PlanMedico) REFERENCES ORACLE_FANS.Planes_Medicos(Cod_PlanMedico)
);

GO

--Creación de la tabla: Turnos
CREATE TABLE ORACLE_FANS.Turnos
(
	[Cod_Turno][numeric](18),
	[Matricula][int],
	[Cod_Especialidad][numeric](18),
	[Cod_Afiliado][int],
	[Fecha][datetime],
	[habilitado][bit]
CONSTRAINT PK_Turno PRIMARY KEY (Cod_Turno)
CONSTRAINT FK_Cod_Afiliado FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados(Cod_Afiliado),
CONSTRAINT FK_Matricula FOREIGN KEY (Matricula) REFERENCES ORACLE_FANS.Profesionales(Matricula),
CONSTRAINT FK_Cod_Especiliadad FOREIGN KEY (Cod_Especialidad) REFERENCES ORACLE_FANS.Especialidades(Cod_Especialidad)
);
GO 

--Creación de la tabla: Consultas
CREATE TABLE ORACLE_FANS.Consultas
(
	[Cod_Turno][numeric](18),
	[Bono_Consulta_Numero][numeric](18),
	[Cod_Afiliado][int],
	[Sintomas][varchar](255),
	[Enfermedades][varchar](255)
CONSTRAINT FK_Cod_Turno_Consultas FOREIGN KEY (Cod_Turno) REFERENCES ORACLE_FANS.Turnos(Cod_Turno),
CONSTRAINT FK_Bono_Consulta_Numero FOREIGN KEY (Bono_Consulta_Numero) REFERENCES ORACLE_FANS.Bono_Consulta(Numero),
CONSTRAINT FK_Cod_Afiliado_Consultas FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados(Cod_Afiliado)
);

GO

--Creación de la Tabla Grilla
CREATE TABLE ORACLE_FANS.Grilla
(
	[Cod_Grilla][int],
	[Dia][varchar](10),
	[Hora][time],
	[Activo][bit]
CONSTRAINT PK_Cod_Grilla PRIMARY KEY (Cod_Grilla)  
);
GO

--Creación de la Tabla Agenda
CREATE TABLE ORACLE_FANS.Agenda
(
	[Matricula][int],
	[Cod_Grilla][int],
	[Activo][bit]
CONSTRAINT FK_Agena_Matricula FOREIGN KEY (Matricula) REFERENCES ORACLE_FANS.Profesionales(Matricula),
CONSTRAINT FK_Cod_Grilla FOREIGN KEY (Cod_Grilla) REFERENCES ORACLE_FANS.Grilla(Cod_Grilla)
);
GO		

--Creación de la Tabla Cartilla Medica
CREATE TABLE ORACLE_FANS.Cartilla_Medica
(
	[Cod_Cartilla][int] IDENTITY(1,1),
	[Matricula][int],
	[FechaInicio][DATETIME],
	[FechaFinal][DATETIME]
CONSTRAINT PK_Cod_Cartilla PRIMARY KEY (Cod_Cartilla),
CONSTRAINT FK_Cartilla_Medica_Matricula FOREIGN KEY (Matricula) REFERENCES ORACLE_FANS.Profesionales(Matricula)
);
GO

--Creación de la Tabla Historico_Planes_Medicos
CREATE TABLE ORACLE_FANS.Historico_Planes_Medicos
(
	[Cod_HistoricoPlanesMedicos][int] IDENTITY(1,1),
	[Cod_Afiliado][int],
	[Cod_PlanMedico_Nuevo][numeric](18),
	[Cod_PlanMedico_Anterior][numeric](18),
	[FechaModificacion][datetime],
	[Motivo][varchar](255)
CONSTRAINT PK_Cod_HistoricoPlanesMedicos PRIMARY KEY (Cod_HistoricoPlanesMedicos),
CONSTRAINT FK_Historico_Planes_Medico_Cod_Afiliado FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados(Cod_Afiliado),
CONSTRAINT FK_Historico_Planes_Medico_Cod_PlanMedico_Nuevo FOREIGN KEY (Cod_PlanMedico_Nuevo) REFERENCES ORACLE_FANS.Planes_Medicos(Cod_PlanMedico),
CONSTRAINT FK_Historico_Planes_Medico_Cod_Planmedico_Anterior FOREIGN KEY (Cod_PlanMedico_Anterior) REFERENCES ORACLE_FANS.Planes_Medicos(Cod_PlanMedico)
);
GO

--Creación de la Tabla Recetas
CREATE TABLE ORACLE_FANS.Recetas
(
	[Cod_Receta][int] IDENTITY (1,1),
	[Cod_Turno][numeric](18),
	[Numero_Bono_Farmacia][numeric](18)
CONSTRAINT PK_Cod_Receta_Recetas PRIMARY KEY (Cod_Receta),
CONSTRAINT FK_Cod_Turno_Recetas FOREIGN KEY (Cod_Turno) REFERENCES ORACLE_FANS.Turnos(Cod_Turno),
CONSTRAINT FK_Numero_Bono_Farmacia_Recetas FOREIGN KEY (Numero_Bono_Farmacia) REFERENCES ORACLE_FANS.Bono_Farmacia(Numero)  
);
GO

CREATE TABLE ORACLE_FANS.Medicamentos_Acomodados
(
	[Cod_Medicamento][int] IDENTITY(1,1) PRIMARY KEY,
	[Descripcion][varchar](255)
);
GO

--Creación de la tabla Medicamentos Recetados
CREATE TABLE ORACLE_FANS.MedicamentosRecetados
(
	[Cod_Receta][int],
	[Cod_Medicamento][int],
	[Prescripcion][datetime],
	[Cantidad][int]
CONSTRAINT FK_Cod_Receta_MedicamentosRecetados FOREIGN KEY (Cod_Receta) REFERENCES ORACLE_FANS.Recetas(Cod_Receta),
CONSTRAINT FK_Cod_Medicamento_MedicamentosRecetados FOREIGN KEY (Cod_Medicamento) REFERENCES ORACLE_FANS.Medicamentos_Acomodados(Cod_Medicamento)

);
GO

--Creacion de la Tabla Turnos_Cancelados 
CREATE TABLE ORACLE_FANS.Turnos_Cancelados
(
	[Cod_Cancelacion][int] PRIMARY KEY IDENTITY(1,1),
	[Cod_Turno][numeric](18),
	[Tipo_Cancelacion][varchar](50),
	[Descripcion_Cancelacion][varchar](255),
	[Rol_Cancelacion][char],
	[Fecha_Cancelacion][datetime]
CONSTRAINT FK_Cod_Turno_Turnos_Cancelados FOREIGN KEY (Cod_Turno) REFERENCES ORACLE_FANS.Turnos(Cod_Turno)
);
GO



CREATE TABLE ORACLE_FANS.Compras_Realizadas
(
	[Cod_Compra][int] PRIMARY KEY IDENTITY(1,1),
	[Tipo_Bono][char],
	[Cod_Afiliado][int],
	[Cantidad_Bonos_Compra][int],
	[Importe_Compra][int],
	[Fecha_Compra][datetime]
CONSTRAINT FK_Cod_Afiliado_Compras_Realizadas FOREIGN KEY (Cod_Afiliado) REFERENCES ORACLE_FANS.Afiliados (Cod_Afiliado)
);

			/*FIN DE LA CREACION DE TABLAS*/





			/*INICIO MIGRACIÓN*/


--Llenado de la tabla de Roles 

INSERT INTO ORACLE_FANS.Roles (nombre,isActive) VALUES ('Afiliado',1)
GO
INSERT INTO ORACLE_FANS.Roles (nombre,isActive) VALUES ('Administrativo',1)
GO
INSERT INTO ORACLE_FANS.Roles (nombre,isActive) VALUES ('Profesional',1)
GO

--Llenado de Funcionalidades
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (1,'Abm rol')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (2,'Registro de Usuario')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (3,'Abm Afiliado')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (4,'Abm Profesional')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (5,'Abm Especialidades Medicas')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (6,'Abm de Planes')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (7,'Registrar agenda del médico')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (8,'Compra de bonos')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (9,'Pedir Turno')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (10,'Registro de llegada para atención médica')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (11,'Registrar  resultado para atención médica')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (12,'Cancelar atención médica [Afiliado]')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (13,'Cancelar atención médica [Profesional]')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (14,'Generar Receta ')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (15,'Listado estadístico')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (16,'Compra Bono Consulta [Afiliado]')
GO
INSERT INTO ORACLE_FANS.Funcionalidades (id_funcionalidad,descripcion) VALUES (17,'Compra Bono Farmacia [Afiliado]')
GO

/*Llenado la tabla Planes_Medicos*/
INSERT 
INTO ORACLE_FANS.Planes_Medicos
SELECT Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra
GROUP BY Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia 
ORDER BY Plan_Med_Codigo ASC

/*Llenado de la tabla Afiliados*/
INSERT INTO ORACLE_FANS.Afiliados (Cod_Afiliado,Cod_PlanMedico,Nombre,Apellido,Numero_Documento,Direccion,Telefono,Mail,Fecha_Nac,Activo)
	SELECT DISTINCT ROW_NUMBER() OVER (order by M.Paciente_DNI) * 100 + 1 ,Plan_Med_Codigo,Paciente_Nombre,Paciente_Apellido,Paciente_Dni,Paciente_Direccion,Paciente_Telefono,Paciente_Mail,Paciente_Fecha_Nac,1
	FROM gd_esquema.Maestra M
	GROUP BY Plan_Med_Codigo,Paciente_Nombre,Paciente_Apellido,Paciente_Dni,Paciente_Direccion,Paciente_Telefono,Paciente_Mail,Paciente_Fecha_Nac
	ORDER BY 1




/*Llenado de la tabla Tipo_Especialidad*/
INSERT
INTO ORACLE_FANS.Tipo_Especialidad
select Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion
from gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL
GROUP BY Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion
ORDER BY Tipo_Especialidad_Codigo ASC,Tipo_Especialidad_Descripcion ASC



/*Llenado de la tabla Especialidad*/
INSERT 
INTO ORACLE_FANS.Especialidades (Cod_Especialidad,Cod_Tipo_Especialidad,Descripcion)
SELECT Especialidad_Codigo,Tipo_Especialidad_Codigo,Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL
GROUP BY Especialidad_Codigo,Tipo_Especialidad_Codigo,Especialidad_Descripcion
ORDER BY Especialidad_Codigo ASC,Tipo_Especialidad_Codigo ASC,Especialidad_Descripcion ASC


/*Llenado de la tabla Profesionales*/
INSERT 
INTO ORACLE_FANS.Profesionales (Matricula,Nombre, Apellido, Numero_documento, Direccion, Telefono, Mail, Fecha_Nac, Activo)
SELECT DISTINCT ROW_NUMBER() OVER (order by M.Medico_DNI),Medico_Nombre,Medico_Apellido,Medico_Dni,Medico_Direccion,Medico_Telefono,Medico_Mail,Medico_Fecha_Nac, 1
FROM gd_esquema.Maestra as M
WHERE Medico_Nombre IS NOT NULL
GROUP BY Medico_Nombre,Medico_Apellido,Medico_Dni,Medico_Direccion,Medico_Telefono,Medico_Mail,Medico_Fecha_Nac
ORDER BY Medico_Nombre ASC, Medico_Apellido ASC

/* Llenado de la tabla de Medico_Especialidad */
INSERT
INTO ORACLE_FANS.Medico_Especialidad
SELECT DISTINCT M.Especialidad_Codigo, P.Matricula
FROM ORACLE_FANS.Profesionales P
JOIN gd_esquema.Maestra M on P.Numero_Documento = M.Medico_Dni
ORDER BY M.Especialidad_Codigo

--Llenado de la tabla de Usuarios
INSERT 
INTO ORACLE_FANS.Usuarios
(id_Rol, username, password, intentosLogin,habilitado)
VALUES(2, 'admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 3, 1)
--w23e encriptado en SHA256 es e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7

	INSERT INTO ORACLE_FANS.Usuarios
	SELECT 1,Numero_Documento,'280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02',3,1
	FROM ORACLE_FANS.Afiliados
--welcome encriptado en SHA256 es 280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02
	INSERT INTO ORACLE_FANS.Usuarios
	SELECT 3,Numero_Documento,'280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02',3,1
	FROM ORACLE_FANS.Profesionales
--welcome encriptado en SHA256 es 280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02


/*Llenado de la tabla de Bono_Farmacia*/

INSERT 
INTO ORACLE_FANS.Bono_Farmacia (Cod_Afiliado,Cod_PlanMedico,Fecha_Impresion,Fecha_Vencimiento,Activo)
select DISTINCT A.Cod_Afiliado,A.Cod_PlanMedico,Bono_Farmacia_Fecha_Impresion,Bono_Farmacia_Fecha_Vencimiento,0
from gd_esquema.Maestra as M
join ORACLE_FANS.Afiliados as A ON A.Numero_Documento=M.Paciente_Dni
WHERE M.Bono_Farmacia_Numero IS NOT NULL AND M.bono_Farmacia_Medicamento IS NOT NULL AND M.Compra_Bono_Fecha IS NULL


/*Llenado de la tabla de Bono_Consulta*/

INSERT 
INTO ORACLE_FANS.Bono_Consulta (Numero,Cod_Afiliado,Numero_Consulta,Fecha_Impresion,Activo,Cod_PlanMedico)
select DISTINCT M.Bono_Consulta_Numero,Cod_Afiliado,COUNT(Cod_Afiliado) as C, M.Bono_Consulta_Fecha_Impresion,0,M.Plan_Med_Codigo
from gd_esquema.Maestra as M
join ORACLE_FANS.Afiliados AS A ON A.Numero_Documento=M.Paciente_Dni
WHERE Bono_Consulta_Numero IS NOT NULL AND Turno_Numero IS NOT NULL
GROUP BY  M.Bono_Consulta_Numero,Cod_Afiliado, M.Bono_Consulta_Fecha_Impresion,M.Plan_Med_Codigo
ORDER BY M.Bono_Consulta_Numero ASC


/*LLenado de la tabla Turnos*/

INSERT 
INTO ORACLE_FANS.Turnos (Cod_Turno,Matricula,Cod_Especialidad,Cod_Afiliado,Fecha,habilitado)
select DISTINCT M.Turno_Numero,P.Matricula,M.Especialidad_Codigo,A.Cod_Afiliado,M.Turno_Fecha,0
from gd_esquema.Maestra AS M
JOIN ORACLE_FANS.Profesionales AS P ON M.Medico_Dni=P.Numero_Documento
JOIN ORACLE_FANS.Afiliados AS A ON A.Numero_Documento=M.Paciente_Dni
WHERE M.Turno_Numero IS NOT NULL
ORDER BY P.Matricula ASC

/*Llenado de la tabla Consulta*/
	
INSERT 
INTO ORACLE_FANS.Consultas
select DISTINCT T.Cod_Turno,BC.Numero,A.Cod_Afiliado,M.Consulta_Sintomas,M.Consulta_Enfermedades
from gd_esquema.Maestra as M
JOIN ORACLE_FANS.Afiliados as A ON M.Paciente_Dni=A.Numero_Documento
JOIN ORACLE_FANS.Bono_Consulta as BC ON A.Cod_Afiliado=BC.Cod_Afiliado
JOIN ORACLE_FANS.Turnos as T ON A.Cod_Afiliado=T.Cod_Afiliado
WHERE M.Turno_Numero IS NOT NULL AND M.Bono_Consulta_Numero IS NOT NULL
ORDER BY A.Cod_Afiliado ASC



/*Llenado de la tabla Grilla*/
INSERT INTO ORACLE_FANS.Grilla VALUES ( 100, 1, '07:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 101, 1, '07:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 102, 1, '08:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 103, 1, '08:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 104, 1, '09:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 105, 1, '09:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 106, 1, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 107, 1, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 108, 1, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 109, 1, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 110, 1, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 111, 1, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 112, 1, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 113, 1, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 114, 1, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 115, 1, '14:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 116, 1, '15:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 117, 1, '15:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 118, 1, '16:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 119, 1, '16:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 120, 1, '17:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 121, 1, '17:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 122, 1, '18:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 123, 1, '18:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 124, 1, '19:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 125, 1, '19:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 200, 2, '07:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 201, 2, '07:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 202, 2, '08:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 203, 2, '08:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 204, 2, '09:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 205, 2, '09:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 206, 2, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 207, 2, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 208, 2, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 209, 2, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 210, 2, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 211, 2, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 212, 2, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 213, 2, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 214, 2, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 215, 2, '14:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 216, 2, '15:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 217, 2, '15:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 218, 2, '16:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 219, 2, '16:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 220, 2, '17:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 221, 2, '17:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 222, 2, '18:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 223, 2, '18:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 224, 2, '19:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 225, 2, '19:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 300, 3, '07:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 301, 3, '07:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 302, 3, '08:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 303, 3, '08:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 304, 3, '09:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 305, 3, '09:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 306, 3, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 307, 3, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 308, 3, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 309, 3, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 310, 3, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 311, 3, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 312, 3, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 313, 3, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 314, 3, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 315, 3, '14:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 316, 3, '15:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 317, 3, '15:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 318, 3, '16:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 319, 3, '16:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 320, 3, '17:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 321, 3, '17:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 322, 3, '18:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 323, 3, '18:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 324, 3, '19:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 325, 3, '19:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 400, 4, '07:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 401, 4, '07:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 402, 4, '08:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 403, 4, '08:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 404, 4, '09:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 405, 4, '09:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 406, 4, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 407, 4, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 408, 4, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 409, 4, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 410, 4, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 411, 4, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 412, 4, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 413, 4, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 414, 4, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 415, 4, '14:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 416, 4, '15:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 417, 4, '15:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 418, 4, '16:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 419, 4, '16:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 420, 4, '17:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 421, 4, '17:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 422, 4, '18:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 423, 4, '18:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 424, 4, '19:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 425, 4, '19:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 500, 5, '07:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 501, 5, '07:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 502, 5, '08:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 503, 5, '08:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 504, 5, '09:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 505, 5, '09:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 506, 5, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 507, 5, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 508, 5, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 509, 5, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 510, 5, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 511, 5, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 512, 5, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 513, 5, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 514, 5, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 515, 5, '14:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 516, 5, '15:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 517, 5, '15:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 518, 5, '16:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 519, 5, '16:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 520, 5, '17:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 521, 5, '17:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 522, 5, '18:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 523, 5, '18:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 524, 5, '19:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 525, 5, '19:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 606, 6, '10:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 607, 6, '10:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 608, 6, '11:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 609, 6, '11:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 610, 6, '12:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 611, 6, '12:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 612, 6, '13:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 613, 6, '13:30', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 614, 6, '14:00', 1 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 615, 6, '14:30', 1 );

INSERT INTO ORACLE_FANS.Grilla VALUES ( 700, 7, '07:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 701, 7, '07:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 702, 7, '08:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 703, 7, '08:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 704, 7, '09:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 705, 7, '09:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 706, 7, '10:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 707, 7, '10:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 708, 7, '11:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 709, 7, '11:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 710, 7, '12:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 711, 7, '12:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 712, 7, '13:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 713, 7, '13:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 714, 7, '14:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 715, 7, '14:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 716, 7, '15:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 717, 7, '15:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 718, 7, '16:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 719, 7, '16:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 720, 7, '17:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 721, 7, '17:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 722, 7, '18:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 723, 7, '18:30', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 724, 7, '19:00', 0 );
INSERT INTO ORACLE_FANS.Grilla VALUES ( 725, 7, '19:30', 0 );


/*LLenado de la tabla: Roles_Funcionalidad*/
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (1,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (2,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (3,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (4,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (5,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (6,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (7,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (8,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (9,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (10,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (11,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (12,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (13,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (14,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (15,2)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (8,1)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (9,1)
GO
INSERT
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (16,1)
GO
INSERT
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (17,1)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (7,3)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (11,3)
GO
INSERT 
INTO ORACLE_FANS.Roles_Funcionalidad (id_Funcionalidad,id_Rol) VALUES (13,3)
GO





/*LLenado de la tabla Agenda*/
	INSERT INTO ORACLE_FANS.Agenda (Matricula,Cod_Grilla,Activo)
	SELECT DISTINCT P.Matricula, G.Cod_Grilla,1
	FROM ORACLE_FANS.Grilla G, ORACLE_FANS.Turnos T, ORACLE_FANS.Profesionales P
	WHERE P.Matricula = T.Matricula
	AND G.Dia = DATEPART(WEEKDAY,T.Fecha)
	AND DATEPART(HH,G.Hora) = DATEPART(HH,T.Fecha)
	AND DATEPART(MINUTE,G.Hora) = DATEPART(MINUTE,T.Fecha)
	ORDER BY 1,2
GO


/*LLenado de la tabla CartillaMedica*/	
INSERT INTO ORACLE_FANS.Cartilla_Medica (Matricula,FechaInicio,FechaFinal)
	SELECT Matricula, Min(CAST(Fecha AS date)) AS FechaMin, Max(CAST(Fecha AS date)) AS FechaMax FROM ORACLE_FANS.Turnos
	GROUP BY Matricula
	ORDER BY 1
GO


/*Llenado de la tabla Compras_Realizadas*/
INSERT INTO 
ORACLE_FANS.Compras_Realizadas (Cod_Afiliado,Tipo_Bono,Cantidad_Bonos_Compra,Importe_Compra,Fecha_Compra)
SELECT DISTINCT BC.Cod_Afiliado,'c' as Tipo,COUNT(*) as Cantidad,COUNT(*)*PM.Precio_Bono_Consulta as Importe,BC.Fecha_Impresion
FROM ORACLE_FANS.Bono_Consulta as BC
JOIN ORACLE_FANS.Planes_Medicos as PM ON BC.Cod_PlanMedico=PM.Cod_PlanMedico
GROUP BY BC.Cod_Afiliado,PM.Precio_Bono_Consulta,BC.Fecha_Impresion
ORDER BY BC.Cod_Afiliado ASC

INSERT INTO 
ORACLE_FANS.Compras_Realizadas (Cod_Afiliado,Tipo_Bono,Cantidad_Bonos_Compra,Importe_Compra,Fecha_Compra)
SELECT DISTINCT BF.Cod_Afiliado,'f' as Tipo,COUNT(*) as Cantidad,COUNT(*)*PM.Precio_Bono_Farmacia as Importe,BF.Fecha_Impresion
FROM ORACLE_FANS.Bono_Farmacia as BF
JOIN ORACLE_FANS.Planes_Medicos as PM ON PM.Cod_PlanMedico=BF.Cod_PlanMedico
GROUP BY BF.Cod_Afiliado,PM.Precio_Bono_Farmacia,BF.Fecha_Impresion
ORDER BY BF.Cod_Afiliado ASC
GO

/*Llenado de la tabla Recetas*/

INSERT INTO 
ORACLE_FANS.Recetas (Cod_Turno,Numero_Bono_Farmacia)
SELECT T.Cod_Turno, BF.Numero
FROM ORACLE_FANS.Bono_Farmacia BF, ORACLE_FANS.Turnos T, gd_esquema.Maestra M
WHERE BF.Numero = M.Bono_Farmacia_Numero
AND T.Cod_Turno = M.Turno_Numero
ORDER BY T.Cod_Turno

									/*FIN DE MIGRACIONES*/		
								
								
							/* INICIO DE CREACION DE STORE PROCEDURES */
GO

CREATE PROCEDURE ORACLE_FANS.proc_login 
(@user_name varchar(10))
AS

	SELECT username, habilitado as estado, intentosLogin as usuario_intentos_fallidos, password, id_Rol
	FROM ORACLE_FANS.Usuarios
	WHERE username = @user_name

GO

CREATE PROCEDURE ORACLE_FANS.intentos_Fallidos
(@user_name varchar(10))
AS 

	UPDATE ORACLE_FANS.Usuarios
	SET intentosLogin=intentosLogin-1
	RETURN 1
GO
		

CREATE PROCEDURE ORACLE_FANS.agregar_Un_Rol (@unRol varchar(50)) As 

	IF NOT EXISTS( SELECT 1 FROM ORACLE_FANS.ROLES WHERE Nombre = @unRol )
		BEGIN
			INSERT INTO ORACLE_FANS.Roles 
				(Nombre, isActive )
			VALUES
				(@unRol, 1)
		
			return @@IDENTITY
		END
	ELSE
		BEGIN
			RAISERROR('Rol existente',16,1)
		END
GO

	
CREATE PROCEDURE ORACLE_FANS.agregar_Una_Funcionalidad (@id_Funcionalidad int ,@id_Rol int) AS

	IF NOT EXISTS ( SELECT 1 FROM ORACLE_FANS.Funcionalidades WHERE id_funcionalidad = @id_Funcionalidad )
		BEGIN
			RAISERROR('Funcionalidad Inexistente', 16, 1)
		END
	ELSE	
		BEGIN
			IF EXISTS ( SELECT 1 FROM ORACLE_FANS.Roles_Funcionalidad 
						WHERE id_Funcionalidad = @id_Funcionalidad
						AND id_Rol = @id_Rol )
				BEGIN
					RAISERROR('Funcionalidad-Rol Repetida', 16, 1)
				END
			ELSE
				BEGIN
					INSERT INTO ORACLE_FANS.Roles_Funcionalidad ( id_Funcionalidad, id_Rol )
					VALUES ( @id_Funcionalidad, @id_Rol )
				END
		END
GO


CREATE PROCEDURE ORACLE_FANS.modificar_NombreRol
(@nombre_Rol varchar(50),@id_Rol int)
AS

	DECLARE @mensaje_Error varchar(30)

	IF EXISTS(SELECT 1 FROM ORACLE_FANS.Roles WHERE id_Rol=@id_Rol)
		BEGIN 
			UPDATE ORACLE_FANS.Roles
			SET Nombre=@nombre_Rol
			WHERE id_Rol=@id_Rol
		END
	ELSE 
		BEGIN
			SET @mensaje_Error='El rol que se intenta modificar no existe.'
			RAISERROR(@mensaje_Error,16,1)
			RETURN -1
		END
GO				

CREATE PROCEDURE ORACLE_FANS.EliminarFuncionalidades(@id_Rol int) 
AS
DECLARE @mensaje_Error varchar(100)
	
	IF EXISTS (SELECT 1 FROM ORACLE_FANS.Roles_Funcionalidad WHERE id_Rol = @id_Rol)
		BEGIN	
			DELETE FROM ORACLE_FANS.Roles_Funcionalidad
			WHERE id_Rol = @id_Rol
			return 1
		END
	ELSE 
		BEGIN 
			SET @mensaje_Error='El rol al que le esta intentando eliminar sus funcionalidades no existe'
			RAISERROR (@mensaje_Error,16,1)
			RETURN -1
		END 
	
	
GO

	
CREATE PROCEDURE ORACLE_FANS.dar_BajaRol
(@id_Rol int)
AS
	DECLARE @mensaje_Error varchar(50)
	
	IF EXISTS(SELECT 1 FROM ORACLE_FANS.Roles WHERE id_Rol=@id_Rol)
	BEGIN 
		IF EXISTS(SELECT 1 FROM ORACLE_FANS.Roles WHERE id_Rol=@id_Rol AND isActive=1)
		BEGIN
			 UPDATE ORACLE_FANS.Roles
			 SET isActive=0
			 WHERE id_Rol=@id_Rol
			 RETURN 1
		END 
		ELSE
		BEGIN
			SET @mensaje_Error='El Rol ya esta dado de baja.'
			RAISERROR(@mensaje_Error,16,1)
			RETURN -1
		END
	END 
	ELSE 
	BEGIN
		SET @mensaje_Error='El rol que intenta dar de baja no existe.'
		RAISERROR(@mensaje_Error,16,1)
		RETURN -1 
	END 

GO

CREATE PROCEDURE ORACLE_FANS.modificarRol_HabilitarRol
(@id_Rol int)
AS
 
	DECLARE @mensaje_Error varchar(50)
	
		IF EXISTS(SELECT 1 FROM ORACLE_FANS.Roles WHERE id_Rol=@id_Rol)
		BEGIN 
			IF EXISTS (SELECT 1 FROM ORACLE_FANS.Roles WHERE id_Rol=@id_Rol AND isActive=0)
				BEGIN 
					UPDATE ORACLE_FANS.Roles
					SET isActive=1
					WHERE id_Rol=@id_Rol
					RETURN 1
				END
			ELSE 
				BEGIN 
					SET @mensaje_Error='El rol ya esta activo'
					RAISERROR (@mensaje_Error,16,1)
					RETURN -1
				END 
		END
		ELSE 
			BEGIN 
				SET @mensaje_Error='El rol que intenta Habilitar no existe.'
				RAISERROR (@mensaje_Error,16,1)
				RETURN -1
			END
	
GO

CREATE PROCEDURE ORACLE_FANS.modificar_Afiliado
(
@Cod_Afiliado int,
@Tipo_Documento varchar(6),
@Direccion varchar(255),
@Telefono numeric(18),
@Mail varchar(255),
@Sexo char,
@Estado_Civil varchar(15)
)
AS 
DECLARE @mensaje_Error varchar(100)

IF EXISTS (SELECT 1 FROM ORACLE_FANS.Afiliados WHERE Cod_Afiliado=@Cod_Afiliado)
	BEGIN 
		UPDATE ORACLE_FANS.Afiliados
		SET 
		Tipo_Documento=@Tipo_Documento,
		Direccion=@Direccion,
		Telefono=@Telefono,
		Mail=@Mail,
		Sexo=@Sexo,
		Estado_Civil=@Estado_Civil
	WHERE Cod_Afiliado=@Cod_Afiliado
	RETURN 1
	END
ELSE 
	BEGIN 
		SET @mensaje_Error='El Afiliado se esta intentando modificar no existe .'
		RAISERROR(@mensaje_Error,16,1)
		RETURN -1
	END
GO
	
CREATE PROCEDURE ORACLE_FANS.insertar_Historico
(
@Cod_Afiliado int,
@Cod_PlanMedico_Nuevo numeric(18),
@Cod_PlanMedico_Anterior numeric(18),
@FechaModificacion datetime,
@Motivo varchar(255)
)
AS
	DECLARE @Cod_Afiliado_Principal int
	DECLARE @CantFam int
	
	SET @Cod_Afiliado_Principal = @Cod_Afiliado / 100 * 100 + 1
	SET @CantFam = ( SELECT Cant_Familiares_A_Cargo FROM ORACLE_FANS.Afiliados
					 WHERE Cod_Afiliado = @Cod_Afiliado_Principal )
	
	IF @CantFam > 0
		BEGIN
			-- Insertar en Tabla Historico_Planes_Medicos
			INSERT
			INTO ORACLE_FANS.Historico_Planes_Medicos(Cod_Afiliado,Cod_PlanMedico_Nuevo,Cod_PlanMedico_Anterior,FechaModificacion,Motivo)
			VALUES(@Cod_Afiliado,@Cod_PlanMedico_Nuevo,@Cod_PlanMedico_Anterior,@FechaModificacion,@Motivo)
			
			-- Insertar en Tabla Historico_Planes_Medicos
			INSERT 	INTO ORACLE_FANS.Historico_Planes_Medicos
				SELECT Cod_Afiliado,@Cod_PlanMedico_Nuevo,@Cod_PlanMedico_Anterior,@FechaModificacion,'Modificacion en Afiliado Principal'
				FROM ORACLE_FANS.Afiliados
				WHERE Activo = 1
				AND Cod_Afiliado BETWEEN (@Cod_Afiliado_Principal + 1) AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
			
			-- Update Tabla Afiliados			
			UPDATE ORACLE_FANS.Afiliados
			SET Cod_PlanMedico = @Cod_PlanMedico_Nuevo
			WHERE Activo = 1
			AND Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
			
			-- Update Tabla Bono_Consulta
			UPDATE ORACLE_FANS.Bono_Consulta
			SET Activo = 0
			WHERE Cod_PlanMedico = @Cod_PlanMedico_Anterior	
			AND Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
			AND Activo = 1
			
			-- Update Tabla Bono_Farmacia
			UPDATE ORACLE_FANS.Bono_Farmacia
			SET Activo = 0
			WHERE Cod_PlanMedico = @Cod_PlanMedico_Anterior	
			AND Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
			AND Activo = 1
		END
	ELSE
		BEGIN
			-- Insertar en Tabla Historico_Planes_Medicos
			INSERT
			INTO ORACLE_FANS.Historico_Planes_Medicos(Cod_Afiliado,Cod_PlanMedico_Nuevo,Cod_PlanMedico_Anterior,FechaModificacion,Motivo)
			VALUES(@Cod_Afiliado,@Cod_PlanMedico_Nuevo,@Cod_PlanMedico_Anterior,@FechaModificacion,@Motivo)
			
			-- Update Tabla Afiliados
			UPDATE ORACLE_FANS.Afiliados
			SET Cod_PlanMedico = @Cod_PlanMedico_Nuevo
			WHERE Cod_Afiliado =  @Cod_Afiliado
			
			-- Update Tabla Bono_Consulta
			UPDATE ORACLE_FANS.Bono_Consulta
			SET Activo = 0
			WHERE Cod_PlanMedico = @Cod_PlanMedico_Anterior	
			AND Cod_Afiliado =  @Cod_Afiliado
			AND Activo = 1
			
			-- Update Tabla Bono_Farmacia
			UPDATE ORACLE_FANS.Bono_Farmacia
			SET Activo = 0
			WHERE Cod_PlanMedico = @Cod_PlanMedico_Anterior	
			AND Cod_Afiliado =  @Cod_Afiliado
			AND Activo = 1
		END
GO

CREATE PROCEDURE ORACLE_FANS.baja_Afiliado
(@Cod_Afiliado int, @Fecha_Baja datetime)
AS
	DECLARE @mensaje_Error varchar(50)
	DECLARE @Cod_Afiliado_Principal int
	DECLARE @CantFam int
	
	SET @Cod_Afiliado_Principal = @Cod_Afiliado / 100 * 100 + 1
	SET @CantFam = ( SELECT Cant_Familiares_A_Cargo FROM ORACLE_FANS.Afiliados
					 WHERE Cod_Afiliado = @Cod_Afiliado_Principal )
	
	IF EXISTS(SELECT 1 FROM ORACLE_FANS.Afiliados WHERE Cod_Afiliado=@Cod_Afiliado)
		BEGIN 
			IF @Cod_Afiliado = @Cod_Afiliado_Principal
				BEGIN		
					-- Dar de Bajar todo el grupo Familiar
					UPDATE ORACLE_FANS.Afiliados
					SET 
					Activo=0,
					Fecha_Baja=@Fecha_Baja,
					Cant_Familiares_A_Cargo = 0
					WHERE Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
					
					-- Dar de Bajar todos los turnos del grupo familiar
					UPDATE ORACLE_FANS.Turnos
					SET
					habilitado=0
					WHERE Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
					AND habilitado = 1
					
					-- Dar de Bajar todos los Bonos Consulta del grupo familiar
					UPDATE ORACLE_FANS.Bono_Consulta
					SET Activo=0
					WHERE Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100
					AND Activo=1
					
					-- Dar de Bajar todos los Bonos Farmacia del grupo familiar
					UPDATE ORACLE_FANS.Bono_Farmacia
					SET Activo=0
					WHERE Cod_Afiliado=@Cod_Afiliado
					AND Activo=1
					
					-- Dar de Bajar todos los Usuarios del grupo familiar
					UPDATE ORACLE_FANS.Usuarios
					SET 
					habilitado = 0
					WHERE username IN ( SELECT CAST(Numero_Documento AS VARCHAR) FROM ORACLE_FANS.Afiliados
									    WHERE Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100 )
				END
			ELSE
				BEGIN
					-- Dar de Bajar todo el Familiar
					UPDATE ORACLE_FANS.Afiliados
					SET 
					Activo=0,
					Fecha_Baja=@Fecha_Baja
					WHERE Cod_Afiliado = @Cod_Afiliado
					
					-- Disminuir la cantidad de familiares 
					UPDATE ORACLE_FANS.Afiliados
					SET 
					Cant_Familiares_A_Cargo=@CantFam - 1
					WHERE Cod_Afiliado = @Cod_Afiliado_Principal
					
					-- Dar de Baja los turnos
					UPDATE ORACLE_FANS.Turnos
					SET
					habilitado=0
					WHERE Cod_Afiliado BETWEEN @Cod_Afiliado_Principal AND ( @Cod_Afiliado_Principal / 100 + 1 ) * 100	
					AND habilitado = 1
					
					-- Dar de Bajar todos los Usuario
					UPDATE ORACLE_FANS.Usuarios
					SET 
					habilitado = 0
					WHERE username = ( SELECT CAST(Numero_Documento AS VARCHAR) FROM ORACLE_FANS.Afiliados
									   WHERE Cod_Afiliado = @Cod_Afiliado )
				END
			RETURN 0	
		END
	ELSE 
		BEGIN 
		SET @mensaje_Error='El Afiliado que se esta intentando dar de baja no existe.'
		RAISERROR(@mensaje_Error,16,1)
		RETURN -1
		END 
GO


CREATE PROCEDURE ORACLE_FANS.alta_Afiliado
(
@Cod_PlanMedico numeric(18),
@Nombre varchar(255),
@Apellido varchar(255),
@Tipo_Documento varchar(6),
@Numero_Documento numeric(18),
@Direccion varchar(255),
@Telefono numeric(18),
@Mail varchar(255),
@Fecha_Nac datetime,
@Sexo char,
@Estado_Civil varchar(15)
)
AS 
DECLARE @cod_afiliado int

SET @cod_afiliado = (SELECT TOP 1 (ROW_NUMBER() OVER (order by A.Cod_Afiliado) + 1) * 100 + 1
							 FROM ORACLE_FANS.Afiliados A order by A.Cod_Afiliado DESC)

IF NOT EXISTS(SELECT 1 FROM ORACLE_FANS.Afiliados WHERE Numero_Documento=@Numero_Documento)
	BEGIN	
		INSERT INTO 
		ORACLE_FANS.Afiliados (Cod_Afiliado,Cod_PlanMedico, Nombre,Apellido,Tipo_Documento,Numero_Documento,Direccion,Telefono,Mail,Fecha_Nac,Sexo,Estado_Civil,Cant_Familiares_A_Cargo,Activo)
		VALUES (@cod_afiliado,@Cod_PlanMedico,@Nombre,@Apellido,@Tipo_Documento,@Numero_Documento,@Direccion,@Telefono,@Mail,@Fecha_Nac,@Sexo,@Estado_Civil,0,1)
		return @cod_afiliado
	END
ELSE
	RAISERROR('DNI Existente - Posible Afiliado Repetido',16,1)
	RETURN -1
GO


CREATE FUNCTION ORACLE_FANS.sacaDigito
(@Cod_Afiliado numeric(18))
RETURNS numeric(18)
AS
BEGIN 
	DECLARE @Cod_AfiliadoSinDigito numeric(18)
	SET @Cod_AfiliadoSinDigito=FLOOR(@Cod_Afiliado/100)
	RETURN @Cod_AfiliadoSinDigito
END
GO


CREATE PROCEDURE ORACLE_FANS.Alta_Familiar
(
	@Cod_afiliado numeric(18),
	@Cod_PlanMedico numeric(18),
	@Nombre varchar(255),
	@Apellido varchar(255),
	@Tipo_Documento varchar(6),
	@Numero_Documento numeric(18),
	@Direccion varchar(255),
	@Telefono numeric(18),
	@Mail varchar(255),
	@Fecha_Nac datetime,
	@Sexo char,
	@Estado_Civil varchar(15)
)
AS 		
 		DECLARE @numero int
 		DECLARE @Cod_Afiliado_Principal int
 		DECLARE @cant_familiares int
 		
 		SET @numero = ( SELECT TOP 1 Cod_Afiliado % 100 FROM ORACLE_FANS.Afiliados
 						WHERE Cod_Afiliado BETWEEN ( @Cod_afiliado / 100 ) * 100  AND ( @Cod_afiliado / 100 + 1 ) * 100
 						ORDER BY 1 DESC )
				
		SET @cant_familiares = ( SELECT Cant_Familiares_A_Cargo FROM ORACLE_FANS.Afiliados
								 WHERE Cod_Afiliado = @Cod_Afiliado )
			 					
 		IF NOT EXISTS(SELECT 1 FROM ORACLE_FANS.Afiliados WHERE Numero_Documento=@Numero_Documento)
			BEGIN	
 				INSERT INTO 
 				ORACLE_FANS.Afiliados (Cod_Afiliado,Cod_PlanMedico, Nombre,Apellido,Tipo_Documento,Numero_Documento,Direccion,Telefono,Mail,Fecha_Nac,Sexo,Estado_Civil,Cant_Familiares_A_Cargo,Activo)
				VALUES (@Cod_afiliado + @numero,@Cod_PlanMedico,@Nombre,@Apellido,@Tipo_Documento,@Numero_Documento,@Direccion,@Telefono,@Mail,@Fecha_Nac,@Sexo,@Estado_Civil,0,1)
				
				UPDATE ORACLE_FANS.Afiliados
				SET Cant_Familiares_A_Cargo = @cant_familiares + 1 
				WHERE Cod_Afiliado = @Cod_afiliado
				
				return @cod_afiliado + @numero
			END
		ELSE
			RAISERROR('DNI Existente - Posible Afiliado Repetido',16,1)
			RETURN -1
GO


CREATE PROCEDURE ORACLE_FANS.bajaBono
(
	@tipoBono char,
	@Numero numeric(18),
	@Cod_Afiliado numeric(18)
)
AS
DECLARE @mensaje_Error varchar(50)

	IF @tipoBono='c' 
		BEGIN 
			IF EXISTS (SELECT 1 FROM ORACLE_FANS.Bono_Consulta WHERE Cod_Afiliado=@Cod_Afiliado AND Numero=@Numero)
			BEGIN
				UPDATE ORACLE_FANS.Bono_Consulta
				SET Activo=0
				WHERE  Cod_Afiliado=@Cod_Afiliado AND Numero=@Numero
				RETURN 1
			END
			ELSE 
			BEGIN
				SET @mensaje_Error='El bono que intenta dar de baja no existe'
				RAISERROR(@mensaje_Error,16,1)
				RETURN -1
			END
	
		END
	IF @tipoBono='f' 
		BEGIN 
			IF EXISTS (SELECT 1 FROM ORACLE_FANS.Bono_Farmacia WHERE Cod_Afiliado=@Cod_Afiliado AND Numero=@Numero)
			BEGIN
				UPDATE ORACLE_FANS.Bono_Farmacia
				SET Activo=0
				WHERE  Cod_Afiliado=@Cod_Afiliado AND Numero=@Numero
				RETURN 1
			END
			ELSE 
			BEGIN
				SET @mensaje_Error='El bono que intenta dar de baja no existe'
				RAISERROR(@mensaje_Error,16,1)
				RETURN -1
			END
		END
GO


CREATE PROCEDURE ORACLE_FANS.darAltaBonoConsulta
(
	@Cod_PlanMedico numeric(18),
	@Cod_Afiliado int,
	@Fecha_Impresion datetime
)
AS 
	INSERT INTO ORACLE_FANS.Bono_Consulta (Numero,Cod_PlanMedico,Cod_Afiliado,Fecha_Impresion,Activo)
	select top 1 BC.Numero + 1,@Cod_PlanMedico,@Cod_Afiliado,@Fecha_Impresion,1
	FROM ORACLE_FANS.Bono_Consulta as BC
	order by BC.Numero desc
GO

CREATE PROCEDURE ORACLE_FANS.darAltaBonoFarmacia
(
	@Cod_PlanMedico numeric(18),
	@Cod_Afiliado int,
	@fec_imp datetime
)
AS
	INSERT INTO ORACLE_FANS.Bono_Farmacia(Cod_PlanMedico,Cod_Afiliado,Fecha_Impresion,Fecha_Vencimiento,Activo)
	VALUES (@Cod_PlanMedico,@Cod_Afiliado,@fec_imp,@fec_imp+60,1)
GO


CREATE PROCEDURE ORACLE_FANS.modificarProfesional
(
	@Matricula int,
	@Nombre varchar(255),
	@Apellido varchar(255),
	@Tipo_Documento varchar(6),
	@Direccion varchar(255),
	@Telefono numeric(18),
	@Mail varchar(255),
	@Sexo char
)
AS
DECLARE @mensajeError varchar(60)
	
	IF EXISTS(SELECT 1 FROM ORACLE_FANS.Profesionales WHERE Matricula=@Matricula)
		BEGIN 
			UPDATE ORACLE_FANS.Profesionales
			SET
			Nombre=@Nombre,
			Apellido=@Apellido,
			Tipo_Documento=@Tipo_Documento,
			Direccion=@Direccion,
			Telefono=@Telefono,
			Mail=@Mail,
			Sexo=@Sexo,
			Activo=1
			WHERE Matricula=@Matricula
			RETURN 1
		END
	ELSE 
		BEGIN 
			SET @mensajeError='El Profesional que esta intetando dar de alta no Existe'
			RAISERROR(@mensajeError,16,1)
			RETURN -1			
		END 
GO



CREATE PROCEDURE ORACLE_FANS.altaProfesional
(
	@Matricula int,
	@Nombre varchar(255),
	@Apellido varchar(255),
	@Tipo_Documento varchar(6),
	@Numero_Documento numeric(18),
	@Direccion varchar(255),
	@Telefono numeric(18),
	@Mail varchar(255),
	@Fecha_Nac datetime,
	@Sexo char
)
AS
DECLARE @mensajeError varchar(50)

	IF EXISTS(SELECT 1 FROM ORACLE_FANS.profesionales WHERE Matricula=@Matricula AND Numero_Documento=@Numero_Documento)
		BEGIN
			SET @mensajeError='El profesional que intenta dar de alta ya existe'
			RAISERROR(@mensajeError,16,1)
			RETURN -1
	
		END 
			INSERT
			INTO ORACLE_FANS.Profesionales 
			(Matricula,Nombre,Apellido,Tipo_Documento,Numero_Documento,Direccion,Telefono,Mail,Fecha_Nac,Sexo,Activo)
			VALUES (@Matricula,@Nombre,@Apellido,@Tipo_Documento,@Numero_Documento,@Direccion,@Telefono,@Mail,@Fecha_Nac,@Sexo,1)
			RETURN 1

GO


CREATE PROCEDURE ORACLE_FANS.crearReceta
(
	@num_bono numeric(18),
	@Cod_Turno numeric(18)
)
AS
DECLARE @mensajeError varchar(60),
		@Cod_Afiliado int,
		@Cod_Receta int,
		@Cod_Medicamento numeric
		
SET @Cod_Afiliado=(SELECT Cod_Afiliado FROM ORACLE_FANS.Bono_Farmacia WHERE Numero=@num_bono)
	
IF EXISTS(SELECT 1 FROM ORACLE_FANS.Afiliados WHERE Cod_Afiliado=@Cod_Afiliado)
	BEGIN
		INSERT 
		INTO ORACLE_FANS.Recetas (Cod_Receta,Cod_Turno,Numero_Bono_Farmacia)
		VALUES (@Cod_Afiliado,@Cod_Turno,@num_bono)

	END 
ELSE 
	BEGIN 
		SET @mensajeError='El afiliado al que quiere asociar una receta no existe'
		RAISERROR(@mensajeError,16,1)
		RETURN -1
	END 


GO


CREATE PROCEDURE ORACLE_FANS.medicamentosRecetadosP
(
	@nom_med varchar(255),
	@cant_med int, 
	@pres_med datetime,
	@cod_turno int
)
AS 
DECLARE @Cod_Medicamento numeric
DECLARE @Cod_Receta int

SET @Cod_Medicamento=(select Cod_Medicamento FROM ORACLE_FANS.Medicamentos_Acomodados WHERE Descripcion=@nom_med)
SET @Cod_Receta = (SELECT Cod_Receta FROM ORACLE_FANS.Recetas WHERE Cod_Turno = @cod_turno)

IF EXISTS (SELECT 1 FROM ORACLE_FANS.Medicamentos_Acomodados WHERE Descripcion=@nom_med)
	BEGIN 
		INSERT INTO
		ORACLE_FANS.MedicamentosRecetados(Cod_Receta,Cod_Medicamento,Prescripcion,Cantidad)
		VALUES (@Cod_Receta,@Cod_Medicamento,@pres_med,@cant_med)
	END

GO

CREATE PROCEDURE ORACLE_FANS.deshabilitarUsuario
(
	@idUsuario int 
)
AS
DECLARE @mensajeError varchar(60)

IF EXISTS(SELECT 1 FROM ORACLE_FANS.Usuarios WHERE idUsuario=@idUsuario)
	BEGIN 
		UPDATE ORACLE_FANS.Usuarios
		SET habilitado=0
		WHERE idUsuario=@idUsuario
		RETURN 1
	END 
ELSE 
	BEGIN 
		SET @mensajeError='El usuario que esta intentando dar de baja no existe'
		RAISERROR(@mensajeError,16,1)
		RETURN -1
	END

GO


CREATE PROCEDURE ORACLE_FANS.Bajar_CantFamiliares ( 
@cod_afiliado int,
@numero_orden int
)
AS
	DECLARE @cod_afiliado_pcpal int
	DECLARE @cant_familiares int
		
		
	SET @cod_afiliado_pcpal = ( SELECT ( @cod_afiliado / 100 ) * 100 + 1 FROM ORACLE_FANS.Afiliados
								WHERE Cod_Afiliado = @cod_afiliado )
								
	SET @cant_familiares = ( SELECT COUNT(Cod_Afiliado) - 1  FROM ORACLE_FANS.Afiliados
							 WHERE Cod_Afiliado BETWEEN @cod_afiliado_pcpal AND (@cod_afiliado_pcpal  + 10)
							 AND Activo = 1 )
							 
	UPDATE ORACLE_FANS.Afiliados
	SET Cant_Familiares_A_Cargo = @cant_familiares - @numero_orden
	WHERE Cod_Afiliado = @cod_afiliado_pcpal
GO

CREATE PROCEDURE ORACLE_FANS.baja_turnos
(@matricula int)
AS
UPDATE ORACLE_FANS.Turnos
SET habilitado = 0
WHERE Matricula = @matricula
GO

CREATE PROCEDURE ORACLE_FANS.baja_agenda
(@matricula int)
AS
UPDATE ORACLE_FANS.Agenda
SET Activo = 0
WHERE Matricula = @matricula
GO


CREATE PROCEDURE ORACLE_FANS.baja_profesional
(@mat int)
AS
UPDATE ORACLE_FANS.Profesionales
SET Activo = 0
WHERE Matricula = @mat
EXEC ORACLE_FANS.baja_turnos @mat
EXEC ORACLE_FANS.baja_agenda @mat
--Dar de baja su agenda y sus turnos
GO


CREATE PROCEDURE ORACLE_FANS.acomodarMedicamentos
AS

	--Creación de la Tabla Medicamentos Temporal
	CREATE TABLE ORACLE_FANS.Medicamentos
	(
		[Cod_Medicamento][numeric] IDENTITY(1,1) PRIMARY KEY,
		[Descripcion][varchar](255)
	)

	--Llenado de la Tabla Medicamentos
	INSERT INTO ORACLE_FANS.Medicamentos (Descripcion)
		SELECT DISTINCT Bono_Farmacia_Medicamento
		FROM gd_esquema.Maestra
		WHERE Bono_Farmacia_Medicamento IS NOT NULL
		ORDER BY 1

	DECLARE
		@contador int,
		@descripcion varchar(255),
		@separador1 int,
		@separador2 int,
		@separador3 int,
		@separador4 int,
		@med1 varchar(255),
		@med2 varchar(255),
		@med3 varchar(255),
		@med4 varchar(255),
		@med5 varchar(255)
	
	SET @contador = 1
	
	WHILE (@contador <> 590)
		BEGIN
		SET @descripcion = (SELECT Descripcion FROM ORACLE_FANS.Medicamentos WHERE Cod_Medicamento = @contador)
		SET @separador1 = ISNULL(CHARINDEX('+', @descripcion, 1), 0)
		SET @separador2 = ISNULL(CHARINDEX('+', @descripcion, @separador1 + 1), 0)
		SET @separador3 = ISNULL(CHARINDEX('+', @descripcion, @separador2 + 1), 0)
		SET @separador4 = ISNULL(CHARINDEX('+', @descripcion, @separador3 + 1), 0)
		IF (@separador1 <> 0)
		BEGIN
			SET @med1 = SUBSTRING(@descripcion, 1, @separador1 - 1)
			UPDATE ORACLE_FANS.Medicamentos
			SET Descripcion = @med1
			WHERE Cod_Medicamento = @contador
			IF (@separador2 <> 0)
			BEGIN
				SET @med2 = SUBSTRING(@descripcion, @separador1 + 1, @separador2 - @separador1 - 1)
				INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med2)
				IF (@separador3 <> 0)
				BEGIN
					SET @med3 = SUBSTRING(@descripcion, @separador2 + 1, @separador3 - @separador2 - 1)
					INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med3)
					IF (@separador4 <> 0)
					BEGIN
						SET @med4 = SUBSTRING(@descripcion, @separador3 + 1, @separador4 - @separador3 - 1)
						SET @med5 = SUBSTRING(@descripcion, @separador4 + 1, LEN(@descripcion) - @separador4 - 1)
						INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med4)
						INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med5)
					END
					ELSE
					BEGIN
						SET @med4 = SUBSTRING(@descripcion, @separador3 + 1, LEN(@descripcion) - @separador3 - 1)
						INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med4)
					END
				END
				ELSE
				BEGIN
					SET @med3 = SUBSTRING(@descripcion, @separador2 + 1, LEN(@descripcion) - @separador2 - 1)
					INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med3)
				END
			END
			ELSE
			BEGIN
				SET @med2 = SUBSTRING(@descripcion, @separador1 + 1, LEN(@descripcion) - @separador1 - 1)
				INSERT INTO ORACLE_FANS.Medicamentos (Descripcion) VALUES (@med2)		
			END
		END
		SET @contador = @contador + 1
	END
	
	INSERT INTO ORACLE_FANS.Medicamentos_Acomodados
	SELECT DISTINCT RTRIM(LTRIM(Descripcion)) FROM ORACLE_FANS.Medicamentos
GO

EXEC ORACLE_FANS.acomodarMedicamentos
DROP TABLE ORACLE_FANS.Medicamentos
GO

CREATE PROCEDURE ORACLE_FANS.MigrarMedicamentosRecetados
AS
	INSERT INTO ORACLE_FANS.MedicamentosRecetados
		SELECT R.Cod_Receta, M.Cod_Medicamento, NULL, 1
		FROM ORACLE_FANS.Recetas R, ORACLE_FANS.Medicamentos_Acomodados M, gd_esquema.Maestra Ma
		WHERE Ma.Bono_Farmacia_Numero IS NOT NULL
		AND Ma.Bono_Farmacia_Medicamento IS NOT NULL
		AND R.Numero_Bono_Farmacia = Ma.Bono_Farmacia_Numero
		AND Ma.Bono_Farmacia_Medicamento LIKE '%'+M.Descripcion+'%'
GO

EXEC ORACLE_FANS.MigrarMedicamentosRecetados
GO

CREATE PROCEDURE ORACLE_FANS.BajarTurnoAfiliado
(
	@Cod_Afiliado int,
	@Cod_Turno numeric(18)
)
AS 
DECLARE @mensajeError varchar(60)

IF EXISTS (SELECT 1 FROM ORACLE_FANS.Turnos WHERE Cod_Afiliado=@Cod_Afiliado AND Cod_Turno=@Cod_Turno)
	BEGIN
		UPDATE ORACLE_FANS.Turnos
		SET habilitado=0
		WHERE Cod_Turno=@Cod_Turno AND Cod_Afiliado=@Cod_Afiliado
		RETURN 1
	END  
ELSE 
	BEGIN 
		SET @mensajeError='El Turno que quiere dar de baja no existe'
		RAISERROR(@mensajeError,16,1)
		RETURN -1
	END 
GO


CREATE PROCEDURE ORACLE_FANS.modif_esp
(@esp varchar(255), @prof int)
AS
DECLARE @cod_esp int = (SELECT Cod_Especialidad FROM ORACLE_FANS.Especialidades WHERE Descripcion = @esp)
IF NOT EXISTS(SELECT * FROM ORACLE_FANS.Medico_Especialidad WHERE Matricula = @prof AND Cod_Especialidad = @cod_esp)
BEGIN
	INSERT ORACLE_FANS.Medico_Especialidad (Cod_Especialidad, Matricula)
	VALUES (@cod_esp, @prof)
END
GO


CREATE PROCEDURE ORACLE_FANS.agregar_esp
(@esp varchar(255), @prof int)
AS
DECLARE @cod_esp int = (SELECT Cod_Especialidad FROM ORACLE_FANS.Especialidades WHERE Descripcion = @esp)
INSERT ORACLE_FANS.Medico_Especialidad (Cod_Especialidad, Matricula)
VALUES (@cod_esp, @prof)
GO


CREATE PROCEDURE ORACLE_FANS.agregar_cancelacion
(@cod_turno int, @rol char, @tipo varchar(20), @desc varchar(255), @fecha datetime)
AS
INSERT ORACLE_FANS.Turnos_Cancelados (Cod_Turno, Rol_Cancelacion, Tipo_Cancelacion, Descripcion_Cancelacion, Fecha_Cancelacion)
VALUES (@cod_turno, @rol, @tipo, @desc, @fecha)
GO


CREATE PROCEDURE ORACLE_FANS.agregar_compra
(@tipo char, @cod_afi int, @cant_bonos int, @importe int, @fecha datetime)
AS
INSERT ORACLE_FANS.Compras_Realizadas (Tipo_Bono, Cod_Afiliado, Cantidad_Bonos_Compra, Importe_Compra, Fecha_Compra)
VALUES (@tipo, @cod_afi, @cant_bonos, @importe, @fecha)
GO

CREATE PROCEDURE ORACLE_FANS.ActualizarConsulta
 (
	@Numero_Bono numeric(18),
	@Cod_Afiliado int,
	@Cod_Turno numeric(18),
	@Sintoma varchar(255),
	@Diagnostico varchar(255)
 )
AS 
DECLARE @mensajeErro varchar(60),
		@numeroConsulta int

	INSERT INTO
	ORACLE_FANS.Consultas (Cod_Turno,Bono_Consulta_Numero,Cod_Afiliado,Sintomas,Enfermedades)
	VALUES (@Cod_Turno,@Numero_Bono,@Cod_Afiliado,@Sintoma,@Diagnostico)
	
	SET @numeroConsulta=(select COUNT (*) FROM ORACLE_FANS.Consultas WHERE Cod_Afiliado=@Cod_Afiliado)
	UPDATE ORACLE_FANS.Bono_Consulta
	SET Numero_Consulta=@numeroConsulta
	WHERE Numero=@Numero_Bono

GO

CREATE PROCEDURE ORACLE_FANS.AgregarCartilla
(
	@Matricula int,
	@FechaDesde DateTime,
	@FechaHasta DateTime
)
AS
	INSERT INTO ORACLE_FANS.Cartilla_Medica
	VALUES(@Matricula, @FechaDesde, @FechaHasta)
	
	return @@IDENTITY
GO	

CREATE PROCEDURE ORACLE_FANS.AgregarAAgenda
(
	@Matricula int,
	@dia int,
	@hora time
)
AS
	INSERT INTO ORACLE_FANS.Agenda
		SELECT @Matricula, Cod_Grilla, 1
		FROM ORACLE_FANS.Grilla
		WHERE Dia = @dia
		AND Hora = @hora
GO

CREATE PROCEDURE ORACLE_FANS.ListarMedicos
(
	@Matricula int,
	@Nombre varchar(255),
	@Apellido varchar(255),
	@Especialidad varchar(255),
	@Fecha DateTime
)
AS

	
	SELECT P.Matricula, P.Nombre, P.Apellido, E.Descripcion As Especialidad
	FROM ORACLE_FANS.Profesionales P, ORACLE_FANS.Medico_Especialidad ME, 
 		 ORACLE_FANS.Especialidades E, ORACLE_FANS.Cartilla_Medica C
	WHERE P.Matricula = ME.Matricula
			AND ME.Cod_Especialidad = E.Cod_Especialidad
			AND P.Matricula = C.Matricula
			AND P.Matricula LIKE ISNULL(@Matricula,P.Matricula)
			AND P.Nombre LIKE '%' +@Nombre+ '%'
			AND P.Apellido LIKE '%' + @Apellido + '%'
			AND E.Descripcion LIKE '%' + ISNULL(@Especialidad,E.Descripcion) + '%'
			AND C.FechaInicio <= @Fecha
			AND C.FechaFinal >= @Fecha
GO

CREATE PROCEDURE ORACLE_FANS.ListarTurnosDisponibles
(
	@Matricula int,
	@Fecha datetime
)
AS
	SELECT G.Hora
	FROM ORACLE_FANS.Agenda A, ORACLE_FANS.Grilla G
	WHERE A.Cod_Grilla = G.Cod_Grilla
	AND Matricula = @Matricula
	AND G.Dia = DATEPART(WEEKDAY,@Fecha) - 1
	AND G.Activo = 1
	AND A.Activo = 1
	order by 1
GO

CREATE PROCEDURE ORACLE_FANS.ListarTurnosOcupadosAfiliado
(
	@Cod_Afiliado int,
	@Fecha datetime
)
AS
	SELECT G.Hora
	FROM ORACLE_FANS.Turnos T, ORACLE_FANS.Grilla G
	WHERE  G.Dia = DATEPART(WEEKDAY,T.Fecha)
	AND DATEPART(HH,G.Hora) = DATEPART(HH,T.Fecha)
	AND DATEPART(MINUTE,G.Hora) = DATEPART(MINUTE,T.Fecha)
	AND T.Cod_Afiliado = @Cod_Afiliado
	AND DATEPART(DAYOFYEAR,T.Fecha) = DATEPART(DAYOFYEAR,@Fecha)
	AND T.habilitado = 1
	order by 1
GO

CREATE PROCEDURE ORACLE_FANS.ListarTurnosOcupados
(
	@Matricula int,
	@Fecha datetime
)
AS
	SELECT G.Hora
	FROM ORACLE_FANS.Turnos T, ORACLE_FANS.Grilla G
	WHERE  G.Dia = DATEPART(WEEKDAY,T.Fecha)
	AND DATEPART(HH,G.Hora) = DATEPART(HH,T.Fecha)
	AND DATEPART(MINUTE,G.Hora) = DATEPART(MINUTE,T.Fecha)
	AND T.Matricula = @Matricula
	AND DATEPART(DAYOFYEAR,T.Fecha) = DATEPART(DAYOFYEAR,@Fecha)
	AND T.habilitado = 1
	order by 1
GO
	
CREATE PROCEDURE ORACLE_FANS.Turno_Registrar
(
	@Matricula int,
	@Cod_Afiliado int,
	@Cod_Especialidad int,
	@Fecha datetime
)
AS
	DECLARE @Cod_Turno int
	
	SET @Cod_Turno = (SELECT TOP 1 Cod_Turno FROM ORACLE_FANS.Turnos
					  ORDER BY 1 DESC)
	INSERT INTO ORACLE_FANS.Turnos
	VALUES ( @Cod_Turno + 1, @Matricula, @Cod_Especialidad, @Cod_Afiliado, @Fecha, 1)
	
	return @Cod_Turno + 1
GO	

CREATE PROCEDURE ORACLE_FANS.Profesional_CancelarTurno
(
	@Matricula int,
	@FechaDesde DateTime,
	@FechaHasta DateTime,
	@TipoCancelacion varchar(255),
	@Descripcion varchar(255),
	@FechaHoy DateTime
)
AS
	INSERT INTO ORACLE_FANS.Turnos_Cancelados
		SELECT Cod_Turno, @TipoCancelacion, @Descripcion, 3, @FechaHoy
		FROM ORACLE_FANS.Turnos
		WHERE Cod_Turno IN ( SELECT Cod_Turno FROM ORACLE_FANS.Turnos
							WHERE Matricula = @Matricula
							AND Habilitado = 1
							AND Fecha BETWEEN @FechaDesde AND @FechaHasta )
							
	
	UPDATE ORACLE_FANS.Turnos
	SET
		habilitado = 0
	WHERE Matricula = @Matricula
	AND Cod_Turno IN ( SELECT Cod_Turno FROM ORACLE_FANS.Turnos
						WHERE Matricula = @Matricula
						AND Habilitado = 1
						AND Fecha BETWEEN @FechaDesde AND @FechaHasta )
	
GO

CREATE PROCEDURE ORACLE_FANS.Afiliado_ListarTurnos
(
	@Cod_Afiliado int,
	@FechaTurno DateTime
)
AS
	SELECT Cod_Turno, DATENAME(WEEKDAY,Fecha) As Dia_De_Semana, CONVERT(DATE,Fecha) As Fecha,  CONVERT(TIME,FECHA) As Time
	FROM ORACLE_FANS.Turnos
	WHERE habilitado = 1
	And Cod_Afiliado = @Cod_Afiliado
	And Fecha > @FechaTurno
GO

CREATE PROCEDURE ORACLE_FANS.Afiliado_DarBajaTurno
(
	@Cod_Turno int,
	@Fecha DateTime,
	@TipoCancelacion varchar(255),
	@Descripcion varchar(255)
)
AS
	UPDATE ORACLE_FANS.Turnos
	SET habilitado = 0
	WHERE Cod_Turno = @Cod_Turno
	
	INSERT INTO 
	ORACLE_FANS.Turnos_Cancelados(Cod_Turno,Tipo_Cancelacion,Descripcion_Cancelacion,Rol_Cancelacion,Fecha_Cancelacion)
	VALUES (@Cod_Turno, @TipoCancelacion, @Descripcion, 1, @Fecha)
GO

CREATE PROCEDURE ORACLE_FANS.Usuario_Crear
(
	@username varchar(10),
	@id_Rol int
)
AS
	INSERT INTO ORACLE_FANS.Usuarios
	VALUES (@id_Rol, @username, '280d44ab1e9f79b5cce2dd4f58f5fe91f0fbacdac9f7447dffc318ceb79f2d02', 3, 1)
GO

/*FIN DE STORE PROCEDURE*/





/*PROCEDURES LISTADOS*/

--PROCEDURE #1 Listado de TOP 5 Especialidad + Canceladad 

CREATE PROCEDURE ORACLE_FANS.ListadoDeCancelaciones
( 
	@Anio int,
	@mes int,
	@idRol int
)
AS
		SELECT TOP 5 E.Descripcion, COUNT(*) AS Cantidad
		FROM ORACLE_FANS.Turnos_Cancelados as TC, ORACLE_FANS.Turnos T, ORACLE_FANS.Especialidades E
		WHERE TC.Cod_Turno = T.Cod_Turno
		AND T.Cod_Especialidad = E.Cod_Especialidad
		AND TC.Rol_Cancelacion = @idRol
		AND MONTH(TC.Fecha_Cancelacion) BETWEEN @mes AND (@mes + 6)
		AND YEAR(TC.Fecha_Cancelacion) = @Anio
		GROUP BY E.Descripcion
		ORDER BY 2 DESC
GO

--PROCEDURE #2 Listado TOP 5 Bonos 
CREATE PROCEDURE ORACLE_FANS.ListadoBonosFarmaciaVencidosPorAfiliadoSemestral
(
	@Anio int,
	@mes int
)
AS 
	SELECT TOP 5 A.Cod_Afiliado,A.Apellido,A.Nombre,COUNT(DISTINCT BF.Numero) as Cantidad
		FROM ORACLE_FANS.Afiliados A, ORACLE_FANS.Bono_Farmacia BF, ORACLE_FANS.Recetas R
		WHERE A.Cod_Afiliado = BF.Cod_Afiliado
		AND BF.Numero = R.Numero_Bono_Farmacia
		AND YEAR(BF.Fecha_Vencimiento) = @Anio 
		AND MONTH(BF.Fecha_Vencimiento) BETWEEN @mes AND (@mes + 6)
		GROUP BY A.Cod_Afiliado,A.Apellido,A.Nombre
		HAVING COUNT(DISTINCT R.Numero_Bono_Farmacia) = 0
		ORDER BY Cantidad DESC
GO

--PROCEDURE #3 Listado TOP 5 de Las Especialidades + Bonos

CREATE PROCEDURE ORACLE_FANS.ListadoDeEspecialidadesConMasBonosVendidos
(
	@Anio int,
	@mes int 
)
AS
	SELECT TOP 5 E.Descripcion, COUNT(DISTINCT BF.Numero) as Cantidad
	FROM ORACLE_FANS.Bono_Farmacia as BF, ORACLE_FANS.Recetas R, ORACLE_FANS.Turnos T, ORACLE_FANS.Especialidades E
	WHERE BF.Numero = R.Numero_Bono_Farmacia
	AND R.Cod_Turno = T.Cod_Turno
	AND T.Cod_Especialidad = E.Cod_Especialidad
	AND MONTH(T.Fecha) BETWEEN @mes AND (@mes+6)
	AND YEAR(T.Fecha) = @Anio
	GROUP BY E.Descripcion
	ORDER BY Cantidad DESC
GO

--PROCEDURE #4 Listado TOP 10 de los Afiliados 
CREATE PROCEDURE ORACLE_FANS.ListadoDeBonosCompradosYUsadosPorDistintoAfiliado
(
	@Anio int,
	@mes int
)
AS
	SELECT TOP 10 A.Cod_Afiliado, A.Apellido, A.Nombre, COUNT(BC.Numero) as Cantidad
	FROM ORACLE_FANS.Afiliados A, ORACLE_FANS.Turnos T, ORACLE_FANS.Consultas C,ORACLE_FANS.Bono_Consulta BC
	WHERE A.Cod_Afiliado = T.Cod_Afiliado
	AND T.Cod_Turno = C.Cod_Turno
	AND C.Bono_Consulta_Numero = BC.Numero
	AND BC.Cod_Afiliado <> T.Cod_Afiliado
	AND MONTH(T.Fecha) BETWEEN @mes AND (@mes+6)
	AND YEAR(T.Fecha) = @Anio
	GROUP BY A.Cod_Afiliado,A.Apellido, A.Nombre
	ORDER BY Cantidad DESC
GO

CREATE PROCEDURE ORACLE_FANS.ListadoDeEspecialidadesConMasBonosVendidosEnUnMes
(
	@Mes int,
	@Anio int
)
AS 
		SELECT TOP 5 COUNT(*) as Cantidad,E.Descripcion
		FROM ORACLE_FANS.Bono_Farmacia as BF
		JOIN ORACLE_FANS.Recetas as R ON BF.Numero=R.Numero_Bono_Farmacia
		JOIN ORACLE_FANS.Turnos as T ON T.Cod_Turno=R.Cod_Turno
		JOIN ORACLE_FANS.Profesionales as P ON P.Matricula=T.Matricula
		JOIN ORACLE_FANS.Medico_Especialidad as ME ON ME.Matricula=P.Matricula
		JOIN ORACLE_FANS.Especialidades as E ON E.Cod_Especialidad=ME.Cod_Especialidad
		WHERE  YEAR(BF.Fecha_Impresion)=@Anio AND MONTH(BF.Fecha_Impresion)=@Mes
		GROUP BY E.Descripcion

GO






/*Fin de Listados*/