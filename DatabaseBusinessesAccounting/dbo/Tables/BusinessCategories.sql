CREATE TABLE [dbo].[BusinessCategories] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (40) NOT NULL,
    [CategoryType] INT           NOT NULL,
    [ParentId]     INT           NULL,
    [BusinessId]   INT           NOT NULL,
    CONSTRAINT [PK_BusinessCategories] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessCategories_BusinessCategories] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

