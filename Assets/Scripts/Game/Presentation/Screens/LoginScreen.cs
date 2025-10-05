using UnityEngine;
using UnityEngine.UIElements;
using Game.Domain.Auth;
using Game.Application.Auth;

public class LoginScreen : MonoBehaviour, ILoginView
{
    public VisualTreeAsset loginFormUXML;
    private TextField usernameField;
    private TextField passwordField;
    private Button loginButton;
    private Label errorLabel;

    private LoginPresenter presenter;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        loginFormUXML.CloneTree(root);

        usernameField = root.Q<TextField>("usernameField");
        passwordField = root.Q<TextField>("passwordField");
        loginButton = root.Q<Button>("loginButton");
        errorLabel = root.Q<Label>("errorLabel");

        presenter = new LoginPresenter(this, new LoginService());
        loginButton.clicked += presenter.OnLoginClicked;
    }

    public string Username => usernameField.text;
    public string Password => passwordField.text;

    public void ShowError(string message)
    {
        errorLabel.text = message;
        errorLabel.style.color = new StyleColor(Color.red);
    }

    public void ShowSuccess(string message)
    {
        errorLabel.text = message;
        errorLabel.style.color = new StyleColor(Color.green);
    }
}