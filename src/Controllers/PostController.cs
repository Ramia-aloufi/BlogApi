using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.DB;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(401)]
    public class PostController(ILogger<PostController> logger, IMapper mapper, IPostRepository postRepository) : Controller
    {
        private readonly ILogger<PostController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IPostRepository _postRepository = postRepository;

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var posts = await _postRepository.GetAll();
            var postsDTO = _mapper.Map<List<PostDTO>>(posts);
            _logger.LogInformation("GetPosts Started");
            return Ok(postsDTO);
        }
        [HttpGet("{id:int}", Name = "GetPostsById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostsById(int id)
        {
            {
                if (id <= 0)
                {
                    _logger.LogWarning("GetPostsById BadRequest");

                    return BadRequest();
                }

                var post = await _postRepository.GetById(post => post.Id == id);
                if (post != null)
                {
                    PostDTO selectedPost = _mapper.Map<PostDTO>(post);
                    _logger.LogWarning("GetPostsById Successfully");
                    return Ok(selectedPost);
                }
                _logger.LogWarning("GetPostsById NotFound");
                return NotFound($"Student with {id} not found");

            }
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> DeletePostsById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var post =  await _postRepository.GetById(post => post.Id == id);
            if (post == null)
                return NotFound(false);
            await _postRepository.Delete(post);
            return Ok(true);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<PostDTO>>> CreatePost([FromBody] PostDTO post)
        {
            if (post == null)
                return BadRequest();
            Post newPost = _mapper.Map<Post>(post);
            var postAdded = await _postRepository.Create(newPost);
            return CreatedAtRoute("GetPostsById", new { id = postAdded.Id }, postAdded);

        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdatePostsById([FromBody] PostDTO model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();
            var post = await _postRepository.GetById(post => post.Id == model.Id, true);
            if (post == null)
                return NotFound($"post with {model.Id} not found");
            var updatedPost = _mapper.Map<Post>(model);
            await _postRepository.Update(updatedPost);
            return NoContent();
        }
    }



}