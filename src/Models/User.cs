
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogApi.src.DTOs;

namespace BlogApi.src.Models
{
    public class User:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
         [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(100)]
        public required string Password { get; set; }
        [Required]
        public required string PasswordSalt { get; set; }
        public  bool IsActive { get; set; } = false;
        public  bool IsDeleted { get; set; } = false;
        public string? ActivationToken { get; set; } 
        public DateTime? TokenExpiration { get; set; } 
        public  DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public  DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; } = Role.user;
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}