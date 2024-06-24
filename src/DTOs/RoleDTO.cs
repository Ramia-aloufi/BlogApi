using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required]
        public  string roleName { get; set; }
        public  string description { get; set; }
        [Required]
        public  bool iActive { get; set; }
       
    }
}