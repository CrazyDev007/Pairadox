using Game.Domain.Auth;

namespace Game.Application.Auth
{
    public class LoginService : ILoginService
    {
        public LoginResult Login(string username, string password)
        {
            // Replace with real authentication logic
            if (username == "admin" && password == "password")
                return new LoginResult(true);
            return new LoginResult(false, "Invalid username or password.");
        }
    }
}