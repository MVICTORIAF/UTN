USE [Colchoneria]
GO
/****** Object:  Table [dbo].[Colchones]    Script Date: 18/6/2021 19:38:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colchones](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[marca] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Colchones] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 18/6/2021 19:38:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] NOT NULL,
	[nombreMarca] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Colchones] ([codigo], [nombre], [marca], [precio]) VALUES (1, N'Dorado', 1, 50000)
INSERT [dbo].[Colchones] ([codigo], [nombre], [marca], [precio]) VALUES (2, N'Nimbus', 3, 45000)
INSERT [dbo].[Colchones] ([codigo], [nombre], [marca], [precio]) VALUES (3, N'Princess', 6, 60000)
GO
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (1, N'Belmo')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (2, N'Piero')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (3, N'Inducol')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (4, N'Simmons')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (5, N'Cannon')
INSERT [dbo].[Marcas] ([idMarca], [nombreMarca]) VALUES (6, N'King Koil')
GO
