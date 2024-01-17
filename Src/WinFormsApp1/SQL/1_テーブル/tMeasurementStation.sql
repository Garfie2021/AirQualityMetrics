USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImport]    Script Date: 2023/12/19 19:15:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tMeasurementStation]') AND type in (N'U'))
	DROP TABLE [dbo].[tMeasurementStation];
GO

--‘ª’è‹Çˆê——
CREATE TABLE tMeasurementStation (
    [MeasurementStationCode] [varchar](50) NOT NULL,
    StationName NVARCHAR(255),
    [“s“¹•{Œ§] [varchar](255),
    Address NVARCHAR(255),
    [ImportDate_Min] [date] NULL,
    [ImportDate_Max] [date] NULL,
    [MapURL] [varchar](1000),
    [‚»‚ç‚Ü‚ß‚­‚ñURL] [varchar](1000),
    SO2 NVARCHAR(1),
    NO NVARCHAR(1),
    NO2 NVARCHAR(1),
    NOX NVARCHAR(1),
    CO NVARCHAR(1),
    OX NVARCHAR(1),
    NMHC NVARCHAR(1),
    CH4 NVARCHAR(1),
    THC NVARCHAR(1),
    SPM NVARCHAR(1),
    PM25 NVARCHAR(1),
    SP NVARCHAR(1),
    WD NVARCHAR(1),
    WS NVARCHAR(1),
    TEMP NVARCHAR(1),
    HUM NVARCHAR(1),
    ContactInfo NVARCHAR(255),
    StationType NVARCHAR(255)
    PRIMARY KEY CLUSTERED 
    (
        [MeasurementStationCode] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO


