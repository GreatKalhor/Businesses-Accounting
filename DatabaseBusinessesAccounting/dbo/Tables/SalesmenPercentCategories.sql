CREATE TABLE [dbo].[SalesmenPercentCategories] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [CategoryId]         INT NOT NULL,
    [SalesmenId]         INT NOT NULL,
    [SalesPercent]       INT NOT NULL,
    [SalesReturnPercent] INT NOT NULL,
    CONSTRAINT [PK_SalesmenPercentCategories] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_SalesmenPercentCategories_BusinessCategories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[BusinessCategories] ([Id]),
    CONSTRAINT [FK_SalesmenPercentCategories_Salesmen] FOREIGN KEY ([SalesmenId]) REFERENCES [dbo].[Salesmen] ([Id])
) ON [BusinessesData];

