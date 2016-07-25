using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Client.Api.Authentication
{
    public class AuthConfiguration
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; set; }

        static AuthConfiguration()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                AllowInsecureHttp = false,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(15),
                AuthorizeEndpointPath = new PathString("/api/user/externalsignin")
            };

            OAuthBearerOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = OAuthOptions.AuthenticationType,
                AuthenticationMode = OAuthOptions.AuthenticationMode,
                AccessTokenFormat = OAuthOptions.AccessTokenFormat,
                AccessTokenProvider = OAuthOptions.AccessTokenProvider,
                Description = OAuthOptions.Description,
                SystemClock = OAuthOptions.SystemClock
            };
        }

        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}