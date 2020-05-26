﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class AuthOptions
    {
        public static string Issuer => "TM";
        public static string Audience => "APIclients";
        public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSecretKey_CoVid19"));

        internal static string GenerateToken(bool is_admin = false)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>
{
new Claim(ClaimsIdentity.DefaultNameClaimType, "user"),
new Claim(ClaimsIdentity.DefaultRoleClaimType, is_admin?"admin":"guest")
};
            ClaimsIdentity identity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            notBefore: now,
            expires: now.AddYears(1),
            claims: identity.Claims,
            signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)); ;
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
