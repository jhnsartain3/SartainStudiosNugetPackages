using Microsoft.IdentityModel.Tokens;
using Sartain_Studios_Common.Interfaces.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sartain_Studios_Common.Token
{
    public class JwtToken : IToken
    {
        private static string _jwtSecret;
        private static int _jwtExpirationInMinutes;

        public JwtToken(string jwtSecret, int jwtExpirationInMinutes)
        {
            _jwtSecret = jwtSecret;
            _jwtExpirationInMinutes = jwtExpirationInMinutes;
        }

        public string GenerateToken()
        {
            return GenerateJwtToken(_jwtSecret, _jwtExpirationInMinutes);
        }

        public static string GenerateJwtToken(string jwtSecret, int jwtExpirationInMinutes)
        {
            return new JwtSecurityTokenHandler().WriteToken(CreateJwtToken(jwtSecret, jwtExpirationInMinutes));
        }

        private static JwtSecurityToken CreateJwtToken(string jwtSecret, int jwtExpirationInMinutes)
        {
            return new JwtSecurityToken(GetJwtHeader(jwtSecret), GetJwtPayload(jwtExpirationInMinutes));
        }

        private static JwtHeader GetJwtHeader(string jwtSecret)
        {
            return new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)), SecurityAlgorithms.HmacSha256));
        }

        private static JwtPayload GetJwtPayload(int jwtExpirationInMinutes)
        {
            return new JwtPayload(CreateJwtClaims(jwtExpirationInMinutes));
        }

        private static IEnumerable<Claim> CreateJwtClaims(int jwtExpirationInMinutes)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddMinutes(jwtExpirationInMinutes)).ToUnixTimeSeconds().ToString())
            };
        }
    }
}
