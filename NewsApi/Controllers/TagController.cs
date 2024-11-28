using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;
using NewsApi.Services;
using NewsApi.Services.Implementations;

namespace NewsApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagService _tagService;


        public TagController(ILogger<TagController> logger, ITagService tagService)
        {
            _logger = logger;
            _tagService = tagService;

        }


        [HttpGet("GetAllTags")]
        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {            
            return await _tagService.GetAllAsync();
        }

        [HttpGet("GetTagById")]
        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tagService.GetById(id);
        }
    }
}
