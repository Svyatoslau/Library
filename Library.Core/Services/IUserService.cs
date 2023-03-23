using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services;
public interface IUserService : IService<User>
{
    Task<string> Authenticate(string nickname, string password);
    Task<User> Registr(string nickname, string password);
}
