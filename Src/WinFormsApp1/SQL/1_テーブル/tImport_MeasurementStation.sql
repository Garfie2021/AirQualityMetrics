USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImportPlane]    Script Date: 2023/12/19 19:14:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tImport_MeasurementStation]') AND type in (N'U'))
    DROP TABLE [dbo].[tImport_MeasurementStation];
GO

CREATE TABLE [dbo].[tImport_MeasurementStation](
    [Id] [bigint] IDENTITY(1,1) NOT NULL,
    [MeasurementStationCode] [varchar](50) NULL,
    [StationName] [varchar](255),
    [Address] [varchar](255),
    [SO2] [varchar](255),
    [NO] [varchar](255),
    [NO2] [varchar](255),
    [NOX] [varchar](255),
    [CO] [varchar](255),
    [OX] [varchar](255),
    [NMHC] [varchar](255),
    [CH4] [varchar](255),
    [THC] [varchar](255),
    [SPM] [varchar](255),
    [PM25] [varchar](255),
    [SP] [varchar](255),
    [WD] [varchar](255),
    [WS] [varchar](255),
    [TEMP] [varchar](255),
    [HUM] [varchar](255),
    [ContactInfo] [varchar](255),
    [StationType] [varchar](255),
 CONSTRAINT [PK_tImport_MeasurementStation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


