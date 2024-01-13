CREATE TABLE [dbo].[ContactGeneralInfos] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ContactId]          INT            NOT NULL,
    [FinancialCredit]    INT            NOT NULL,
    [IranianTaxType]     INT            NOT NULL,
    [NationalCode]       VARCHAR (20)   NULL,
    [EconomicCode]       VARCHAR (20)   NULL,
    [RegistrationNumber] VARCHAR (20)   NULL,
    [BranchCode]         VARCHAR (4)    NULL,
    [Note]               NVARCHAR (256) NULL,
    CONSTRAINT [PK_ContactGeneralInfos] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ContactGeneralInfos_Contacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([Id])
) ON [BusinessesData];

