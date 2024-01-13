CREATE TABLE [dbo].[Accounts] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [ParentId]     INT            NULL,
    [SubAccountId] INT            NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC) ON [AccountingData],
    CONSTRAINT [FK_Accounts_Accounts] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Accounts] ([Id]),
    CONSTRAINT [FK_Accounts_SubAccounts] FOREIGN KEY ([SubAccountId]) REFERENCES [dbo].[SubAccounts] ([Id])
) ON [AccountingData];

