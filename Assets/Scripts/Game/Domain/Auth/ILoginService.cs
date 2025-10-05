namespace Game.Domain.Auth
{
    public interface ILoginService
    {
        LoginResult Login(string username, string password);
    }

    public class LoginResult
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        public LoginResult(bool isSuccess, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}