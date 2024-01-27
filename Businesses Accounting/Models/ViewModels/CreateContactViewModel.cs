
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Businesses_Accounting.Models.ViewModels;

public partial class CreateContactViewModel
{

    public CreateContactViewModel()
    {
        files=new List<IFormFile>();
    }
    public CreateContactViewModel(Contact contact)
    {
        files = new List<IFormFile>();
        this.Id = contact.Id;
        this.BusinessId = contact.BusinessId;
        this.IsActive = contact.IsActive;
        this.Company = contact.Company;
        this.TitleC = contact.Title;
        this.FirstName = contact.FirstName;
        this.LastName = contact.LastName;
        this.DisplayName = contact.DisplayName;
        this.CategoryId = contact.CategoryId;
        this.ImageUrl = contact.ImageUrl;
        this.IsCustomer = contact.IsCustomer;
        this.IsVendor = contact.IsVendor;
        this.IsStockholder = contact.IsStockholder;
        this.Employee = contact.Employee;
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
    public IEnumerable<IFormFile> files { get; set; }

    [Display(Name = "مشتری")]
    public bool? IsCustomer { get; set; }

    [Display(Name = "تامین کننده")]
    public bool? IsVendor { get; set; }

    [Display(Name = "سهامدار")]
    public bool? IsStockholder { get; set; }

    [Display(Name = "کارمند")]
    public bool? Employee { get; set; }

    [Display(Name = "نوع")]
    public CheckBoxGroupViewModel? Type
    {
        get
        {

            var ans = new CheckBoxGroupViewModel()
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
                        },
                        new InputGroupItemModel ()
                        {
                            Label = "کارمند",
                            Enabled = true,
                            Encoded = false,
                           // CssClass = "blue",
                            Value = "4"
                        },
                },
                CheckBoxGroupValue = new string[] {}



            };
            List<string> strings = new List<string>();
            if (this.IsCustomer != null ? this.IsCustomer.Value : false)
            {
                strings.Add("1");
            }
            if (this.IsVendor != null ? this.IsVendor.Value : false)
            {
                strings.Add("2");
            }
            if (this.IsStockholder != null ? this.IsStockholder.Value : false)
            {
                strings.Add("3");
            }
            if (this.Employee != null ? this.Employee.Value : false)
            {
                strings.Add("4");
            }
            ans .CheckBoxGroupValue=strings.ToArray ();
            return ans;
        }
    }

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