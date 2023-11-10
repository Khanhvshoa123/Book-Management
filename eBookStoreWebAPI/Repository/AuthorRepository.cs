using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace eBookStoreWebAPI.Repository
{
    public class AuthorRepository : IAuthorRespository
    {   
        private readonly EBookContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<AuthorDTO> _valid;
        public AuthorRepository(EBookContext context, IMapper mapper,IValidator<AuthorDTO> valid)
        {
            _context = context;
            _mapper = mapper;
            _valid = valid;
        }
        public async Task AddAuthor(AuthorDTO authordto)
        {
            try
            {
                var validationResult = _valid.Validate(authordto);
                if (!validationResult.IsValid)
                {
                    // Handle validation errors (e.g., log or throw an exception)
                    throw new ValidationException(validationResult.Errors);
                }

                var author = _mapper.Map<Author>(authordto);
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                
            }
            catch (Exception)
            {

                throw new DbUpdateException("abc");
            }
        }

        public async Task DeleteAuthor(int id)
        {
            var existingauthor = _context.Authors.Find(id);
            if (existingauthor == null)
            {
                throw new NotFoundException("Khong tim thay");
            }

            _context.Authors.Remove(existingauthor);
            _context.SaveChanges();
        }

        public async Task<List<AuthorDTO>> GetAllAuthor()
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<List<AuthorDTO>>(authors);
        }

        public async Task<AuthorDTO> GetAuthorbyId(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);

                if (author == null)
                {
                    throw new NotFoundException("Khong tim thay");
                }

                return _mapper.Map<AuthorDTO>(author);
            }
            catch (Exception)
            {
                
                throw ;  
            }
        }

        public async Task UpdateAuthor(int authorId, AuthorDTO authordto)
        {
            var validationResult = _valid.Validate(authordto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var existingAuthor = _context.Authors.Find(authorId);
            if (existingAuthor == null)
            {
                throw new NotFoundException("Khong tim thay");
            }
            var edit = _mapper.Map(authordto, existingAuthor);
            _context.SaveChanges();

        }


    }
}
