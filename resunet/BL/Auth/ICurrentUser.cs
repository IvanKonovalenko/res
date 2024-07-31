public interface ICurrentUser
{
    Task<bool> IsLoggedIn();
}