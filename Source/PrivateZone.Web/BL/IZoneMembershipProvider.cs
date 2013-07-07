namespace PrivateZone.Web.BL
{
    public interface IZoneMembershipProvider
    {
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
    }
}