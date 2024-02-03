﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Security.Principal;
using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Businesses_Accounting.Services;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Data
{
    public partial class BA_dbContext : DbContext
    {
        public BA_dbContext()
        {
        }

        public BA_dbContext(DbContextOptions<BA_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<AccountingJournal> AccountingJournals { get; set; }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

        public virtual DbSet<BankingType> BankingTypes { get; set; }

        public virtual DbSet<Business> Businesses { get; set; }

        public virtual DbSet<BusinessBanking> BusinessBankings { get; set; }

        public virtual DbSet<BusinessBankingInfo> BusinessBankingInfos { get; set; }

        public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }

        public virtual DbSet<BusinessCurrencyConversion> BusinessCurrencyConversions { get; set; }

        public virtual DbSet<BusinessFinancialInfo> BusinessFinancialInfos { get; set; }

        public virtual DbSet<BusinessFiscalYear> BusinessFiscalYears { get; set; }

        public virtual DbSet<BusinessProduct> BusinessProducts { get; set; }

        public virtual DbSet<BusinessProject> BusinessProjects { get; set; }

        public virtual DbSet<BusinessService> BusinessServices { get; set; }

        public virtual DbSet<BusinessType> BusinessTypes { get; set; }

        public virtual DbSet<BusinessUser> BusinessUsers { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<ContactAddressInfo> ContactAddressInfos { get; set; }

        public virtual DbSet<ContactBankAccountInfo> ContactBankAccountInfos { get; set; }

        public virtual DbSet<ContactGeneralInfo> ContactGeneralInfos { get; set; }

        public virtual DbSet<ContactPhoneInfo> ContactPhoneInfos { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<ProductPriceList> ProductPriceLists { get; set; }

        public virtual DbSet<Salesman> Salesmen { get; set; }

        public virtual DbSet<SalesmenPercentCategory> SalesmenPercentCategories { get; set; }

        public virtual DbSet<SalesmenPercentProduct> SalesmenPercentProducts { get; set; }

        public virtual DbSet<ServicePriceList> ServicePriceLists { get; set; }

        public virtual DbSet<Stockholder> Stockholders { get; set; }

        public virtual DbSet<SubAccount> SubAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Accounts_Accounts");

                entity.HasOne(d => d.SubAccount).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.SubAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_SubAccounts");
            });

            modelBuilder.Entity<AccountingJournal>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.Property(e => e.SubAccount).HasMaxLength(300);

                entity.HasOne(d => d.Account).WithMany(p => p.AccountingJournals)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountingJournals_Accounts");

                entity.HasOne(d => d.Currency).WithMany(p => p.AccountingJournals)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountingJournals_Currencies");

                entity.HasOne(d => d.Document).WithMany(p => p.AccountingJournals)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountingJournals_Documents");

                entity.HasOne(d => d.SubAccountNavigation).WithMany(p => p.AccountingJournals)
                    .HasForeignKey(d => d.SubAccountId)
                    .HasConstraintName("FK_AccountingJournals_SubAccounts");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.FullName).HasMaxLength(256);
                entity.Property(e => e.ImageUrl).HasMaxLength(256);
                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");
                            j.ToTable("AspNetUserRoles");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BankingType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.BusinessLine).HasMaxLength(256);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.EconomicCode).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.Fax).HasMaxLength(15);
                entity.Property(e => e.LegalName)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.LogoUrl).HasMaxLength(500);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.NationalCode).HasMaxLength(20);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.RegistrationNumber).HasMaxLength(20);
                entity.Property(e => e.StateProvince).HasMaxLength(100);
                entity.Property(e => e.Website).HasMaxLength(256);

                entity.HasOne(d => d.Language).WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Businesses_Language");

                entity.HasOne(d => d.Type).WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Businesses_BusinessTypes");
            });

            modelBuilder.Entity<BusinessBanking>(entity =>
            {
                entity.ToTable("BusinessBanking");

                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.Note).HasMaxLength(256);

                entity.HasOne(d => d.Banking).WithMany(p => p.BusinessBankings)
                    .HasForeignKey(d => d.BankingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessBanking_BankingTypes");

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessBankings)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessBanking_Businesses");

                entity.HasOne(d => d.Currency).WithMany(p => p.BusinessBankings)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessBanking_Currencies");
            });

            modelBuilder.Entity<BusinessBankingInfo>(entity =>
            {
                entity.ToTable("BusinessBankingInfo");

                entity.Property(e => e.AcceptanceNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.AccountNumber).HasMaxLength(150);
                entity.Property(e => e.Branch).HasMaxLength(150);
                entity.Property(e => e.CardNumber).HasMaxLength(20);
                entity.Property(e => e.HoldersName).HasMaxLength(150);
                entity.Property(e => e.Iban)
                    .HasMaxLength(100)
                    .HasColumnName("IBAN");
                entity.Property(e => e.MobileNumberRegistered)
                    .HasMaxLength(13)
                    .IsUnicode(false);
                entity.Property(e => e.PaymentSwitchNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Posnumber)
                    .HasMaxLength(100)
                    .HasColumnName("POSNumber");

                entity.HasOne(d => d.BusinessBanking).WithMany(p => p.BusinessBankingInfos)
                    .HasForeignKey(d => d.BusinessBankingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessBankingInfo_BusinessBanking");
            });

            modelBuilder.Entity<BusinessCategory>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessCategories)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessCategories_BusinessCategories");
            });

            modelBuilder.Entity<BusinessCurrencyConversion>(entity =>
            {
                entity.ToTable("BusinessCurrencyConversion");

                entity.Property(e => e.MainValue)
                    .HasDefaultValue(1m)
                    .HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessCurrencyConversions)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessCurrencyConversion_Businesses");

                entity.HasOne(d => d.Currency).WithMany(p => p.BusinessCurrencyConversions)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessCurrencyConversion_Currencies");
            });

            modelBuilder.Entity<BusinessFinancialInfo>(entity =>
            {
                entity.ToTable("BusinessFinancialInfo");

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessFinancialInfos)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessFinancialInfo_Businesses");
            });

            modelBuilder.Entity<BusinessFiscalYear>(entity =>
            {
                entity.ToTable("BusinessFiscalYear");

                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessFiscalYears)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessFiscalYear_Businesses");
            });

            modelBuilder.Entity<BusinessProduct>(entity =>
            {
                entity.Property(e => e.Barcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.MainUnit).HasMaxLength(30);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.Note).HasMaxLength(256);
                entity.Property(e => e.ProductCode).HasMaxLength(30);
                entity.Property(e => e.PurchaseInformation).HasMaxLength(256);
                entity.Property(e => e.SalesInformation).HasMaxLength(256);
                entity.Property(e => e.SalesTaxable).HasDefaultValue(true);
                entity.Property(e => e.SubUnit).HasMaxLength(30);
                entity.Property(e => e.TrackQuantity).HasDefaultValue(true);
                entity.Property(e => e.UnitConversionFactor).HasDefaultValue(1);

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessProducts)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessProducts_Businesses");

                entity.HasOne(d => d.Category).WithMany(p => p.BusinessProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessProducts_BusinessCategories");
            });

            modelBuilder.Entity<BusinessProject>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessProjects)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessProjects_Businesses");
            });

            modelBuilder.Entity<BusinessService>(entity =>
            {
                entity.Property(e => e.Barcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.MainUnit).HasMaxLength(30);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.Note).HasMaxLength(256);
                entity.Property(e => e.ProductCode).HasMaxLength(30);
                entity.Property(e => e.PurchaseInformation).HasMaxLength(256);
                entity.Property(e => e.SalesInformation).HasMaxLength(256);
                entity.Property(e => e.SubUnit).HasMaxLength(30);

                entity.HasOne(d => d.Business).WithMany(p => p.BusinessServices)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessServices_Businesses");

                entity.HasOne(d => d.Category).WithMany(p => p.BusinessServices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessServices_BusinessCategories");
            });

            modelBuilder.Entity<BusinessType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<BusinessUser>(entity =>
            {
                entity.HasOne(d => d.Business).WithMany(p => p.BusinessUsers)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_BusinessUsers_Businesses");

                entity.HasOne(d => d.User).WithMany(p => p.BusinessUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessUsers_AspNetUsers");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(100);
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Business).WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_Contacts_Businesses");

                entity.HasOne(d => d.Category).WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacts_BusinessCategories");
            });

            modelBuilder.Entity<ContactAddressInfo>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.StateProvince).HasMaxLength(100);

                entity.HasOne(d => d.Contact).WithMany(p => p.ContactAddressInfos)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactAddressInfos_Contacts");
            });

            modelBuilder.Entity<ContactBankAccountInfo>(entity =>
            {
                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Bank)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.CardNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Iban)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IBAN");

                entity.HasOne(d => d.Contact).WithMany(p => p.ContactBankAccountInfos)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactBankAccountInfos_Contacts");
            });

            modelBuilder.Entity<ContactGeneralInfo>(entity =>
            {
                entity.Property(e => e.BranchCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.EconomicCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.NationalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Note).HasMaxLength(256);
                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact).WithMany(p => p.ContactGeneralInfos)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactGeneralInfos_Contacts");
            });

            modelBuilder.Entity<ContactPhoneInfo>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.Fax).HasMaxLength(15);
                entity.Property(e => e.Mobile).HasMaxLength(15);
                entity.Property(e => e.Mobile2).HasMaxLength(15);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.Phone1).HasMaxLength(15);
                entity.Property(e => e.Website).HasMaxLength(256);

                entity.HasOne(d => d.Contact).WithMany(p => p.ContactPhoneInfos)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactPhoneInfos_Contacts");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(256);
                entity.Property(e => e.DocumentDate).HasColumnType("datetime");
                entity.Property(e => e.InsertDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BusinessFiscalYear).WithMany(p => p.Documents)
                    .HasForeignKey(d => d.BusinessFiscalYearId)
                    .HasConstraintName("FK_Documents_BusinessFiscalYear");

                entity.HasOne(d => d.Project).WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Documents_BusinessProjects");
                entity.HasOne(d => d.Contact).WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Documents_Contacts");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Flag)
                    .IsRequired()
                    .HasMaxLength(250);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ProductPriceList>(entity =>
            {
                entity.ToTable("ProductPriceList");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Currency).WithMany(p => p.ProductPriceLists)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPriceList_Currencies");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductPriceLists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPriceList_BusinessProducts");
            });

            modelBuilder.Entity<Salesman>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Note).HasMaxLength(256);

                entity.HasOne(d => d.Business).WithMany(p => p.Salesmen)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_Salesmen_Businesses");
            });

            modelBuilder.Entity<SalesmenPercentCategory>(entity =>
            {
                entity.HasOne(d => d.Category).WithMany(p => p.SalesmenPercentCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesmenPercentCategories_BusinessCategories");

                entity.HasOne(d => d.Salesmen).WithMany(p => p.SalesmenPercentCategories)
                    .HasForeignKey(d => d.SalesmenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesmenPercentCategories_Salesmen");
            });

            modelBuilder.Entity<SalesmenPercentProduct>(entity =>
            {
                entity.HasOne(d => d.Salesmen).WithMany(p => p.SalesmenPercentProducts)
                    .HasForeignKey(d => d.SalesmenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesmenPercentProducts_Salesmen");
            });

            modelBuilder.Entity<ServicePriceList>(entity =>
            {
                entity.ToTable("ServicePriceList");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Currency).WithMany(p => p.ServicePriceLists)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePriceList_Currencies");

                entity.HasOne(d => d.Service).WithMany(p => p.ServicePriceLists)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePriceList_BusinessServices");
            });

            modelBuilder.Entity<Stockholder>(entity =>
            {
                entity.HasOne(d => d.Contact).WithMany(p => p.Stockholders)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stockholders_Contacts");
            });

            modelBuilder.Entity<SubAccount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_SubAccount");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(270);

                entity.HasOne(d => d.Business).WithMany(p => p.SubAccounts)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SubAccounts_Businesses");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


    namespace Businesses_Accounting
{
    public class CurrentUser
    {

        public static Guid? GetUserId(ClaimsPrincipal User)
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.Parse(userId);
            }

            return null;
        }
        static Dictionary<Guid, AspNetUser> users;
        public static AspNetUser GetUser(ClaimsPrincipal User)
        {
            if (users == null)
            {
                users = new Dictionary<Guid, AspNetUser>();
            }
            var _userId = GetUserId(User);
            if (_userId is not null)
            {
                var userId = _userId.Value;
                if (!users.Any(x => x.Key == userId))
                {
                    using (UserService us = new UserService())
                    {
                        var user = us.GetUser(userId);
                        users.Add(userId, user);
                    }
                }
                return users[userId];

            }
            else
            {
                return null;
            }
        }
   
        public static void Logout(ClaimsPrincipal User)
        {
            if (users == null)
            {
                users = new Dictionary<Guid, AspNetUser>();
            }
            else
            {
                var _userId = GetUserId(User);
                if (_userId is not null)
                {
                    var userId = _userId.Value;
                    if (users.Any(x => x.Key == userId))
                    {
                            users.Remove(userId);
                    }

                }
            }
        }
    }
}