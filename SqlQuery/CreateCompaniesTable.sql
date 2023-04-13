USE [H1PD021123_Gruppe1]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 12-04-2023 12:10:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [text] NOT NULL,
	[Road] [text] NOT NULL,
	[HouseNumber] [text] NOT NULL,
	[ZipCode] [text] NOT NULL,
	[City] [text] NOT NULL,
	[Country] [text] NOT NULL,
	[Currency] [text] NOT NULL,
	[Cvr] [text] NOT NULL,	
	[Email] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


