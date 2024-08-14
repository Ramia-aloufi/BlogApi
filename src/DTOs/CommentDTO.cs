using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.DTOs
{
    public class CommentDTO:ITDto
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public required string Name { get; set; }
    public int UserId { get; set; }
    // public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int PostId { get; set; }

    public User? User { get; set; }
    }
    public class CommentOnPostDTO:ITDto
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public required string Name { get; set; }
    public int UserId { get; set; }

    public virtual UserReadOnlyDTO? User { get; set; }
    }
}