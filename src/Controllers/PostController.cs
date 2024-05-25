using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<PostDTO>> GetPosts()
        {
            var posts = PostRepository.Posts.Select(p =>
                new PostDTO()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                });
            return Ok(posts);
        }
        [HttpGet("{id:int}",Name ="GetPostsById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<PostDTO>> GetPostsById(int id)
        {
            {
                if (id >= 0)
                    return BadRequest();

                var post = PostRepository.Posts.Where(post => post.Id == id).FirstOrDefault();
                if (post != null)
                {

                    PostDTO selectedPost = new PostDTO()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        CreatedAt = post.CreatedAt,
                        UpdatedAt = post.UpdatedAt
                    };
                    return Ok(selectedPost);
                }
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
            if (id >= 0)
                return BadRequest();

            var post = PostRepository.Posts.Where(post => post.Id == id).FirstOrDefault();
            if (post == null)
                return NotFound(false);
            PostRepository.Posts.Remove(post);
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
            int newId = PostRepository.Posts.LastOrDefault().Id + 1;
            Post newPost = new Post()
            {
                Id = newId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
            PostRepository.Posts.Add(newPost);
            post.Id = newId;
            return CreatedAtRoute("GetPostsById",new {id=post.Id},post);

        }


    }
}