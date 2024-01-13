CREATE TABLE [dbo].[ContactBankAccountInfos] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ContactId]     INT           NOT NULL,
    [Bank]          NVARCHAR (50) NOT NULL,
    [AccountNumber] VARCHAR (30)  NULL,
    [CardNumber]    VARCHAR (20)  NULL,
    [IBAN]          VARCHAR (32)  NULL,
    CONSTRAINT [PK_ContactBankAccountInfos] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ContactBankAccountInfos_Contacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([Id])
) ON [BusinessesData];

