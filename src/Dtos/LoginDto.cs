namespace reword.src.Dtos;
using System.ComponentModel.DataAnnotations;
public class LoginResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}

    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string Password { get; set; } = string.Empty;
    }
    public class UserDto
{
    public int Id { get; set; } 

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;

}
public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;

    public UserDto User { get; set; } = new();
}