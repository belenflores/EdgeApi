using Microsoft.IdentityModel.Tokens;
using EdgeApi.POCO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace EdgeApi_API.JWT
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        public readonly string Key;
        public JWTAuthenticationManager(string key) 
        {
            this.Key = key;
        }

        public string Authenticate(Credentials credentials)
        {
 

            //I know we should not save pass in db, i need a little more time to implement something better :)
            //if (!db.Users.Where(x => x.UserName == credentials.UserName && x.Password == credentials.Password).Any())
            if (credentials.UserName != "edge" || credentials.Password != "Pa$$w0rd")
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(this.Key);

            //token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,credentials.UserName)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials =  new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
