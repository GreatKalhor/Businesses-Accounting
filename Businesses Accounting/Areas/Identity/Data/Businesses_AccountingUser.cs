using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Businesses_Accounting.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Businesses_AccountingUser class
public class Businesses_AccountingUser : IdentityUser<Guid>
{
}
public class Businesses_AccountingRole : IdentityRole<Guid>
{
}
