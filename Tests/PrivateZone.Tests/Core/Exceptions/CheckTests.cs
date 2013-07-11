using System;
using NUnit.Framework;
using PrivateZone.Core.Exceptions;
using SharpTestsEx;

namespace PrivateZone.Tests.Core.Exceptions
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void Require_AssertionIsTrue_NotThrowsException()
        {
            Executing
                .This(() => Check.Require<ArgumentNullException>(true, "inner"))
                .Should().NotThrow();
        }

        [Test]
        public void Require_AssertionIsFalse_ThrowsExceptionWithMessage()
        {
            var excMsg = "Precondition failed!";

            Executing
                 .This(() => Check.Require<ArgumentNullException>(false, excMsg))
                 .Should()
                     .Throw<ArgumentNullException>()
                     .And.Exception.Message.Should().Contain(excMsg);
        }
    }
}
