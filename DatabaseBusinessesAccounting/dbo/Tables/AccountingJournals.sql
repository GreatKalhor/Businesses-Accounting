CREATE TABLE [dbo].[AccountingJournals] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [DocumentId]   INT            NOT NULL,
    [AccountId]    INT            NOT NULL,
    [SubAccountId] INT            NULL,
    [SubAccount]   NVARCHAR (300) NULL,
    [Description]  NVARCHAR (400) NULL,
    [Debit]        INT            NOT NULL,
    [Credit]       INT            NOT NULL,
    [CurrencyId]   INT            NOT NULL,
    [Amount]       INT            NOT NULL,
    CONSTRAINT [PK_AccountingJournals] PRIMARY KEY CLUSTERED ([Id] ASC) ON [AccountingData],
    CONSTRAINT [FK_AccountingJournals_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([Id]),
    CONSTRAINT [FK_AccountingJournals_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([Id]),
    CONSTRAINT [FK_AccountingJournals_Documents] FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Documents] ([Id]),
    CONSTRAINT [FK_AccountingJournals_SubAccounts] FOREIGN KEY ([SubAccountId]) REFERENCES [dbo].[SubAccounts] ([Id])
) ON [AccountingData];

