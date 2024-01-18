
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Businesses_Accounting.Models.ViewModels;

public partial class CreateContactViewModel
{
    public int Id { get; set; }

    [Display(Name = "کسب و کار")]
    public int BusinessId { get; set; }

    [Display(Name = "فعال")]
    public bool IsActive { get; set; }

    [Display(Name = "شرکت")]
    public string Company { get; set; }

    [Display(Name = "عنوان")]
    public string TitleC { get; set; }

    [Display(Name = "نام")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; }

    [Display(Name = "نام مستعار")]
    public string DisplayName { get; set; }

    [Display(Name = "دسته بندی")]
    public int CategoryId { get; set; }

    [Display(Name = "تصویر")]
    public string ImageUrl { get; set; }

    [Display(Name = "مشتری")]
    public bool IsCustomer { get; set; }

    [Display(Name = "تامین کننده")]
    public bool IsVendor { get; set; }

    [Display(Name = "سهامدار")]
    public bool IsStockholder { get; set; }

    [Display(Name = "کارمند")]
    public bool Employee { get; set; }

    [Display(Name = "نوع")]
    public CheckBoxGroupViewModel Type { get; set; }

}