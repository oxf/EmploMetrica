using EmploMetrica.Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EmploMetrica.Infrastructure
{
    public class JwtAuthService(IConfiguration _config,
        IOptionsMonitor<JwtBearerOptions> _jwtBearerOptions) : IAuthTokenService
    {
        public string GenerateAccessToken(int UserId)
        {
            var TokenHandler = new JwtSecurityTokenHandler();

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Jwt:Issuer"],
                Issuer = _config["Jwt:Issuer"],
                Subject = new ClaimsIdentity(new[] { new Claim("Id", UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(5), // Token expiration time
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }

        public string GenerateRefreshToken(int UserId)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            var claims = new[]
            {
                new Claim("Id", UserId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Jwt:Issuer"],
                Issuer = _config["Jwt:Issuer"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Example: Refresh token expiration time (e.g., 7 days)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateAccessTokenFromRefreshToken(string RefreshToken)
        {
            var refreshTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtOptions = _jwtBearerOptions.Get(JwtBearerDefaults.AuthenticationScheme);
                // Validate the refresh token using global token validation parameters
                var principal = refreshTokenHandler.ValidateToken(RefreshToken, jwtOptions.TokenValidationParameters, out var validatedToken);

                // Extract user ID from the refresh token's claims
                var userIdClaim = principal.FindFirst("Id");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    throw new SecurityTokenException("Invalid refresh token. User ID claim is missing or invalid.");
                }
                // Retrieve user information from the database (if needed)
                // Generate a new access token for the user
                var accessToken = GenerateAccessToken(userId);

                return accessToken;
            }
            catch (Exception ex)
            {
                // Handle token validation errors
                Console.WriteLine($"Failed to generate access token from refresh token: {ex.Message}");
                return null;
            }
        }
    }
}
