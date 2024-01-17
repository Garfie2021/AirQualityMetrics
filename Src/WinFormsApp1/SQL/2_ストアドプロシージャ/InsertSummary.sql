USE AirQualityMetricsDB;
GO

-- ストアドプロシージャが存在する場合は削除
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertSummary')
    DROP PROCEDURE InsertSummary;
GO

-- ストアドプロシージャの再作成
CREATE PROCEDURE InsertSummary
    @Year [smallint]
AS
BEGIN

    --declare @Year [smallint] = 2023;

	DELETE FROM [dbo].[tSummary] WHERE Year([Year]) = @Year;

	INSERT INTO [dbo].[tSummary] (
		[MeasurementStationCode],
		[Year],

		[SO2_ppm_CntNotNull],
		[SO2_ppm_Avg],
		[SO2_ppm_Sum],
		[SO2_ppm_Sum補正後],

		[NO_ppm_CntNotNull],
		[NO_ppm_Avg],
		[NO_ppm_Sum],
		[NO_ppm_Sum補正後],

		[NO2_ppm_CntNotNull],
		[NO2_ppm_Avg],
		[NO2_ppm_Sum],
		[NO2_ppm_Sum補正後],

		[NOx_ppm_CntNotNull],
		[NOx_ppm_Avg],
		[NOx_ppm_Sum],
		[NOx_ppm_Sum補正後],

		[CO_ppm_CntNotNull],
		[CO_ppm_Avg],
		[CO_ppm_Sum],
		[CO_ppm_Sum補正後],

		[Ox_ppm_CntNotNull],
		[Ox_ppm_Avg],
		[Ox_ppm_Sum],
		[Ox_ppm_Sum補正後],

		[NMHC_ppmC_CntNotNull],
		[NMHC_ppmC_Avg],
		[NMHC_ppmC_Sum],
		[NMHC_ppmC_Sum補正後],

		[CH4_ppmC_CntNotNull],
		[CH4_ppmC_Avg],
		[CH4_ppmC_Sum],
		[CH4_ppmC_Sum補正後],

		[THC_ppmC_CntNotNull],
		[THC_ppmC_Avg],
		[THC_ppmC_Sum],
		[THC_ppmC_Sum補正後],

		[SPM_mg_per_m3_CntNotNull],
		[SPM_mg_per_m3_Avg],
		[SPM_mg_per_m3_Sum],
		[SPM_mg_per_m3_Sum補正後],

		[PM25_ug_per_m3_CntNotNull],
		[PM25_ug_per_m3_Avg],
		[PM25_ug_per_m3_Sum],
		[PM25_ug_per_m3_Sum補正後],

		[SP_mg_per_m3_CntNotNull],
		[SP_mg_per_m3_Avg],
		[SP_mg_per_m3_Sum],
		[SP_mg_per_m3_Sum補正後],

		[WS_m_per_s_CntNotNull],
		[WS_m_per_s_Min],
		[WS_m_per_s_Max],
		[WS_m_per_s_Avg],

		[TEMP_C_CntNotNull],
		[TEMP_C_Min],
		[TEMP_C_Max],
		[TEMP_C_Avg],

		[HUM_percent_CntNotNull],
		[HUM_percent_Min],
		[HUM_percent_Max],
		[HUM_percent_Avg]
	)
	SELECT
		[MeasurementStationCode],
		@Year AS [Year],

		COUNT(CASE WHEN [SO2_ppm] > 0 THEN 1 ELSE NULL END) AS [SO2_ppm_CntNull],
		AVG(CASE WHEN [SO2_ppm] > 0 THEN [SO2_ppm] ELSE NULL END) AS [SO2_ppm_Avg],
		SUM(CASE WHEN [SO2_ppm] > 0 THEN [SO2_ppm] ELSE NULL END) AS [SO2_ppm_Sum],
		NULL AS [SO2_ppm_Sum補正後],

		COUNT(CASE WHEN [NO_ppm] > 0 THEN 1 ELSE NULL END) AS [NO_ppm_CntNull],
		AVG(CASE WHEN [NO_ppm] > 0 THEN [NO_ppm] ELSE NULL END) AS [NO_ppm_Avg],
		SUM(CASE WHEN [NO_ppm] > 0 THEN [NO_ppm] ELSE NULL END) AS [NO_ppm_Sum],
		NULL AS [NO_ppm_Sum補正後],

		COUNT(CASE WHEN 0.1 > [NO2_ppm] AND [NO2_ppm] > 0 THEN 1 ELSE NULL END) AS [NO2_ppm_CntNull],
		AVG(CASE WHEN 0.1 > [NO2_ppm] AND [NO2_ppm] > 0 THEN [NO2_ppm] ELSE NULL END) AS [NO2_ppm_Avg],
		SUM(CASE WHEN 0.1 > [NO2_ppm] AND [NO2_ppm] > 0 THEN [NO2_ppm] ELSE NULL END) AS [NO2_ppm_Sum],
		NULL AS [NO2_ppm_Sum補正後],

		COUNT(CASE WHEN [NOx_ppm] > 0 THEN 1 ELSE NULL END) AS [NOx_ppm_CntNull],
		AVG(CASE WHEN [NOx_ppm] > 0 THEN [NOx_ppm] ELSE NULL END) AS [NOx_ppm_Avg],
		SUM(CASE WHEN [NOx_ppm] > 0 THEN [NOx_ppm] ELSE NULL END) AS [NOx_ppm_Sum],
		NULL AS [NOx_ppm_Sum補正後],

		COUNT(CASE WHEN [CO_ppm] > 0 THEN 1 ELSE NULL END) AS [CO_ppm_CntNull],
		AVG(CASE WHEN [CO_ppm] > 0 THEN [CO_ppm] ELSE NULL END) AS [CO_ppm_Avg],
		SUM(CASE WHEN [CO_ppm] > 0 THEN [CO_ppm] ELSE NULL END) AS [CO_ppm_Sum],
		NULL AS [CO_ppm_Sum補正後],

		COUNT(CASE WHEN [Ox_ppm] > 0 THEN 1 ELSE NULL END) AS [Ox_ppm_CntNull],
		AVG(CASE WHEN [Ox_ppm] > 0 THEN [Ox_ppm] ELSE NULL END) AS [Ox_ppm_Avg],
		SUM(CASE WHEN [Ox_ppm] > 0 THEN [Ox_ppm] ELSE NULL END) AS [Ox_ppm_Sum],
		NULL AS [Ox_ppm_Sum補正後],

		COUNT(CASE WHEN [NMHC_ppmC] > 0 THEN 1 ELSE NULL END) AS [NMHC_ppmC_CntNull],
		AVG(CASE WHEN [NMHC_ppmC] > 0 THEN [NMHC_ppmC] ELSE NULL END) AS [NMHC_ppmC_Avg],
		SUM(CASE WHEN [NMHC_ppmC] > 0 THEN [NMHC_ppmC] ELSE NULL END) AS [NMHC_ppmC_Sum],
		NULL AS [NMHC_ppmC_Sum補正後],

		COUNT(CASE WHEN [CH4_ppmC] > 0 THEN 1 ELSE NULL END) AS [CH4_ppmC_CntNull],
		AVG(CASE WHEN [CH4_ppmC] > 0 THEN [CH4_ppmC] ELSE NULL END) AS [CH4_ppmC_Avg],
		SUM(CASE WHEN [CH4_ppmC] > 0 THEN [CH4_ppmC] ELSE NULL END) AS [CH4_ppmC_Sum],
		NULL AS [CH4_ppmC_Sum補正後],

		COUNT(CASE WHEN [THC_ppmC] > 0 THEN 1 ELSE NULL END) AS [THC_ppmC_CntNull],
		AVG(CASE WHEN [THC_ppmC] > 0 THEN [THC_ppmC] ELSE NULL END) AS [THC_ppmC_Avg],
		SUM(CASE WHEN [THC_ppmC] > 0 THEN [THC_ppmC] ELSE NULL END) AS [THC_ppmC_Sum],
		NULL AS [THC_ppmC_Sum補正後],

		COUNT(CASE WHEN [SPM_mg_per_m3] > 0 THEN 1 ELSE NULL END) AS [SPM_mg_per_m3_CntNull],
		AVG(CASE WHEN [SPM_mg_per_m3] > 0 THEN [SPM_mg_per_m3] ELSE NULL END) AS [SPM_mg_per_m3_Avg],
		SUM(CASE WHEN [SPM_mg_per_m3] > 0 THEN [SPM_mg_per_m3] ELSE NULL END) AS [SPM_mg_per_m3_Sum],
		NULL AS [SPM_mg_per_m3_Sum補正後],

		COUNT(CASE WHEN 100 > [PM25_ug_per_m3] AND [PM25_ug_per_m3] > 0 THEN 1 ELSE NULL END) AS [PM25_ug_per_m3_CntNull],
		AVG(CASE WHEN 100 > [PM25_ug_per_m3] AND [PM25_ug_per_m3] > 0 THEN [PM25_ug_per_m3] ELSE NULL END) AS [PM25_ug_per_m3_Avg],
		SUM(CASE WHEN 100 > [PM25_ug_per_m3] AND [PM25_ug_per_m3] > 0 THEN [PM25_ug_per_m3] ELSE NULL END) AS [PM25_ug_per_m3_Sum],
		NULL AS [PM25_ug_per_m3_Sum補正後],

		COUNT(CASE WHEN [SP_mg_per_m3] > 0 THEN 1 ELSE NULL END) AS [SP_mg_per_m3_CntNull],
		AVG(CASE WHEN [SP_mg_per_m3] > 0 THEN [SP_mg_per_m3] ELSE NULL END) AS [SP_mg_per_m3_Avg],
		SUM(CASE WHEN [SP_mg_per_m3] > 0 THEN [SP_mg_per_m3] ELSE NULL END) AS [SP_mg_per_m3_Sum],
		NULL AS [SP_mg_per_m3_Sum補正後],

		COUNT(CASE WHEN [WS_m_per_s] > 0 THEN 1 ELSE NULL END) AS [WS_m_per_s_CntNull],
		MIN(CASE WHEN [WS_m_per_s] > 0 THEN [WS_m_per_s] ELSE NULL END) AS [WS_m_per_s_Min],
		MAX(CASE WHEN [WS_m_per_s] > 0 THEN [WS_m_per_s] ELSE NULL END) AS [WS_m_per_s_Max],
		AVG(CASE WHEN [WS_m_per_s] > 0 THEN [WS_m_per_s] ELSE NULL END) AS [WS_m_per_s_Avg],

		COUNT([TEMP_C]) AS [TEMP_C_CntNull],
		MIN([TEMP_C]) AS [TEMP_C_Min],
		MAX([TEMP_C]) AS [TEMP_C_Max],
		AVG([TEMP_C]) AS [TEMP_C_Avg],

		COUNT([HUM_percent]) AS [HUM_percent_CntNull],
		MIN([HUM_percent]) AS [HUM_percent_Min],
		MAX([HUM_percent]) AS [HUM_percent_Max],
		AVG([HUM_percent]) AS [HUM_percent_Avg]
	FROM [dbo].[tMeasurementData]
	WHERE YEAR([ImportDate]) = @Year
	GROUP BY [MeasurementStationCode];

	declare @HourCnt [int];
	SELECT @HourCnt = [HourCnt] FROM [dbo].[tHour] WHERE [Year] = @Year;

	UPDATE [dbo].[tSummary]
	SET 
		[SO2_ppm_Sum補正後] = [SO2_ppm_Sum] + ([SO2_ppm_Avg] * (@HourCnt - [SO2_ppm_CntNotNull])),
		[NO_ppm_Sum補正後] = [NO_ppm_Sum] + ([NO_ppm_Avg] * (@HourCnt - [NO_ppm_CntNotNull])),
		[NO2_ppm_Sum補正後] = [NO2_ppm_Sum] + ([NO2_ppm_Avg] * (@HourCnt - [NO2_ppm_CntNotNull])),
		[NOx_ppm_Sum補正後] = [NOx_ppm_Sum] + ([NOx_ppm_Avg] * (@HourCnt - [NOx_ppm_CntNotNull])),
		[CO_ppm_Sum補正後] = [CO_ppm_Sum] + ([CO_ppm_Avg] * (@HourCnt - [CO_ppm_CntNotNull])),
		[Ox_ppm_Sum補正後] = [Ox_ppm_Sum] + ([Ox_ppm_Avg] * (@HourCnt - [Ox_ppm_CntNotNull])),
		[NMHC_ppmC_Sum補正後] = [NMHC_ppmC_Sum] + ([NMHC_ppmC_Avg] * (@HourCnt - [NMHC_ppmC_CntNotNull])),
		[CH4_ppmC_Sum補正後] = [CH4_ppmC_Sum] + ([CH4_ppmC_Avg] * (@HourCnt - [CH4_ppmC_CntNotNull])),
		[THC_ppmC_Sum補正後] = [THC_ppmC_Sum] + ([THC_ppmC_Avg] * (@HourCnt - [THC_ppmC_CntNotNull])),
		[SPM_mg_per_m3_Sum補正後] = [SPM_mg_per_m3_Sum] + ([SPM_mg_per_m3_Avg] * (@HourCnt - [SPM_mg_per_m3_CntNotNull])),
		[PM25_ug_per_m3_Sum補正後] = [PM25_ug_per_m3_Sum] + ([PM25_ug_per_m3_Avg] * (@HourCnt - [PM25_ug_per_m3_CntNotNull])),
		[SP_mg_per_m3_Sum補正後] = [SP_mg_per_m3_Sum] + ([SP_mg_per_m3_Avg] * (@HourCnt - [SP_mg_per_m3_CntNotNull]))
	WHERE [Year] = @Year;

END;
