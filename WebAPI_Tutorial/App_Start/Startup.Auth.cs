using Microsoft.Owin.Security.OAuth;
using System;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace WebAPI_Tutorial.App_Start
{
    public class Startup
    {
        static Startup()
        {
            PublicClientID = "self";

            UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientID, UserManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AllowInsecureHttp = true
            };
        }


        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }

        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

        public static string PublicClientID { get; private set; }

    }
}