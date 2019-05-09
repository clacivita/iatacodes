ALTER TABLE [dbo].[Airports]
	ADD CONSTRAINT [UQ_Airports_IATACode]
	UNIQUE ([IATACode])
