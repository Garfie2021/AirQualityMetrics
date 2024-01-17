USE AirQualityMetricsDB;
GO

-- ストアドプロシージャが存在する場合は削除
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertMeasurementData')
    DROP PROCEDURE InsertMeasurementData;
GO

-- ストアドプロシージャの再作成
CREATE PROCEDURE InsertMeasurementData
    @StartRow INT,
    @EndRow INT
AS
BEGIN
    --declare @StartRow INT = 1;
    --declare @EndRow INT = 100000;

     --tImportPlane からデータを取得して tImport に挿入
    INSERT INTO tMeasurementData (
        MeasurementStationCode,
        ImportDate,
        ImportTime,
        SO2_ppm,
        NO_ppm,
        NO2_ppm,
        NOx_ppm,
        CO_ppm,
        Ox_ppm,
        NMHC_ppmC,
        CH4_ppmC,
        THC_ppmC,
        SPM_mg_per_m3,
        PM25_ug_per_m3,
        SP_mg_per_m3,
        WD_16Dir,
        WS_m_per_s,
        TEMP_C,
        HUM_percent
    )
	SELECT 
		MeasurementStationCode,
		CAST(ImportDate AS DATE),
		CAST(ImportTime AS TINYINT),
		CASE 
			WHEN SO2_ppm IN ('', '-', '0') OR SO2_ppm LIKE '%#%' THEN NULL
			ELSE CAST(SO2_ppm AS FLOAT)
		END AS SO2_ppm,
		CASE 
			WHEN NO_ppm IN ('', '-', '0') OR NO_ppm LIKE '%#%' THEN NULL
			ELSE CAST(NO_ppm AS FLOAT)
		END AS NO_ppm,
		CASE 
			WHEN NO2_ppm IN ('', '-', '0') OR NO2_ppm LIKE '%#%' THEN NULL
			ELSE CAST(NO2_ppm AS FLOAT)
		END AS NO2_ppm,
		CASE 
			WHEN NOx_ppm IN ('', '-', '0') OR NOx_ppm LIKE '%#%' THEN NULL
			ELSE CAST(NOx_ppm AS FLOAT)
		END AS NOx_ppm,
		CASE 
			WHEN CO_ppm IN ('', '-', '0') OR CO_ppm LIKE '%#%' THEN NULL
			ELSE CAST(CO_ppm AS FLOAT)
		END AS CO_ppm,
		CASE 
			WHEN Ox_ppm IN ('', '-', '0') OR Ox_ppm LIKE '%#%' THEN NULL
			ELSE CAST(Ox_ppm AS FLOAT)
		END AS Ox_ppm,
		CASE 
			WHEN NMHC_ppmC IN ('', '-', '0') OR NMHC_ppmC LIKE '%#%' THEN NULL
			ELSE CAST(NMHC_ppmC AS FLOAT)
		END AS NMHC_ppmC,
		CASE 
			WHEN CH4_ppmC IN ('', '-', '0') OR CH4_ppmC LIKE '%#%' THEN NULL
			ELSE CAST(CH4_ppmC AS FLOAT)
		END AS CH4_ppmC,
		CASE 
			WHEN THC_ppmC IN ('', '-', '0') OR THC_ppmC LIKE '%#%' THEN NULL
			ELSE CAST(THC_ppmC AS FLOAT)
		END AS THC_ppmC,
		CASE 
			WHEN SPM_mg_per_m3 IN ('', '-', '0') OR SPM_mg_per_m3 LIKE '%#%' THEN NULL
			ELSE CAST(SPM_mg_per_m3 AS FLOAT)
		END AS SPM_mg_per_m3,
		CASE 
			WHEN PM25_ug_per_m3 IN ('', '-', '0') OR PM25_ug_per_m3 LIKE '%#%' THEN NULL
			ELSE CAST(PM25_ug_per_m3 AS FLOAT)
		END AS PM25_ug_per_m3,
		CASE 
			WHEN SP_mg_per_m3 IN ('', '-', '0') OR SP_mg_per_m3 LIKE '%#%' THEN NULL
			ELSE CAST(SP_mg_per_m3 AS FLOAT)
		END AS SP_mg_per_m3,
		CASE 
			WHEN WD_16Dir IN ('', '-') OR WD_16Dir LIKE '%#%' THEN NULL
			ELSE WD_16Dir
		END AS WD_16Dir,
		CASE 
			WHEN WS_m_per_s IN ('', '-', '0') OR WS_m_per_s LIKE '%#%' THEN NULL
			ELSE CAST(WS_m_per_s AS FLOAT)
		END AS WS_m_per_s,
		CASE 
			WHEN TEMP_C IN ('', '-', '0') OR TEMP_C LIKE '%#%' THEN NULL
			ELSE CAST(TEMP_C AS FLOAT)
		END AS TEMP_C,
		CASE 
			WHEN HUM_percent IN ('', '-', '0') OR HUM_percent LIKE '%#%' THEN NULL
			ELSE CAST(HUM_percent AS FLOAT)
		END AS HUM_percent
	FROM tImport_MeasurementData
	WHERE Id BETWEEN @StartRow AND @EndRow AND 
		ImportDate IS NOT NULL AND ImportDate != '' AND
		ImportTime IS NOT NULL AND ImportTime != '';

END;
