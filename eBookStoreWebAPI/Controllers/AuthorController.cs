using BusinessObject.DTO;
using eBookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRespository _author;

        public AuthorController(IAuthorRespository author)
        {
            _author = author;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<List<AuthorDTO>> GetAllAuthors() => await _author.GetAllAuthor();

        [HttpGet("GetAuthorById")]
        public async Task<AuthorDTO> GetAuthorById(int id) => await _author.GetAuthorbyId(id);

        [HttpPost("AddAuthor")]
        public async Task<Boolean> AddAuthor([FromBody] AuthorDTO authordto)
        {
            try
            {
                await _author.AddAuthor(authordto);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<Boolean> DeleteAuthor(int id)
        {
            try
            {
                await _author.DeleteAuthor(id);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpPut("EditAuthor")]
        public async Task<Boolean> UpdateAuthor(int id, [FromBody] AuthorDTO authordto)
        {
            try
            {
                await _author.UpdateAuthor(id, authordto);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
