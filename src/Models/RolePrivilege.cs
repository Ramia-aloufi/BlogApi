using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.Models
{
    public class RolePrivilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string RolePrivilegeName { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int RoleId{ get; set; }
        [Required]
         public  bool isActive { get; set; }
        [Required]
        public  bool isDeleted { get; set; }
        [Required]
        public  DateTime createdDte { get; set; }
        public  DateTime UpdatedDate { get; set; }
        public Role Role { get; set; }

        
    }
}