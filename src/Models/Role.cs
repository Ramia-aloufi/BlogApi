using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.Models
{
    public class Role
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public  string roleName { get; set; }
        [Required]
        [StringLength(250)]
        public  string description { get; set; }
        [Required]
        public  bool iActive { get; set; }
        [Required]
        public  bool isDeleted { get; set; }
        [Required]
        public  DateTime createdDte { get; set; }
        public  DateTime UpdatedDate { get; set; }




    }
}