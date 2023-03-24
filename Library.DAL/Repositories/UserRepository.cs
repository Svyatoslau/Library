using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(LibraryDbContext context) : base(context) { }

    public async Task<User?> FindByNameAsync(string nickname)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Nickname == nickname);
    }
}
