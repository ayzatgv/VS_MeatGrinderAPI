using MeatGrinderAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MeatGrinderAPI.Helpers
{
    public class MyToken
    {
        private static readonly string _secretkey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string TokenGeneration(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.Role_Name.ToString()));
            claimsIdentity.AddClaim(new Claim("roleid", user.Role.ID.ToString()));

            var token = tokenHandler.CreateJwtSecurityToken(subject: claimsIdentity, signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.Default.GetBytes(_secretkey)), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey)),
                RequireExpirationTime = false,
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.FromMilliseconds(100)
            };
        }

        public static ClaimsPrincipal TokenDecryption(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            ClaimsPrincipal claimsPrincipal;

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return null;
            }

            return claimsPrincipal;
        }

        public static int GetUserID(string token)
        {
            ClaimsPrincipal claimsPrincipal = TokenDecryption(token);

            return Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        public static int GetRoleID(string token)
        {
            ClaimsPrincipal claimsPrincipal = TokenDecryption(token);

            return Convert.ToInt32(claimsPrincipal.Claims.Where(c => c.Type == "roleid").Single().Value);
        }

        public static string GetUsername(string token)
        {
            ClaimsPrincipal claimsPrincipal = TokenDecryption(token);

            return claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }
    }
}