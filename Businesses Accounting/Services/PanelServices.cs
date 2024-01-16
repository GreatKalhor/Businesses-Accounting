using Businesses_Accounting.Models;
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
        public UIBIBFYISviewModel(string selected)
        {
            var split = selected.Split(new string[] { "BAapp" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i++)
            {
                var splitItem = split[i];
                if (i == 0)
                {
                    int.TryParse(splitItem, out int bi);
                    BusinessId = bi;
                }
                else if (i == 1)
                {
                    Guid.TryParse(splitItem, out Guid ui);
                    UserId = ui;
                }
                else if (i == 2)
                {
                    int.TryParse(splitItem, out int bfyi);
                    BusinessFiscalYearId = bfyi;
                }
            }
        }
        public int BusinessId { get; set; }
        public int BusinessFiscalYearId { get; set; }
        public Guid UserId { get; set; }

    }
    public static class PanelServices
    {
        public static string toString(this UIBIBFYISviewModel helper)
        {
            return string.Format("{0}BAapp{1}BAapp{2}", helper.BusinessId, helper.UserId, helper.BusinessFiscalYearId);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this string txt)
        {
            return new UIBIBFYISviewModel(txt);
        }
        public static UIBIBFYISviewModel ToPanelViewModel(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            var sss = context.Request.RouteValues["ubis"];
            return new UIBIBFYISviewModel(sss is not null ? (string)sss : "");
        }
        public static string GenerateUBselected(Guid userId, int businessId, int businessfiscalyearId)
        {
            return new UIBIBFYISviewModel(userId, businessId, businessfiscalyearId).toString();
        }
        // public static UIBIBFYISviewModel GetPanelViewModel()
    }
}
