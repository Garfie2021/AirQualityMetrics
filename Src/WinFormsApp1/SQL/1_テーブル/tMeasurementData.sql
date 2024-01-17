USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImport]    Script Date: 2023/12/19 19:15:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tMeasurementData]') AND type in (N'U'))
	DROP TABLE [dbo].[tMeasurementData];
GO

CREATE TABLE [dbo].[tMeasurementData](
    [MeasurementStationCode] [varchar](50) NOT NULL,
    [ImportDate] [date] NOT NULL,
    [ImportTime] [tinyint] NOT NULL,
    [SO2_ppm] [float] NULL,
    [NO_ppm] [float] NULL,
    [NO2_ppm] [float] NULL,
    [NOx_ppm] [float] NULL,
    [CO_ppm] [float] NULL,
    [Ox_ppm] [float] NULL,
    [NMHC_ppmC] [float] NULL,
    [CH4_ppmC] [float] NULL,
    [THC_ppmC] [float] NULL,
    [SPM_mg_per_m3] [float] NULL,
    [PM25_ug_per_m3] [float] NULL,
    [SP_mg_per_m3] [float] NULL,
    [WD_16Dir] [varchar](255) NULL,
    [WS_m_per_s] [float] NULL,
    [TEMP_C] [float] NULL,
    [HUM_percent] [float] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [MeasurementStationCode] ASC,
        [ImportDate] ASC,
        [ImportTime] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO



