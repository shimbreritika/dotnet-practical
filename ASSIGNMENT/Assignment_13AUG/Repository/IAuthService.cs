namespace Assignment_13AUG.Repository
{
    public interface IAuthService
    {
        string? Login(string username, string password);
    }
}