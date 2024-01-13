CREATE TABLE [dbo].[SalesmenPercentProducts] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [SalesmenId]         INT NOT NULL,
    [SalesPercent]       INT NOT NULL,
    [SalesReturnPercent] INT NOT NULL,
    [ObjectId]           INT NOT NULL,
    [ObjectType]         INT NOT NULL,
    CONSTRAINT [PK_SalesmenPercentProducts] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_SalesmenPercentProducts_Salesmen] FOREIGN KEY ([SalesmenId]) REFERENCES [dbo].[Salesmen] ([Id])
) ON [BusinessesData];

