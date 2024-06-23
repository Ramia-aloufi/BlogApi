using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required]
    public string username { get; set; }
    [Required]
    public string Password { get; set; }
}
public class LoginResponceDTO
{
    public string username { get; set; }
    public string token { get; set; }
}