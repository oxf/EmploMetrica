using AutoMapper;
using EmploMetrica.Application.UseCases.Users;
using EmploMetrica.Domain.Shared;
using EmploMetrica.Domain.Users;
using EmploMetrica.Infrastructure.Interfaces.Authentication;
using EmploMetrica.Infrastructure.Model;
using EmploMetrica.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Infrastructure.Services
{
    public class AuthenticationService(IUserService _userService,
        IAuthTokenService _authTokenService) : IAuthenticationService
    {
        public Result<User> Register(RegisterDto registerDto)
        {
            return new Result<User>(true, _userService.RegisterUser(registerDto), null);
        }
        public Result<TokenResponse> Login(LoginDto loginDto)
        {
            //get user by email
            var user = _userService.GetUserByEmail(loginDto.Email);
            if (user == null)
            {
                return new Result<TokenResponse>(false, null, ["Login unsuccessful"]);
            }
            //check password
            if (user.Password != loginDto.Password)
            {
                return new Result<TokenResponse>(false, null, ["Login unsuccessful"]);
            }
            //generate tokens
            var result = new TokenResponse
            {
                AccessToken = _authTokenService.GenerateAccessToken(user.Id),
                RefreshToken = _authTokenService.GenerateRefreshToken(user.Id)
            };
            return new Result<TokenResponse>(true, result, null);
        }

        public Result<AccessToken> Refresh(RefreshToken RefreshTokenRequest)
        {
            var result = _authTokenService.GenerateAccessTokenFromRefreshToken(RefreshTokenRequest.RefreshTokenValue);
            return new Result<AccessToken>(true, new AccessToken { AccessTokenValue = result }, null);
        }
    }
}
