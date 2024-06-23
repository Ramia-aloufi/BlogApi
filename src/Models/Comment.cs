using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.Models
{
    public class Comment
    {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int PostId { get; set; }

    public Post Post { get; set; }

    }
}