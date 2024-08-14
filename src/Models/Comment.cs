using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.DTOs;

namespace BlogApi.src.Models
{
    public class Comment:IEntity
    {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(500)]
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int PostId { get; set; }
    public int UserId { get; set; }
    
    [ForeignKey("PostId")]
    public Post? Post { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }

    }
}