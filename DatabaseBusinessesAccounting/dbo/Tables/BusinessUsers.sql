CREATE TABLE [dbo].[BusinessUsers](
    [Id]           int              IDENTITY (1, 1) NOT NULL,
    [UserId]       uniqueidentifier NOT NULL,
    [BusinessId]   int              NOT NULL,
    [AccessTypeId] int              NOT NULL,
    CONSTRAINT [PK_BusinessUsers] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_BusinessUsers_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_BusinessUsers_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

