using System.Security.Claims;
using System.Security.Principal;

namespace ToLearningCloud.Infra.CrossCutting.Identity.Configuration
{
    public static class IdentityExtensions
    {

        public static string GetInfoUser(this IPrincipal user, string claimName)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    foreach (var claim in claimsIdentity.Claims)
                    {
                        if (claim.Type == claimName)
                            return claim.Value;
                    }
                }
                return "";
            }
            else
                return "";
        }



        //public static string GetFullName(this IPrincipal user)
        //{
        //    if (user.Identity.IsAuthenticated)
        //    {
        //        var claimsIdentity = user.Identity as ClaimsIdentity;
        //        if (claimsIdentity != null)
        //        {
        //            foreach (var claim in claimsIdentity.Claims)
        //            {
        //                if (claim.Type == "FullName")
        //                    return claim.Value;
        //            }
        //        }
        //        return "";
        //    }
        //    else
        //        return "";
        //}


    }
}
