CREATE TABLE [dbo].[Businesses] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (256) NOT NULL,
    [LanguageId]         INT            NOT NULL,
    [LegalName]          NVARCHAR (256) NOT NULL,
    [TypeId]             INT            NOT NULL,
    [BusinessLine]       NVARCHAR (256) NULL,
    [NationalCode]       NVARCHAR (20)  NULL,
    [EconomicCode]       NVARCHAR (20)  NULL,
    [RegistrationNumber] NVARCHAR (20)  NULL,
    [Country]            NVARCHAR (100) NULL,
    [StateProvince]      NVARCHAR (100) NULL,
    [City]               NVARCHAR (100) NULL,
    [PostalCode]         NVARCHAR (10)  NULL,
    [Phone]              NVARCHAR (15)  NULL,
    [Fax]                NVARCHAR (15)  NULL,
    [Address]            NVARCHAR (500) NULL,
    [Website]            NVARCHAR (256) NULL,
    [Email]              NVARCHAR (256) NULL,
    [LogoUrl]            NVARCHAR (500) NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_Businesses_BusinessTypes] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[BusinessTypes] ([Id]),
    CONSTRAINT [FK_Businesses_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id])
) ON [BusinessesData];



