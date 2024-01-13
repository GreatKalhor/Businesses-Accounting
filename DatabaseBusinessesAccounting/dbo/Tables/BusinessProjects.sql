CREATE TABLE [dbo].[BusinessProjects] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId] INT            NOT NULL,
    [Name]       NVARCHAR (150) NOT NULL,
    [IsActive]   BIT            CONSTRAINT [DF_BusinessProjects_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDefault]  BIT            NOT NULL,
    CONSTRAINT [PK_BusinessProjects] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessProjects_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

