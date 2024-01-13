CREATE TABLE [dbo].[BusinessCurrencyConversion] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [BusinessId] INT              NOT NULL,
    [CurrencyId] INT              NOT NULL,
    [MainValue]  DECIMAL (18, 10) CONSTRAINT [DF_BusinessCurrencyConversion_MainValue] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BusinessCurrencyConversion] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessCurrencyConversion_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id]),
    CONSTRAINT [FK_BusinessCurrencyConversion_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
) ON [BusinessesData];

