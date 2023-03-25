using Library.Core.Models;
using Library.Core.Models.Dto;
using Library.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services;
public interface IUserService : IService<User>
{
    Task<string?> Authenticate(LoginUserDto userDto);
    Task<User?> Registr(LoginUserDto userDto);
}