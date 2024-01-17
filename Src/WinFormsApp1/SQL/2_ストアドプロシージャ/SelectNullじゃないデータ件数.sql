USE AirQualityMetricsDB;
GO

-- ストアドプロシージャが存在する場合は削除
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SelectNullじゃないデータ件数')
    DROP PROCEDURE SelectNullじゃないデータ件数;
GO

-- ストアドプロシージャの再作成
CREATE PROCEDURE SelectNullじゃないデータ件数
AS
BEGIN

	SELECT 
		COUNT([SO2_ppm_Sum]) AS [SO2_ppm_Sum_Count],
		COUNT([NO_ppm_Sum]) AS [NO_ppm_Sum_Count],
		COUNT([NO2_ppm_Sum]) AS [NO2_ppm_Sum_Count],
		COUNT([NOx_ppm_Sum]) AS [NOx_ppm_Sum_Count],
		COUNT([CO_ppm_Sum]) AS [CO_ppm_Sum_Count],
		COUNT([Ox_ppm_Sum]) AS [Ox_ppm_Sum_Count],
		COUNT([NMHC_ppmC_Sum]) AS [NMHC_ppmC_Sum_Count],
		COUNT([CH4_ppmC_Sum]) AS [CH4_ppmC_Sum_Count],
		COUNT([THC_ppmC_Sum]) AS [THC_ppmC_Sum_Count],
		COUNT([SPM_mg_per_m3_Sum]) AS [SPM_mg_per_m3_Sum_Count],
		COUNT([PM25_ug_per_m3_Sum]) AS [PM25_ug_per_m3_Sum_Count],
		COUNT([SP_mg_per_m3_Sum]) AS [SP_mg_per_m3_Sum_Count],
		COUNT([WS_m_per_s_Min]) AS [WS_m_per_s_Min_Count],
		COUNT([WS_m_per_s_Max]) AS [WS_m_per_s_Max_Count],
		COUNT([WS_m_per_s_Avg]) AS [WS_m_per_s_Avg_Count],
		COUNT([TEMP_C_Min]) AS [TEMP_C_Min_Count],
		COUNT([TEMP_C_Max]) AS [TEMP_C_Max_Count],
		COUNT([TEMP_C_Avg]) AS [TEMP_C_Avg_Count],
		COUNT([HUM_percent_Min]) AS [HUM_percent_Min_Count],
		COUNT([HUM_percent_Max]) AS [HUM_percent_Max_Count],
		COUNT([HUM_percent_Avg]) AS [HUM_percent_Avg_Count]
	FROM [dbo].[tSummary]

END;
