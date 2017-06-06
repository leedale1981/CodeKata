using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ATT.Examples.O365.APIs.Models;
using Microsoft.Owin.Security.OpenIdConnect;
using O365APIs.Utils;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;

namespace ATT.Examples.O365.APIs.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
                {
                    RedirectUri = "/"
                }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public void SignOut()
        {
            string userObjectId = ClaimsPrincipal.Current.FindFirst(SettingsHelper.ClaimTypeObjectIdentifier).Value;
            AuthenticationContext authContext = new AuthenticationContext(SettingsHelper.AzureADAuthority,
                new EFADALTokenCache(userObjectId));

            authContext.TokenCache.Clear();
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

        }

        public ActionResult ConsentApp()
        {
            string strResource = Request.QueryString["resource"];
            string strRedirectController = Request.QueryString["redirect"];

            string authorizationRequest = String.Format(
                "{0}oauth2/authorize?response_type=code&client_id={1}&resource={2}&redirect_uri={3}",
                    Uri.EscapeDataString(SettingsHelper.AzureADAuthority),
                    Uri.EscapeDataString(SettingsHelper.ClientId),
                    Uri.EscapeDataString(strResource),
                    Uri.EscapeDataString(String.Format("{0}/{1}", this.Request.Url.GetLeftPart(UriPartial.Authority), strRedirectController))
                    );

            return new RedirectResult(authorizationRequest);
        }

        public ActionResult AdminConsentApp()
        {
            string strResource = Request.QueryString["resource"];
            string strRedirectController = Request.QueryString["redirect"];

            string authorizationRequest = String.Format(
                "{0}oauth2/authorize?response_type=code&client_id={1}&resource={2}&redirect_uri={3}&prompt={4}",
                    Uri.EscapeDataString(SettingsHelper.AzureADAuthority),
                    Uri.EscapeDataString(SettingsHelper.ClientId),
                    Uri.EscapeDataString(strResource),
                    Uri.EscapeDataString(String.Format("{0}/{1}", this.Request.Url.GetLeftPart(UriPartial.Authority), strRedirectController)),
                    Uri.EscapeDataString("admin_consent")
                    );

            return new RedirectResult(authorizationRequest);

        }
    }
}