using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace eBookStoreWebAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly EBookContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<BookDTO> _valid;
        public BookRepository(EBookContext context, IMapper mapper, IValidator<BookDTO> valid)
        {
            _context = context;
            _mapper = mapper;
            _valid = valid;
        }
        public async Task AddBook(BookDTO bookdto)
        {
            try
            {
                var validationResult = _valid.Validate(bookdto);
                if (!validationResult.IsValid)
                {
                    // Handle validation errors (e.g., log or throw an exception)
                    throw new ValidationException(validationResult.Errors);
                }

                var book = _mapper.Map<Book>(bookdto);
               await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Add Book Error");
            }
        }

        public async Task DeleteBook(int id)
        {
            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                throw new NotFoundException("Khong tim thay");
            }

            _context.Books.Remove(existingBook);
            _context.SaveChanges();
        }

        public async Task<List<BookDTO>> GetAllBook()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            try
            {
                // lay danh sach book tu id truyen vao
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    throw new NotFoundException("Khong tim thay");
                }

                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateBook(int bookId, BookDTO bookdto)
        {
            var validationResult = _valid.Validate(bookdto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var existingBook = _context.Books.Find(bookId);
            if (existingBook == null)
            {
                throw new NotFoundException("Khong tim thay");
            }
            var edit = _mapper.Map(bookdto, existingBook);
            _context.SaveChanges();
        }
    }
}
