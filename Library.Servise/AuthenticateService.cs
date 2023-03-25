using AutoMapper;
using Library.Core.Models;
using Library.Core.Models.Dto;
using Library.Core.Repositories;
using Library.Core.Security;
using Library.Core.Services;
using Library.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servise;
public class AuthenticateService : IAuthenticationService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IHasher _hasher;

    public AuthenticateService(
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IHasher hasher
    )
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _hasher = hasher;
    }
   
    public async Task<string?> Authenticate(LoginUserDto userDto)
    {
        var user = await _unitOfWork.UserRepository.FindByNameAsync(userDto.Nickname);
        if (user is null)
        {
            return null;
        }

        bool IsPasswordConfirm = _hasher.Verify(userDto.Password, user.Password);
        if (!IsPasswordConfirm)
        {
            return null;
        }

        return _tokenService.CreateToken(user.Nickname);
    }
}
