using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace WebAPI_Tutorial
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // Add comment
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var requestIdentity = new ClaimsIdentity(context.Ticket.Identity);
            requestIdentity.AddClaim(new Claim("newClaim", "newValue"));
            var newTicket = new AuthenticationTicket(requestIdentity, context.Ticket.Properties);
            context.Validated(newTicket);
            return Task.FromResult<object>(null);
        }
    }
}