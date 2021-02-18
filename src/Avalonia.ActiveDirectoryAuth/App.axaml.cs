using Avalonia.ActiveDirectoryAuth.Helpers;
using Avalonia.ActiveDirectoryAuth.ViewModels;
using Avalonia.ActiveDirectoryAuth.Views;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Identity.Client;

namespace Avalonia.ActiveDirectoryAuth
{
    public class App : Application
    {
        public static IPublicClientApplication PublicClientApp { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(Configuration.ClientId)
                    .WithB2CAuthority(Configuration.AuthoritySignUpSignIn)
                    .WithRedirectUri(Configuration.RedirectUri)
                    .Build();
            TokenCacheHelper.Bind(PublicClientApp.UserTokenCache);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
