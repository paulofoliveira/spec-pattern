CREATE DATABASE [SpecPattern]
GO
USE [SpecPattern]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Filme](
	[FilmeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[DataLancamento] [datetime] NOT NULL,
	[AvaliacaoMpaa] [int] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Avaliacao] [float] NOT NULL,
 CONSTRAINT [PK_Filme] PRIMARY KEY CLUSTERED 
(
	[FilmeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Filme] ON 

GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (1, N'The Amazing Spider-Man', CAST(N'2012-07-03 00:00:00.000' AS DateTime), 3, N'Aventura', 7)
GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (2, N'Beauty and the Beast', CAST(N'2017-03-17 00:00:00.000' AS DateTime), 3, N'Familiar', 7.8)
GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (3, N'The Secret Life of Pets', CAST(N'2016-07-08 00:00:00.000' AS DateTime), 1, N'Aventura', 6.6)
GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (4, N'The Jungle Book', CAST(N'2016-04-15 00:00:00.000' AS DateTime), 2, N'Fantasy', 7.5)
GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (5, N'Split', CAST(N'2017-01-20 00:00:00.000' AS DateTime), 3, N'Horror', 7.4)
GO
INSERT [dbo].[Filme] ([FilmeID], [Nome], [DataLancamento], [AvaliacaoMpaa], [Genero], [Avaliacao]) VALUES (6, N'The Mummy', CAST(N'2017-06-09 00:00:00.000' AS DateTime), 4, N'Ação', 6.7)
GO
SET IDENTITY_INSERT [dbo].[Filme] OFF
GO
