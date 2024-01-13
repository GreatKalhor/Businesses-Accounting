CREATE TABLE [dbo].[Language] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (150) NOT NULL,
    [Flag] NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED ([Id] ASC)
);

