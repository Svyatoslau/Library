using Library.Core.Repositories;
using Library.Core.UnitOfWork;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _context;
    private IBookRepository _bookRepository;
    private IUserRepository _userRepository;

    public UnitOfWork(LibraryDbContext context) =>
        _context= context;

    public IBookRepository BookRepository => _bookRepository =
        _bookRepository ?? new BookRepository(_context);

    public IUserRepository UserRepository => _userRepository = 
        _userRepository ?? new UserRepository(_context);

    public async Task CommitAsync() =>
        await _context.SaveChangesAsync();

    public async Task RollbackAsync() =>
        await _context.DisposeAsync();
}
