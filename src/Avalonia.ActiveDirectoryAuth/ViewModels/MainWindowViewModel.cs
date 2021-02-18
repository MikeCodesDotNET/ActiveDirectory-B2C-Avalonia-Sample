using Avalonia.ActiveDirectoryAuth.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Avalonia.ActiveDirectoryAuth.Helpers;
using Avalonia.Controls;

namespace Avalonia.ActiveDirectoryAuth.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserInfo userInfo;
        public UserInfo UserInfo
        {
            get => userInfo;
            set => this.RaiseAndSetIfChanged(ref userInfo, value);
        }



        private string errorText;
        public string ErrorText
        {
            get => errorText;
            set => this.RaiseAndSetIfChanged(ref errorText, value);
        }

        public ICommand SignInCommand { get; private set; }

        public MainWindowViewModel()
        {
            SignInCommand = ReactiveCommand.CreateFromTask(SignIn);

            if (Design.IsDesignMode)
                UserInfo = new UserInfo() { Name = "Tom Jones", Emails = new List<string> { "tom.jones@musicmaker.ms" }, IdentityProvider = "Sample Data" };
        }

        private async Task SignIn()
        {
            AuthenticationResult authResult = null;
            var app = App.PublicClientApp;
            try
            {
                ErrorText = "";
                authResult = await app.AcquireTokenInteractive(Configuration.ApiScopes).ExecuteAsync().ConfigureAwait(false);
                UserInfo = authResult.ToUserInfo();
            }
            catch (MsalException ex)
            {
                try
                {
                    if (ex.Message.Contains("AADB2C90118"))
                    {
                        //authResult = await app.AcquireTokenInteractive(App.ApiScopes)
                        //    .WithParentActivityOrWindow(new WindowInteropHelper(this).Handle)
                        //    .WithPrompt(Prompt.SelectAccount)
                        //    .WithB2CAuthority(App.AuthorityResetPassword)
                        //    .ExecuteAsync();
                    }
                    else
                    {
                        ErrorText = $"Error Acquiring Token:    {ex}";
                    }
                }
                catch (Exception exe)
                {
                    ErrorText = $"Error Acquiring Token:    {exe}";
                }
            }
            catch (Exception ex)
            {
                ErrorText = $"Error Acquiring Token:    {ex}";
            }
        }
    }
}
