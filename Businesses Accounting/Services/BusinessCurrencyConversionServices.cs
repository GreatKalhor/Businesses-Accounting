using Businesses_Accounting.Data;
using Businesses_Accounting.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Businesses_Accounting.Services
{
    public class BusinessCurrencyConversionServices : BaseServices
    {

        public BusinessCurrencyConversionServices() : base()
        {
        }
        public BusinessCurrencyConversionServices(BA_dbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
