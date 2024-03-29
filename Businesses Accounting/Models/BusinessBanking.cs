﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class BusinessBanking
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public int BankingId { get; set; }

    public bool IsActive { get; set; }

    public string Name { get; set; }

    public int CurrencyId { get; set; }

    public bool IsDefault { get; set; }

    public string Note { get; set; }

    public virtual BankingType Banking { get; set; }

    public virtual Business Business { get; set; }

    public virtual ICollection<BusinessBankingInfo> BusinessBankingInfos { get; set; } = new List<BusinessBankingInfo>();

    public virtual Currency Currency { get; set; }
}