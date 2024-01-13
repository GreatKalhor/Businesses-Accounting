CREATE TABLE [dbo].[BusinessTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_BusinessTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

