USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImportPlane]    Script Date: 2023/12/19 19:14:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tImport_MeasurementData]') AND type in (N'U'))
    DROP TABLE [dbo].[tImport_MeasurementData];
GO

CREATE TABLE [dbo].[tImport_MeasurementData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
    [MeasurementStationCode] [varchar](50) NULL,
    [ImportDate] [varchar](255) NULL,
    [ImportTime] [varchar](255) NULL,
    [SO2_ppm] [varchar](255) NULL,
    [NO_ppm] [varchar](255) NULL,
    [NO2_ppm] [varchar](255) NULL,
    [NOx_ppm] [varchar](255) NULL,
    [CO_ppm] [varchar](255) NULL,
    [Ox_ppm] [varchar](255) NULL,
    [NMHC_ppmC] [varchar](255) NULL,
    [CH4_ppmC] [varchar](255) NULL,
    [THC_ppmC] [varchar](255) NULL,
    [SPM_mg_per_m3] [varchar](255) NULL,
    [PM25_ug_per_m3] [varchar](255) NULL,
    [SP_mg_per_m3] [varchar](255) NULL,
    [WD_16Dir] [varchar](255) NULL,
    [WS_m_per_s] [varchar](255) NULL,
    [TEMP_C] [varchar](255) NULL,
    [HUM_percent] [varchar](255) NULL
 CONSTRAINT [PK_tImport_MeasurementData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
