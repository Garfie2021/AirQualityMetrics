USE [AirQualityMetricsDB]
GO

/****** Object:  Table [dbo].[tImport]    Script Date: 2023/12/19 19:15:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tHour]') AND type in (N'U'))
	DROP TABLE [dbo].[tHour];
GO

CREATE TABLE [dbo].[tHour](
    [Year] [int] NOT NULL,
    [DayCnt] [smallint] NULL,
    [HourCnt] [int] NULL,
    PRIMARY KEY CLUSTERED 
    (
        [Year] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO



