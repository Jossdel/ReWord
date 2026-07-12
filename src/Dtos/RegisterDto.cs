namespace reword.src.Dtos;
using System.ComponentModel.DataAnnotations;
public class RegisterDto
{

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string PasswordHash { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string NativeLanguage { get; set; } = "es";

    public string LearningLanguage { get; set; } = string.Empty;
}