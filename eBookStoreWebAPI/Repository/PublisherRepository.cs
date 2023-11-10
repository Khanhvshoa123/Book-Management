using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace eBookStoreWebAPI.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly EBookContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<PublisherDTO> _valid;

        public PublisherRepository(EBookContext context, IMapper mapper, IValidator<PublisherDTO> valid)
        {
            _context = context;
            _mapper = mapper;
            _valid = valid;
        }

        public async Task AddPublisher(PublisherDTO publisherdto)
        {
            try
            {
                var validationResult = _valid.Validate(publisherdto);
                if (!validationResult.IsValid)
                {
                    // Handle validation errors (e.g., log or throw an exception)
                    throw new ValidationException(validationResult.Errors);
                }

                var publisher = _mapper.Map<Publisher>(publisherdto);
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("abc");
            }
        }

        public async Task DeletePublisher(int id)
        {
            var existingPublisher = _context.Publishers.Find(id);
            if (existingPublisher == null)
            {
                throw new NotFoundException("Khong tim thay");
            }

            _context.Publishers.Remove(existingPublisher);
            _context.SaveChanges();
        }

        public async Task<List<PublisherDTO>> GetAllPublisher()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return _mapper.Map<List<PublisherDTO>>(publishers);
        }

        public async Task<PublisherDTO> GetPublisherById(int id)
        {
            try
            {
                var publisher = await _context.Publishers.FindAsync(id);

                if (publisher == null)
                {
                    throw new NotFoundException("Khong tim thay");
                }

                return _mapper.Map<PublisherDTO>(publisher);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePublisher(int publisherId, PublisherDTO publisherdto)
        {
            var validationResult = _valid.Validate(publisherdto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingPublisher = _context.Publishers.Find(publisherId);
            if (existingPublisher == null)
            {
                throw new NotFoundException("Khong tim thay");
            }

            var edit = _mapper.Map(publisherdto, existingPublisher);
            _context.SaveChanges();
        }
    }
}