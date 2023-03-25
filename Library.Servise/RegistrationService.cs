using AutoMapper;
using Library.Core.Models.Dto;
using Library.Core.Models;
using Library.Core.Repositories;
using Library.Core.Security;
using Library.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Services;

namespace Library.Servise;
public class RegistrationService : IRegistrationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHasher _hasher;
    private readonly IMapper _mapper;

    public RegistrationService(IUnitOfWork unitOfWork, IHasher hasher, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _hasher = hasher;
        _mapper = mapper;
    }

    public async Task<User?> Registr(LoginUserDto userDto)
    {
        var user = await _unitOfWork.UserRepository.FindByNameAsync(userDto.Nickname);
        if (user is not null)
        {
            return null;
        }
        
        var newUser = _mapper.Map<User>(userDto);
        newUser.Password = _hasher.Hash(newUser.Password);

        await _unitOfWork.UserRepository.AddAsync(newUser);
        await _unitOfWork.CommitAsync();

        Console.WriteLine($"{newUser.Id} {newUser.Nickname}");

        return newUser;
    }
}
