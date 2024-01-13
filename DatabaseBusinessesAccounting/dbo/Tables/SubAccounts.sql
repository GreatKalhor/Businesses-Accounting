CREATE TABLE [dbo].[SubAccounts] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (270) NOT NULL,
    [ObjetcId]   INT            NOT NULL,
    [ObjetcType] INT            NOT NULL,
    [BusinessId] INT            NULL,
    CONSTRAINT [PK_SubAccount] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_SubAccount_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

