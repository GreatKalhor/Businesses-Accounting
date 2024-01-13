CREATE TABLE [dbo].[BusinessFinancialInfo] (
    [Id]                        INT IDENTITY (1, 1) NOT NULL,
    [BusinessId]                INT NOT NULL,
    [InventoryAccountingSystem] INT NOT NULL,
    [HasMultiCurrency]          BIT NOT NULL,
    [HasWarehouseManagement]    BIT NOT NULL,
    [MainCurrencyId]            INT NOT NULL,
    [CalendarId]                INT NOT NULL,
    [ValueAddedTaxRate]         INT NOT NULL,
    CONSTRAINT [PK_BusinessFinancialInfo] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessFinancialInfo_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];



