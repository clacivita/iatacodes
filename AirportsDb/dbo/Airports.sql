CREATE TABLE [dbo].[Airports] (
    [Id]           INT            NOT NULL,
    [FullName]     NVARCHAR (128) NOT NULL,
    [City]         NVARCHAR (64)  NOT NULL,
    [FullCountry]  NVARCHAR (64)  NOT NULL,
    [IATACode]     NVARCHAR (6)   NOT NULL,
    [ICAOCode]     NVARCHAR (6)   NOT NULL,
    [Latitude]     FLOAT (53)     NOT NULL,
    [Longitude]    FLOAT (53)     NOT NULL,
    [Altitude]     INT            NOT NULL,
    [Timezone]     NVARCHAR (32)  NOT NULL,
    [DST]          NVARCHAR (6)   NOT NULL,
    [TimezoneName] NVARCHAR (64)  NOT NULL,
    [Type]         NVARCHAR (32)  NOT NULL,
    [Source]       NVARCHAR (64)  NOT NULL,
    CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED ([Id] ASC)
);

