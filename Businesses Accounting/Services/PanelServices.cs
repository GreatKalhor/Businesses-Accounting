using Azure.Core;
using Businesses_Accounting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Telerik.SvgIcons;

namespace Businesses_Accounting.Services
{
    public class UIBIBFYISviewModel
    {
        public UIBIBFYISviewModel()
        {

        }
        public UIBIBFYISviewModel(Guid userId, int businessId, int businessfiscalyearId)
        {
            UserId = userId;
            BusinessId = businessId; BusinessFiscalYearId = businessfiscalyearId;
        }
        public UIBIBFYISviewModel(string selected, Guid? userid, bool ckackdatabase)
        {
            var split = selected.Split(new string[] { "BAapp" }, StringSplitOptions.RemoveEmptyEntries);
            bool badparam = false;
            for (int i = 0; i < split.Length; i++)
            {
                var splitItem = split[i];
                if (i == 0)
                {
                    int.TryParse(splitItem, out int bi);
                    BusinessId = bi;
                    badparam = (bi == 0);
                }
                else if (i == 1)
                {
                    Guid.TryParse(splitItem, out Guid ui);
                    UserId = ui;
                    badparam = (ui != userid);

                }
                else if (i == 2)
                {
                    int.TryParse(splitItem, out int bfyi);
                    BusinessFiscalYearId = bfyi;
                    badparam = (bfyi == 0);

                }
                if (badparam)
                {
                    break;
                }
            }
            bool businessIdOnDataBase = true;
            bool businessFiscalYearIdOnDataBase = true;
            if (ckackdatabase)
            {
                using (Data.BA_dbContext _context = new Data.BA_dbContext())
                {
                    using (BusinessServices bs = new BusinessServices(_context))
                    {
                        var bss = bs.GetBusinessWithUser(userid).Result;
                        businessIdOnDataBase=!(bss == null ||(bss!=null && !bss.Any(x => x.Id == BusinessId)));
                        if (businessIdOnDataBase)
                        {
                            using (BusinessFiscalYearServices bfys = new BusinessFiscalYearServices(_context))
                            {
                                var bfyss =  bfys.GetWithBusinessId(BusinessId).Result;
                                businessFiscalYearIdOnDataBase = !(bfyss == null || (bfyss != null && bfyss.Id != BusinessFiscalYearId));
                            } 
                        }
                    }
                }

            }
            _valid = !((BusinessId == 0) || (UserId != userid) || (BusinessFiscalYearId == 0) || !businessIdOnDataBase || !businessFiscalYearIdOnDataBase);
        }
        public int BusinessId { get; set; }
        public int BusinessFiscalYearId { get; set; }
        public Guid UserId { get; set; }

        private bool _valid;

        public bool IsValid
        {
            get { return _valid; }
            set { _valid = value; }
        }


    }
    public static class PanelServices
    {
        public static string toString(this UIBIBFYISviewModel helper)
        {
            return string.Format("{0}BAapp{1}BAapp{2}", helper.BusinessId, helper.UserId, helper.BusinessFiscalYearId);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this string txt)
        {
            return txt.ToPanelViewModel(null);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this string txt, Guid? userId)
        {
            return txt.ToPanelViewModel(null, false);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this string txt, Guid? userId, bool ckackdatabase)
        {
            return new UIBIBFYISviewModel(txt, userId, ckackdatabase);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            return context.ToPanelViewModel(false);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this Microsoft.AspNetCore.Http.HttpContext context, bool ckackdatabase)
        {
            var sss = context.Request.RouteValues["ubis"];
            return new UIBIBFYISviewModel(sss is not null ? (string)sss : "", CurrentUser.GetUserId(context.User), ckackdatabase);
        }
        public static string GenerateUBselected(Guid userId, int businessId, int businessfiscalyearId)
        {
            return new UIBIBFYISviewModel(userId, businessId, businessfiscalyearId).toString();
        }

        public static List<Enum> GetEnumAllValues<T>()
        {
            List<Enum> ans = new List<Enum>();
            foreach (Enum i in Enum.GetValues(typeof(T)))
            {
                ans.Add(i);
            }
            return ans;
        }

        public static List<SelectListItem> EnumToSelectListItem<T>()
        {

            List<SelectListItem> ans = new List<SelectListItem>();
            foreach (var item in GetEnumAllValues<T>())
            {
                object val = Convert.ChangeType(item, item.GetTypeCode());
                ans.Add(new SelectListItem { Value = (val).ToString(), Text = item.GetDescription() });
            }
            return ans;
        }
    }
}
