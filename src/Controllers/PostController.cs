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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly DBContext _context;

        private readonly IMapper _mapper;

        public PostController(ILogger<PostController> logger , DBContext context , IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<PostDTO>> GetPosts()
        {  
            var posts = _context.posts.ToList();
            var postsDTO = _mapper.Map<List<PostDTO>>(posts);
             _logger.LogInformation("GetPosts Started");
            return Ok(postsDTO);
        }
        [HttpGet("{id:int}",Name ="GetPostsById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<PostDTO>> GetPostsById(int id)
        {
            {
                if (id <= 0){
                     _logger.LogWarning("GetPostsById BadRequest");

                    return BadRequest();
                }

                var post = _context.posts.Where(post => post.Id == id).FirstOrDefault();
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
        public ActionResult<bool> DeletePostsById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var post = _context.posts.Where(post => post.Id == id).FirstOrDefault();
            if (post == null)
                return NotFound(false);
            _context.posts.Remove(post);
            _context.SaveChanges();
            return Ok(true);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<PostDTO>> CreatePost([FromBody] PostDTO post)
        {
            if (post == null)
                return BadRequest();
            Post newPost = _mapper.Map<Post>(post);
            _context.posts.Add(newPost);
            _context.SaveChanges();
            return CreatedAtRoute("GetPostsById",new {id=post.Id},post);

        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult UpdatePostsById([FromBody] PostDTO model)
        {
        
                if (model.Id <= 0 || model == null)
                    return BadRequest();
                var post = _context.posts.AsNoTracking().Where(post => post.Id == model.Id).FirstOrDefault();
                if (post == null)
                     return NotFound($"post with {model.Id} not found");
                   var updatedPost = _mapper.Map<Post>(model);
                      _context.posts.Update(updatedPost);
                        _context.SaveChanges();
                    return NoContent();
                

            }
        }


    
}