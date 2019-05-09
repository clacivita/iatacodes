ALTER TABLE [dbo].[Airports]
	ADD CONSTRAINT [UQ_Airports_ICAOCode]
	UNIQUE ([ICAOCode])
