﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class ContactBankAccountInfo
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public string Bank { get; set; }

    public string AccountNumber { get; set; }

    public string CardNumber { get; set; }

    public string Iban { get; set; }

    public virtual Contact Contact { get; set; }
}