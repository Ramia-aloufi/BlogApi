using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        public ICollection<Post> Posts { get; set; }


    }
}