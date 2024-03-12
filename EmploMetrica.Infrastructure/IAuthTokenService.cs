using EmploMetrica.Domain.Users;

namespace EmploMetrica.Infrastructure
{
    public interface IAuthTokenService
    {
        public string GenerateAccessToken(int UserId);
        public string GenerateRefreshToken(int UserId);
        public string GenerateAccessTokenFromRefreshToken(string RefreshToken);
    }
}
