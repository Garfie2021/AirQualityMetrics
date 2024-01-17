USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImportPlane]    Script Date: 2023/12/19 19:14:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tImport_MeasurementStation_“s“¹•{Œ§]') AND type in (N'U'))
    DROP TABLE [dbo].[tImport_MeasurementStation_“s“¹•{Œ§];
GO

CREATE TABLE [dbo].[tImport_MeasurementStation_“s“¹•{Œ§](
    [Id] [bigint] IDENTITY(1,1) NOT NULL,
    [MeasurementStationCode] [varchar](50) NULL,
    [“s“¹•{Œ§] [varchar](255),
 CONSTRAINT [PK_tImport_MeasurementStation_“s“¹•{Œ§] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


