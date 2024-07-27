using System.ComponentModel.DataAnnotations;

public interface IAuthBL
{
    Task<int> CreateUser(UserModel user);
    Task<int> Authenticate(string email, string password,bool rememberMe);
    Task<ValidationResult?> Validate(string email);
}