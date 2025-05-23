﻿using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;
using NewsApi.Services;
using NewsApi.Model.DTO;
using NewsApi.Services.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace NewsApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("AddTag")]
        public async Task<Tag> AddTagAsync(TagDTO tag)
        {
            return await _tagService.AddAsync(tag);
        }

        [HttpPut("UpdateTag")]
        public async Task<int> UpdateTagAsync(TagDTO tag)
        {
            return await _tagService.UpdateAsync(tag);
        }
    }
}
