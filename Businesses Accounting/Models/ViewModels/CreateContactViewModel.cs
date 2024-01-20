
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Businesses_Accounting.Models.ViewModels;

public partial class CreateContactViewModel
{
    public CreateContactViewModel()
    {
        Type = new CheckBoxGroupViewModel()
        {
            Items = new List<Kendo.Mvc.UI.IInputGroupItem>()
        {
            new InputGroupItemModel ()
                {
                    Label = "مشتری",
                    Enabled = true,
                    Encoded = false,
                // CssClass = "blue",
                    Value = "1"
                },
            new InputGroupItemModel ()
                {
                    Label = "تامین کننده",
                    Enabled = true,
                    Encoded = false,
                   // CssClass = "blue",
                    Value = "2"
                },
           new InputGroupItemModel ()
    {
        Label = "سهامدار",
        Enabled = true,
        Encoded = false,
       // CssClass = "blue",
        Value = "3"
    },new InputGroupItemModel ()
    {
        Label = "کارمند",
        Enabled = true,
        Encoded = false,
       // CssClass = "blue",
        Value = "4"
    },
        },
            CheckBoxGroupValue = new string[] { "1", "2", "3", "4" }
        };
    }
    public int Id { get; set; }

    [Display(Name = "کسب و کار")]
    public int BusinessId { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "شرکت")]
    public string? Company { get; set; }

    [Display(Name = "عنوان")]
    public string? TitleC { get; set; }

    [Display(Name = "نام")]
    public string? FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string? LastName { get; set; }

    [Display(Name = "نام مستعار")]
    public string DisplayName { get; set; }

    [Display(Name = "دسته بندی")]
    public int CategoryId { get; set; }

    [Display(Name = "تصویر")]
    public string? ImageUrl { get; set; } = " ";

    [Display(Name = "مشتری")]
    public bool? IsCustomer { get; set; }

    [Display(Name = "تامین کننده")]
    public bool? IsVendor { get; set; }

    [Display(Name = "سهامدار")]
    public bool? IsStockholder { get; set; }

    [Display(Name = "کارمند")]
    public bool? Employee { get; set; }

    [Display(Name = "نوع")]
    public CheckBoxGroupViewModel? Type { get; set; }

    public Contact ToContact()
    {
        Contact ans = new Contact()
        {
            Id = this.Id,
            BusinessId = this.BusinessId,
            IsActive = this.IsActive,
            Company = this.Company,
            Title = this.TitleC,
            FirstName = this.FirstName,
            LastName = this.LastName,
            DisplayName = this.DisplayName,
            CategoryId = this.CategoryId,
            ImageUrl = this.ImageUrl,
            IsCustomer = this.IsCustomer != null ? this.IsCustomer.Value : false,
            IsVendor = this.IsVendor != null ? this.IsVendor.Value : false,
            IsStockholder = this.IsStockholder != null ? this.IsStockholder.Value : false,
            Employee = this.Employee != null ? this.Employee.Value : false,
        };
        return ans;
    }

}