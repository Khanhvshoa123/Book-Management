using BusinessObject.DTO;

namespace eBookStoreWebAPI.Repository
{
    public interface IAuthorRespository
    {
        Task<AuthorDTO> GetAuthorbyId(int id);
        Task<List<AuthorDTO>> GetAllAuthor();
        Task AddAuthor(AuthorDTO authordto);
        Task DeleteAuthor(int id);
        Task UpdateAuthor(int authorId, AuthorDTO authordto);
       
    }
}
