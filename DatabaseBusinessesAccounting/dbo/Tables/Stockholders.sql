CREATE TABLE [dbo].[Stockholders] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ContactId] INT NOT NULL,
    [Percent]   INT NOT NULL,
    CONSTRAINT [PK_Stockholders] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_Stockholders_Contacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([Id])
) ON [BusinessesData];

