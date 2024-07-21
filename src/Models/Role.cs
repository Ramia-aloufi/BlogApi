using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.DTOs;

namespace BlogApi.src.Models
{
    public class Role:IEntity
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        [Required]
        [StringLength(250)]
        public  string? Description { get; set; }
        public  bool IsActive { get; set; } = true;
        public  bool IsDeleted { get; set; } = false;
        public  DateTime CreatedDte { get; set; }  = DateTime.UtcNow;
        public  DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<RolePrivilege>? RolePrivileges { get; set; }
        public virtual ICollection<UserRoleMapping>? UserRoleMappings { get; set; }






    }
}