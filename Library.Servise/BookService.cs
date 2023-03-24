using Library.Core.Models;
using Library.Core.Repositories;
using Library.Core.Services;
using Library.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servise;
public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = _unitOfWork.BookRepository;
    }


    public async Task<Book?> AddAsync(Book entity)
    {
        Console.WriteLine($"{entity.Name} {entity.Isbn}");
        var book = await GetByIsbnAsync(entity.Isbn);


        if (book is not null)
        {
            return null;
        }


        await _bookRepository.AddAsync(entity);
        await _unitOfWork.CommitAsync();

        Console.WriteLine($"{entity.Name} {entity.Id}");

        return entity;
    }

    public async Task<Book> DeleteAsync(Book entity)
    {
        return await DeleteByIdAsync(entity.Id);
    }

    public async Task<Book?> DeleteByIdAsync(int id)
    {
        var book = await GetByIdAsync(id);
        if (book is null )
        {
            return null;
        }

        await _bookRepository.DeleteAsync(book);
        await _unitOfWork.CommitAsync();

        return book;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<Book?> GetByIsbnAsync(string isbn)
    {
        return await _bookRepository.GetBookByIsbn(isbn);
    }

    public async Task<Book> UpdateAsync(Book entity)
    {
        await _bookRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return entity;
    }
}
