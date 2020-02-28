using System.Threading.Tasks;
using GeneralAPI.Data;
using GeneralAPI.Factories;
using GeneralAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeneralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await _service.GetBook(id);

            if(book == null)
            {
                return BadRequest(new { Message = "Could not find any book with that ID" });
            }

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _service.GetBooks();

            if(books == null || books.Count == 0)
            {
                return BadRequest(new { Message = "Could not find any books" });
            }

             return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBook newBook)
        {
            var book = await _service.CreateBook(BookFactory.CreateBookFromCreateBook(newBook));

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var result = await _service.DeleteBook(id);

            if (!result)
            {
                return BadRequest(new { Message = "Could not find and delete any book with that ID" });
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] Book newBook)
        {
            var book = await _service.UpdateBook(id, newBook);

            return Ok(book);
        }
    }
}