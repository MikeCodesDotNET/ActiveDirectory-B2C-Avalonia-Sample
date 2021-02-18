using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.ActiveDirectoryAuth
{
    internal static class Configuration
    {
        internal static readonly string TenantName = "Update_This_Value";
        internal static readonly string ClientId = "Update_This_Value";


        internal static readonly string Tenant = $"{TenantName}.onmicrosoft.com";
        internal static readonly string AzureAdB2CHostname = $"{TenantName}.b2clogin.com";

        internal static readonly string RedirectUri = "http://localhost:";

        internal static string[] ApiScopes = { "offline_access" };

        internal static string PolicySignUpSignIn = "B2C_1_SignUp_SignIn";

        internal static string AuthorityBase = $"https://{AzureAdB2CHostname}/tfp/{Tenant}/";
        internal static string AuthoritySignUpSignIn = $"{AuthorityBase}{PolicySignUpSignIn}";


    }
}
