﻿using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories;
public interface IUserRepository : IRepository<User> 
{
    Task<User?> FindByNameAsync(string nickname);
}
