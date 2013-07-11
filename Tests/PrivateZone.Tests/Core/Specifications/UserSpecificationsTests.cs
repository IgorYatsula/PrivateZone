using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PrivateZone.Core.Domain;
using PrivateZone.Core.Specifications;
using SharpTestsEx;

namespace PrivateZone.Tests.Core.Specifications
{
    [TestFixture]
    public class UserSpecificationsTests
    {
        [Test]
        public void ByNameAndPassword_SatisfyingElements_ReturnsMatchedItems()
        {
            const string expectedName = "CorrectName", expectedPassword = "correct_password";
            var expectedUser = new User {Name = expectedName, Password = expectedPassword};
            var testUsers = new List<User>
                {
                    new User {Name = expectedName, Password = "unknown_password"},
                    new User {Name = "unknown_name", Password = expectedPassword},
                    expectedUser,
                    new User {Name = "unknown_password", Password = "unknown_password"}
                };
            var spec = UserSpecifications.ByNameAndPassword(expectedName, expectedPassword);

            var result = spec.SatisfyFrom(testUsers.AsQueryable());

            result.Should().Have.SameSequenceAs(new[] {expectedUser});
        }
    }
}