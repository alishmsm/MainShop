using System.Security.Claims;

namespace EndPoint.Site.Helper;

public static class AuthExtension
{
    public static int GetUserId(this HttpContext context)
    {
       var claimvalue = context.User.Claims
            .Where(u => u.Type == ClaimTypes.NameIdentifier)
            .Select(u => u.Value)
            .FirstOrDefault();
       int _claimvalue = 0;
       bool res = int.TryParse(claimvalue, out _claimvalue);
       if(res == true) return _claimvalue;
       return 0;
    }
    
    public static string GetUserName(this HttpContext context)
    {
        var claimvalue = context.User.Claims
            .Where(u => u.Type == ClaimTypes.Name)
            .Select(u => u.Value)
            .FirstOrDefault();
        return claimvalue;
    }
}