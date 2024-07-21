using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.DTOs;

namespace BlogApi.src.Models
{
    public class RolePrivilege:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int RoleId{ get; set; }
         public  bool IsActive { get; set; } = true;
        public  bool IsDeleted { get; set; } = false;
        public  DateTime CreatedDte { get; set; }= DateTime.UtcNow;
        public  DateTime UpdatedDate { get; set; }= DateTime.UtcNow;
        public Role? Role { get; set; }

        
    }
}