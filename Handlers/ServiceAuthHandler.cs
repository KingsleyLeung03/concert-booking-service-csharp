using concert_booking_service_csharp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace concert_booking_service_csharp.Handlers
{
    public class ServiceAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IServiceRepo _repository;

        public ServiceAuthHandler(
            IServiceRepo repository,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
            _repository = repository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                Response.Headers.Append("WWW-Authenticate", "Basic");
                return AuthenticateResult.Fail("Authorization header not found.");
            }
            else
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var username = credentials[0];
                var password = credentials[1];

                if (_repository.ValidUserLogin(username, password))
                {
                    var claims = new[] { new Claim("user", username) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else if (_repository.ValidAdminLogin(username, password))
                {
                    var claims = new[] { new Claim("admin", username) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                Response.Headers.Append("WWW-Authenticate", "Basic");
                return AuthenticateResult.Fail("username and password do not match");
            }
        }
    }
}
