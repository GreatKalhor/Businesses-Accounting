﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Businesses_Accounting.Models;

public partial class Stockholder
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int Percent { get; set; }

    public virtual Contact Contact { get; set; }
}