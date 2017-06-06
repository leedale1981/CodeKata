using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using O365APIs.Utils;
using System.IdentityModel.Tokens;

namespace ATT.Examples.O365.APIs
{
    public partial class Startup
    { 
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = SettingsHelper.ClientId,
                Authority = SettingsHelper.AzureADAuthority,
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    AuthorizationCodeReceived = (context) =>
                    {
                        string code = context.Code;

                        ClientCredential creds = new ClientCredential(SettingsHelper.ClientId, SettingsHelper.ClientSecret);
                        string userObject = context.AuthenticationTicket.Identity.FindFirst(System.IdentityModel.Claims.ClaimTypes.NameIdentifier).Value;

                        EFADALTokenCache cache = new EFADALTokenCache(userObject);
                        Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext authContext = 
                            new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(SettingsHelper.AzureADAuthority, cache);
                        Uri redirectUri = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path));
                        AuthenticationResult authResult = authContext.AcquireTokenByAuthorizationCode(code, redirectUri,
                            creds, SettingsHelper.AzureAdGraphResourceId);

                        return Task.FromResult(0);
                    },
                    AuthenticationFailed = (context) =>
                    {
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }
                },
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false
                }
            });
        }
    }
}