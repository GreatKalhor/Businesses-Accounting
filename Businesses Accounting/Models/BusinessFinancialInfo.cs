﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class BusinessFinancialInfo
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public int InventoryAccountingSystem { get; set; }

    public bool HasMultiCurrency { get; set; }

    public bool HasWarehouseManagement { get; set; }

    public int MainCurrencyId { get; set; }

    public int CalendarId { get; set; }

    public int ValueAddedTaxRate { get; set; }

    public virtual Business Business { get; set; }
}