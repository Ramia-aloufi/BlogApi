using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.DTOs
{
    public class UserReadOnlyDTO
    {
        
        public int Id { get; set; }
        [Required]
        public  string username { get; set; }
        [Required]
        public  int userTypeId { get; set; }
        [Required]
        public  bool isActive { get; set; } 
    }
} 