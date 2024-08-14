using NpgsqlTypes;

namespace BlogApi.src.Models
{
    [PgName("blog.role")]
    public enum Role
    {
        user,
        admin
        
            }
}