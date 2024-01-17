USE AirQualityMetricsDB;
GO

-- ストアドプロシージャが存在する場合は削除
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertMeasurementStation')
    DROP PROCEDURE InsertMeasurementStation;
GO

-- ストアドプロシージャの再作成
CREATE PROCEDURE InsertMeasurementStation
AS
BEGIN
    --declare @StartRow INT = 0;
    --declare @EndRow INT = 10000;

	INSERT INTO tMeasurementStation
		([MeasurementStationCode]
		,[StationName]
		,[Address]
		,[SO2]
		,[NO]
		,[NO2]
		,[NOX]
		,[CO]
		,[OX]
		,[NMHC]
		,[CH4]
		,[THC]
		,[SPM]
		,[PM25]
		,[SP]
		,[WD]
		,[WS]
		,[TEMP]
		,[HUM]	
		,[ContactInfo]
		,[StationType]
	)
	SELECT 
		[MeasurementStationCode],
		[StationName],
		[Address],
		[SO2],
		[NO],
		[NO2],
		[NOX],
		[CO],
		[OX],
		[NMHC],
		[CH4],
		[THC],
		[SPM],
		[PM25],
		[SP],
		[WD],
		[WS],
		[TEMP],
		[HUM],
		[ContactInfo],
		[StationType]
	FROM tImport_MeasurementStation

	UPDATE tms
	SET tms.都道府県 = TRIM(tmp.都道府県)
	FROM tMeasurementStation tms
		INNER JOIN tImport_MeasurementStation_都道府県 tmp
			ON tms.MeasurementStationCode = tmp.MeasurementStationCode

	UPDATE tms
	SET 
		tms.ImportDate_Min = tmd.MinDate,
		tms.ImportDate_Max = tmd.MaxDate
	FROM tMeasurementStation tms
	INNER JOIN 
		(
			SELECT 
				MeasurementStationCode,
				MIN(ImportDate) AS MinDate,
				MAX(ImportDate) AS MaxDate
			FROM tMeasurementData
			GROUP BY MeasurementStationCode
		) tmd
	ON tms.MeasurementStationCode = tmd.MeasurementStationCode;

END;
