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
            if (userModel == null) userModel = new UserModel();

            if (userModel.Username == null) userModel.Username = "No name found";
            if (userModel.FirstName == null) userModel.FirstName = "No first name given";
            if (userModel.Lastname == null) userModel.Lastname = "No last name found";
            if (userModel.Id == null) userModel.Id = "No user id found";
            if (userModel.ProfilePhoto == null) userModel.ProfilePhoto = "No profile photo found";
            if (userModel.Email == null) userModel.Email = "No email found";

            return new[]
            {
                new Claim(ClaimTypes.Name, userModel.Username),
                new Claim(JwtRegisteredClaimNames.GivenName, userModel.FirstName +" "+ userModel.Lastname),
                new Claim(JwtRegisteredClaimNames.NameId, userModel.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, userModel.ProfilePhoto),
                new Claim(JwtRegisteredClaimNames.Email, userModel.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddMinutes(jwtExpirationInMinutes)).ToUnixTimeSeconds().ToString())
            };
        }
    }
}
