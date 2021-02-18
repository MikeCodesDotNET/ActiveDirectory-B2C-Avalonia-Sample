using Avalonia.ActiveDirectoryAuth.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;

namespace Avalonia.ActiveDirectoryAuth.Helpers
{
    internal static class AuthenticationResultHelper
    {
        public static UserInfo ToUserInfo(this AuthenticationResult authResult)
        {
            if (authResult != null)
            {
                var userInfo = new UserInfo();
                JObject user = ParseIdToken(authResult.IdToken);

                userInfo.Name = user["name"]?.ToString();
                userInfo.UserId = user["oid"]?.ToString();
                userInfo.Street = user["streetAddress"]?.ToString();
                userInfo.City = user["city"]?.ToString();
                userInfo.State = user["state"]?.ToString();
                userInfo.Country = user["country"]?.ToString();
                userInfo.JobTitle = user["jobTitle"]?.ToString();
                userInfo.Alias = user["alias"]?.ToString();


                if (user["emails"] is JArray emails)
                {
                    userInfo.Emails.Add(emails[0].ToString());
                }
                userInfo.IdentityProvider = user["iss"]?.ToString();
                return userInfo;
            }
            return null;
        }

        static JObject ParseIdToken(string idToken)
        {
            // Parse the idToken to get user info
            idToken = idToken.Split('.')[1];
            idToken = Base64UrlDecode(idToken);
            return JObject.Parse(idToken);
        }

        static string Base64UrlDecode(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(s);
            var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
            return decoded;
        }
    }
}
