CREATE TABLE [dbo].[Salesmen] (
    [Id]                                       INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId]                               INT            NOT NULL,
    [IsActive]                                 BIT            CONSTRAINT [DF_Salesmen_IsActive] DEFAULT ((1)) NOT NULL,
    [Name]                                     NVARCHAR (100) NOT NULL,
    [SalesPercent]                             INT            NOT NULL,
    [SalesReturnPercent]                       INT            NOT NULL,
    [ExcludeItemDiscount]                      BIT            NOT NULL,
    [ExcludeAdditionsAndDeductionsOfInvoice]   BIT            NOT NULL,
    [AddJournalExpenseRecordInInvoiceDocument] BIT            NOT NULL,
    [Note]                                     NVARCHAR (256) NULL,
    CONSTRAINT [PK_Salesmen] PRIMARY KEY CLUSTERED ([Id] ASC) ON [BusinessesData],
    CONSTRAINT [FK_Salesmen_Businesses] FOREIGN KEY ([BusinessId]) REFERENCES [dbo].[Businesses] ([Id])
) ON [BusinessesData];

