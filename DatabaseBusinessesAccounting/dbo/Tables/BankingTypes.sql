CREATE TABLE [dbo].[BankingTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_BankingTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

