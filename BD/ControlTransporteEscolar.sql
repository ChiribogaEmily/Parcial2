USE [ControlTransporteEscolar]
GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 17/04/2025 19:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutas](
	[ID_Ruta] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Hora_Salida] [time](7) NOT NULL,
	[Hora_Regreso] [time](7) NOT NULL,
	[ID_Vehiculo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Ruta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 17/04/2025 19:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[ID_Estudiante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Grado] [varchar](20) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[ID_Ruta] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EstudiantesPorRuta]    Script Date: 17/04/2025 19:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EstudiantesPorRuta]
AS
SELECT        dbo.Estudiantes.ID_Ruta, dbo.Estudiantes.Apellido, dbo.Estudiantes.Grado, dbo.Estudiantes.Nombre, dbo.Estudiantes.ID_Estudiante
FROM            dbo.Estudiantes INNER JOIN
                         dbo.Rutas ON dbo.Estudiantes.ID_Ruta = dbo.Rutas.ID_Ruta AND dbo.Estudiantes.ID_Ruta = dbo.Rutas.ID_Ruta
GO
/****** Object:  Table [dbo].[Conductores]    Script Date: 17/04/2025 19:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conductores](
	[ID_Conductor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Licencia] [varchar](20) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[Fecha_Contratacion] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Conductor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 17/04/2025 19:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[ID_Vehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](10) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[ID_Conductor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD FOREIGN KEY([ID_Ruta])
REFERENCES [dbo].[Rutas] ([ID_Ruta])
GO
ALTER TABLE [dbo].[Rutas]  WITH CHECK ADD FOREIGN KEY([ID_Vehiculo])
REFERENCES [dbo].[Vehiculos] ([ID_Vehiculo])
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD FOREIGN KEY([ID_Conductor])
REFERENCES [dbo].[Conductores] ([ID_Conductor])
GO

-- Insertar conductores
INSERT INTO Conductores (Nombre, Licencia, Telefono, Fecha_Contratacion) 
VALUES 
    ('Juan Pérez', 'LIC123456', '555-1001', '2020-05-15'),
    ('María Gómez', 'LIC789012', '555-1002', '2021-02-20'),
    ('Carlos López', 'LIC345678', '555-1003', '2019-11-10');
GO
-- Insertar vehículos
INSERT INTO Vehiculos (Placa, Marca, Modelo, ID_Conductor)
VALUES
    ('ABC123', 'Toyota', 'Hiace', 1),
    ('XYZ789', 'Nissan', 'Urvan', 2),
    ('DEF456', 'Mercedes', 'Sprinter', 3);
GO
-- Insertar rutas
INSERT INTO Rutas (Nombre, Descripcion, Hora_Salida, Hora_Regreso, ID_Vehiculo)
VALUES
    ('Ruta Norte', 'Zona residencial norte', '07:00:00', '08:30:00', 1),
    ('Ruta Sur', 'Zona comercial sur', '06:30:00', '09:00:00', 2),
    ('Ruta Centro', 'Centro histórico', '07:15:00', '08:45:00', 3);
GO
-- Insertar estudiantes
INSERT INTO Estudiantes (Nombre, Apellido, Grado, Direccion, Telefono, ID_Ruta)
VALUES
    ('Ana', 'Martínez', '5to Primaria', 'Calle 123, Zona Norte', '555-2001', 1),
    ('Luis', 'Rodríguez', '6to Primaria', 'Avenida 456, Zona Sur', '555-2002', 2),
    ('Sofía', 'Hernández', '4to Primaria', 'Boulevard 789, Centro', '555-2003', 3);
