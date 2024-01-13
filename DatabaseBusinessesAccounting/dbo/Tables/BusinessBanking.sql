CREATE TABLE [dbo].[BusinessBanking] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId] INT            NOT NULL,
    [BankingId]  INT            NOT NULL,
    [IsActive]   BIT            CONSTRAINT [DF_BusinessBanking_IsActive] DEFAULT ((1)) NOT NULL,
    [Name]       NVARCHAR (150) NOT NULL,
    [CurrencyId] INT            NOT NULL,
    [IsDefault]  BIT            NOT NULL,
    [Note]       NVARCHAR (256) NULL,
    CONSTRAINT [PK_BusinessBanking] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessBanking_BankingTypes] FOREIGN KEY ([BankingId]) REFERENCES [dbo].[BankingTypes] ([Id]),
    CONSTRAINT [FK_BusinessBanking_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id]),
    CONSTRAINT [FK_BusinessBanking_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id])
) ON [BusinessesData];

