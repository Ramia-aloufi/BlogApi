using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Url]
        public string ImageUrl { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR63XIy9VsNtzBDN5WqZPXvBpoHdmq8YUlSYEfwNghm0Q&s";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int CategoryId { get; set; }

    }
}