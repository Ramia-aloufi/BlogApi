using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.DTOs
{
    public class RolePrivilegeDTO:ITDto
    {

        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int RoleId{ get; set; }
         public  bool IsActive { get; set; }
        public  bool IsDeleted { get; set; }

    }
}