using WebMatrix.WebData;

namespace PrivateZone.Web.BL.Security
{
    public class SecurityService : IWebSecurity
    {
        public bool Login(string userName, string password, bool persistCookie = false)
        {
            return WebSecurity.Login(userName, password, persistCookie);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }
    }
}