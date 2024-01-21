﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Businesses_Accounting.Models.ViewModels;

public partial class CreatBusinessServiceViewModel
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    [Display(Name = "عنوان خدمات")]
    public string Name { get; set; }
    [Display(Name = "فعال")]
    public bool IsActive { get; set; } = true;
    [Display(Name = "کد کالا")]
    public string ProductCode { get; set; }
    [Display(Name = "بارکد")]
    public string Barcode { get; set; }
    [Display(Name = "دسته بندی")]
    public int CategoryId { get; set; }

    public int SalesPrice { get; set; }

    public string SalesInformation { get; set; }

    public int PurchaseCost { get; set; }

    public string PurchaseInformation { get; set; }

    public string MainUnit { get; set; }
    [Display(Name = "توضیحات")]

    public string Note { get; set; }

    public string SubUnit { get; set; }

    public int UnitConversionFactor { get; set; }

    public bool SalesTaxable { get; set; }

    public int SalesTax { get; set; }

    public bool PurchaseTaxable { get; set; }

    public int PurchaseTax { get; set; }

    public int TaxId { get; set; }

    public int TaxUnitId { get; set; }

    public int IranianTaxTypeId { get; set; }

    public string ImageUrl { get; set; }
}