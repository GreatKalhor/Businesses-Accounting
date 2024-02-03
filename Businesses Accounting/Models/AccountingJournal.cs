﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class AccountingJournal
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int AccountId { get; set; }

    public int? SubAccountId { get; set; }

    public string SubAccount { get; set; }

    public string Description { get; set; }

    public int Debit { get; set; }

    public int Credit { get; set; }

    public int CurrencyId { get; set; }

    public int Amount { get; set; }

    public virtual Account Account { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual Document Document { get; set; }

    public virtual SubAccount SubAccountNavigation { get; set; }
}