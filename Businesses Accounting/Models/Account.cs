﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentId { get; set; }

    public int SubAccountId { get; set; }
    public bool HasChildren { get { return InverseParent.Count() > 0; } }

    public virtual ICollection<AccountingJournal> AccountingJournals { get; set; } = new List<AccountingJournal>();

    public virtual ICollection<Account> InverseParent { get; set; } = new List<Account>();

    public virtual Account Parent { get; set; }

    public virtual SubAccount SubAccount { get; set; }
}