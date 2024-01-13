CREATE TABLE [dbo].[ServicePriceList] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ServiceId]  INT            NOT NULL,
    [Title]      NVARCHAR (100) NULL,
    [Price]      INT            NOT NULL,
    [CurrencyId] INT            NOT NULL,
    CONSTRAINT [PK_ServicePriceList] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ServicePriceList_BusinessServices] FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[BusinessServices] ([Id]),
    CONSTRAINT [FK_ServicePriceList_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
) ON [BusinessesData];

