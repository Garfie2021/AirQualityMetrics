USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImport]    Script Date: 2023/12/19 19:15:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tSummary]') AND type in (N'U'))
	DROP TABLE [dbo].[tSummary];
GO

CREATE TABLE [dbo].[tSummary](
    [MeasurementStationCode] [varchar](50) NOT NULL,
    [Year] [smallint] NOT NULL,
	
	[SO2_ppm_CntNotNull] [int] NULL,
	[SO2_ppm_Avg] [float] NULL,
	[SO2_ppm_Sum] [float] NULL,
	[SO2_ppm_Sumï‚ê≥å„] [float] NULL,

	[NO_ppm_CntNotNull] [int] NULL,
	[NO_ppm_Avg] [float] NULL,
	[NO_ppm_Sum] [float] NULL,
	[NO_ppm_Sumï‚ê≥å„] [float] NULL,

	[NO2_ppm_CntNotNull] [int] NULL,
	[NO2_ppm_Avg] [float] NULL,
	[NO2_ppm_Sum] [float] NULL,
	[NO2_ppm_Sumï‚ê≥å„] [float] NULL,

	[NOx_ppm_CntNotNull] [int] NULL,
	[NOx_ppm_Avg] [float] NULL,
	[NOx_ppm_Sum] [float] NULL,
	[NOx_ppm_Sumï‚ê≥å„] [float] NULL,

	[CO_ppm_CntNotNull] [int] NULL,
	[CO_ppm_Avg] [float] NULL,
	[CO_ppm_Sum] [float] NULL,
	[CO_ppm_Sumï‚ê≥å„] [float] NULL,

	[Ox_ppm_CntNotNull] [int] NULL,
	[Ox_ppm_Avg] [float] NULL,
	[Ox_ppm_Sum] [float] NULL,
	[Ox_ppm_Sumï‚ê≥å„] [float] NULL,

	[NMHC_ppmC_CntNotNull] [int] NULL,
	[NMHC_ppmC_Avg] [float] NULL,
	[NMHC_ppmC_Sum] [float] NULL,
	[NMHC_ppmC_Sumï‚ê≥å„] [float] NULL,

	[CH4_ppmC_CntNotNull] [int] NULL,
	[CH4_ppmC_Avg] [float] NULL,
	[CH4_ppmC_Sum] [float] NULL,
	[CH4_ppmC_Sumï‚ê≥å„] [float] NULL,

	[THC_ppmC_CntNotNull] [int] NULL,
	[THC_ppmC_Avg] [float] NULL,
	[THC_ppmC_Sum] [float] NULL,
	[THC_ppmC_Sumï‚ê≥å„] [float] NULL,

	[SPM_mg_per_m3_CntNotNull] [int] NULL,
	[SPM_mg_per_m3_Avg] [float] NULL,
	[SPM_mg_per_m3_Sum] [float] NULL,
	[SPM_mg_per_m3_Sumï‚ê≥å„] [float] NULL,

	[PM25_ug_per_m3_CntNotNull] [int] NULL,
	[PM25_ug_per_m3_Avg] [float] NULL,
	[PM25_ug_per_m3_Sum] [float] NULL,
	[PM25_ug_per_m3_Sumï‚ê≥å„] [float] NULL,

	[SP_mg_per_m3_CntNotNull] [int] NULL,
	[SP_mg_per_m3_Avg] [float] NULL,
	[SP_mg_per_m3_Sum] [float] NULL,
	[SP_mg_per_m3_Sumï‚ê≥å„] [float] NULL,

	[WS_m_per_s_CntNotNull] [int] NULL,
	[WS_m_per_s_Min] [float] NULL,
	[WS_m_per_s_Max] [float] NULL,
	[WS_m_per_s_Avg] [float] NULL,

	[TEMP_C_CntNotNull] [int] NULL,
	[TEMP_C_Min] [float] NULL,
	[TEMP_C_Max] [float] NULL,
	[TEMP_C_Avg] [float] NULL,

	[HUM_percent_CntNotNull] [int] NULL,
	[HUM_percent_Min] [float] NULL,
	[HUM_percent_Max] [float] NULL,
	[HUM_percent_Avg] [float] NULL,

    PRIMARY KEY CLUSTERED 
    (
        [MeasurementStationCode] ASC,
		[Year] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO



