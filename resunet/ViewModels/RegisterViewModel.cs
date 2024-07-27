using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage ="Некорректный формат")]  
    public string? Email { get; set; }
    [Required(ErrorMessage = "Пароль обязателен")]  
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*-]).{10,}$", ErrorMessage = "Пароль слишком простой")]
    public string? Password { get; set; }


}