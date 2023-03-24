using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories;
public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context) { }
    public async Task<Book?> GetBookByIsbn(string isbn)
    {
        return await _dbSet.FirstOrDefaultAsync(b => b.Isbn == isbn);
    }
}
