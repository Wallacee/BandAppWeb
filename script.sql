USE [DBBand]
GO
/****** Object:  Table [dbo].[Band]    Script Date: 17/02/16 12:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Band](
	[idBand] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[foundationDate] [date] NOT NULL,
	[fk_style] [int] NOT NULL,
 CONSTRAINT [PK_Band] PRIMARY KEY CLUSTERED 
(
	[idBand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BandMusician]    Script Date: 17/02/16 12:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BandMusician](
	[FK_Band] [int] NOT NULL,
	[FK_Musician] [int] NOT NULL,
 CONSTRAINT [PK_BandMusician] PRIMARY KEY CLUSTERED 
(
	[FK_Band] ASC,
	[FK_Musician] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instrument]    Script Date: 17/02/16 12:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrument](
	[idInstrument] [int] IDENTITY(1,1) NOT NULL,
	[instrument] [nchar](40) NOT NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[idInstrument] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Musician]    Script Date: 17/02/16 12:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musician](
	[idMusician] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[fk_instrument] [int] NOT NULL,
 CONSTRAINT [PK_Musician] PRIMARY KEY CLUSTERED 
(
	[idMusician] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Style]    Script Date: 17/02/16 12:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Style](
	[idStyle] [int] IDENTITY(1,1) NOT NULL,
	[style] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Style] PRIMARY KEY CLUSTERED 
(
	[idStyle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Band]  WITH CHECK ADD  CONSTRAINT [FK_Band_Style] FOREIGN KEY([fk_style])
REFERENCES [dbo].[Style] ([idStyle])
GO
ALTER TABLE [dbo].[Band] CHECK CONSTRAINT [FK_Band_Style]
GO
ALTER TABLE [dbo].[BandMusician]  WITH CHECK ADD  CONSTRAINT [FK_BandMusician_Band] FOREIGN KEY([FK_Band])
REFERENCES [dbo].[Band] ([idBand])
GO
ALTER TABLE [dbo].[BandMusician] CHECK CONSTRAINT [FK_BandMusician_Band]
GO
ALTER TABLE [dbo].[BandMusician]  WITH CHECK ADD  CONSTRAINT [FK_BandMusician_Musician] FOREIGN KEY([FK_Musician])
REFERENCES [dbo].[Musician] ([idMusician])
GO
ALTER TABLE [dbo].[BandMusician] CHECK CONSTRAINT [FK_BandMusician_Musician]
GO
ALTER TABLE [dbo].[Musician]  WITH NOCHECK ADD  CONSTRAINT [FK_Musician_Instrument] FOREIGN KEY([fk_instrument])
REFERENCES [dbo].[Instrument] ([idInstrument])
GO
ALTER TABLE [dbo].[Musician] CHECK CONSTRAINT [FK_Musician_Instrument]
GO
