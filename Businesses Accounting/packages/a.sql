USE [BusinessesAccounting_db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountingJournals]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountingJournals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[SubAccountId] [int] NULL,
	[SubAccount] [nvarchar](300) NULL,
	[Description] [nvarchar](400) NULL,
	[Debit] [bigint] NOT NULL,
	[Credit] [bigint] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Amount] [bigint] NOT NULL,
 CONSTRAINT [PK_AccountingJournals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [AccountingData]
) ON [AccountingData]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ParentId] [int] NULL,
	[SubAccountId] [int] NOT NULL
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [AccountingData]
) ON [AccountingData]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ImageUrl] [nvarchar](256) NULL,
	[FullName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankingTypes]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankingTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_BankingTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessBanking]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessBanking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[BankingId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[Note] [nvarchar](256) NULL,
 CONSTRAINT [PK_BusinessBanking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessBankingInfo]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessBankingInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessBankingId] [int] NOT NULL,
	[Branch] [nvarchar](150) NULL,
	[AccountNumber] [nvarchar](150) NULL,
	[CardNumber] [nvarchar](20) NULL,
	[IBAN] [nvarchar](100) NULL,
	[HoldersName] [nvarchar](150) NULL,
	[POSNumber] [nvarchar](100) NULL,
	[MobileNumberRegistered] [varchar](13) NULL,
	[PaymentSwitchNumber] [varchar](20) NULL,
	[AcceptanceNumber] [varchar](20) NULL,
 CONSTRAINT [PK_BusinessBankingInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessCategories]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](40) NOT NULL,
	[CategoryType] [int] NOT NULL,
	[ParentId] [int] NULL,
	[BusinessId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessCurrencyConversion]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessCurrencyConversion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[MainValue] [decimal](18, 10) NOT NULL,
 CONSTRAINT [PK_BusinessCurrencyConversion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[Businesses]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Businesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[LegalName] [nvarchar](256) NOT NULL,
	[TypeId] [int] NOT NULL,
	[BusinessLine] [nvarchar](256) NULL,
	[NationalCode] [nvarchar](20) NULL,
	[EconomicCode] [nvarchar](20) NULL,
	[RegistrationNumber] [nvarchar](20) NULL,
	[Country] [nvarchar](100) NULL,
	[StateProvince] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Phone] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[Address] [nvarchar](500) NULL,
	[Website] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[LogoUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Businesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessFinancialInfo]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessFinancialInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[InventoryAccountingSystem] [int] NOT NULL,
	[HasMultiCurrency] [bit] NOT NULL,
	[HasWarehouseManagement] [bit] NOT NULL,
	[MainCurrencyId] [int] NOT NULL,
	[CalendarId] [int] NOT NULL,
	[ValueAddedTaxRate] [int] NOT NULL,
 CONSTRAINT [PK_BusinessFinancialInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessFiscalYear]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessFiscalYear](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[InventoryValuationMethod] [int] NOT NULL,
 CONSTRAINT [PK_BusinessFiscalYear] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [AccountingData]
) ON [AccountingData]
GO
/****** Object:  Table [dbo].[BusinessProducts]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ProductCode] [nvarchar](30) NULL,
	[Barcode] [varchar](1000) NULL,
	[CategoryId] [int] NOT NULL,
	[SalesPrice] [int] NOT NULL,
	[SalesInformation] [nvarchar](256) NULL,
	[PurchaseCost] [int] NOT NULL,
	[PurchaseInformation] [nvarchar](256) NULL,
	[MainUnit] [nvarchar](30) NULL,
	[Note] [nvarchar](256) NULL,
	[SubUnit] [nvarchar](30) NULL,
	[UnitConversionFactor] [int] NOT NULL,
	[TrackQuantity] [bit] NOT NULL,
	[ReorderPoint] [int] NOT NULL,
	[MinimumOrder] [int] NOT NULL,
	[LeadTimeDays] [int] NOT NULL,
	[SalesTaxable] [bit] NOT NULL,
	[SalesTax] [int] NOT NULL,
	[PurchaseTaxable] [bit] NOT NULL,
	[PurchaseTax] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
	[TaxUnitId] [int] NOT NULL,
	[IranianTaxTypeId] [int] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_BusinessProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessProjects]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_BusinessProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessServices]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ProductCode] [nvarchar](30) NULL,
	[Barcode] [varchar](1000) NULL,
	[CategoryId] [int] NOT NULL,
	[SalesPrice] [int] NOT NULL,
	[SalesInformation] [nvarchar](256) NULL,
	[PurchaseCost] [int] NOT NULL,
	[PurchaseInformation] [nvarchar](256) NULL,
	[MainUnit] [nvarchar](30) NULL,
	[Note] [nvarchar](256) NULL,
	[SubUnit] [nvarchar](30) NULL,
	[UnitConversionFactor] [int] NOT NULL,
	[SalesTaxable] [bit] NOT NULL,
	[SalesTax] [int] NOT NULL,
	[PurchaseTaxable] [bit] NOT NULL,
	[PurchaseTax] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
	[TaxUnitId] [int] NOT NULL,
	[IranianTaxTypeId] [int] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_BusinessServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[BusinessTypes]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessUsers]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[BusinessId] [int] NOT NULL,
	[AccessTypeId] [int] NOT NULL,
 CONSTRAINT [PK_BusinessUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[ContactAddressInfos]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactAddressInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Country] [nvarchar](100) NULL,
	[StateProvince] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_ContactAddressInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[ContactBankAccountInfos]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactBankAccountInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Bank] [nvarchar](50) NOT NULL,
	[AccountNumber] [varchar](30) NULL,
	[CardNumber] [varchar](20) NULL,
	[IBAN] [varchar](32) NULL,
 CONSTRAINT [PK_ContactBankAccountInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[ContactGeneralInfos]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactGeneralInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[FinancialCredit] [int] NOT NULL,
	[IranianTaxType] [int] NOT NULL,
	[NationalCode] [varchar](20) NULL,
	[EconomicCode] [varchar](20) NULL,
	[RegistrationNumber] [varchar](20) NULL,
	[BranchCode] [varchar](4) NULL,
	[Note] [nvarchar](256) NULL,
 CONSTRAINT [PK_ContactGeneralInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[ContactPhoneInfos]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactPhoneInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Phone1] [nvarchar](15) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Mobile2] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[Email] [nvarchar](256) NULL,
	[Website] [nvarchar](256) NULL,
 CONSTRAINT [PK_ContactPhoneInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Company] [nvarchar](100) NULL,
	[Title] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DisplayName] [nvarchar](150) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[IsCustomer] [bit] NOT NULL,
	[IsVendor] [bit] NOT NULL,
	[IsStockholder] [bit] NOT NULL,
	[Employee] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ShortName] [varchar](4) NOT NULL,
	[DisplayName] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessFiscalYearId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Reference] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[ProjectId] [int] NULL,
	[Description] [nvarchar](256) NULL,
	[DocumentDate] [datetime] NOT NULL,
	[Amount] [bigint] NOT NULL,
	[ContactId] [int] NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [AccountingData]
) ON [AccountingData]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Flag] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPriceList]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPriceList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Price] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_ProductPriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[Salesmen]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesmen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SalesPercent] [int] NOT NULL,
	[SalesReturnPercent] [int] NOT NULL,
	[ExcludeItemDiscount] [bit] NOT NULL,
	[ExcludeAdditionsAndDeductionsOfInvoice] [bit] NOT NULL,
	[AddJournalExpenseRecordInInvoiceDocument] [bit] NOT NULL,
	[Note] [nvarchar](256) NULL,
 CONSTRAINT [PK_Salesmen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[SalesmenPercentCategories]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesmenPercentCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SalesmenId] [int] NOT NULL,
	[SalesPercent] [int] NOT NULL,
	[SalesReturnPercent] [int] NOT NULL,
 CONSTRAINT [PK_SalesmenPercentCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[SalesmenPercentProducts]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesmenPercentProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesmenId] [int] NOT NULL,
	[SalesPercent] [int] NOT NULL,
	[SalesReturnPercent] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
	[ObjectType] [int] NOT NULL,
 CONSTRAINT [PK_SalesmenPercentProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[ServicePriceList]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicePriceList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Price] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_ServicePriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[Stockholders]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stockholders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Percent] [int] NOT NULL,
 CONSTRAINT [PK_Stockholders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
/****** Object:  Table [dbo].[SubAccounts]    Script Date: 1/24/2024 2:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](270) NOT NULL,
	[ObjetcId] [int] NOT NULL,
	[ObjetcType] [int] NOT NULL,
	[BusinessId] [int] NULL,
 CONSTRAINT [PK_SubAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [BusinessesData]
) ON [BusinessesData]
GO
ALTER TABLE [dbo].[BusinessBanking] ADD  CONSTRAINT [DF_BusinessBanking_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BusinessCurrencyConversion] ADD  CONSTRAINT [DF_BusinessCurrencyConversion_MainValue]  DEFAULT ((1)) FOR [MainValue]
GO
ALTER TABLE [dbo].[BusinessProducts] ADD  CONSTRAINT [DF_BusinessProducts_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BusinessProducts] ADD  CONSTRAINT [DF_BusinessProducts_UnitConversionFactor]  DEFAULT ((1)) FOR [UnitConversionFactor]
GO
ALTER TABLE [dbo].[BusinessProducts] ADD  CONSTRAINT [DF_BusinessProducts_TrackQuantity]  DEFAULT ((1)) FOR [TrackQuantity]
GO
ALTER TABLE [dbo].[BusinessProducts] ADD  CONSTRAINT [DF_BusinessProducts_SalesTaxable]  DEFAULT ((1)) FOR [SalesTaxable]
GO
ALTER TABLE [dbo].[BusinessProjects] ADD  CONSTRAINT [DF_BusinessProjects_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Salesmen] ADD  CONSTRAINT [DF_Salesmen_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AccountingJournals]  WITH CHECK ADD  CONSTRAINT [FK_AccountingJournals_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[AccountingJournals] CHECK CONSTRAINT [FK_AccountingJournals_Accounts]
GO
ALTER TABLE [dbo].[AccountingJournals]  WITH CHECK ADD  CONSTRAINT [FK_AccountingJournals_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[AccountingJournals] CHECK CONSTRAINT [FK_AccountingJournals_Currencies]
GO
ALTER TABLE [dbo].[AccountingJournals]  WITH CHECK ADD  CONSTRAINT [FK_AccountingJournals_Documents] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[AccountingJournals] CHECK CONSTRAINT [FK_AccountingJournals_Documents]
GO
ALTER TABLE [dbo].[AccountingJournals]  WITH CHECK ADD  CONSTRAINT [FK_AccountingJournals_SubAccounts] FOREIGN KEY([SubAccountId])
REFERENCES [dbo].[SubAccounts] ([Id])
GO
ALTER TABLE [dbo].[AccountingJournals] CHECK CONSTRAINT [FK_AccountingJournals_SubAccounts]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Accounts] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Accounts]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_SubAccounts] FOREIGN KEY([SubAccountId])
REFERENCES [dbo].[SubAccounts] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_SubAccounts]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BusinessBanking]  WITH CHECK ADD  CONSTRAINT [FK_BusinessBanking_BankingTypes] FOREIGN KEY([BankingId])
REFERENCES [dbo].[BankingTypes] ([Id])
GO
ALTER TABLE [dbo].[BusinessBanking] CHECK CONSTRAINT [FK_BusinessBanking_BankingTypes]
GO
ALTER TABLE [dbo].[BusinessBanking]  WITH CHECK ADD  CONSTRAINT [FK_BusinessBanking_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessBanking] CHECK CONSTRAINT [FK_BusinessBanking_Businesses]
GO
ALTER TABLE [dbo].[BusinessBanking]  WITH CHECK ADD  CONSTRAINT [FK_BusinessBanking_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[BusinessBanking] CHECK CONSTRAINT [FK_BusinessBanking_Currencies]
GO
ALTER TABLE [dbo].[BusinessBankingInfo]  WITH CHECK ADD  CONSTRAINT [FK_BusinessBankingInfo_BusinessBanking] FOREIGN KEY([BusinessBankingId])
REFERENCES [dbo].[BusinessBanking] ([Id])
GO
ALTER TABLE [dbo].[BusinessBankingInfo] CHECK CONSTRAINT [FK_BusinessBankingInfo_BusinessBanking]
GO
ALTER TABLE [dbo].[BusinessCategories]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCategories_BusinessCategories] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessCategories] CHECK CONSTRAINT [FK_BusinessCategories_BusinessCategories]
GO
ALTER TABLE [dbo].[BusinessCurrencyConversion]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCurrencyConversion_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessCurrencyConversion] CHECK CONSTRAINT [FK_BusinessCurrencyConversion_Businesses]
GO
ALTER TABLE [dbo].[BusinessCurrencyConversion]  WITH CHECK ADD  CONSTRAINT [FK_BusinessCurrencyConversion_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[BusinessCurrencyConversion] CHECK CONSTRAINT [FK_BusinessCurrencyConversion_Currencies]
GO
ALTER TABLE [dbo].[Businesses]  WITH CHECK ADD  CONSTRAINT [FK_Businesses_BusinessTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[BusinessTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Businesses] CHECK CONSTRAINT [FK_Businesses_BusinessTypes]
GO
ALTER TABLE [dbo].[Businesses]  WITH CHECK ADD  CONSTRAINT [FK_Businesses_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[Businesses] CHECK CONSTRAINT [FK_Businesses_Language]
GO
ALTER TABLE [dbo].[BusinessFinancialInfo]  WITH CHECK ADD  CONSTRAINT [FK_BusinessFinancialInfo_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessFinancialInfo] CHECK CONSTRAINT [FK_BusinessFinancialInfo_Businesses]
GO
ALTER TABLE [dbo].[BusinessFiscalYear]  WITH CHECK ADD  CONSTRAINT [FK_BusinessFiscalYear_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessFiscalYear] CHECK CONSTRAINT [FK_BusinessFiscalYear_Businesses]
GO
ALTER TABLE [dbo].[BusinessProducts]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProducts_BusinessCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BusinessCategories] ([Id])
GO
ALTER TABLE [dbo].[BusinessProducts] CHECK CONSTRAINT [FK_BusinessProducts_BusinessCategories]
GO
ALTER TABLE [dbo].[BusinessProducts]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProducts_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessProducts] CHECK CONSTRAINT [FK_BusinessProducts_Businesses]
GO
ALTER TABLE [dbo].[BusinessProjects]  WITH CHECK ADD  CONSTRAINT [FK_BusinessProjects_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessProjects] CHECK CONSTRAINT [FK_BusinessProjects_Businesses]
GO
ALTER TABLE [dbo].[BusinessServices]  WITH CHECK ADD  CONSTRAINT [FK_BusinessServices_BusinessCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BusinessCategories] ([Id])
GO
ALTER TABLE [dbo].[BusinessServices] CHECK CONSTRAINT [FK_BusinessServices_BusinessCategories]
GO
ALTER TABLE [dbo].[BusinessServices]  WITH CHECK ADD  CONSTRAINT [FK_BusinessServices_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessServices] CHECK CONSTRAINT [FK_BusinessServices_Businesses]
GO
ALTER TABLE [dbo].[BusinessUsers]  WITH CHECK ADD  CONSTRAINT [FK_BusinessUsers_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[BusinessUsers] CHECK CONSTRAINT [FK_BusinessUsers_AspNetUsers]
GO
ALTER TABLE [dbo].[BusinessUsers]  WITH CHECK ADD  CONSTRAINT [FK_BusinessUsers_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessUsers] CHECK CONSTRAINT [FK_BusinessUsers_Businesses]
GO
ALTER TABLE [dbo].[ContactAddressInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactAddressInfos_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[ContactAddressInfos] CHECK CONSTRAINT [FK_ContactAddressInfos_Contacts]
GO
ALTER TABLE [dbo].[ContactBankAccountInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactBankAccountInfos_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[ContactBankAccountInfos] CHECK CONSTRAINT [FK_ContactBankAccountInfos_Contacts]
GO
ALTER TABLE [dbo].[ContactGeneralInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactGeneralInfos_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[ContactGeneralInfos] CHECK CONSTRAINT [FK_ContactGeneralInfos_Contacts]
GO
ALTER TABLE [dbo].[ContactPhoneInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactPhoneInfos_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[ContactPhoneInfos] CHECK CONSTRAINT [FK_ContactPhoneInfos_Contacts]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_BusinessCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BusinessCategories] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_BusinessCategories]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Businesses]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_BusinessFiscalYear] FOREIGN KEY([BusinessFiscalYearId])
REFERENCES [dbo].[BusinessFiscalYear] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_BusinessFiscalYear]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_BusinessProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[BusinessProjects] ([Id])
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_BusinessProjects]
GO
ALTER TABLE [dbo].[ProductPriceList]  WITH CHECK ADD  CONSTRAINT [FK_ProductPriceList_BusinessProducts] FOREIGN KEY([ProductId])
REFERENCES [dbo].[BusinessProducts] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceList] CHECK CONSTRAINT [FK_ProductPriceList_BusinessProducts]
GO
ALTER TABLE [dbo].[ProductPriceList]  WITH CHECK ADD  CONSTRAINT [FK_ProductPriceList_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceList] CHECK CONSTRAINT [FK_ProductPriceList_Currencies]
GO
ALTER TABLE [dbo].[Salesmen]  WITH CHECK ADD  CONSTRAINT [FK_Salesmen_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salesmen] CHECK CONSTRAINT [FK_Salesmen_Businesses]
GO
ALTER TABLE [dbo].[SalesmenPercentCategories]  WITH CHECK ADD  CONSTRAINT [FK_SalesmenPercentCategories_BusinessCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BusinessCategories] ([Id])
GO
ALTER TABLE [dbo].[SalesmenPercentCategories] CHECK CONSTRAINT [FK_SalesmenPercentCategories_BusinessCategories]
GO
ALTER TABLE [dbo].[SalesmenPercentCategories]  WITH CHECK ADD  CONSTRAINT [FK_SalesmenPercentCategories_Salesmen] FOREIGN KEY([SalesmenId])
REFERENCES [dbo].[Salesmen] ([Id])
GO
ALTER TABLE [dbo].[SalesmenPercentCategories] CHECK CONSTRAINT [FK_SalesmenPercentCategories_Salesmen]
GO
ALTER TABLE [dbo].[SalesmenPercentProducts]  WITH CHECK ADD  CONSTRAINT [FK_SalesmenPercentProducts_Salesmen] FOREIGN KEY([SalesmenId])
REFERENCES [dbo].[Salesmen] ([Id])
GO
ALTER TABLE [dbo].[SalesmenPercentProducts] CHECK CONSTRAINT [FK_SalesmenPercentProducts_Salesmen]
GO
ALTER TABLE [dbo].[ServicePriceList]  WITH CHECK ADD  CONSTRAINT [FK_ServicePriceList_BusinessServices] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[BusinessServices] ([Id])
GO
ALTER TABLE [dbo].[ServicePriceList] CHECK CONSTRAINT [FK_ServicePriceList_BusinessServices]
GO
ALTER TABLE [dbo].[ServicePriceList]  WITH CHECK ADD  CONSTRAINT [FK_ServicePriceList_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[ServicePriceList] CHECK CONSTRAINT [FK_ServicePriceList_Currencies]
GO
ALTER TABLE [dbo].[Stockholders]  WITH CHECK ADD  CONSTRAINT [FK_Stockholders_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[Stockholders] CHECK CONSTRAINT [FK_Stockholders_Contacts]
GO
ALTER TABLE [dbo].[SubAccounts]  WITH CHECK ADD  CONSTRAINT [FK_SubAccounts_Businesses] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubAccounts] CHECK CONSTRAINT [FK_SubAccounts_Businesses]
GO
