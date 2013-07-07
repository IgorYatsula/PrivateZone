namespace PrivateZone.Web.BL
{
    public interface IWebSecurity
    {
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
    }
}