namespace PrivateZone.Web.BL.Security
{
    public interface IWebSecurity
    {
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
    }
}