using AutoMapper;
using Library.Core.Models;
using Library.Core.Models.Dto;
using Library.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    public BookController(IBookService bookService, IMapper mapper) 
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet("books")]
    public async Task<ActionResult> GetBooksAsync()
    {
        var books = await _bookService.GetAllAsync();

        var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

        return Ok(booksDto);
    }

    [HttpGet("book/{id}")]
    public async Task<ActionResult> GetBookByIdAsync(
        [FromRoute] int id
    )
    {
        var book = await _bookService.GetByIdAsync(id);
        if(book is null)
        {
            return NotFound($"The book, with id: {id}, was not found");
        }

        var bookDto = _mapper.Map<BookDto>(book);

        return Ok(bookDto);
    }

    [HttpGet("book")]
    public async Task<ActionResult> GetBookByIsbnAsync(
        [FromQuery] string isbn
    )
    {
        var book = await _bookService.GetByIsbnAsync(isbn);
        if (book is null)
        {
            return NotFound($"The book, with ISBN: {isbn}, was not found");
        }
        
        var bookDto = _mapper.Map<BookDto>(book);

        return Ok(bookDto);
    }

    [HttpPost("book")]
    public async Task<ActionResult> CreateBookAsync(
        [FromBody] BookForCreateDto model
    )
    {
        var newBook = _mapper.Map<Book>(model);


        var createdBook = await _bookService.AddAsync(newBook);
        if (createdBook is null)
        {
            return BadRequest(new { message = "Book exists" });
        }

        var createdBookDto = _mapper.Map<BookDto>(createdBook);

        return Ok(createdBookDto);
    }

    [HttpPut("book/{id}")]
    public async Task<ActionResult> UpdateBookAsync(
        [FromBody] Book model,
        [FromRoute] int id
    )
    {
        if (model.Id != id)
        {
            return BadRequest(new { message = "Different id" });
        }

        var updatedBook = await _bookService.UpdateAsync(model);
        if (updatedBook is null)
        {
            return NotFound(new { message = "Book for update not exists" });
        }

        var updatedBookDto = _mapper.Map<BookDto>(updatedBook);

        return Ok(updatedBookDto);
    }

    [HttpDelete("book/{id}")]
    public async Task<ActionResult> DeleteBookAsync(
        [FromRoute] int id
    )
    {
        var deletedBook = await _bookService.DeleteByIdAsync(id);
        if (deletedBook is null)
        {
            return NotFound("Book for delete not exists");
        }

        var deletedBookDto = _mapper.Map<BookDto>(deletedBook);

        return Ok(deletedBookDto);
    }

}
