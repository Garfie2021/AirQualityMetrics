USE AirQualityMetricsDB;
GO

-- ストアドプロシージャが存在する場合は削除
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Select解析結果_固定局')
    DROP PROCEDURE Select解析結果_固定局;
GO

-- ストアドプロシージャの再作成
CREATE PROCEDURE Select解析結果_固定局
    @固定測定局コード NVARCHAR(MAX) -- 
AS
BEGIN
	--declare @SelectType INT = 1

    -- @固定測定局コードを行で分割してテーブル変数に格納
    SET @固定測定局コード = REPLACE(@固定測定局コード, CHAR(13) + CHAR(10), CHAR(10));

    DECLARE @MeasurementStationCodes TABLE (Code NVARCHAR(100));
    INSERT INTO @MeasurementStationCodes (Code)
    SELECT TRIM(value) FROM STRING_SPLIT(@固定測定局コード, CHAR(10)); -- CHAR(10)は改行文字
	
	SELECT 
		ROW_NUMBER() OVER (ORDER BY ts.NO2_ppm_Sum補正後 * ts.PM25_ug_per_m3_Sum補正後) AS 順位,
		tms.MeasurementStationCode 測定局コード,
		tms.StationName 測定局名,
		TRIM(tms.都道府県) 都道府県,
		tms.Address 住所,
		tms.[MapURL],
		tms.[そらまめくんURL],
		ROUND(ts.PM25_ug_per_m3_Sum補正後, 0, 0) PM25_ug_per_m3,
		ROUND(ts.NO2_ppm_Sum補正後, 2, 0) NO2_ppm,
		ROUND(ts.NO_ppm_Sum補正後, 2, 0) NO_ppm,
		ROUND(ts.NOx_ppm_Sum補正後, 2, 0) NOx_ppm,
		ROUND(ts.SO2_ppm_Sum補正後, 2, 0) SO2_ppm,
		ROUND(ts.CO_ppm_Sum補正後, 0, 0) CO_ppm,
		ROUND(ts.Ox_ppm_Sum補正後, 0, 0) Ox_ppm,
		ROUND(ts.NMHC_ppmC_Sum補正後, 0, 0) NMHC_ppmC,
		ROUND(ts.CH4_ppmC_Sum補正後, 0, 0) CH4_ppmC,
		ROUND(ts.THC_ppmC_Sum補正後, 0, 0) THC_ppmC,
		ROUND(ts.SPM_mg_per_m3_Sum補正後, 0, 0) SPM_mg_per_m3,
		ROUND(ts.SP_mg_per_m3_Sum補正後, 2, 0) SP_mg_per_m3,
		ROUND([WS_m_per_s_Min], 1, 0) WS_m_per_s_Min,
		ROUND([WS_m_per_s_Max], 1, 0) WS_m_per_s_Max,
		ROUND([WS_m_per_s_Avg], 1, 0) WS_m_per_s_Avg,
		[TEMP_C_CntNotNull],
		ROUND([TEMP_C_Min], 1, 0) TEMP_C_Min,
		ROUND([TEMP_C_Max], 1, 0) TEMP_C_Max,
		ROUND([TEMP_C_Avg], 1, 0) TEMP_C_Avg,
		ROUND([HUM_percent_Min], 0, 0) HUM_percent_Min,
		ROUND([HUM_percent_Max], 0, 0) HUM_percent_Max,
		ROUND([HUM_percent_Avg], 0, 0) HUM_percent_Avg
	FROM tSummary ts
		INNER JOIN tMeasurementStation tms ON ts.MeasurementStationCode = tms.MeasurementStationCode
        INNER JOIN @MeasurementStationCodes msc ON tms.MeasurementStationCode = msc.Code
	ORDER BY
		tms.都道府県, tms.Address
	;

END;
