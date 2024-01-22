﻿using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Businesses_Accounting.Services
{
    public class SalesmanServices : BaseServices
    {

        public SalesmanServices() : base()
        {
        }
        public SalesmanServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
    }
}
