using System.ComponentModel.DataAnnotations;

public interface IAuth
{
    Task<int> CreateUser(UserModel user);
    Task<int> Authenticate(string email, string password,bool rememberMe);
    Task ValidateEmail(string email);
    Task Register(UserModel user);
}