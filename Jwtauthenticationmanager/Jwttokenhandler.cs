using Jwtauthenticationmanager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwtauthenticationmanager
{
    public class Jwttokenhandler
    {
        public const string JWT_SECURITY_KEY = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kwq5R2Nmf4FWs03Hdx";
        private const int JWT_TOKEN_VALIDITY_MINS = 30;

        public Authenticationresponse? Generatejwttoken(Authenticationrequest request)
        {
            var Tokenexpirytimestamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var Tokenkey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var Claimidentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,request.Username),
                new Claim(ClaimTypes.Role,"")
            });
            var Signingcredentials = new SigningCredentials(
                new SymmetricSecurityKey(Tokenkey),
                SecurityAlgorithms.HmacSha256Signature
                );
            var Securitytokendescriptor = new SecurityTokenDescriptor
            {
                Subject = Claimidentity,
                Expires = Tokenexpirytimestamp,
                SigningCredentials = Signingcredentials
            };
            var Jwtsecuritytokenhandler = new JwtSecurityTokenHandler();
            var Securitytoken = Jwtsecuritytokenhandler.CreateToken(Securitytokendescriptor);
            var Token = Jwtsecuritytokenhandler.WriteToken(Securitytoken);

            return new Authenticationresponse
            {
                Username = request.Username,
                Expiresin = (int)Tokenexpirytimestamp.Subtract(DateTime.Now).TotalSeconds,
                Jwttoken = Token,
            };
        }
    }
}
