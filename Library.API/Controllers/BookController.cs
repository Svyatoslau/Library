using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Authorize]
[Route("api")]
[ApiController]
public class BookController : ControllerBase
{
    
    public BookController()
    {

    }

    [HttpGet("books")]
    public async Task<ActionResult> GetBooksAsync()
    {
        return Ok();
    }

    [HttpGet("book/{id}")]
    public async Task<ActionResult> GetBookByIdAsync(
        [FromRoute] int id
    )
    {
        return Ok();
    }

    [HttpGet("book")]
    public async Task<ActionResult> GetBookByIsbnAsync(
        [FromQuery] string isbn
    )
    {
        return Ok();
    }

    [HttpPost("book")]
    public async Task<ActionResult> CreateBookAsync(
        [FromBody] string book
    )
    {
        return Ok();
    }

    [HttpPut("book")]
    public async Task<ActionResult> UpdateBookAsync(
        [FromBody] string book
    )
    {
        return Ok();
    }

    [HttpDelete("book/{id}")]
    public async Task<ActionResult> DeleteBookAsyncNow(
        [FromRoute] int id
    )
    {
        return Ok();
    }

}
