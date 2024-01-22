﻿using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class BusinessProjectServices : BaseServices
    {

        public BusinessProjectServices() : base()
        {
        }
        public BusinessProjectServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
