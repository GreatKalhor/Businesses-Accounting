CREATE TABLE [dbo].[ProductPriceList] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT            NOT NULL,
    [Title]      NVARCHAR (100) NULL,
    [Price]      INT            NOT NULL,
    [CurrencyId] INT            NOT NULL,
    CONSTRAINT [PK_ProductPriceList] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ProductPriceList_BusinessProducts] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[BusinessProducts] ([Id]),
    CONSTRAINT [FK_ProductPriceList_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
) ON [BusinessesData];

