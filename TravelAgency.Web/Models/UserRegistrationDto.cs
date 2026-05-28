using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Web.Models;

public class UserRegistrationDto
{
    [Required(ErrorMessage = "Введіть ваше ім'я")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть Email")]
    [EmailAddress(ErrorMessage = "Некоректний формат Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть пароль")]
    [MinLength(6, ErrorMessage = "Пароль має бути не менше 6 символів")]
    public string Password { get; set; } = string.Empty;
}