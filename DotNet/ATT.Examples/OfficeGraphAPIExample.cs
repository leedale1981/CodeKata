using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationContext context = new AuthenticationContext("https://login.microsoftonline.com/4d2e09c3-d0cf-4bdb-a78e-fe439a99fb82");
            ClientCredential creds = new ClientCredential(
                "c39d59ae-f903-49fd-8566-11aef3652a7c",
                "8fnJoz2sWR5AZYUgLrsw2OhKd1ryGUSdrsRFsD8hIuY=");

            string resource = "https://graph.microsoft.com";
            AuthenticationResult authenticationResult = context.AcquireTokenAsync(resource, creds).Result;
            string token = authenticationResult.AccessToken;

            GraphServiceClient client = new GraphServiceClient(
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                new DelegateAuthenticationProvider(async (requestMessage) =>
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                }));
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

            User me = client.Me.Request().Select("mail,userPrincipleName").GetAsync().Result;
            Console.WriteLine(me.Mail ?? me.UserPrincipalName);
        }
    }
}
