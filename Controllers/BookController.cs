using CRUD_ASP.NET_CORE.Models;
using CRUD_ASP.NET_CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ASP.NET_CORE.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        public BookController()
        {

        }
        //get all 
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return BookService.GetAll();
        }

        //getOne 
        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var book = BookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            BookService.Add(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = BookService.Get(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            try
            {
                BookService.Update(id, book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var book = BookService.Get(id);

            if(book is null)
            {
                return NotFound();
            }

            try
            {
                BookService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

    }
}
