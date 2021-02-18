using Microsoft.Identity.Client;
using System.IO;

namespace Avalonia.ActiveDirectoryAuth.Helpers
{
    //DONT deploy this to production! 
    internal static class TokenCacheHelper
    {
        /// <summary>
        /// Path to the token cache
        /// </summary>
        public static readonly string CacheFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalcache.bin";

        private static readonly object FileLock = new object();

        public static void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (FileLock)
            {
                args.TokenCache.DeserializeMsalV3(File.Exists(CacheFilePath)
                    ? (File.ReadAllBytes(CacheFilePath))
                    : null);
            }
        }

        public static void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (args.HasStateChanged)
            {
                lock (FileLock)
                {
                    // reflect changes in the persistent store
                    File.WriteAllBytes(CacheFilePath, args.TokenCache.SerializeMsalV3());
                }
            }
        }

        internal static void Bind(ITokenCache tokenCache)
        {
            tokenCache.SetBeforeAccess(BeforeAccessNotification);
            tokenCache.SetAfterAccess(AfterAccessNotification);
        }
    }
}
