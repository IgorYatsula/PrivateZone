using PrivateZone.Core.Domain;
using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Core.Specifications
{
    public static class UserSpecifications
    {
        public static ISpecification<User> ByNameAndPassword(string name, string password)
        {
            return new QuerySpecification<User>(user => user.Name == name && user.Password == password);
        }
    }
}