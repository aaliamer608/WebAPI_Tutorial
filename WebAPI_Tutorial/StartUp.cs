//using System;
//using System.Web.Http;
//using Microsoft.Owin;
//using Microsoft.Owin.Security.OAuth;
//using Owin;

//[assembly: OwinStartup(typeof(WebAPI_Tutorial.Startup))]
//namespace WebAPI_Tutorial
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            HttpConfiguration config = new HttpConfiguration();

//            ConfigureOAuth(app);

//            WebApiConfig.Register(config);
//            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
//            app.UseWebApi(config);
//        }

//        private void ConfigureOAuth(IAppBuilder app)
//        {
//            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
//            {
//                AllowInsecureHttp = true,
//                TokenEndpointPath = new PathString("/token"),
//                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
//                Provider = new SimpleAuthorizationServerProvider()

//            };



//            app.UseOAuthAuthorizationServer(OAuthServerOptions);
//            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


//        }
//    }
//}