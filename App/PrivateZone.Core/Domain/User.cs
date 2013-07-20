using System;
using System.Security.Cryptography;
using System.Text;

namespace PrivateZone.Core.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}