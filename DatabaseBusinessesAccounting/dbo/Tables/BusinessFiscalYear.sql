CREATE TABLE [dbo].[BusinessFiscalYear] (
    [Id]                       INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId]               INT            NOT NULL,
    [StartDate]                DATETIME       NOT NULL,
    [EndDate]                  DATETIME       NOT NULL,
    [Title]                    NVARCHAR (150) NOT NULL,
    [InventoryValuationMethod] INT            NOT NULL,
    CONSTRAINT [PK_BusinessFiscalYear] PRIMARY KEY CLUSTERED ([Id] ASC) ON [AccountingData],
    CONSTRAINT [FK_BusinessFiscalYear_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [AccountingData];

