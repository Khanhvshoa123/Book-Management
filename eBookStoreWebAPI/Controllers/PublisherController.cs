using BusinessObject.DTO;
using eBookStoreWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisher;

        public PublisherController(IPublisherRepository publisher)
        {
            _publisher = publisher;
        }

        [HttpGet("GetAllPublishers")]
        public async Task<List<PublisherDTO>> GetAllPublishers() => await _publisher.GetAllPublisher();

        [HttpGet("GetPublisherById")]
        public async Task<PublisherDTO> GetPublisherById(int id) => await _publisher.GetPublisherById(id);

        [HttpPost("AddPublisher")]
        public async Task<Boolean> AddPublisher([FromBody] PublisherDTO publisherdto)
        {
            try
            {
                await _publisher.AddPublisher(publisherdto);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("DeletePublisher")]
        public async Task<Boolean> DeletePublisher(int id)
        {
            try
            {
                await _publisher.DeletePublisher(id);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpPut("EditPublisher")]
        public async Task<Boolean> UpdatePublisher(int id, [FromBody] PublisherDTO publisherdto)
        {
            try
            {
                await _publisher.UpdatePublisher(id, publisherdto);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
