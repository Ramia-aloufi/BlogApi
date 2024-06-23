
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.src.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public  string username { get; set; }
        [Required]
        [StringLength(100)]
        public  string password { get; set; }
        [Required]
        public  string passwordSalt { get; set; }
        [Required]
        public  int userType { get; set; }
        [Required]
        public  bool isActive { get; set; }
        [Required]
        public  bool isDeleted { get; set; }
        [Required]
        public  DateTime createdDte { get; set; }
        public  DateTime UpdatedDate { get; set; }




    }
}