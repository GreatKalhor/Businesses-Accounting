CREATE TABLE [dbo].[Currencies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (150) NOT NULL,
    [ShortName]   VARCHAR (4)    NOT NULL,
    [DisplayName] NVARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

