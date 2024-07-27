public interface IEncrypt
{
    string HashPassword(string password,string salt);
}