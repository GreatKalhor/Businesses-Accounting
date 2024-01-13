CREATE TABLE [dbo].[Contacts] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId]    INT            NOT NULL,
    [IsActive]      BIT            CONSTRAINT [DF_Contacts_IsActive] DEFAULT ((1)) NOT NULL,
    [Company]       NVARCHAR (100) NULL,
    [Title]         NVARCHAR (50)  NULL,
    [FirstName]     NVARCHAR (50)  NULL,
    [LastName]      NVARCHAR (50)  NULL,
    [DisplayName]   NVARCHAR (150) NOT NULL,
    [CategoryId]    INT            NOT NULL,
    [ImageUrl]      NVARCHAR (500) NULL,
    [IsCustomer]    BIT            NOT NULL,
    [IsVendor]      BIT            NOT NULL,
    [IsStockholder] BIT            NOT NULL,
    [Employee]      BIT            NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_Contacts_BusinessCategories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[BusinessCategories] ([Id]),
    CONSTRAINT [FK_Contacts_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

