using AutoMapper;
using EmploMetrica.Application.UseCases.Users;
using EmploMetrica.Domain.Shared;
using EmploMetrica.Domain.Users;
using EmploMetrica.Infrastructure;
using EmploMetrica.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases
{
    public interface IAuthenticationService
    {
        public Result<User> Register(RegisterDto registerDto);
        public Result<TokenResponse> Login(LoginDto loginDto);
        public Result<AccessToken> Refresh(RefreshToken RefreshTokenRequest);
    }
}
