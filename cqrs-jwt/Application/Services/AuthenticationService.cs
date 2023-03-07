using Application.Commands;
using Application.Common.Interfaces;
using Application.Options;
using Application.Responses;
using CryptoHashVerify;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IIdentity _identity;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(IIdentity identity, JwtSettings jwtSettings)
        {
            _identity = identity;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginCommand user)
        {
            var existingUser = await _identity.FindUserByIdAsync(user.UserId);

            if (existingUser == null)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "Username / password incorrect" }
                };
            }

            if (!CheckPasswordAsync(existingUser.Password, existingUser.Salt, user.Password))
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "Username / password incorrect" }
                };
            }

            return await GenerateAuthenticationResponseForUserAsync(existingUser);
        }

        public async Task<AuthenticationResponse> RegisterAsync(CreateUserCommand user)
        {
            var existingUser = await _identity.FindUserByIdAsync(user.UserId);

            if (existingUser != null)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "User with this user id already exists" }
                };
            }

            var (password, salt) = GenerateHashPasswordAndSalt(password: user.Password);

            var result = await _identity
                .CreateUserAsync(new User { UserId = user.UserId, Password = password, Salt = salt, Role = user.Role });

            if (!result)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "Unable to create user" }
                };
            }

            var newUser = await _identity.FindUserByIdAsync(user.UserId);

            return await GenerateAuthenticationResponseForUserAsync(newUser);
        }

        private bool CheckPasswordAsync(string hashPassword, string salt, string password)
        {
            return HashVerify.VerifyHashString(hashPassword, salt, password);
        }

        private Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Role, user.Role),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("id", user.Id.ToString()),
               new Claim("userId", user.UserId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "http://dev.chandu.com",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthenticationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }

        private (string, string) GenerateHashPasswordAndSalt(string password)
        {
            return HashVerify.GenerateHashString(password);
        }
    }
}
