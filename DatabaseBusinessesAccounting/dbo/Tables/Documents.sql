CREATE TABLE [dbo].[Documents] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [BusinessFiscalYearId] INT            NOT NULL,
    [Number]               INT            NOT NULL,
    [Reference]            INT            NOT NULL,
    [InsertDate]           DATETIME       CONSTRAINT [DF_Documents_InsertDate] DEFAULT (getdate()) NOT NULL,
    [ProjectId]            INT            NULL,
    [Description]          NVARCHAR (256) NULL,
    [DocumentDate]         DATETIME       NOT NULL,
    [Amount]               INT            NOT NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC) ON [AccountingData],
    CONSTRAINT [FK_Documents_BusinessFiscalYear] FOREIGN KEY ([BusinessFiscalYearId]) REFERENCES [dbo].[BusinessFiscalYear] ([Id]),
    CONSTRAINT [FK_Documents_BusinessProjects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[BusinessProjects] ([Id])
) ON [AccountingData];

