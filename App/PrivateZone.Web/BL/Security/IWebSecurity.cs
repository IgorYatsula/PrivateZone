namespace PrivateZone.Web.BL.Security
{
    public interface IWebSecurity
    {
        void Register(string userName, string password);
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
    }
}