using BusinessObject.DTO;

namespace eBookStoreWebAPI.Repository
{
    public interface IPublisherRepository
    {
        Task<PublisherDTO> GetPublisherById(int id);
        Task<List<PublisherDTO>> GetAllPublisher();
        Task AddPublisher(PublisherDTO publisherdto);
        Task DeletePublisher(int id);
        Task UpdatePublisher(int publisherId, PublisherDTO publisherdto);
    }
}
