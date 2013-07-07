namespace PrivateZone.Web.BL.Security
{
    public interface IZoneMembershipProvider
    {
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
    }
}