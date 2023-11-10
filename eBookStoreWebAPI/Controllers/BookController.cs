using BusinessObject.DTO;
using eBookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _book;

        public BookController(IBookRepository book)
        {
            _book = book;
        }

        [HttpGet("GetAllBooks")]
        public async Task<List<BookDTO>> GetAllBook() => await _book.GetAllBook();



        [HttpGet("GetBookById")]
        public async Task<BookDTO> GetBookById(int id) =>  await _book.GetBookById(id);


        [HttpPost("AddBook")]
        public async Task<Boolean> AddBook([FromBody] BookDTO bookdto)
        {

            try
            {
                await _book.AddBook(bookdto);

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("DeleteBook")]
        public async Task<Boolean> DeleteBook(int id)
        {
            try
            {
                await _book.DeleteBook(id);

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpPut("EditBook")]
        public async Task<Boolean> UpdateBook(int id, [FromBody] BookDTO bookdto)
        {
            try
            {
                await _book.UpdateBook(id, bookdto);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
