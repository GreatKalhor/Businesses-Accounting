CREATE TABLE [dbo].[ContactAddressInfos] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ContactId]     INT            NOT NULL,
    [Country]       NVARCHAR (100) NULL,
    [StateProvince] NVARCHAR (100) NULL,
    [City]          NVARCHAR (100) NULL,
    [PostalCode]    NVARCHAR (10)  NULL,
    [Address]       NVARCHAR (500) NULL,
    CONSTRAINT [PK_ContactAddressInfos] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ContactAddressInfos_Contacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([Id])
) ON [BusinessesData];

