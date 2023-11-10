using BusinessObject.DTO;

namespace eBookStoreWebAPI.Repository
{
    public interface IBookRepository
    {
       
       
       
        Task<BookDTO> GetBookById(int id);
        Task<List<BookDTO>> GetAllBook();
        Task AddBook(BookDTO bookdto);
        Task DeleteBook(int id);
        Task UpdateBook(int bookId, BookDTO bookdto);
    }
}
