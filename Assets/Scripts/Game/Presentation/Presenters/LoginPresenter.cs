using Game.Domain.Auth;

public interface ILoginView
{
    void ShowError(string message);
    void ShowSuccess(string message);
    string Username { get; }
    string Password { get; }
}

public class LoginPresenter
{
    private readonly ILoginView view;
    private readonly ILoginService loginService;

    public LoginPresenter(ILoginView view, ILoginService loginService)
    {
        this.view = view;
        this.loginService = loginService;
    }

    public void OnLoginClicked()
    {
        var username = view.Username;
        var password = view.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            view.ShowError("Please enter both username and password.");
            return;
        }

        var result = loginService.Login(username, password);
        if (result.IsSuccess)
            view.ShowSuccess("Login successful!");
        else
            view.ShowError(result.ErrorMessage ?? "Invalid username or password.");
    }
}