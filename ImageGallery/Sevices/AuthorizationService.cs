using ImageGallery.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ImageGallery.Sevices
{
    public class AuthorizationService : IAuthorizationService, IJWTokenService
    {
        private readonly ICRUDService<UserModel> _userCRUDService;

        public AuthorizationService(ICRUDService<UserModel> userCRUDService)
        {
            _userCRUDService = userCRUDService;
        }

        public TokenModel LogIn(UserModel model)
        {

            return Token(model.Email, model.Password);
        }

        public TokenModel Registration(UserModel user)
        {
            var model = _userCRUDService.CreateOrUpdate(user);

            return Token(model.Email, model.Password);
        }

        public TokenModel Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new TokenModel()
            {
                AccessToken = encodedJwt,
                Username = identity.Name
            };

            return response;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            UserModel user = _userCRUDService.GetAll().FirstOrDefault(x => x.Email.ToLower().Equals(username.ToLower()));
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
