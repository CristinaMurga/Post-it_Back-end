using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pedalacom.BLogic.Encryption;
using Posti_it_web.Repository;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace Posti_it_web.Logic.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly PostItDbContext _context;

        

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, PostItDbContext context) : base(options, logger, encoder, clock)
        {
            _context = context;
        }


        private AuthenticateResult authenticationResult;
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            try
            {
                Response.Headers.Add("WWW-Authenticate", "Basic");

                if (!Request.Headers.ContainsKey("Authorization"))
                {

                    throw new InvalidOperationException("Autorizzazione mancante: Procedere con l'autenticazione");

                }

                var authorizationHeader = Request.Headers["Authorization"].ToString();

                var authorizationRegEx = new Regex(@"Basic (.*)");

                if (!authorizationRegEx.IsMatch(authorizationHeader))
                {
                    throw new InvalidOperationException("Autorizzazione non valida : tipologia autorizazione non valida");
                }

                var authorizationBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationRegEx.Replace(authorizationHeader, "$1")));

                var authorizationSplit = authorizationBase64.Split(':', 2);

                if (authorizationSplit.Length != 2)
                {
                    throw new InvalidOperationException("Autorizzazione non valida : credenziali non complete");
                }

                var username = authorizationSplit[0];
                var password = authorizationSplit[1];


                // Verifica nel database
                var user = await _context.Users
                    .Where(c => c.Username.ToLower() == username.ToLower())
                    .FirstOrDefaultAsync();
             


                DecryptSalt decryptSalt = new();

                if (user == null || !decryptSalt.DecryptSaltCredential(user, password))
                {
                    throw new InvalidOperationException("Autorizzazione non valida : utente non registrato");
                }
                var authenticationUser = new AuthenticationUser(username, "BasicAuthentication", true);
                var claims = new ClaimsPrincipal(new ClaimsIdentity(authenticationUser));

                authenticationResult = AuthenticateResult.Success(new AuthenticationTicket(claims, "BasicAuthentication"));
                return authenticationResult;
            }
            catch (Exception ex)
            {
                
                authenticationResult = AuthenticateResult.Fail($"Errore : {ex.Message}");
                return authenticationResult;

            }
        }
    }
}
