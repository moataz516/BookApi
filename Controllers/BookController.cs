using Book.Models;
using Book.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBookAsync([FromBody] BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            if (id == 0)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetBookById), new {id=id,controller="book"},id);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute]int id, [FromBody] BookModel bookModel)
        {
            await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok();
        }

        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);

            return Ok();
        }
    }
}
