using System.Collections.Generic;

namespace Avalonia.ActiveDirectoryAuth.Models
{
    public class UserInfo
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string JobTitle { get; set; }

        public List<string> Emails { get; set; }

        public string Alias { get; set; }


        public string IdentityProvider { get; set; }

        public UserInfo()
        {
            Emails = new List<string>();
        }
    }
}
