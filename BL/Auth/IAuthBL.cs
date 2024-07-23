public interface IAuthBL
{
    Task<int> CreateUser(UserModel user);
}