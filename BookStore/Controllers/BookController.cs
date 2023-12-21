using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book{Id = 1, Title = "Sol Ayağım", GenreId = 1, PageCount = 128, PublishDate = DateTime.Now},
        };
        [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(books);
        }
        [HttpGet("{id}")]
        public ActionResult GetBookB(int id)
        {
            if(id != null)
            {
                return Ok(books.FirstOrDefault(B => B.Id == id));
            }
            return NotFound("This id doesn't match with any book.");
        }
        [HttpPost]
        public ActionResult AddBook(Book newBook)
        {
            books.Add(newBook);
            return Ok(newBook);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.Find(b => b.Id == id);

            if(book != null)
            {
                book.Id = updatedBook.Id;
                book.Title = updatedBook.Title;
                book.GenreId = updatedBook.GenreId;
                book.PageCount = updatedBook.PageCount;
                book.PublishDate = updatedBook.PublishDate;

                return Ok(book);
            }
            return NotFound();
           

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.Find(b => b.Id == id);
            if(book != null )
            {
                books.Remove(book);
                return Ok(book);
            }
            return NotFound();
            
        }

    }
}
