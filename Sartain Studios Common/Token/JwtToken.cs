using Microsoft.IdentityModel.Tokens;
using Sartain_Studios_Common.Interfaces.Token;
using SharedModels;
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

        public string GenerateToken(UserModel userModel = null)
        {
            return GenerateJwtToken(_jwtSecret, _jwtExpirationInMinutes, userModel);
        }

        public static string GenerateJwtToken(string jwtSecret, int jwtExpirationInMinutes, UserModel userModel = null)
        {
            return new JwtSecurityTokenHandler().WriteToken(CreateJwtToken(jwtSecret, jwtExpirationInMinutes, userModel));
        }

        private static JwtSecurityToken CreateJwtToken(string jwtSecret, int jwtExpirationInMinutes, UserModel userModel = null)
        {
            return new JwtSecurityToken(GetJwtHeader(jwtSecret), GetJwtPayload(jwtExpirationInMinutes, userModel));
        }

        private static JwtHeader GetJwtHeader(string jwtSecret)
        {
            return new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)), SecurityAlgorithms.HmacSha256));
        }

        private static JwtPayload GetJwtPayload(int jwtExpirationInMinutes, UserModel userModel = null)
        {
            return new JwtPayload(CreateJwtClaims(jwtExpirationInMinutes, userModel));
        }

        private static IEnumerable<Claim> CreateJwtClaims(int jwtExpirationInMinutes, UserModel userModel = null)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, userModel.Username?? "No name found"),
                new Claim(JwtRegisteredClaimNames.GivenName, userModel.FirstName +" "+ userModel.Lastname?? "No name given"),
                new Claim(JwtRegisteredClaimNames.NameId, userModel.Id.ToString() ?? "No user id found"),
                new Claim(JwtRegisteredClaimNames.FamilyName, userModel.ProfilePhoto??"No profile photo found"),
                new Claim(JwtRegisteredClaimNames.Email, userModel.Email ?? "No email found"),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddMinutes(jwtExpirationInMinutes)).ToUnixTimeSeconds().ToString())
            };
        }
    }
}
