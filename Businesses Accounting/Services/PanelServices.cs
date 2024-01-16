using Businesses_Accounting.Models;
using System.Security.Claims;
using Telerik.SvgIcons;

namespace Businesses_Accounting.Services
{
    public class PanelServices
    {

        static Dictionary<Guid, int> businessIds;
        public static int GetCurrentBusinessId(ClaimsPrincipal User)
        {
            int ans = 0;
            if (businessIds == null)
            {
                businessIds = new Dictionary<Guid, int>();
            }
            var _userId = CurrentUser.GetUserId(User);
            if (_userId is not null)
            {
                var userId = _userId.Value;
                if (businessIds.Any(x => x.Key == userId))
                {
                    ans = businessIds[userId];
                }
            }
            else
            {
            }
            return ans;
        }
        public static int SetCurrentBusinessId(ClaimsPrincipal User,int businessId)
        {
            int ans = 0;
            if (businessIds == null)
            {
                businessIds = new Dictionary<Guid, int>();
            }
            var _userId = CurrentUser.GetUserId(User);
            if (_userId is not null)
            {
                var userId = _userId.Value;
                if (businessIds.Any(x => x.Key == userId))
                {
                     businessIds[userId]= businessId;
                }
            }
            else
            {
            }
            return ans;
        }
    }
}
