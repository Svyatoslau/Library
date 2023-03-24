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
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepositry;
    private readonly IRegistrationService _registrationService;
    private readonly IAuthenticationService _authenticationService;
    public UserService(
        IUnitOfWork unitOfWork,
        IRegistrationService registrationService,
        IAuthenticationService authenticationService
    )
    {
        _unitOfWork = unitOfWork;
        _userRepositry = unitOfWork.UserRepository;
        _registrationService = registrationService;
        _authenticationService = authenticationService;
    }


    public async Task<User?> AddAsync(User entity)
    {
        var user = await _userRepositry.FindByNameAsync(entity.Nickname);
        if (user is not null)
        {
            return null;
        }

        await _userRepositry.AddAsync(entity);
        await _unitOfWork.CommitAsync();

        return entity;

    }

    public async Task<string?> Authenticate(LoginUserDto userDto)
    {
        return await _authenticationService.Authenticate(userDto);
    }

    public async Task<User?> DeleteAsync(User entity)
    {
        return await DeleteByIdAsync(entity.Id);
    }

    public async Task<User?> DeleteByIdAsync(int id)
    {
        var user = await _userRepositry.GetByIdAsync(id);
        if (user is null)
        {
            return null;
        }

        await _userRepositry.DeleteAsync(user);
        await _unitOfWork.CommitAsync();

        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepositry.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepositry.GetByIdAsync(id);
    }

    public async Task<User?> Registr(LoginUserDto userDto)
    {
        return await _registrationService.Registr(userDto);
    }

    public async Task<User> UpdateAsync(User entity)
    {
        await _userRepositry.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return entity;
    }
}
