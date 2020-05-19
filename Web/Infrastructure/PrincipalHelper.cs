using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UtilityLib.Helpers;

namespace Web.Infrastructure
{
    public class PrincipalHelper
    {
        public static UserPrincipal GetUserPrincipal()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return (UserPrincipal)HttpContext.Current.User;
            }

            return null;
        }
    }
}
