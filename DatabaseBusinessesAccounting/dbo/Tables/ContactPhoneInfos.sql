CREATE TABLE [dbo].[ContactPhoneInfos] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ContactId] INT            NOT NULL,
    [Phone]     NVARCHAR (15)  NULL,
    [Phone1]    NVARCHAR (15)  NULL,
    [Mobile]    NVARCHAR (15)  NULL,
    [Mobile2]   NVARCHAR (15)  NULL,
    [Fax]       NVARCHAR (15)  NULL,
    [Email]     NVARCHAR (256) NULL,
    [Website]   NVARCHAR (256) NULL,
    CONSTRAINT [PK_ContactPhoneInfos] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_ContactPhoneInfos_Contacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([Id])
) ON [BusinessesData];

