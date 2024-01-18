using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Businesses_Accounting.Controllers
{
    [Authorize]
    [GreatAttribute(true)]

    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

  
    }
}
