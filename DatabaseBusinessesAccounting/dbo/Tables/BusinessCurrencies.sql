CREATE TABLE [dbo].[BusinessCurrencies] (
    [BusinessId] INT NOT NULL,
    [CurrencyId] INT NOT NULL,
    CONSTRAINT [PK_BusinessCurrencies] PRIMARY KEY CLUSTERED ([BusinessId] ASC, [CurrencyId] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessCurrencies_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id]),
    CONSTRAINT [FK_BusinessCurrencies_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
) ON [BusinessesData];

