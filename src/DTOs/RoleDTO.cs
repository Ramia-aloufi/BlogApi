using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.DTOs
{
    public class RoleDTO:ITDto
    {
        [Required]
        public required string Name { get; set; }
        public required  string Description { get; set; }
        public int Id { get; set; }
    }
        public class ReadRoleDTO
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required  string Description { get; set; } 
       
    }
}