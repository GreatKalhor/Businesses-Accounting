CREATE TABLE [dbo].[BusinessBankingInfo] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [BusinessBankingId]      INT            NOT NULL,
    [Branch]                 NVARCHAR (150) NULL,
    [AccountNumber]          NVARCHAR (150) NULL,
    [CardNumber]             NVARCHAR (20)  NULL,
    [IBAN]                   NVARCHAR (100) NULL,
    [HoldersName]            NVARCHAR (150) NULL,
    [POSNumber]              NVARCHAR (100) NULL,
    [MobileNumberRegistered] VARCHAR (13)   NULL,
    [PaymentSwitchNumber]    VARCHAR (20)   NULL,
    [AcceptanceNumber]       VARCHAR (20)   NULL,
    CONSTRAINT [PK_BusinessBankingInfo] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessBankingInfo_BusinessBanking] FOREIGN KEY ([BusinessBankingId]) REFERENCES [dbo].[BusinessBanking] ([Id])
) ON [BusinessesData];

